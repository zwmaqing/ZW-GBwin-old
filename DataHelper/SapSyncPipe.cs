
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

namespace DataHelper
{

    /// <summary>
    /// Class NamedPipeListenServer.
    /// Usage, for example,
    /// using (NamedPipeClient client = new NamedPipeClient(".",PipeServerName))
    ///              {
    ///                retrunStr = client.Query(SapSyncMesg.Request_Get_AttendHid);
    ///              }
    ///              if (retrunStr != SapSyncMesg.Reply_Request_Completed)
    ///              {}
    /// </summary>
    public class NamedPipeListenServer
    {
        List<NamedPipeServerStream> _serverPool = new List<NamedPipeServerStream>();

        string _pipName = "SapSyncPipeServer";//系统同步 命名管道服务名称

        bool _isStop = false;

        Thread servers;
        public NamedPipeListenServer(string pipName)
        {
            _pipName = pipName;
        }

        /// <summary>
        /// 创建一个NamedPipeServerStream
        /// </summary>
        /// <returns></returns>
        protected NamedPipeServerStream CreateNamedPipeServerStream()
        {
            NamedPipeServerStream npss = new NamedPipeServerStream(_pipName, PipeDirection.InOut, 2);
            _serverPool.Add(npss);
            //Console.WriteLine("启动了一个NamedPipeServerStream " + npss.GetHashCode());
            return npss;
        }

        /// <summary>
        /// 销毁
        /// </summary>
        /// <param name="npss"></param>
        protected void DistroyObject(NamedPipeServerStream npss)
        {
            npss.Close();
            if (_serverPool.Contains(npss))
            {
                _serverPool.Remove(npss);
            }
            //Console.WriteLine("销毁一个NamedPipeServerStream " + npss.GetHashCode());
            if (_serverPool.Count == 0 && !_isStop)
            {
                Run();
            }
        }

        public void Run()
        {
            servers = new Thread(runMethod);
            servers.IsBackground = true;
            servers.Start();
        }

