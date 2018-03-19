// ***********************************************************************
// Assembly         : DataHelper
// Author           : zw_maqing
// Created          : 11-10-2014
//
// Last Modified By : zw_maqing
// Last Modified On : 01-27-2015
// ***********************************************************************
// <copyright file="SystemHelper.cs" company="ZhiweiTech">
//     Copyright (c) ZhiweiTech. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

/// <summary>
/// The DataHelper namespace.
/// </summary>
namespace DataHelper
{
    /// <summary>
    /// Class WinMesgHelper.
    /// </summary>
    public class WinMesgHelper
    {
        /// <summary>
        /// The w m_ copydata
        /// </summary>
        public const int WM_COPYDATA = 0x4a;

        /// <summary>
        /// The data code_ sapmanager
        /// </summary>
        private const uint DataCode_Sapmanager = 1000;//消息数据代码

        /// <summary>
        /// The code_ attend hid_ request
        /// </summary>
        public const uint Code_AttendHid_Request = 1501;//请求 刷卡接收HID 通讯通道
        /// <summary>
        /// The code_ attend hid_ released
        /// </summary>
        public const uint Code_AttendHid_Released = 1502;//已经释放 刷卡接收HID 通讯通道
        /// <summary>
        /// The code_ attend hid_ not released
        /// </summary>
        public const uint Code_AttendHid_NotReleased = 1503;//未能释放 刷卡接收HID 通讯通道


        /// <summary>
        /// The code_ play dvice_ request
        /// </summary>
        public const uint Code_PlayDvice_Request = 1505;//请求 音频功放设备 控制权
        /// <summary>
        /// The code_ play dvice_ released
        /// </summary>
        public const uint Code_PlayDvice_Released = 1506;//已经释放 音频功放设备 控制权
        /// <summary>
        /// The code_ play dvice_ not released
        /// </summary>
        public const uint Code_PlayDvice_NotReleased = 1507;//未能释放 音频功放设备 控制权


        /// <summary>
        /// The code_ play task_ changed
        /// </summary>
        public const uint Code_PlayTask_Changed = 1521;//播放任务已更改   uint lParam -> taskID
        /// <summary>
        /// The code_ play task_ load
        /// </summary>
        public const uint Code_PlayTask_Load = 1524;//加载播放任务
        /// <summary>
        /// The code_ play task_ start
        /// </summary>
        public const uint Code_PlayTask_Start = 1525;//开始播放任务
        /// <summary>
        /// The code_ play task_ pause
        /// </summary>
        public const uint Code_PlayTask_Pause = 1526;//暂停播放任务
        /// <summary>
        /// The code_ play task_ stop
        /// </summary>
        public const uint Code_PlayTask_Stop = 1527;//停止播放任务

        /// <summary>
        /// The code_ audio play user_ changed
        /// </summary>
        public const uint Code_AudioPlayUser_Changed = 1551;//音频设备 播放通道组合已更改

        public const uint Code_Runtime_IsRunning = 1611;//Runtime 已经开始运行

        public const uint Code_Runtime_IsCloseing = 1612;//Runtime 已经开始运行

        public const uint Code_SapManager_IsRunning = 1621;//SapManager 已经开始运行

        public const uint Code_SapManager_IsCloseing = 1622;//SapManager 已经开始运行

        /// <summary>
        /// The code_ app_ close
        /// </summary>
        public const uint Code_App_Close = 1601;//请求接收应用关闭
        /// <summary>
        /// The code_ app_ minimize
        /// </summary>
        public const uint Code_App_Minimize = 1602;//请求接收应用最小化
        /// <summary>
        /// The code_ app_ maximize
        /// </summary>
        public const uint Code_App_Maximize = 1603;//请求接收应用最大化

        /// <summary>
        /// The command_ request
        /// </summary>
        public const string Command_Request = "Request";
        /// <summary>
        /// The command_ reply
        /// </summary>
        public const string Command_Reply = "Reply";
        /// <summary>
        /// The command_ system not device
        /// </summary>
        public const string Command_SysNotDevice = "System not the device.";
        /// <summary>
        /// The command_ device using
        /// </summary>
        public const string Command_DeviceUsing = "The device is using.";
        /// <summary>
        /// The command_ ok
        /// </summary>
        public const string Command_OK = "OK";

