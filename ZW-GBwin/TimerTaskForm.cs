using DataHelper;
using DevComponents.DotNetBar;
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
using ZW_GBwin.Properties;

namespace ZW_GBwin
{
    public partial class TimerTaskForm : DevComponents.DotNetBar.Metro.MetroForm
    {

        bool _isTimeOverlapOk = false;

        List<ZWGB_Area> _allArea;
        List<deviceInfo> _allDevList;
        ZWGB_PlayTask _newTask;
        List<TaskDeviceSync> _devicesSync;
        bool isEditTask = false;

        public TimerTaskForm(List<ZWGB_Area> allArea, List<deviceInfo> allDevList, ZWGB_PlayTask newTask, List<TaskDeviceSync> devicesSync)
        {
            InitializeComponent();

            _allArea = allArea;
            _allDevList = allDevList;
            _newTask = newTask;
            _devicesSync = devicesSync;
        }

        private void TimerTaskForm_Load(object sender, EventArgs e)
        {
            CrumbBarItem rootItem = new CrumbBarItem();
            rootItem.Text = "所有区域";
            rootItem.Image = Resources.group_22;
            crumbBar_Area.Items.Add(rootItem);

            var rootNodes = _allArea.FindAll(x => x.ParentAreaID == 0);
            foreach (var oneRoot in rootNodes)
            {
                CrumbBarItem node = new CrumbBarItem();
                node.Tag = oneRoot;
                node.Text = oneRoot.AreaName;
                node.Image = Resources.group_22;
                rootItem.SubItems.Add(node);
            }

            crumbBar_Area.SelectedItem = rootItem;

            if (_newTask.TaskID > 0)
            {
                loadTaskToInput(_newTask);
                isEditTask = true;
            }
        }