        private void runMethod(object obj)
        {
            using (NamedPipeServerStream pipeServer = CreateNamedPipeServerStream())
            {
                pipeServer.WaitForConnection();
                //Console.WriteLine("建立一个连接 " + pipeServer.GetHashCode());

                // Action act = new Action(Run);
                // act.BeginInvoke(null, null);

                try
                {
                    bool isRun = true;
                    while (isRun)
                    {
                        string str = null;
                        StreamReader sr = new StreamReader(pipeServer);
                        while (pipeServer.CanRead && (null != (str = sr.ReadLine())))
                        {
                            ProcessMessage(str, pipeServer);

                            if (!pipeServer.IsConnected)
                            {
                                isRun = false;
                                break;
                            }
                        }
                        //  Thread.Sleep(50);
                    }
                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.

                catch (IOException e)
                {
                    //Console.WriteLine("ERROR: {0}", e.Message);
                }
                finally
                {
                    DistroyObject(pipeServer);
                }
            }
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pipeServer"></param>
        protected virtual void ProcessMessage(string str, NamedPipeServerStream pipeServer)
        {
            string returnStr = SapSyncMesg.Reply_Request_Failed;//默认返回失败信息
            bool isCloseApp = false;
            switch (str)
            {
                case SapSyncMesg.Request_Get_AttendHid:
                case SapSyncMesg.Request_Return_AttendHid:
                case SapSyncMesg.Notice_AttendHid_Changed:
                    {
                        if (AttendHid_Control != null)
                        {
                            if (AttendHid_Control(str))
                            {
                                returnStr = SapSyncMesg.Reply_Request_Completed;
                            }
                        }
                        break;
                    }
                case SapSyncMesg.Request_Get_PlayDevice:
                case SapSyncMesg.Request_Return_PlayDevice:
                case SapSyncMesg.Notice_PlayDevice_Changed:
                case SapSyncMesg.Notice_AudioPlayUser_Changed:
                    {
                        if (PlayDevice_Control != null)
                        {
                            if (PlayDevice_Control(str))
                            {
                                returnStr = SapSyncMesg.Reply_Request_Completed;
                            }
                        }
                        break;
                    }
                case SapSyncMesg.Request_Close:
                    {
                        isCloseApp = true;
                        returnStr = SapSyncMesg.Reply_Request_Completed;
                        using (StreamWriter sw = new StreamWriter(pipeServer))
                        {
                            sw.AutoFlush = true;
                            sw.WriteLine(returnStr);
                        }
                        if (App_Control != null)
                        {
                            App_Control(str);
                        }
                        break;
                    }
                case SapSyncMesg.Request_Maximize:
                case SapSyncMesg.Request_Minimize:
                    {
                        if (App_Control != null)
                        {
                            App_Control(str);
                            returnStr = SapSyncMesg.Reply_Request_Completed;
                        }
                        break;
                    }
                case SapSyncMesg.Request_PlayTask_Pause:
                case SapSyncMesg.Request_PlayTask_Start:
                case SapSyncMesg.Request_PlayTask_Stop:
                case SapSyncMesg.Notice_PlayTask_Changed:
                    {
                        if (PlayTaskControl != null)
                        {
                            if (PlayTaskControl(str))
                            {
                                returnStr = SapSyncMesg.Reply_Request_Completed;
                            }
                        }
                        break;
                    }
                case SapSyncMesg.Notice_VideoDevice_Changed:
                case SapSyncMesg.Request_VideoDevice_Start:
                case SapSyncMesg.Request_VideoDevice_Stop:
                    {
                        if (VideoDevice_Control != null)
                        {
                            if (VideoDevice_Control(str))
                            {
                                returnStr = SapSyncMesg.Reply_Request_Completed;
                            }
                        }
                        break;
                    }
                case SapSyncMesg.Notice_ManagementApp_Runing:
                case SapSyncMesg.Notice_RuningTimeApp_Runing:
                    {
                        if (AppRuningNotice != null)
                        {
                            AppRuningNotice(str);
                            returnStr = SapSyncMesg.Reply_Notice_Received;
                        }
                        break;
                    }
                case SapSyncMesg.Notice_RuntimeSetting_Changed:
                    {
                        if (RuntimeSettingChanged != null)
                        {
                            RuntimeSettingChanged(str);
                            returnStr = SapSyncMesg.Reply_Notice_Received;
                        }
                        break;
                    }
                case SapSyncMesg.Notice_AttendConfig_Changed:
                    {
                        if (AttendConfigChanged != null)
                        {
                            AttendConfigChanged(str);
                            returnStr = SapSyncMesg.Reply_Notice_Received;
                        }
                        break;
                    }
                case SapSyncMesg.Notice_DedicatedCommDevices_Changed:
                    {
                        if (DedicatedCommDevicesChanged != null)
                        {
                            DedicatedCommDevicesChanged(str);
                            returnStr = SapSyncMesg.Reply_Notice_Received;
                        }
                        break;
                    }
                default:
                    {
                        returnStr = SapSyncMesg.Error_Invalid;
                        break;
                    }
            }
            if (!isCloseApp)
            {
                using (StreamWriter sw = new StreamWriter(pipeServer))
                {
                    sw.AutoFlush = true;
                    sw.WriteLine(returnStr);
                }
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            _isStop = true;
            for (int i = 0; i < _serverPool.Count; i++)
            {
                var item = _serverPool[i];

                DistroyObject(item);
            }
            if (servers != null)
            {
                servers.Abort();
            }
        }

        #region EventHandler

        /// <summary>
        /// Delegate SapSyncEventHandler
        /// </summary>
        /// <param name="commandStr">The command string.</param>
        public delegate void SapSyncEventHandler(string commandStr);

        public event SapSyncEventHandler Request_AttendHid_Control;//

        public event SapSyncEventHandler Request_PlayDevice_Control;

        public event SapSyncEventHandler Request_VideoDevice_Control;

        public event SapSyncEventHandler Request_PlayTask_Control;

        public event SapSyncEventHandler Request_App_Control;

        public event SapSyncEventHandler Notice_RuntimeSettingChanged;//

        public event SapSyncEventHandler Notice_AttendConfigChanged;//

        public event SapSyncEventHandler Notice_DedicatedCommDevicesChanged;

        #endregion EventHandler

        #region On Event

        public void OnAttendHid_ControlEvent(string commandStr)
        {
            if (Request_AttendHid_Control != null)
                Request_AttendHid_Control(commandStr);
        }

        public void OnPlayDevice_ControlEvent(string commandStr)
        {
            if (Request_PlayDevice_Control != null)
                Request_PlayDevice_Control(commandStr);
        }

        public void OnVideoDevice_ControlEvent(string commandStr)
        {
            if (Request_VideoDevice_Control != null)
                Request_VideoDevice_Control(commandStr);
        }

        public void OnPlayTask_ControlEvent(string commandStr)
        {
            if (Request_PlayTask_Control != null)
                Request_PlayTask_Control(commandStr);
        }

        public void OnApp_Control(string commandStr)
        {
            if (Request_App_Control != null)
                Request_App_Control(commandStr);
        }

        #endregion On Event

        #region SapSync Delegate Method

        public delegate bool SapSyncDelegateMethod(string commandStr);

        public SapSyncDelegateMethod AttendHid_Control;//Get & Return

        public SapSyncDelegateMethod PlayDevice_Control;//Get & Return & AudioPlayUser_Changed

        public SapSyncDelegateMethod VideoDevice_Control;//Notice_AudioPlayUser_Changed

        public SapSyncDelegateMethod PlayTaskControl;//PlayTask_Changed & Start & Pause & Stop

        public SapSyncDelegateMethod AppRuningNotice;//协作系统应用运行通知处理方法

        public SapSyncDelegateMethod App_Control;//Close & Minimize & Maximize 

        public SapSyncDelegateMethod RuntimeSettingChanged;//

        public SapSyncDelegateMethod AttendConfigChanged;//

        public SapSyncDelegateMethod DedicatedCommDevicesChanged;//


        #endregion SapSync Delegate Method
    }

    public class NamedPipeClient : IDisposable
    {
        string _serverName;
        string _pipName;
        NamedPipeClientStream _pipeClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverName">服务器地址</param>
        /// <param name="pipName">管道名称</param>
        public NamedPipeClient(string serverName, string pipName)
        {
            _serverName = serverName;
            _pipName = pipName;

            _pipeClient = new NamedPipeClientStream(serverName, pipName, PipeDirection.InOut);

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Query(string request)
        {
            if (!_pipeClient.IsConnected)
            {
                try
                {
                    _pipeClient.Connect(1000);
                }
                catch
                {
                    return "Exception | Unable to connect to NamedPipe.";
                }
            }

            StreamWriter sw = new StreamWriter(_pipeClient);
            sw.WriteLine(request);
            sw.Flush();

            StreamReader sr = new StreamReader(_pipeClient);
            string temp;
            string returnVal = "";
            while ((temp = sr.ReadLine()) != null)
            {
                returnVal = temp;
                //nothing
            }
            return returnVal;
        }

        #region IDisposable 成员

        bool _disposed = false;
        public void Dispose()
        {
            if (!_disposed && _pipeClient != null)
            {
                _pipeClient.Dispose();
                _disposed = true;
            }
        }

        #endregion
    }

    public class SapSyncMesg
    {
        public const string Error_Invalid = "Error|Invalid";//无效操作
        public const string Exception_Invalid = "Exception|Invalid";//严重错误
        public const string Exception_Unable = "Exception|Unable";//目标未知

        public const string Request_Get_AttendHid = "Request|Get AttendHid";               //请求 获取刷卡设备接收HID 通讯通道
        public const string Request_Return_AttendHid = "Request|Return AttendHid";         //请求 归还刷卡设备接收HID 通讯通道

        public const string Request_Get_PlayDevice = "Request|Get PlayDevice";             //请求  请求音频功放设备 控制权
        public const string Request_Return_PlayDevice = "Request|Return PlayDevice";       //请求  归还音频功放设备 控制权

        public const string Request_VideoDevice_Start = "Request|VideoDevice Start";       //请求 视频设备启动
        public const string Request_VideoDevice_Stop = "Request|VideoDevice Stop";         //请求 视频设备停止

        public const string Request_PlayTask_Start = "Request|PlayTask Start";             //请求  播放任务开始
        public const string Request_PlayTask_Pause = "Request|PlayTask Pause";             //请求  播放任务暂停
        public const string Request_PlayTask_Stop = "Request|PlayTask Stop";             //请求  播放任务停止(结束)

        public const string Request_Close = "Request|Close";//请求 应用程序关闭
        public const string Request_Minimize = "Request|Minimize";//请求 应用程序最小化
        public const string Request_Maximize = "Request|Maximize";//请求 应用程序最大化

        public const string Notice_PlayTask_Changed = "Notice|PlayTask Changed";//通知 播放任务已更改   uint lParam -> taskID
        public const string Notice_AudioPlayUser_Changed = "Notice|AudioPlayUser Changed";//通知 音频设备 播放通道组合已更改

        public const string Notice_AttendHid_Changed = "Notice|AttendHid_Changed";//通知 刷卡通讯设备HID 已更改

        public const string Notice_PlayDevice_Changed = "Notice|PlayDevice_Changed";//通知 音频设备 已更改

        public const string Notice_VideoDevice_Changed = "Notice|VideoDevice Changed";//通知 视频频设备 已更改

        public const string Notice_RuningTimeApp_Runing = "Notice|RuningTimeApp Runing";//通知 RuningTimeApp 已经启动

        public const string Notice_ManagementApp_Runing = "Notice|ManagementApp Runing";//通知 ManagementApp 已经启动

        public const string Notice_RuntimeSetting_Changed = "Notice|RuntimeSetting Changed";//通知 Runtime 配置已经更改

        public const string Notice_AttendConfig_Changed = "Notice|AttendConfig Changed";//通知 考勤 配置已经更改

        public const string Notice_DedicatedCommDevices_Changed = "Notice|DedicatedCommDevices Changed";//通讯设备更改

        public const string Reply_Notice_Received = "Reply|Notice Received";//回复 已收到通知

        public const string Reply_Request_Completed = "Reply|Request Completed";//回复 请求任务执行完成
        public const string Reply_Request_Failed = "Reply|Request Failed";//回复 请求任务执行失败

        public const string Reply_AttendHid_Freed = "Reply|AttendHid_Freed";//回复 刷卡设备通讯通道释放成功
        public const string Reply_AttendHid_Failed = "Reply|AttendHid_Failed";//回复 刷卡设备通讯通道释放失败

        public const string Reply_PlayDevice_Freed = "Reply|PlayDevice_Freed";//回复 音频功放设备释放成功
        public const string Reply_PlayDevice_Failed = "Reply|PlayDevice_Failed";//回复 音频功放设备释放失败

    }
}