        /*
         * 使用说明
         *  ZhiWeiTech.DataHelper.Win32API.COPYDATASTRUCT Dome=new Win32API.COPYDATASTRUCT ();
            Dome.dataCode=Code_PlayDvice_Request;
            byte[] bytes = Encoding.Default.GetBytes(Command_OK);
            Dome.strLenght = (uint)bytes.Length;
            Dome.strDataPtr= Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, Dome.strDataPtr, bytes.Length);
         * 
         * */


        /// <summary>
        /// Delegate RequestMessageEventHandler
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public delegate void RequestMessageEventHandler(IntPtr senderHandle, uint dataCode, string commandStr);

        /// <summary>
        /// Occurs when [play dvice reply].
        /// </summary>
        public event RequestMessageEventHandler PlayDviceReply;//播放设备回复
        /// <summary>
        /// Occurs when [attend hid reply].
        /// </summary>
        public event RequestMessageEventHandler AttendHidReply;//考勤设备回复
        /// <summary>
        /// Occurs when [request play dvice].
        /// </summary>
        public event RequestMessageEventHandler RequestPlayDvice;//请求播放设备
        /// <summary>
        /// Occurs when [request attend hid].
        /// </summary>
        public event RequestMessageEventHandler RequestAttendHid;//请求考勤通讯设备

        /// <summary>
        /// Occurs when [play task change notice].
        /// </summary>
        public event RequestMessageEventHandler PlayTaskChangeNotice;//播放任务已更改通知
        /// <summary>
        /// Occurs when [request play start].
        /// </summary>
        public event RequestMessageEventHandler RequestPlayStart;//请求播放任务 开始播放
        /// <summary>
        /// Occurs when [request play pause].
        /// </summary>
        public event RequestMessageEventHandler RequestPlayPause;//请求播放任务 暂停播放
        /// <summary>
        /// Occurs when [request play stop].
        /// </summary>
        public event RequestMessageEventHandler RequestPlayStop;//请求播放任务 停止播放

        /// <summary>
        /// Occurs when [play user change notice].
        /// </summary>
        public event RequestMessageEventHandler PlayUserChangeNotice;//播放通道组合已更改通知

        public event RequestMessageEventHandler SapModulesRunningEvent;

        /// <summary>
        /// Occurs when [request close].
        /// </summary>
        public event RequestMessageEventHandler RequestClose;//请求应用关闭
        /// <summary>
        /// Occurs when [request minimize].
        /// </summary>
        public event RequestMessageEventHandler RequestMinimize;//请求应用最小化
        /// <summary>
        /// Occurs when [request maximize].
        /// </summary>
        public event RequestMessageEventHandler RequestMaximize;//请求应用最大化


        /// <summary>
        /// Initializes a new instance of the <see cref="WinMesgHelper"/> class.
        /// </summary>
        public WinMesgHelper()
        {

        }

        /// <summary>
        /// Sends the message to process window.
        /// </summary>
        /// <param name="processName">Name of the process.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="contentStr">The content string.</param>
        /// <returns>System.Int32.</returns>
        public int SendMessageToProcessWindow(string processName, int msg, string contentStr)
        {
            IntPtr hWnd = new IntPtr(0);
            int to = 0;
            Process[] pros = Process.GetProcesses(); //获取本机所有进程
            for (int i = 0; i < pros.Length; i++)
            {
                if (pros[i].ProcessName == processName) //名称为 toWindows.Text的进程
                {
                    hWnd = pros[i].MainWindowHandle; //获取 toWindows.Text主窗口句柄
                }
            }
            if (hWnd != (IntPtr)0)
            {
                IntPtr i = Marshal.StringToHGlobalAuto(contentStr);
                to = Win32API.SendMessage(hWnd, msg, 0, i.ToInt32());
            }
            return to;
        }

