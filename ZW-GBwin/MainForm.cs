using DataHelper;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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


        #endregion Click Event

        #endregion 快捷键  **

        #endregion 播放资源管理


        private void superTabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {
            switch (e.NewValue.Name)
            {
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






        private void showToastNotice(string msg, Image img, eToastPosition position = eToastPosition.BottomRight, int scenes = 3, eToastGlowColor color = eToastGlowColor.Blue)
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


    }
}