        private void loadTaskToInput(ZWGB_PlayTask task)
        {
            textBoxX_TaskName.Text = task.TaskName;
            timeInput_TaskStart.Value = task.StarTime;
            timeInput_TaskEnd.Value = task.EndTime;
            slider_TaskStartVolume.Value = task.StarVolume;
            slider_TaskEndVolume.Value = task.EndVolume;

            chk_taskIsMonday.Checked = task.WeekStr.Contains("1");
            chk_taskIsTuesday.Checked = task.WeekStr.Contains("2");
            chk_taskIsWednesday.Checked = task.WeekStr.Contains("3");
            chk_taskIsThursday.Checked = task.WeekStr.Contains("4");
            chk_taskIsFriday.Checked = task.WeekStr.Contains("5");
            chk_taskIsSaturday.Checked = task.WeekStr.Contains("6");
            chk_taskIsSunday.Checked = task.WeekStr.Contains("7");

            lab_oldAreaFullPath.Text = task.AreaPath;
            crumbBar_Area.Enabled = false;
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

        private GetCHGroupsResult getNetPowerGroups(string IP, string token)
        {
            string url = "http://" + IP + "/API/Group";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CMD", "GetCHGroups");
            parameters.Add("Range", "1-10");
            parameters.Add("Token", token);

            try
            {
                string re = HttpGet(url, parameters);
                GetCHGroupsResult result = JsonConvert.DeserializeObject<GetCHGroupsResult>(re);
                return result;
            }
            catch
            {
                return null;
            }
        }

        private IsTaskTimeOverlapResult isTheTaskTimeOverlapForDevice(string IP, string token, string starTimeStr, string spanStr, string weekStr)
        {
            string url = "http://" + IP + "/API/Task";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CMD", "IsTaskTimeOverlap");
            parameters.Add("StartTime", starTimeStr);
            parameters.Add("TimeSpan", spanStr);
            parameters.Add("Week", weekStr);
            parameters.Add("Token", token);

            try
            {
                string re = HttpGet(url, parameters);
                IsTaskTimeOverlapResult result = JsonConvert.DeserializeObject<IsTaskTimeOverlapResult>(re);
                return result;
            }
            catch
            {
                return null;
            }
        }

        private OperateTaskResult addTaskToDevice(string IP, string token, string taskName, string starTimeStr, string spanStr, string group, string volume, string weekStr)
        {
            string url = "http://" + IP + "/API/Task";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CMD", "AddTask");
            parameters.Add("TaskName", taskName);//TaskName
            parameters.Add("IsSystem", "false");
            parameters.Add("TaskType", "Music");
            parameters.Add("PlayModel", "Order");
            parameters.Add("StartTime", starTimeStr);
            parameters.Add("TimeSpan", spanStr);
            parameters.Add("Week", weekStr);
            parameters.Add("Volume", volume);
            parameters.Add("ProCount", "0");
            if (!String.IsNullOrEmpty(group))
                parameters.Add("Groups", group);
            parameters.Add("Token", token);

            try
            {
                string re = HttpGet(url, parameters);
                OperateTaskResult result = JsonConvert.DeserializeObject<OperateTaskResult>(re);
                return result;
            }
            catch
            {
                return null;
            }
        }

        private OperateTaskResult editTaskToDevice(string IP, string token, int taskDevID, string taskName, string starTimeStr, string spanStr, string group, string volume, string weekStr)
        {
            string url = "http://" + IP + "/API/Task";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CMD", "EditTask");
            parameters.Add("TaskID", taskDevID.ToString());
            parameters.Add("TaskName", taskName);//TaskName
            parameters.Add("IsSystem", "false");
            parameters.Add("TaskType", "Music");
            parameters.Add("PlayModel", "Order");
            parameters.Add("StartTime", starTimeStr);
            parameters.Add("TimeSpan", spanStr);
            parameters.Add("Week", weekStr);
            parameters.Add("Volume", volume);
            parameters.Add("ProCount", "0");
            if (!String.IsNullOrEmpty(group))
                parameters.Add("Groups", group);
            parameters.Add("Token", token);

            try
            {
                string re = HttpGet(url, parameters);
                OperateTaskResult result = JsonConvert.DeserializeObject<OperateTaskResult>(re);
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Show Toast
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="img"></param>
        /// <param name="position"></param>
        /// <param name="scenes"></param>
        /// <param name="color"></param>
        private void showToastNotice(string msg, Image img, eToastPosition position = eToastPosition.MiddleCenter, int scenes = 3, eToastGlowColor color = eToastGlowColor.Blue)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(
                                delegate
                                {
                                    if (img == null)
                                    {
                                        img = global::ZW_GBwin.Properties.Resources.information_net_32;
                                    }
                                    ToastNotification.Show(this, msg, img, scenes * 1000, color, position);
                                }
                                ));
            }
            else
            {
                if (img == null)
                {
                    img = global::ZW_GBwin.Properties.Resources.information_net_32;
                }
                ToastNotification.Show(this, msg, img, scenes * 1000, color, position);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (btn_Cancel.Text == "退出")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btn_SaveTaskBaseInfo_Click(object sender, EventArgs e)
        {
            richText_log.Text = "";

            if (String.IsNullOrEmpty(this.textBoxX_TaskName.Text))
            {
                this.textBoxX_TaskName.Focus();
                return;
            }
            if (timeInput_TaskStart.Value >= timeInput_TaskEnd.Value)//检测开始结束时间的合法性
            {
                MessageBoxEx.Show("注意：开始时间必须小于结束时间", "任务时间有误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string weekStr = getInputWeekStr();
            if (String.IsNullOrEmpty(weekStr))
            {
                showToastNotice("没有选择执行此任务的周日时间！", null, eToastPosition.MiddleCenter, 2);
                return;
            }
            if (!isEditTask)
            {
                _devicesSync = getSelectedAreaContainsDevices(_devicesSync);
            }
            else
            {
                //  if (loginToDevices(_devicesSync) > 0) { }
            }
            if (_devicesSync.Count == 0)
            {
                showToastNotice("选择的区域里未包含收听设备！", null, eToastPosition.MiddleCenter, 2);
                crumbBar_Area.Focus();
                return;
            }
            circularProgress1.IsRunning = true;
            btn_SaveTaskBaseInfo.Enabled = false;
            if (isEditTask || btn_SaveTaskBaseInfo.Text == "补充发布")
            {
                lab_notice.Text = "正在补充发布任务到未成功的设备... ...";

                var newThread = new System.Threading.Thread(addTaskToDevicesThread);
                newThread.IsBackground = true;//设置为后台线程
                newThread.Start(_devicesSync);//启动补充发布线程
            }
            else
            {

                lab_notice.Text = "正在查询此任务时段与设备既有任务重叠... ...";

                var newThread = new System.Threading.Thread(checkIsTaskTimeOverlapThread);

                newThread.IsBackground = true;//设置为后台线程
                newThread.Start(_devicesSync);//启动
            }
        }

        private void crumbBar_Area_SelectedItemChanged(object sender, CrumbBarSelectionEventArgs e)
        {
            CrumbBarItem parent = e.NewSelectedItem;
            if (parent == null || parent.SubItems.Count > 0)
            {
                return;
            }

            if (parent.Tag is ZWGB_Area)
            {
                ZWGB_Area theArea = (ZWGB_Area)parent.Tag;
                //加载子区域
                var childNodes = _allArea.FindAll(x => x.ParentAreaID == theArea.AreaID);
                foreach (var oneArea in childNodes)
                {
                    CrumbBarItem node = new CrumbBarItem();
                    node.Tag = oneArea;
                    node.Text = oneArea.AreaName;
                    node.Image = Resources.group_22;
                    parent.SubItems.Add(node);
                }
                //加载包含的设备
                var dev = _allDevList.FindAll(x => x.AreaID == theArea.AreaID);
                foreach (var oneDev in dev)
                {
                    CrumbBarItem node = new CrumbBarItem();
                    node.Tag = oneDev;
                    node.Text = oneDev.AliasName;
                    node.Image = oneDev.Type == "IPTRUMPET" ? Resources.trumpet_net_22 : Resources.PlayPowerDevice_22;//IP喇叭/ip功放
                    parent.SubItems.Add(node);
                }
            }
            else if (parent.Tag is deviceInfo)
            {
                deviceInfo theDev = (deviceInfo)parent.Tag;
                //如果是分区设备加载 分区分组信息
                if (theDev.Type == "IPCHPOWER")
                {
                    if (String.IsNullOrEmpty(theDev.LoginName))
                    {
                        showToastNotice("该设备的登录口令尚未配置，未能添加！", null, eToastPosition.MiddleCenter, 2);
                        e.Cancel = true;
                        return;
                    }

                    LoginDeviceResult logon = loginDeviceHttp(theDev.IPV4, theDev.LoginName, theDev.LoginPass);

                    if (logon != null && logon.Status && logon.Data != null)
                    {
                        theDev.Token = logon.Data.Token;
                        GetCHGroupsResult result = getNetPowerGroups(theDev.IPV4, logon.Data.Token);
                        if (result != null && result.Status && result.Data.Length > 0)
                        {
                            //获取该设备的分组信息，加载到树节点
                            foreach (var oneGroup in result.Data)
                            {
                                CrumbBarItem node = new CrumbBarItem();
                                node.Tag = oneGroup;
                                node.Text = oneGroup.GroupName;
                                node.Image = Resources.group_b_22;//ip功放分区分组
                                parent.SubItems.Add(node);
                            }
                        }
                    }
                    else
                    {
                        showToastNotice("未能登录到目标设备：" + theDev.AliasName + " IP:" + theDev.IPV4, null, eToastPosition.MiddleCenter, 2);
                        e.Cancel = true;
                    }
                }
            }

        }

        /// <summary>
        /// 获取用户选择区域内包含的收听设备
        /// </summary>
        /// <returns></returns>
        private List<TaskDeviceSync> getSelectedAreaContainsDevices(List<TaskDeviceSync> devices)
        {
            if (crumbBar_Area.SelectedItem.Tag is ZWGB_Area)
            {
                //获取名下包含的所有设备
                List<ZWGB_Area> contArea = new List<ZWGB_Area>();
                contArea.Add((ZWGB_Area)crumbBar_Area.SelectedItem.Tag);
                while (contArea.Count > 0)
                {
                    ZWGB_Area theNode = contArea[0];
                    //每次循环都去掉第一个结点，下次循环就是第二个结点
                    contArea.Remove(theNode);
                    var childNodes = _allArea.FindAll(x => x.ParentAreaID == theNode.AreaID);

                    for (int i = 0; i < childNodes.Count; i++)
                    {
                        //把包含的子区域添加
                        contArea.Add(childNodes[i]);
                    }
                    //获取此区域的设备
                    var contDev = _allDevList.FindAll(x => x.AreaID == theNode.AreaID);
                    if (contDev != null && contDev.Count > 0)
                    {
                        foreach (var oneDev in contDev)
                        {
                            if (devices.FindIndex(x => x.DevSN == oneDev.SN) < 0)
                            { devices.Add(deviceInfoToTaskDeviceSync(oneDev)); }
                        }
                    }
                }
            }
            else if (crumbBar_Area.SelectedItem.Tag is deviceInfo)
            {
                //就是本设备
                deviceInfo dev = (deviceInfo)crumbBar_Area.SelectedItem.Tag;
                if (devices.FindIndex(x => x.DevSN == dev.SN) < 0)
                    devices.Add(deviceInfoToTaskDeviceSync(dev));
            }
            else if (crumbBar_Area.SelectedItem.Tag is CHGroup)
            {
                //选择的是分区分组
                deviceInfo power = (deviceInfo)crumbBar_Area.SelectedItem.Parent.Tag;
                CHGroup group = (CHGroup)crumbBar_Area.SelectedItem.Tag;
                TaskDeviceSync oneDev = deviceInfoToTaskDeviceSync(power);

                oneDev.ChannelGroupID = group.GroupID;
                if (devices.FindIndex(x => x.DevSN == oneDev.DevSN) < 0)
                    devices.Add(oneDev);
            }

            return devices;
        }

        /// <summary>
        /// 设备信息类型到任务收听设备同步信息记录类型转换
        /// </summary>
        /// <param name="dev"></param>
        /// <returns></returns>
        private TaskDeviceSync deviceInfoToTaskDeviceSync(deviceInfo dev)
        {
            TaskDeviceSync devDB = null;
            if (dev == null)
            {
                return devDB;
            }
            devDB = new TaskDeviceSync();
            devDB.AreaID = dev.AreaID;
            devDB.DeviceID = dev.TerminalID;
            devDB.DevSN = dev.SN;
            devDB.Token = dev.Token;
            devDB.LoginName = dev.LoginName;
            devDB.LoginPass = dev.LoginPass;
            devDB.IPV4 = dev.IPV4;
            devDB.DevAliasName = dev.AliasName;
            if (dev.Type == "IPCHPOWER")
            { devDB.ChannelGroupID = 100; }
            return devDB;
        }

        private bool checkIsTaskInputTimeOverlap(List<TaskDeviceSync> devices, string starTime, string span, string week)
        {
            foreach (var oneDev in devices)
            {
                string Token = "";
                if (!String.IsNullOrEmpty(oneDev.Token))
                {
                    Token = oneDev.Token;
                }
                else
                {
                    if (String.IsNullOrEmpty(oneDev.LoginName))
                    {
                        oneDev.IsTimeOK = false;
                        oneDev.TimeOverlapStr = "该设备缺少登录信息!";
                        continue;
                    }
                    LoginDeviceResult logon = loginDeviceHttp(oneDev.IPV4, oneDev.LoginName, oneDev.LoginPass);
                    if (logon != null && logon.Status)
                    {
                        Token = logon.Data.Token;
                        oneDev.Token = Token;
                    }
                }

                IsTaskTimeOverlapResult Result = isTheTaskTimeOverlapForDevice(oneDev.IPV4, Token, starTime, span, week);
                if (Result != null)
                {
                    if (Result.Data.IsOverlap)
                    {
                        oneDev.IsTimeOK = false;
                        oneDev.TimeOverlapStr = " 既有任务：" + Result.Data.TaskName + " " + Result.Data.StatusMessage;
                    }
                    else
                    {
                        oneDev.IsTimeOK = true;
                    }
                }
                else
                {
                    oneDev.Token = "";
                    oneDev.IsTimeOK = false;
                    oneDev.TimeOverlapStr = "未能登录到该设备!请确认设备是否在线.";
                    continue;
                }

            }
            return true;
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

        private string getInputWeekStr()
        {
            string weekStr = "";
            if (chk_taskIsMonday.Checked)
            {
                weekStr += "1";
            }
            if (chk_taskIsTuesday.Checked)
            {
                weekStr += weekStr.Length > 0 ? "_2" : "2";
            }
            if (chk_taskIsWednesday.Checked)
            {
                weekStr += weekStr.Length > 0 ? "_3" : "3";
            }
            if (chk_taskIsThursday.Checked)
            {
                weekStr += weekStr.Length > 0 ? "_4" : "4";
            }
            if (chk_taskIsFriday.Checked)
            {
                weekStr += weekStr.Length > 0 ? "_5" : "5";
            }
            if (chk_taskIsSaturday.Checked)
            {
                weekStr += weekStr.Length > 0 ? "_6" : "6";
            }
            if (chk_taskIsSunday.Checked)
            {
                weekStr += weekStr.Length > 0 ? "_7" : "7";
            }
            return weekStr;
        }

        private void checkIsTaskTimeOverlapThread(object state)
        {
            List<TaskDeviceSync> devices = (List<TaskDeviceSync>)state;

            TimeSpan span = timeInput_TaskEnd.Value - timeInput_TaskStart.Value;
            string spanStr = DataTypeConvert.SecondsDoubleToTimeStr(span.TotalSeconds);
            string weekStr = getInputWeekStr();

            if (checkIsTaskInputTimeOverlap(devices, timeInput_TaskStart.Value.ToString("HH:mm:ss"), spanStr, weekStr))
            {
                int notCount = 0;
                string log = "";
                string notice = "";
                foreach (var one in devices)
                {
                    if (!one.IsTimeOK)
                    {
                        notCount++;
                        // richText_log.Text 
                        log += "任务时间检查：" + one.DevAliasName + one.TimeOverlapStr + " 设备IP：" + one.IPV4 + "\n";
                    }
                }
                if (notCount > 0)
                {
                    notice = "选定区域内有 " + notCount + " 台设备任务时间检查未通过!";

                    if (richText_log.IsHandleCreated)
                        richText_log.BeginInvoke(new Action(delegate
                        {
                            //发送到UI 线程执行的代码
                            richText_log.Text += log;
                            lab_notice.Text = notice;
                            circularProgress1.IsRunning = false;
                            btn_SaveTaskBaseInfo.Enabled = true;
                        }));
                }
                else
                {
                    _isTimeOverlapOk = true;

                    if (lab_notice.IsHandleCreated)
                        lab_notice.BeginInvoke(new Action(delegate
                        {
                            //发送到UI 线程执行的代码
                            lab_notice.Text = "正在向区域内设备发布该任务配置信息... ...";
                        }));
                    //
                    var newThread = new System.Threading.Thread(addTaskToDevicesThread);

                    newThread.IsBackground = true;//设置为后台线程
                    newThread.Start(devices);//启动
                }
            }
        }

        private void addTaskToDevicesThread(object state)
        {
            List<TaskDeviceSync> devices = (List<TaskDeviceSync>)state;

            TimeSpan span = timeInput_TaskEnd.Value - timeInput_TaskStart.Value;
            string spanStr = DataTypeConvert.SecondsDoubleToTimeStr(span.TotalSeconds);
            string weekStr = getInputWeekStr();
            string volume = slider_TaskStartVolume.Value.ToString() + "-" + slider_TaskEndVolume.Value.ToString();
            string taskName = textBoxX_TaskName.Text;

            _newTask.TaskName = taskName;
            _newTask.StarTime = timeInput_TaskStart.Value;
            _newTask.EndTime = timeInput_TaskEnd.Value;
            _newTask.StarTimeStr = timeInput_TaskStart.Value.ToString("HH:mm:ss");
            _newTask.EndTimeStr = timeInput_TaskEnd.Value.ToString("HH:mm:ss");
            _newTask.SpanTimeStr = spanStr;
            _newTask.SpanSeconds = (long)span.TotalSeconds;
            _newTask.PlanID = 1;
            _newTask.PlayMode = "Order";
            _newTask.Type = "Music";
            _newTask.IsSystem = false;
            _newTask.StarVolume = slider_TaskStartVolume.Value;
            _newTask.EndVolume = slider_TaskEndVolume.Value;
            _newTask.WeekStr = weekStr;

            if (!isEditTask)
                _newTask.AreaPath = crumbBar_Area.SelectedItem.FullPath;

            int notCount = 0;
            string log = "";
            string notice = "";

            foreach (var oneDev in devices)
            {
                if (!isEditTask && oneDev.IsSync)
                {
                    continue;
                }

                OperateTaskResult resoult = null;
                if (!isEditTask)
                {
                    resoult = addTaskToDevice(oneDev.IPV4, oneDev.Token, taskName, timeInput_TaskStart.Value.ToString("HH:mm:ss"), spanStr, oneDev.ChannelGroupID.ToString(), volume, weekStr);
                }
                else
                {
                    if (String.IsNullOrEmpty(oneDev.Token))
                    {
                        oneDev.Token = loginToDevices(oneDev);
                    }

                    resoult = editTaskToDevice(oneDev.IPV4, oneDev.Token, oneDev.DevTaskID, taskName, timeInput_TaskStart.Value.ToString("HH:mm:ss"), spanStr, oneDev.ChannelGroupID.ToString(), volume, weekStr);
                }
                if (resoult != null && resoult.Status && resoult.Data != null)
                {
                    oneDev.DevTaskID = resoult.Data.TaskID;
                    oneDev.IsSync = true;
                }
                else
                {
                    notCount++;
                    log += "任务发布：" + oneDev.DevAliasName + " 未能成功, 设备IP：" + oneDev.IPV4 + "\n";
                }
            }

            if (notCount > 0)
            {
                notice += "区域内 " + notCount + " 台设备任务发布未成功!";
                if (richText_log.IsHandleCreated)
                    richText_log.BeginInvoke(new Action(delegate
                    {
                        //发送到UI 线程执行的代码
                        richText_log.Text += log;
                        lab_notice.Text = notice;
                        circularProgress1.IsRunning = false;

                        //发布并变成-变成-补充发布按钮
                        //取消-变成-退出按钮
                        btn_Cancel.Text = "退出";
                        btn_SaveTaskBaseInfo.Text = "补充发布";
                        taskInputEnableb(false);
                        btn_SaveTaskBaseInfo.Enabled = true;
                    }));
            }
            else
            {
                _isTimeOverlapOk = false;
                this.DialogResult = DialogResult.OK;
            }
            //存储到数据库
            //
        }

        private void taskInputEnableb(bool en)
        {
            textBoxX_TaskName.Enabled = en;
            switchButton1.Enabled = en;
            timeInput_TaskStart.Enabled = en;
            timeInput_TaskEnd.Enabled = en;
            crumbBar_Area.Enabled = en;
            slider_TaskStartVolume.Enabled = en;
            slider_TaskEndVolume.Enabled = en;
            chk_taskIsMonday.Enabled = en;

            chk_taskIsTuesday.Enabled = en;
            chk_taskIsWednesday.Enabled = en;
            chk_taskIsThursday.Enabled = en;
            chk_taskIsFriday.Enabled = en;
            chk_taskIsSaturday.Enabled = en;
            chk_taskIsSunday.Enabled = en;

        }
    }
}
