using DataHelper;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZW_GBwin.Model;

namespace ZW_GBwin
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();

            _applicationPath = Application.StartupPath;
            _dbHelper = new DbDataService(_applicationPath);
        }

        private string _applicationPath = "";
        private DbDataService _dbHelper;

        #region 点击panelEx_Title控件移动窗口

        Point downPoint;
        private void panelEx_Title_MouseDown(object sender, MouseEventArgs e)
        {
            downPoint = new Point(e.X, e.Y);
        }

        private void panelEx_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - downPoint.X,
                    this.Location.Y + e.Y - downPoint.Y);
            }
        }


        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            resourcesClass.CurrentItemChanged += ResourcesClass_CurrentItemChanged;
            resources.CurrentItemChanged += Resources_CurrentItemChanged;

            currentLocalIP = NetHelper.GetLocalIP();//获取电脑当前本地IP
            loadAllStoregDev();//加载已存储的设备信息
            BindDeviceList = new BindingList<deviceInfo>(DeviceList);
            this.dGrid_devList.DataSourceChanged += DGrid_devList_DataSourceChanged;
            this.dGrid_devList.DataSource = BindDeviceList;
        }


        private void btn_CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Max_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btn_Mix_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelEx_Title_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_Max_Click(sender, e);
        }

        /// <summary>
        /// 进入功能Tab页面后的初始化操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superTabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {
            switch (e.NewValue.Name)
            {
                case "tabItem_Device":
                    {
                        //SearchDev
                        currentLocalIP = NetHelper.GetLocalIP();//获取电脑当前本地IP
                        break;
                    }
                case "tabItem_MusicResources":
                    {
                        loadResourcesClassToUi();
                        break;
                    }
                default:
                    {
                        MessageBox.Show(e.NewValue.Name);
                        break;
                    }
            }

        }


        #region 播放资源管理

        #region 工作缓存

        private System.Windows.Forms.BindingSource resourcesClass = new BindingSource();
        private System.Windows.Forms.BindingSource resources = new BindingSource();

        private long _selectResourcesId;
        private string _selectResourceFileName;
        private long _selectResourcesClassId;
        private string _selectResourcesClassDirectory;

        #endregion 工作缓存

        #region 辅助私有方法


        private void loadResourcesClass()
        {
            resourcesClass.DataSource = _dbHelper.GetResourcesClass();
            resourcesClass.DataMember = "Table0";
            resourcesClass.Sort = "ClassAlias";
        }

        private void ResourcesClass_CurrentItemChanged(object sender, EventArgs e)
        {
            if (resourcesClass.Current == null)
            {

            }
        }

        private void Resources_CurrentItemChanged(object sender, EventArgs e)
        {
            if (resources.Current == null)
            {
                btnItem_EditResources.Enabled = false;
                btnItem_DelResources.Enabled = false;
                btnItem_SendToAreasDev.Enabled = false;
            }
        }

        private void loadResourcesForResourcesClass(long resourcesClassId)
        {
            resources.DataSource = _dbHelper.GetResourcesForClass(resourcesClassId);
            resources.DataMember = "Table0";
            resources.Sort = "FileName";
        }

        private bool delTheResources(string filePathName)
        {
            bool isSucceed = false;

            string resourcesPathName = getCurrentClassFullStorageLocation((DataRowView)resourcesClass.Current);

            resourcesPathName = resourcesPathName + "\\" + filePathName;
            try
            {
                DiskDirFileIo.DeleteFile(resourcesPathName);
                _dbHelper.DelTheResource(_selectResourcesId, _selectResourcesClassId);
                isSucceed = true;
            }
            catch (Exception)
            {
                MessageBox.Show("删除失败，此资源可能正被使用！");
            }

            return isSucceed;
        }

        private string getCurrentClassFullStorageLocation(DataRowView rowView)
        {
            string storageLocation = "";
            bool isAbsolutePath = (bool)rowView["IsAbsolutePath"];
            if (isAbsolutePath)
            {
                storageLocation = rowView["StorageLocation"].ToString();
            }
            else
            {
                storageLocation = _applicationPath + rowView["StorageLocation"].ToString();
            }
            return storageLocation;
        }

        #endregion

        #region UI 私有方法

        private void loadResourcesClassToUi()
        {
            loadResourcesClass();//获取数据

            if (resourcesClass != null && advTree_ResourceClass != null)
            {
                advTree_ResourceClass.DataSource = resourcesClass;
                advTree_ResourceClass.DisplayMembers = "ClassAlias";
                advTree_ResourceClass.GroupingMembers = "ClassifyName";

                if (advTree_ResourceClass.Columns.Count > 0)
                    advTree_ResourceClass.Columns[0].Text = "资源分类";
                // comboBoxEx_ResourceClass.DataSource = resourcesClass;
                // comboBoxEx_ResourceClass.DisplayMember = "ClassAlias";
            }
        }

        private void loadResourcesClassInfoToInputUi(DataRowView resourcesClassInfoRow)
        {
            if (resourcesClassInfoRow != null)
            {
                // textBoxX_ResourceClassName.Text = resourcesClassInfoRow["ClassAlias"].ToString();
                //   comboBox_ResourceClassType.SelectedItem = resourcesClassInfoRow["ClassifyName"].ToString().Trim();
                object ob = resourcesClassInfoRow["IsShare"];
                bool isShare = false;
                if (!ob.GetType().Equals(typeof(System.DBNull)))
                {
                    isShare = Convert.ToBoolean(ob);
                }
                //  checkBoxX_IsShareLocation.Checked = isShare;
                ob = resourcesClassInfoRow["ObjectCount"];
                int objectCount = 0;
                if (!ob.GetType().Equals(typeof(System.DBNull)))
                {
                    //     objectCount = ZhiWeiTech.DataHelper.DataTypeConvert.GetTheObjectInt32(ob);
                }
                // label_ResourceClassCount.Text = objectCount.ToString() + " 个项目";
                // bool isAbsolutePath = (bool)resourcesClassInfoRow["IsAbsolutePath"];
                //  if (isAbsolutePath)
                {
                    //      buttonX_OpenResourceClassLoaction.Tag = resourcesClassInfoRow["StorageLocation"].ToString();
                }
                //  else
                {
                    // buttonX_OpenResourceClassLoaction.Tag = _applicationPath + resourcesClassInfoRow["StorageLocation"].ToString();
                }
                // _selectResourcesClassDirectory = buttonX_OpenResourceClassLoaction.Tag.ToString();
                _selectResourcesClassId = (long)resourcesClassInfoRow["RID"];
                //  comboBoxEx_ResourceClass.Tag = _selectResourcesClassId;
            }
        }

        private void loadResourcesForClassToDataGridUi(DataRowView resourcesClassInfoRow)
        {
            long classId = DataHelper.DataTypeConvert.GetTheObjectInt64(resourcesClassInfoRow["RID"]);
            loadResourcesForResourcesClass(classId);
            dataGridViewX_ResourceProject.DataSource = resources;
            setResourcesInfoGridViewColumns();
        }

        private void setResourcesInfoGridViewColumns()
        {
            if (dataGridViewX_ResourceProject.Tag != null)
            {
                return;
            }
            for (int i = 0; i < dataGridViewX_ResourceProject.Columns.Count; i++)
            {
                dataGridViewX_ResourceProject.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                switch (dataGridViewX_ResourceProject.Columns[i].Name)
                {
                    case "RID":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "资源编号";
                            break;
                        }
                    case "FileName":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "资源名称";
                            break;
                        }
                    case "FileType":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "文件类型";
                            break;
                        }
                    case "ImportDate":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "导入日期";

                            break;
                        }
                    case "DurationTime":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "时长";

                            break;
                        }
                    case "ResourceClass":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "分类编号";
                            break;
                        }
                    case "IsExist":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "存在";
                            break;
                        }
                    case "IsUsed":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "已引用";
                            break;
                        }
                    case "UsedCount":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "引用数";
                            break;
                        }
                    default:
                        {
                            dataGridViewX_ResourceProject.Columns[i].Visible = false;
                            break;
                        }
                }
            }
            dataGridViewX_ResourceProject.Tag = true;
        }

        #endregion

        #region 快捷键  **

        #region Click Event

        private void buttItem_AddResourceClass_Click(object sender, EventArgs e)
        {
            ZWGB_ResourceClass resourceClass = new ZWGB_ResourceClass();
            ResourceClassForm addClass = new ResourceClassForm(_applicationPath, _dbHelper, resourceClass);
            if (addClass.ShowDialog(this) == DialogResult.OK)
            {
                loadResourcesClassToUi();
            }
        }

        private void buttItem_EditResourceClass_Click(object sender, EventArgs e)
        {
            //  setResourcesClassInputEnabled(true);

        }

        private void buttItem_DelResourceClass_Click(object sender, EventArgs e)
        {

        }

        private void btnItem_AddResources_Click(object sender, EventArgs e)
        {
            ResourceFilesForm addFilesForm = new ResourceFilesForm(_applicationPath, _dbHelper, resourcesClass);
            var resolt = addFilesForm.ShowDialog(this);
            if (resolt == DialogResult.OK)
            {
                loadResourcesForClassToDataGridUi((DataRowView)resourcesClass.Current);
            }
        }

        private void btnItem_EditResources_Click(object sender, EventArgs e)
        {

        }

        private void btnItem_DelResources_Click(object sender, EventArgs e)
        {
            _selectResourceFileName = ((DataRowView)resources.Current)["FileName"].ToString();
            _selectResourcesId = (long)((DataRowView)resources.Current)["RID"];


            string message = "真的要删除 " + _selectResourceFileName + " 资源文件？";
            string caption = "请选择是否删除信息";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            if (delTheResources(_selectResourceFileName))
            {
                showToastNotice("删除资源成功!", null);
                loadResourcesForClassToDataGridUi((DataRowView)resourcesClass.Current);
            }
            else
            {
                showToastNotice("删除资源设备!可能正被使用。", null);
            }
        }

        private void btnItem_RefreshResources_Click(object sender, EventArgs e)
        {

        }

        private void btnItem_SendToAreasDev_Click(object sender, EventArgs e)
        {

        }

        private void advTree_ResourceClass_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            loadResourcesClassInfoToInputUi((DataRowView)resourcesClass.Current);
            loadResourcesForClassToDataGridUi((DataRowView)resourcesClass.Current);

            btnItem_AddResources.Enabled = true;//允许添加资源
            this.btnItem_RefreshResources.Enabled = true;//允许刷新资源
        }

        private void advTree_ResourceClass_DataSourceChanged(object sender, EventArgs e)
        {
            btnItem_EditResources.Enabled = false;
            btnItem_DelResources.Enabled = false;
        }

        private void dataGridViewX_ResourceProject_DataSourceChanged(object sender, EventArgs e)
        {
            btnItem_EditResources.Enabled = false;
            btnItem_DelResources.Enabled = false;

        }

        private void dataGridViewX_ResourceProject_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            btnItem_EditResources.Enabled = true;
            btnItem_DelResources.Enabled = true;
            btnItem_SendToAreasDev.Enabled = true;
        }


        #endregion Click Event

        #endregion 快捷键  **

        #endregion 播放资源管理

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


        #region 设备通信模块

        // 发送UDP消息
        private void UdpSendString(IPEndPoint toPoint, string msg)
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                // 启动发送消息
                byte[] messagebytes = Encoding.UTF8.GetBytes(msg);

                using (var sendUdpClient = new UdpClient())
                {
                    try
                    {
                        // 发送消息
                        sendUdpClient.Send(messagebytes, messagebytes.Length, toPoint);
                    }
                    catch (Exception ex)
                    {

                    }
                    sendUdpClient.Close();
                }
            });
        }

        // 发送UDP消息
        private void UdpSendByte(IPEndPoint toPoint, byte[] msg)
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                // 启动发送消息
                using (var sendUdpClient = new UdpClient())
                {
                    // 发送消息
                    int state = sendUdpClient.Send(msg, msg.Length, toPoint);

                    sendUdpClient.Close();
                }
            });
        }

        private void UdpSendStringWaitCallback(IPEndPoint toPoint, string msg, double interval, System.Timers.ElapsedEventHandler callBack)
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                // 启动发送消息
                byte[] messagebytes = Encoding.UTF8.GetBytes(msg);

                using (var sendUdpClient = new UdpClient())
                {
                    // 发送消息
                    int state = sendUdpClient.Send(messagebytes, messagebytes.Length, toPoint);

                    sendUdpClient.Close();

                    System.Timers.Timer timer = new System.Timers.Timer();
                    timer.AutoReset = false;
                    timer.Interval = 1000;
                    timer.Elapsed += callBack;
                    timer.Start();
                }
            });
        }



        #endregion 设备通信模块


        #region 设备管理

        #region 缓存

        private string currentLocalIP = "";

        private udpReceiver udp65000 = new udpReceiver();

        private udpReceiver udp65005 = new udpReceiver();

        private ClientAsync tcpClient;

        /// <summary>
        /// 搜索设备发布信息组播地址端
        /// </summary>
        private IPEndPoint searchDevGroupPoint = new IPEndPoint(IPAddress.Parse("224.1.1.1"), 65000);

        private int UdpRceivePort65000 = 65000;
        private int UdpRceivePort65005 = 65005;

        private List<deviceInfo> DeviceList;//设备列表
        private BindingList<deviceInfo> BindDeviceList;

        private ChangeDevIPData CurrentDev;
        private deviceInfo selectDevice;//用户在设备列表里选定的设备信息缓存

        public delegate void ChangeDevIpHandler(string currentIP, ChangeDevIPData param);

        #endregion 缓存

        #region 私有方法

        private void loadAllStoregDev()
        {
            DeviceList = _dbHelper.LoadAllStoredDevices();
        }

        private void Udp65000_ReceivedSearch(IPAddress arg1, byte[] arg2, string arg3)
        {
            bool ex = false;
            deviceInfo oneDev = JsonConvert.DeserializeObject<deviceInfo>(arg3);
            oneDev.IsOnLine = true;
            oneDev.IsMulticastTo = true;
            foreach (var one in BindDeviceList)
            {
                if (one.SN == oneDev.SN)
                {
                    one.IsMulticastTo = true;
                    one.IsOnLine = true;
                    one.IPV4 = oneDev.IPV4;
                    one.AliasName = oneDev.AliasName;
                    one.IsDHCP = oneDev.IsDHCP;
                    one.SoftwareVersion = oneDev.SoftwareVersion;
                    _dbHelper.UpdateDeviceInfo(one);
                    ex = true;
                    break;
                }
            }

            if (this.dGrid_devList.IsHandleCreated && !ex && oneDev.SN.Length > 0)
                this.dGrid_devList.BeginInvoke(new Action(delegate
                {
                    //发送到UI 线程执行的代码
                    _dbHelper.AddDeviceInfo(oneDev);
                    BindDeviceList.Add(oneDev);
                    this.dGrid_devList.Refresh();
                }));

        }

        private void DGrid_devList_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dGrid_devList.Columns.Count; i++)
            {
                dGrid_devList.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                switch (dGrid_devList.Columns[i].Name)
                {
                    case "AliasName":
                        {
                            dGrid_devList.Columns[i].HeaderText = "设备别名";
                            break;
                        }
                    case "Type":
                        {
                            dGrid_devList.Columns[i].HeaderText = "设备类别";
                            break;
                        }
                    case "HardwareVersion":
                        {
                            dGrid_devList.Columns[i].HeaderText = "硬件版本";
                            break;
                        }
                    case "SoftwareVersion":
                        {
                            dGrid_devList.Columns[i].HeaderText = "软件版本";
                            break;
                        }
                    case "SN":
                        {
                            dGrid_devList.Columns[i].HeaderText = "序列号SN";
                            break;
                        }
                    case "IsDHCP":
                        {
                            dGrid_devList.Columns[i].HeaderText = "自动获取IP";
                            break;
                        }
                    case "IPV4":
                        {
                            dGrid_devList.Columns[i].HeaderText = "IP地址IPV4";
                            break;
                        }
                    case "IsOnLine":
                        {
                            dGrid_devList.Columns[i].HeaderText = "是否在线";
                            break;
                        }
                    case "IsMulticastTo":
                        {
                            dGrid_devList.Columns[i].HeaderText = "是否组可达";
                            break;
                        }
                    case "TaskStatus":
                        {
                            dGrid_devList.Columns[i].HeaderText = "任务状态";
                            break;
                        }
                    case "SpeakBusy":
                        {
                            dGrid_devList.Columns[i].HeaderText = "语音状态";
                            break;
                        }
                    case "MonitorStatus":
                        {
                            dGrid_devList.Columns[i].HeaderText = "监听状态";
                            break;
                        }

                    case "ModeStr":
                        {
                            dGrid_devList.Columns[i].HeaderText = "设备型号";
                            break;
                        }
                    default:
                        {
                            dGrid_devList.Columns[i].Visible = false;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 检查设备是否在线，TCP方法
        /// </summary>
        private void checkDeviceOnlineTcp()
        {
            tcpClient = new ClientAsync();

            tcpClient.Completed += new Action<TcpClient, EnSocketAction>((c, enAction) =>
            {
                switch (enAction)
                {
                    case EnSocketAction.ConnectTimeOut:
                        {
                            showToastNotice("连接设备超时！", null);
                            break;
                        }
                    case EnSocketAction.Connect:
                        {
                            //   var localIP =NetHelper. GetLocalIP();//获取电脑当前本地IP

                            SearchCmd cmd = new SearchCmd("SearchDev", currentLocalIP);
                            var searchCMD = JsonConvert.SerializeObject(cmd);
                            tcpClient.SendAsync(searchCMD);
                            break;
                        }
                }
            });

            tcpClient.Received += new Action<string, string>((key, msg) =>
            {
                if (msg.Contains("SoftwareVersion"))
                {
                    bool ex = false;
                    deviceInfo result = JsonConvert.DeserializeObject<deviceInfo>(msg);
                    result.IsOnLine = true;
                    result.IsMulticastTo = false;
                    foreach (var one in BindDeviceList)
                    {
                        if (one.SN == result.SN)
                        {
                            one.IsOnLine = true;
                            one.IsMulticastTo = false;
                            ex = true;
                            break;
                        }
                    }

                    if (this.dGrid_devList.IsHandleCreated && !ex && result.SN.Length > 0)
                        this.dGrid_devList.BeginInvoke(new Action(delegate
                        {
                            //发送到UI 线程执行的代码
                            result.IsOnLine = true;
                            result.IsMulticastTo = false;
                            BindDeviceList.Add(result);
                        }));
                }
            });
        }

        private void dGrid_devList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DeviceList.Count > 0)
                selectDevice = DeviceList[e.RowIndex];
        }

        private void ChangeDevIpMethod(string currentIP, ChangeDevIPData param)
        {
            try
            {
                System.Timers.ElapsedEventHandler callBack = (Object o, System.Timers.ElapsedEventArgs a) =>
                {
                    showToastNotice("修改配置命令已发出，请40秒后[搜索设备]以获取更改.", null,eToastPosition.MiddleCenter,8);
                };
                string cmdStr = JsonConvert.SerializeObject(param);
                UdpSendStringWaitCallback(new IPEndPoint(IPAddress.Parse(currentIP), 65000), cmdStr, 1000, callBack);
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改网络参数发生错误：" + ex.Message);
            }
        }

        #endregion 私有方法

        #region 快捷键

        private void btnItem_SearchDevice_Click(object sender, EventArgs e)
        {
            btnItem_SearchDevice.Enabled = false;
            CurrentDev = null;//清除设置设备ip命令标志
                              // var localIP = NetHelper.GetLocalIP();//获取电脑当前本地IP

            SearchCmd cmd = new SearchCmd("SearchDev", currentLocalIP);
            var searchCMD = JsonConvert.SerializeObject(cmd);

            udp65000 = new udpReceiver();
            udp65000.Received -= Udp65000_ReceivedSearch;
            udp65000.Received += Udp65000_ReceivedSearch;

            // 创建
            IPAddress localIp = IPAddress.Parse(currentLocalIP);//选定当前系统的IP
            udp65000.StartUdpReceive(localIp, UdpRceivePort65000);
            System.Timers.ElapsedEventHandler callBack = (Object o, System.Timers.ElapsedEventArgs a) =>
            {
                udp65000.Close();
                btnItem_SearchDevice.Enabled = true;
            };
            UdpSendStringWaitCallback(searchDevGroupPoint, searchCMD, 1000, callBack);
        }

        private void btnItem_AddDevice_Click(object sender, EventArgs e)
        {
            tcpClient = new ClientAsync();
            checkDeviceOnlineTcp();
            AddDeviceForm addForm = new AddDeviceForm(tcpClient);
            DialogResult result = addForm.ShowDialog(this);
        }

        private void btnItem_DelDevice_Click(object sender, EventArgs e)
        {
            if (selectDevice != null)
            {
                string message = "真的要删除设备：" + selectDevice.AliasName + " 地址:" + selectDevice.IPV4 + " 的信息？";
                string caption = "请选择是否删除设备信息";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // 操作
                    BindDeviceList.Remove(selectDevice);
                    _dbHelper.DelDeviceInfo(selectDevice.SN);
                }
            }
        }

        private void btnItem_SettingDevice_Click(object sender, EventArgs e)
        {
            if (selectDevice != null)
            {

                DeviceSettingsForm setForm = new DeviceSettingsForm(selectDevice, ChangeDevIpMethod);
                setForm.ShowDialog(this);
            }
        }


        #endregion 快捷键

        #region Click

        #endregion

        #endregion 设备管理



        private void buttonX1_Click(object sender, EventArgs e)
        {
            udp65000 = new udpReceiver();
            udp65000.Received -= Udp65000_Received;
            udp65000.Received += Udp65000_Received;

            //判断IP是否有效
            string currentLocalIPV4 = NetHelper.GetLocalIP();
            // 创建接收套接字
            IPAddress localIp = IPAddress.Parse(currentLocalIPV4);//选定当前系统的IP

            //  udp65000.StartUdpReceive(localIp, integerInput1.Value);

        }

        private void Udp65000_Received(System.Net.IPAddress arg1, byte[] arg2, string arg3)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            udp65000.Close();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse("192.168.10.149");
            IPEndPoint point = new IPEndPoint(ip, 65000);

            System.Timers.ElapsedEventHandler callBack = (Object o, System.Timers.ElapsedEventArgs a) =>
            {
                MessageBox.Show("shijiandao");
            };
            //UdpSendString(point, "你好");
            UdpSendStringWaitCallback(point, "Hello", 1000, callBack);
        }




    }
}