        /// <summary>
        /// Sends the string to window.
        /// </summary>
        /// <param name="destWindow">The dest window.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="str">The string.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SendStringToWindow(string destWindow, int msg, uint flag, string str)
        {
            IntPtr hWnd = Win32API.FindWindow(null, destWindow);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(str);
                copydatastruct.dataCode = flag;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, msg, 0, ref copydatastruct);

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Sends the data to process window.
        /// </summary>
        /// <param name="toWindowPtr">To window PTR.</param>
        /// <param name="WM_Msg_Code">The w m_ MSG_ code.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="dataStr">The data string.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SendDataToProcessWindow(IntPtr toWindowPtr, int WM_Msg_Code, int wParam, uint dataCode, string dataStr)
        {
            if (toWindowPtr == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(dataStr);
                copydatastruct.dataCode = dataCode;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                int result = Win32API.SendMessage(toWindowPtr, WM_Msg_Code, wParam, ref copydatastruct);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #region 通讯方法

        /// <summary>
        /// 请求刷卡通讯 HID设备 的控制
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AttendHidCommRequest(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_AttendHid_Request;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, senderWinPtr.ToInt32(), ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Plays the dvice request.
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PlayDviceRequest(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_PlayDvice_Request;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, senderWinPtr.ToInt32(), ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Replies the attend hid comm request.
        /// </summary>
        /// <param name="toWinPtr">To win PTR.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ReplyAttendHidCommRequest(IntPtr toWinPtr, uint dataCode, string commandStr, IntPtr senderWinPtr)
        {
            return SendDataToProcessWindow(toWinPtr, WM_COPYDATA, senderWinPtr.ToInt32(), dataCode, commandStr);

        }

        /// <summary>
        /// Replies the play dvice request.
        /// </summary>
        /// <param name="toWinPtr">To win PTR.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ReplyPlayDviceRequest(IntPtr toWinPtr, uint dataCode, string commandStr, IntPtr senderWinPtr)
        {
            return SendDataToProcessWindow(toWinPtr, WM_COPYDATA, senderWinPtr.ToInt32(), dataCode, commandStr);

        }

        /// <summary>
        /// Notices the play task changed event.
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool NoticePlayTaskChangedEvent(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_PlayTask_Changed;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, 0, ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Requests the play task load.
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RequestPlayTaskLoad(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_PlayTask_Load;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, senderWinPtr.ToInt32(), ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Requests the play task start.
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RequestPlayTaskStart(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_PlayTask_Start;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, senderWinPtr.ToInt32(), ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Requests the play task pause.
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RequestPlayTaskPause(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_PlayTask_Pause;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, senderWinPtr.ToInt32(), ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Requests the play task stop.
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RequestPlayTaskStop(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_PlayTask_Stop;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, senderWinPtr.ToInt32(), ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Notices the play user change event.
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool NoticePlayUserChangeEvent(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_AudioPlayUser_Changed;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, 0, ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public bool NoticeModulesRunningChangeEvent(string toProcessName, uint changeCode, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = changeCode;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, 0, ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }



        /// <summary>
        /// Requests the application close.
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RequestAppClose(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_App_Close;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, senderWinPtr.ToInt32(), ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Requests the application minimize.
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RequestAppMinimize(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_App_Minimize;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, senderWinPtr.ToInt32(), ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Requests the application maximize.
        /// </summary>
        /// <param name="toProcessName">Name of to process.</param>
        /// <param name="senderWinPtr">The sender win PTR.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RequestAppMaximize(string toProcessName, IntPtr senderWinPtr)
        {
            IntPtr hWnd = Win32API.FindProcessWinHandle(toProcessName);
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }
            try
            {
                Win32API.COPYDATASTRUCT copydatastruct;
                byte[] bytes = Encoding.Default.GetBytes(Command_Request);
                copydatastruct.dataCode = Code_App_Maximize;
                copydatastruct.strLenght = bytes.Length;
                copydatastruct.strDataPtr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, copydatastruct.strDataPtr, bytes.Length);
                Win32API.SendMessage(hWnd, WM_COPYDATA, senderWinPtr.ToInt32(), ref copydatastruct);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        #endregion 通讯方法

        #region 引发事件方法

        /// <summary>
        /// Called when [request play dvice event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnRequestPlayDviceEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (RequestPlayDvice != null)
                RequestPlayDvice(senderHandle, dataCode, commandStr);
        }

        /// <summary>
        /// Called when [request attend hid event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnRequestAttendHidEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (RequestAttendHid != null)
                RequestAttendHid(senderHandle, dataCode, commandStr);
        }

        /// <summary>
        /// Called when [play dvice reply event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnPlayDviceReplyEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (PlayDviceReply != null)
                PlayDviceReply(senderHandle, dataCode, commandStr);
        }

        /// <summary>
        /// Called when [attend hid reply event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnAttendHidReplyEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (AttendHidReply != null)
                AttendHidReply(senderHandle, dataCode, commandStr);
        }

        /// <summary>
        /// Called when [play task change notice event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnPlayTaskChangeNoticeEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (PlayTaskChangeNotice != null)
                PlayTaskChangeNotice(senderHandle, dataCode, commandStr);
        }

        /// <summary>
        /// Called when [request play start event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnRequestPlayStartEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (RequestPlayStart != null)
                RequestPlayStart(senderHandle, dataCode, commandStr);
        }

        /// <summary>
        /// Called when [request play pause event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnRequestPlayPauseEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (RequestPlayPause != null)
                RequestPlayPause(senderHandle, dataCode, commandStr);
        }

        /// <summary>
        /// Called when [request play stop event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnRequestPlayStopEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (RequestPlayStop != null)
                RequestPlayStop(senderHandle, dataCode, commandStr);
        }

        /// <summary>
        /// Called when [request close event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnRequestCloseEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (RequestClose != null)
            {
                RequestClose(senderHandle, dataCode, commandStr);
            }
        }

        /// <summary>
        /// Called when [request minimize event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnRequestMinimizeEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (RequestMinimize != null)
                RequestMinimize(senderHandle, dataCode, commandStr);
        }

        /// <summary>
        /// Called when [request maximize event].
        /// </summary>
        /// <param name="senderHandle">The sender handle.</param>
        /// <param name="dataCode">The data code.</param>
        /// <param name="commandStr">The command string.</param>
        public void OnRequestMaximizeEvent(IntPtr senderHandle, uint dataCode, string commandStr)
        {
            if (RequestMaximize != null)
                RequestMaximize(senderHandle, dataCode, commandStr);
        }

        #endregion 引发事件方法

        public static bool IsTheProcessRunning(string processName)
        {
            if (Win32API.FindProcessWinHandle("SapSchoolSysManager") == IntPtr.Zero)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }


    /// <summary>
    /// Class Win32API.
    /// </summary>
    public class Win32API
    {
        #region 基础API

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="hFile">The h file.</param>
        /// <param name="lpBuffer">The lp buffer.</param>
        /// <param name="nNumberOfBytesToRead">The n number of bytes to read.</param>
        /// <param name="lpNumberOfBytesRead">The lp number of bytes read.</param>
        /// <param name="overlapped">The overlapped.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadFile(
             IntPtr hFile,                   // handle to file
             byte[] lpBuffer,                // data buffer
             int nNumberOfBytesToRead,       // number of bytes to read
             ref int lpNumberOfBytesRead,    // number of bytes read
         int overlapped);

        //关闭句柄：
        /// <summary>
        /// Closes the handle.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);


        //
        /// <summary>
        /// Creates the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileAccess">The file access.</param>
        /// <param name="fileShare">The file share.</param>
        /// <param name="securityAttributes">The security attributes.</param>
        /// <param name="creationDisposition">The creation disposition.</param>
        /// <param name="flags">The flags.</param>
        /// <param name="template">The template.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFile(string fileName, uint fileAccess, uint fileShare, int securityAttributes, uint creationDisposition, int flags, IntPtr template);

        //
        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="hFile">The h file.</param>
        /// <param name="lpBuffer">The lp buffer.</param>
        /// <param name="nNumberOfBytesToWrite">The n number of bytes to write.</param>
        /// <param name="lpNumberOfBytesWritten">The lp number of bytes written.</param>
        /// <param name="lpOverlapped">The lp overlapped.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, [In] ref System.Threading.NativeOverlapped lpOverlapped);

        /// <summary>
        /// Finds the window.
        /// </summary>
        /// <param name="lpClassName">Name of the lp class.</param>
        /// <param name="lpWindowName">Name of the lp window.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// Finds the window ex.
        /// </summary>
        /// <param name="hwndParent">The HWND parent.</param>
        /// <param name="hwndChildAfter">The HWND child after.</param>
        /// <param name="lpClassName">Name of the lp class.</param>
        /// <param name="lpWindowName">Name of the lp window.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);

        /// <summary>
        /// Virtuals the alloc ex.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="lpaddress">The lpaddress.</param>
        /// <param name="size">The size.</param>
        /// <param name="type">The type.</param>
        /// <param name="tect">The tect.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll")]
        public static extern int VirtualAllocEx(IntPtr hwnd, int lpaddress, int size, int type, int tect);

        /// <summary>
        /// Writes the process memory.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="baseaddress">The baseaddress.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="nsize">The nsize.</param>
        /// <param name="filewriten">The filewriten.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll")]
        public static extern int WriteProcessMemory(IntPtr hwnd, int baseaddress, string buffer, int nsize, int filewriten);

        /// <summary>
        /// Gets the proc address.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="lpname">The lpname.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll")]
        public static extern int GetProcAddress(int hwnd, string lpname);

        /// <summary>
        /// Gets the module handle a.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll")]
        public static extern int GetModuleHandleA(string name);

        /// <summary>
        /// Finds the process win handle.
        /// </summary>
        /// <param name="runningAppName">Name of the running application.</param>
        /// <returns>IntPtr.</returns>
        public static IntPtr FindProcessWinHandle(string runningAppName)
        {
            IntPtr hWnd = (IntPtr)0;
            Process[] pros = Process.GetProcesses(); //获取本机所有进程
            for (int i = 0; i < pros.Length; i++)
            {
                if (pros[i].ProcessName == runningAppName) //名称为 runningAppName的进程
                {
                    hWnd = pros[i].MainWindowHandle; //获取 runningAppName主窗口句柄
                    break;
                }
            }
            return hWnd;
        }

        #endregion 基础API

        #region RemoteAPI

        /// <summary>
        /// Creates the remote thread.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="attrib">The attribute.</param>
        /// <param name="size">The size.</param>
        /// <param name="address">The address.</param>
        /// <param name="par">The par.</param>
        /// <param name="flags">The flags.</param>
        /// <param name="threadid">The threadid.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll")]
        public static extern int CreateRemoteThread(IntPtr hwnd, int attrib, int size, int address, int par, int flags, int threadid);

        #endregion RemoteAPI

        #region MailSlot 邮件槽通讯

        /// <summary>
        /// Creates the mailslot.
        /// </summary>
        /// <param name="lpName">Name of the lp.</param>
        /// <param name="nMaxMessageSize">Size of the n maximum message.</param>
        /// <param name="lReadTimeout">The l read timeout.</param>
        /// <param name="lpSecurityAttributes">The lp security attributes.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateMailslot(string lpName, uint nMaxMessageSize, uint lReadTimeout, IntPtr lpSecurityAttributes);

        //  检查MailSlot中的信息情况：
        /// <summary>
        /// Gets the mailslot information.
        /// </summary>
        /// <param name="hMailslot">The h mailslot.</param>
        /// <param name="lpMaxMessageSize">Size of the lp maximum message.</param>
        /// <param name="lpNextSize">Size of the lp next.</param>
        /// <param name="lpMessageCount">The lp message count.</param>
        /// <param name="lpReadTimeout">The lp read timeout.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll")]
        public static extern bool GetMailslotInfo(IntPtr hMailslot, int lpMaxMessageSize, ref int lpNextSize, IntPtr lpMessageCount, IntPtr lpReadTimeout);


        #endregion MailSlot 邮件槽通讯

        #region Win Message

        /// <summary>
        /// 自定义的结构
        /// </summary>
        public struct My_lParam
        {
            /// <summary>
            /// The i
            /// </summary>
            public int i;
            /// <summary>
            /// The s
            /// </summary>
            public string s;
        }

        /// <summary>
        /// 使用COPYDATASTRUCT来传递字符串,重载CopyDataStruct
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            /// <summary>
            /// The data code
            /// </summary>
            public uint dataCode;
            /// <summary>
            /// The string lenght
            /// </summary>
            public int strLenght;
            /// <summary>
            /// The string data PTR
            /// </summary>
            public IntPtr strDataPtr;
        }
        //消息发送API
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄
            int Msg,            // 消息ID
            int wParam,         // 参数1
            IntPtr lParam          //参数2
        );

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄
            int Msg,            // 消息ID
            int wParam,         // 参数1
            int lParam          //参数2
        );


        //消息发送API
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄
            int Msg,            // 消息ID
            int wParam,         // 参数1
            ref My_lParam lParam //参数2
        );

        //消息发送API
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄
            int Msg,            // 消息ID
            int wParam,         // 参数1
            ref  COPYDATASTRUCT lParam  //参数2
        );

        //消息发送API
        /// <summary>
        /// Posts the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄
            int Msg,            // 消息ID
            int wParam,         // 参数1
            int lParam            // 参数2
        );

        //消息发送API
        /// <summary>
        /// Posts the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄
            int Msg,            // 消息ID
            int wParam,         // 参数1
            ref My_lParam lParam //参数2
        );


        #endregion Win Message
    }

}
