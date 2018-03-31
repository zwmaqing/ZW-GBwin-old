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
            loadAllDevFromDB();//加载已存储的设备信息
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
                case "tabItem_ChannlsGroup":
                    {
                        loadAreaMenustrip(advTree_Area);
                        loadAllAreaAndDeviceToTree();
                        break;
                    }
                default:
                    {
                        // MessageBox.Show(e.NewValue.Name);
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

        private void loadAllDevFromDB()
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
                    if (oneDev.Type == "IPCHPOWER")
                    {
                        oneDev.Channals = 16;
                    }
                    else
                    {
                        oneDev.Channals = 1;
                    }
                    oneDev.AreaID = 0;
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
            if (DeviceList.Count > 0 && e.RowIndex > -1)
                selectDevice = DeviceList[e.RowIndex];
        }

        private void ChangeDevIpMethod(string currentIP, ChangeDevIPData param)
        {
            try
            {
                System.Timers.ElapsedEventHandler callBack = (Object o, System.Timers.ElapsedEventArgs a) =>
                {
                    showToastNotice("修改配置命令已发出，请40秒后[搜索设备]以获取更改.", null, eToastPosition.MiddleCenter, 8);
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


        #region 区域管理

        #region 缓存

        DevComponents.AdvTree.Node _selectedAreaNode;

        private List<ZWGB_Area> allArea;//区域数据缓存



        #endregion 缓存

        #region 私有方法

        private void loadAreaMenustrip(Control Control)
        {
            ContextMenuStrip ms = new ContextMenuStrip();
            ms.Items.Add("添加子区域");
            ms.Items.Add("修改区域名");
            ms.Items.Add("添加设备");
            ms.Items.Add("移除该设备");
            ms.Items.Add("添加分区设备组");//4
            ms.Items.Add("修改分区设备组");//5
            ms.Items.Add("删除分区设备组");//6
            ms.BackColor = System.Drawing.SystemColors.ControlDark;
            ms.Opening += Ms_Opening;
            ms.ItemClicked += new ToolStripItemClickedEventHandler(ms_AreaClicked);

            ms.Items[0].Image = this.imageList1.Images["group_32_Add"];
            ms.Items[1].Image = this.imageList1.Images["group_32_Edit"];
            ms.Items[2].Image = this.imageList1.Images["SoundAdd_net_32"];
            ms.Items[3].Image = this.imageList1.Images["soundDelete_net_32"];

            ms.Items[4].Image = this.imageList1.Images["group_32_Add"];

            ms.Items[5].Image = this.imageList1.Images["group_32_Edit"];

            ms.Items[6].Image = this.imageList1.Images["group_32_Del"];
            Control.ContextMenuStrip = ms;
        }

        private void Ms_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip contextMenu = (ContextMenuStrip)sender;
            contextMenu.Items[0].Enabled = false;
            contextMenu.Items[1].Enabled = false;
            contextMenu.Items[2].Enabled = false;
            contextMenu.Items[3].Enabled = false;
            contextMenu.Items[4].Enabled = false;
            contextMenu.Items[5].Enabled = false;
            contextMenu.Items[6].Enabled = false;

            // showToastNotice("selectedAreaNode"+ advTree_Area.SelectedNode.Text, null, eToastPosition.BottomCenter, 1);
            _selectedAreaNode = advTree_Area.SelectedNode;

            if (_selectedAreaNode != null)
            {
                if (_selectedAreaNode.Tag.GetType() == typeof(deviceInfo))
                {
                    contextMenu.Items[0].Enabled = false;
                    contextMenu.Items[1].Enabled = false;
                    contextMenu.Items[2].Enabled = false;

                    contextMenu.Items[3].Enabled = true;
                    deviceInfo theDev = (deviceInfo)_selectedAreaNode.Tag;
                    if (theDev.Type == "IPCHPOWER")
                    {
                        contextMenu.Items[4].Enabled = true;
                    }
                }
                if (_selectedAreaNode.Tag.GetType() == typeof(ZWGB_Area))
                {
                    contextMenu.Items[0].Enabled = true;
                    contextMenu.Items[1].Enabled = true;
                    contextMenu.Items[2].Enabled = true;
                }
                if (_selectedAreaNode.Tag.GetType() == typeof(int))
                {
                    int groupID = (int)_selectedAreaNode.Tag;
                    if (groupID > 100)
                    {
                        contextMenu.Items[5].Enabled = true;
                        contextMenu.Items[6].Enabled = true;
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ms_AreaClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip contextMenu = (ContextMenuStrip)sender;

            switch (e.ClickedItem.Text)
            {
                case "添加子区域":
                    {
                        ZWGB_Area newArea = new Model.ZWGB_Area();
                        ZWGB_Area perentArea = (ZWGB_Area)_selectedAreaNode.Tag;
                        newArea.ParentAreaID = perentArea.AreaID;
                        if (new AreaForm(newArea).ShowDialog() == DialogResult.OK)
                        {
                            _dbHelper.AddAreaInfo(newArea);
                            DevComponents.AdvTree.Node tempNode = new DevComponents.AdvTree.Node();
                            tempNode.Text = newArea.AreaName;
                            tempNode.Tag = newArea;
                            _selectedAreaNode.Nodes.Add(tempNode);
                        }

                        break;
                    }
                case "修改区域名":
                    {
                        ZWGB_Area theArea = (ZWGB_Area)_selectedAreaNode.Tag;
                        if (theArea.AreaID < 2)
                        {
                            showToastNotice("不能编辑此默认区域.", null, eToastPosition.MiddleCenter, 2);
                            return;
                        }
                        if (new AreaForm(theArea).ShowDialog() == DialogResult.OK)
                        {
                            _dbHelper.UpdateAreaInfo(theArea);
                            _selectedAreaNode.Text = theArea.AreaName;
                        }
                        break;
                    }
                case "添加设备":
                    {

                        break;
                    }
                case "移除该设备":
                    {

                        break;
                    }
                case "添加分区设备组":
                    {

                        break;
                    }
                case "修改分区设备组":
                    {

                        break;
                    }
                case "删除分区设备组":
                    {

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void loadAllAreaAndDeviceToTree()
        {
            loadAllDevFromDB();//加载存储的设备
            allArea = _dbHelper.LoadAllArea();//读取所有的区域数据
            advTree_Area.Nodes.Clear();
            if (allArea == null || allArea.Count == 0)
            {
                allArea.Add(new Model.ZWGB_Area { AreaName = "默认区域", AreaID = 1, ParentAreaID = 0 });
            }

            var treeNodes = new List<DevComponents.AdvTree.Node>();
            DevComponents.AdvTree.Node theNode;
            //加载根节点
            var rootNodes = allArea.FindAll(x => x.ParentAreaID == 0);
            foreach (var oneRoot in rootNodes)
            {
                theNode = new DevComponents.AdvTree.Node();
                theNode.Text = oneRoot.AreaName;
                theNode.Tag = oneRoot;
                theNode.DragDropEnabled = false;
                var dev = DeviceList.FindAll(x => x.AreaID == oneRoot.AreaID);
                if (dev != null && dev.Count > 0)
                {
                    loadDeviceToAreaNode(theNode, dev);//加载此区域下的设备节点
                }
                treeNodes.Add(theNode);
                advTree_Area.Nodes.Add(theNode);
            }


            while (treeNodes.Count > 0)
            {
                theNode = treeNodes[0];
                //每次循环都去掉第一个结点，下次循环就是第二个结点
                treeNodes.Remove(theNode);
                var childNodes = allArea.FindAll(x => x.ParentAreaID == ((ZWGB_Area)theNode.Tag).AreaID);

                for (int i = 0; i < childNodes.Count; i++)
                {
                    DevComponents.AdvTree.Node tempNode = new DevComponents.AdvTree.Node();
                    tempNode.Text = childNodes[i].AreaName;
                    tempNode.Tag = childNodes[i];

                    var dev = DeviceList.FindAll(x => x.AreaID == childNodes[i].AreaID);
                    if (dev != null && dev.Count > 0)
                    {
                        loadDeviceToAreaNode(tempNode, dev);//加载此区域下的设备节点
                    }

                    treeNodes.Add(tempNode);
                    theNode.Nodes.Add(tempNode);
                }
            }

        }

        /// <summary>
        /// 将区域下的设备加载
        /// </summary>
        /// <param name="theNode"></param>
        /// <param name="devList"></param>
        private void loadDeviceToAreaNode(DevComponents.AdvTree.Node theNode, List<deviceInfo> devList)
        {
            foreach (var oneDev in devList)
            {
                DevComponents.AdvTree.Node theDevNode = new DevComponents.AdvTree.Node();
                theDevNode.Text = oneDev.AliasName;
                theDevNode.Tag = oneDev;

                if (oneDev.Type == "IPCHPOWER")
                {
                    theDevNode.ImageIndex = 2;
                    //加载物理分区；
                    for (int i = 1; i <= oneDev.Channals; i++)
                    {
                        DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                        node.Text = "第 " + i + " 分区";
                        node.Tag = i;
                        node.ImageIndex = 12;
                        theDevNode.Nodes.Add(node);
                    }
                    //加载分区组；

                }
                if (oneDev.Type == "IPTRUMPET")
                {
                    theDevNode.ImageIndex = 1;
                }
                theNode.Nodes.Add(theDevNode);
            }
        }

        #endregion 私有方法

        #region Click

        private void btnItem_AddArea_Click(object sender, EventArgs e)
        {
            ZWGB_Area newArea = new Model.ZWGB_Area();
            newArea.ParentAreaID = 1;
            if (new AreaForm(newArea).ShowDialog() == DialogResult.OK)
            {
                _dbHelper.AddAreaInfo(newArea);
                DevComponents.AdvTree.Node tempNode = new DevComponents.AdvTree.Node();
                tempNode.Text = newArea.AreaName;
                tempNode.Tag = newArea;
                advTree_Area.Nodes.Add(tempNode);
            }
        }

        private void btnItem_EditArea_Click(object sender, EventArgs e)
        {
            _selectedAreaNode = advTree_Area.SelectedNode;
            if (_selectedAreaNode.Tag.GetType() == typeof(ZWGB_Area))
            {
                ZWGB_Area theArea = (ZWGB_Area)_selectedAreaNode.Tag;
                if (theArea.AreaID < 2)
                {
                    showToastNotice("不能编辑此默认区域.", null, eToastPosition.MiddleCenter, 2);
                    return;
                }
                if (new AreaForm(theArea).ShowDialog() == DialogResult.OK)
                {
                    _dbHelper.UpdateAreaInfo(theArea);
                    _selectedAreaNode.Text = theArea.AreaName;
                }
            }
        }

        private void btnItem_DelArea_Click(object sender, EventArgs e)
        {
            _selectedAreaNode = advTree_Area.SelectedNode;
            if (_selectedAreaNode.Tag.GetType() == typeof(ZWGB_Area))
            {
                ZWGB_Area theArea = (ZWGB_Area)_selectedAreaNode.Tag;
                if (theArea.AreaID < 2)
                {
                    showToastNotice("不能删除此默认区域.", null, eToastPosition.MiddleCenter, 2);
                    return;
                }
                if (_selectedAreaNode.Nodes.Count > 0)
                {
                    showToastNotice("请先删除子节点！再删除此区域.", null, eToastPosition.MiddleCenter, 2);
                    return;
                }

                if (_dbHelper.DelTheAreaInfo(theArea.AreaID))
                {
                    _selectedAreaNode.Parent.Nodes.Remove(_selectedAreaNode);
                }
            }
        }

        private void advTree_Area_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Node != null && e.Node.Tag.GetType() == typeof(ZWGB_Area))
            {
                btnItem_EditArea.Enabled = true;
                btnItem_DelArea.Enabled = true;
            }
        }

        private void advTree_Area_Click(object sender, EventArgs e)
        {
            //_selectedAreaNode = null;

            btnItem_EditArea.Enabled = false;
            btnItem_DelArea.Enabled = false;
        }


        private void advTree_Area_BeforeNodeInsert(object sender, DevComponents.AdvTree.TreeNodeCollectionEventArgs e)
        {
            //  showToastNotice("BeforeNodeInsert", null, eToastPosition.BottomCenter, 1);
        }


        private void advTree_Area_BeforeNodeDragStart(object sender, DevComponents.AdvTree.AdvTreeNodeCancelEventArgs e)
        {
            //分区节点不能拖动
            if (e.Node.Tag.GetType() == typeof(int))
            {
                e.Cancel = true;
            }
        }

        private void advTree_Area_BeforeNodeDrop(object sender, DevComponents.AdvTree.TreeDragDropEventArgs e)
        {
            //父节点是设备的，不接受拖入
            Type parentType = e.NewParentNode.Tag.GetType();
            if (parentType == typeof(deviceInfo) || parentType == typeof(int))
            {
                e.Cancel = true;
            }
            else
            {
                ZWGB_Area parentArea = (ZWGB_Area)e.NewParentNode.Tag;

                Type nodeType = e.Node.Tag.GetType();
                if (nodeType == typeof(deviceInfo))
                {
                    var theDev = (deviceInfo)e.Node.Tag;
                    //更新区域ID
                    theDev.AreaID = parentArea.AreaID;
                    _dbHelper.UpdateDeviceInfo(theDev);
                }
                if (nodeType == typeof(ZWGB_Area))
                {
                    var theArea = (ZWGB_Area)e.Node.Tag;
                    //更新父区域ID
                    theArea.ParentAreaID = parentArea.AreaID;
                    _dbHelper.UpdateAreaInfo(theArea);
                }
            }
        }

        #endregion Click

        #endregion 区域管理

        private void Udp65000_Received(System.Net.IPAddress arg1, byte[] arg2, string arg3)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            udp65000.Close();
        }


    }
}
