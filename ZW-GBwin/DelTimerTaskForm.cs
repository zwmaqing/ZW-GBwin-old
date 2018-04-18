using DataHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ZW_GBwin.Model;

namespace ZW_GBwin
{
    public partial class DelTimerTaskForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        List<deviceInfo> _allDevList;
        ZWGB_PlayTask _theTask;
        List<TaskDeviceSync> _devicesSync;
        bool deleted = false;

        public DelTimerTaskForm(List<deviceInfo> allDevList, ZWGB_PlayTask theTask, List<TaskDeviceSync> devicesSync)
        {
            InitializeComponent();

            _allDevList = allDevList;
            _theTask = theTask;
            _devicesSync = devicesSync;
        }

        public string HttpGet(string Url, Dictionary<string, string> parameters)
        {
            //拼装请求参数列表  
            StringBuilder sb = new StringBuilder();
            string strParameters = "";
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("&");
                    }
                    sb.AppendFormat("{0}={1}", kvp.Key, kvp.Value);
                }
                strParameters = sb.ToString();
            }
            // MessageBox.Show(strParameters);
            string retString = "";
            try
            {
                string str = Url + (strParameters == "" ? "" : "?") + strParameters;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Timeout = 2000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("网络错误：" + ex.Message);
                throw (ex);
            }
            return retString;
        }

        private LoginDeviceResult loginDeviceHttp(string IP, string name, string pass)
        {
            string url = "http://" + IP + "/API/System";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CMD", "LogOn");
            parameters.Add("userName", name);
            parameters.Add("password", pass);

            try
            {
                string re = HttpGet(url, parameters);
                LoginDeviceResult result = JsonConvert.DeserializeObject<LoginDeviceResult>(re);
                return result;
            }
            catch
            {
                return null;
            }
        }

        private OperateNormalResult delTaskToDevice(string IP, string token, int taskDevID)
        {
            string url = "http://" + IP + "/API/Task";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CMD", "DelTask");
            parameters.Add("TaskID", taskDevID.ToString());
            parameters.Add("Token", token);

            try
            {
                string re = HttpGet(url, parameters);
                OperateNormalResult result = JsonConvert.DeserializeObject<OperateNormalResult>(re);
                return result;
            }
            catch
            {
                return null;
            }
        }

        private int loginToDevices(List<TaskDeviceSync> devices)
        {
            int ok = 0;
            foreach (var oneDev in devices)
            {
                oneDev.Token = loginToDevices(oneDev);
                if (!String.IsNullOrEmpty(oneDev.Token))
                {
                    ok++;
                }
                else
                {
                    if (richTxt_Log.IsHandleCreated)
                        richTxt_Log.BeginInvoke(new Action(delegate
                        {
                            richTxt_Log.Text += "登录到设备：" + oneDev.DevAliasName + " " + oneDev.TimeOverlapStr + " 设备IP:" + oneDev.IPV4 + "\n";
                        }));
                }
            }
            return ok;
        }

        private string loginToDevices(TaskDeviceSync deviceSync)
        {
            deviceInfo devInfo = _allDevList.Find(x => x.SN == deviceSync.DevSN);
            string Token = "";

            if (devInfo == null && String.IsNullOrEmpty(devInfo.LoginName))
            {
                deviceSync.TimeOverlapStr = "该设备缺少登录信息!";
            }
            else
            {
                deviceSync.IPV4 = devInfo.IPV4;
                deviceSync.DevAliasName = devInfo.AliasName;
                deviceSync.IsSync = false;
                deviceSync.LoginName = devInfo.LoginName;
                deviceSync.LoginPass = devInfo.LoginPass;
                LoginDeviceResult logon = loginDeviceHttp(deviceSync.IPV4, deviceSync.LoginName, deviceSync.LoginPass);
                if (logon != null && logon.Status)
                {
                    Token = logon.Data.Token;
                    deviceSync.Token = Token;
                }
                else
                {
                    deviceSync.TimeOverlapStr = "登录到设备未能成功!";
                }
            }
            return Token;
        }

        private void delTaskToDevicesThread(object state)
        {
            List<TaskDeviceSync> devices = (List<TaskDeviceSync>)state;
            int loginCount = loginToDevices(devices);
            if (loginCount != devices.Count)
            {
                string message = String.Format("此任务包含的目标设备，有{0}台未能登录，不能完全执行删除操作，是否继续删除？", devices.Count - loginCount);
                string caption = "请确认是否继续删除此任务";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            int notCount = 0;
            string log = "";
            foreach (var oneDev in devices)
            {
                if (!String.IsNullOrEmpty(oneDev.Token))
                {
                    OperateNormalResult result = delTaskToDevice(oneDev.IPV4, oneDev.Token, oneDev.DevTaskID);
                    if (result != null && result.Status)
                    {

                    }
                    else
                    {
                        notCount++;
                        log += "删除任务：" + oneDev.DevAliasName + (result != null ? result.StatusMessage : "") + " 未能成功, 设备IP：" + oneDev.IPV4 + "\n";
                    }
                }
            }
            if (notCount == 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            deleted = true;
            if (richTxt_Log.IsHandleCreated)
                richTxt_Log.BeginInvoke(new Action(delegate
                {
                    richTxt_Log.Text += log;
                    btn_Del.Text = "退出";
                    prog_timer.IsRunning = false;
                    btn_Del.Enabled = true;
                }));
            //对话框再次确认不在线设备信息，
        }


        private void DelTimerTaskForm_Load(object sender, EventArgs e)
        {
            lab_msg.Text += _theTask.TaskName + " 吗？";
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (deleted)
            {
                this.DialogResult = DialogResult.OK;
            }

            prog_timer.IsRunning = true;
            btn_Del.Enabled = false;

            var newThread = new System.Threading.Thread(delTaskToDevicesThread);
            newThread.IsBackground = true;//设置为后台线程
            newThread.Start(_devicesSync);//启动补充发布线程

        }
    }
}
