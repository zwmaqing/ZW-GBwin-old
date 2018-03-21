using DataHelper;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ZW_GBwin
{
    public partial class ResourceFilesForm : MetroForm
    {
        string _applicationPath = "";
        DbDataService _dbHelper;
        BindingSource _resourcesClass;

        long _selectResourcesClassId;

        public ResourceFilesForm(string applicationPath, DbDataService dbHelper, BindingSource resourcesClass)
        {
            InitializeComponent();

            _applicationPath = applicationPath;
            _dbHelper = dbHelper;

            _resourcesClass = resourcesClass;
        }

        private void ResourceFilesForm_Load(object sender, EventArgs e)
        {
            if (_resourcesClass != null)
            {
                _selectResourcesClassId = DataTypeConvert.GetTheObjectInt64(((DataRowView)_resourcesClass.Current)["RID"]);
                comboBoxEx_ResourceClass.Tag = _selectResourcesClassId;
            }

            comboBoxEx_ResourceClass.DataSource = _resourcesClass;
            comboBoxEx_ResourceClass.DisplayMember = "ClassAlias";
        }

        private void buttonX_OpenResourceLoaction_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "请选择要导入的音乐文件";
            openFileDialog1.Filter = "mp3 MusicFile (*.mp3)|*.mp3|wav  MusicFile (*.wmv)|*.wmv|wma MusicFile (*.wma)|*.wma";
            DialogResult _result = openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK && openFileDialog1.FileNames.Length > 0)
            {
                buttonX_SaveResource.Tag = "Add";
                textBoxX_ResourceName.Tag = openFileDialog1.FileNames;
                if (openFileDialog1.FileNames.Length > 1)
                {
                    textBoxX_ResourceName.Text = "选择了" + openFileDialog1.FileNames.Length + " 个音乐文件";
                }
                else
                {
                    textBoxX_ResourceName.Text = Path.GetFileName(openFileDialog1.FileNames[0]);
                }
            }
        }

        private void buttonX_SaveResource_Click(object sender, EventArgs e)
        {
            circularProgress_AddResource.IsRunning = true;
            saveTheResourcesUserChanged();

            buttonX_OpenResourceLoaction.Enabled = false;
            buttonX_SaveResource.Enabled = false;
            buttonX_CancelResource.Enabled = false;
        }

        private void buttonX_CancelResource_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool saveTheResourcesUserChanged()
        {
            bool isSucceed = false;
            DataRowView resourcesClassCurrent = (DataRowView)_resourcesClass.Current;
            long oldResourcesClassId = DataHelper.DataTypeConvert.GetTheObjectInt64(comboBoxEx_ResourceClass.Tag);
            long newResourcesClassId = DataHelper.DataTypeConvert.GetTheObjectInt64(resourcesClassCurrent["RID"]);
            string oldResourcesPath = "";
            string newResourcesPath = "";
            if (oldResourcesClassId != newResourcesClassId)
            {
                // oldResourcesPath = buttonX_OpenResourceClassLoaction.Tag.ToString();
                //  newResourcesPath = getCurrentClassFullStorageLocation(resourcesClassCurrent);
            }
            else
            {
                newResourcesPath = getCurrentClassFullStorageLocation(resourcesClassCurrent);
                oldResourcesPath = newResourcesPath;
            }
            string operType = DataHelper.DataTypeConvert.GetTheObjectString(buttonX_SaveResource.Tag);
            switch (operType)
            {
                case "Edit":
                    {
                        string oldResourcesName = textBoxX_ResourceName.Tag.ToString();
                        string newResourcesName = textBoxX_ResourceName.Text;
                        oldResourcesPath = oldResourcesPath + "\\" + oldResourcesName;
                        newResourcesPath = newResourcesPath + "\\" + newResourcesName;
                        if (oldResourcesPath.Trim() != newResourcesPath.Trim())
                        {
                            try
                            {
                                // DiskDirFileIo.MoveFile(oldResourcesPath.Trim(), newResourcesPath.Trim());
                                //  _dbHelper.ChangeResourceClass(_selectResourcesId, oldResourcesClassId, newResourcesClassId);
                                isSucceed = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("修改失败，此资源可能正被使用！" + ex.Message);
                            }
                        }
                        else
                        {
                            isSucceed = true;
                        }
                        break;
                    }
                case "Add":
                    {
                        if (textBoxX_ResourceName.Tag != null)
                        {
                            Thread moveFiles = new Thread(addFiles);
                            moveFiles.IsBackground = true;
                            moveFiles.Start(newResourcesPath);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return isSucceed;
        }

        private void addFiles(object stata)
        {
            string newResourcesPath = (string)stata;
            try
            {
                string[] filesName = (string[])textBoxX_ResourceName.Tag;
                if (filesName != null && filesName.Length > 0)
                {
                    for (int i = 0; i < filesName.Length; i++)
                    {
                        string fileName = Path.GetFileName(filesName[i]);
                        string newResourcesPathName = newResourcesPath + "\\" + fileName;
                        DiskDirFileIo.CopyFile(filesName[i], newResourcesPathName);

                        string mediaTimeLen = MediaFileHelper.GetMediaTimeLen(newResourcesPathName);
                        string mediaType = Path.GetExtension(newResourcesPathName);
                        _dbHelper.AddResource(fileName, mediaType, mediaTimeLen, _selectResourcesClassId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败，此资源可能正被使用！" + ex.Message);
            }

            circularProgress_AddResource.IsRunning = false;
            this.DialogResult = DialogResult.OK;
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
