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
using System.Windows.Forms;
using ZW_GBwin.Model;

namespace ZW_GBwin
{
    public partial class ResourceClassForm : MetroForm
    {
        ZWGB_ResourceClass _resourceClass;
        string _applicationPath = "";
        DbDataService _dbHelper;

        public ResourceClassForm(string applicationPath, DbDataService dbHelper, ZWGB_ResourceClass resourceClass)
        {
            InitializeComponent();

            _resourceClass = resourceClass;
            _applicationPath = applicationPath;
            _dbHelper = dbHelper;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_ResourceClassName.Text.Length < 1)
            {
                txt_ResourceClassName.Focus();
                return;
            }
            if (cobx_ResourceClassType.SelectedIndex < 0)
            {
                cobx_ResourceClassType.Focus();
                return;
            }
            string path = "";
            if (!chec_IsShareLocation.Checked)
            {
                path = getResourcesClassPath(cobx_ResourceClassType.SelectedItem.ToString(), txt_ResourceClassName.Text);
            }
            else
            {
                path = btn_OpenResourceClassLoaction.Tag.ToString();
                if (String.IsNullOrEmpty(path))
                {
                    btn_OpenResourceClassLoaction.Focus();
                    showToastNotice("请选择要引用的既有共享资源位置!", null);
                    return;
                }
            }
            bool isSucceed = _dbHelper.AddResourcesClass(cobx_ResourceClassType.SelectedItem.ToString(), txt_ResourceClassName.Text, path, 0, chec_IsShareLocation.Checked, chec_IsShareLocation.Checked);
            if (isSucceed)
            {
                path = chec_IsShareLocation.Checked ? path : _applicationPath + path;
                DiskDirFileIo.CreateDir(path);
               // showToastNotice("添加资源分类成功!", null);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                showToastNotice("添加资源分类失败!", null);
            }
        }

        private string getResourcesClassPath(string classifyName, string classAlias)
        {
            string path = @"\Playback File Resource";
            switch (classifyName)
            {
                case "音乐":
                    {
                        path += @"\Music files\" + classAlias;
                        break;
                    }
                case "故事":
                    {
                        path += @"\Story files\" + classAlias;
                        break;
                    }
                default:
                    {
                        path += @"\Composite files\" + classAlias;
                        break;
                    }
            }
            return path;
        }

        private void btn_OpenResourceClassLoaction_Click(object sender, EventArgs e)
        {
            if (btn_OpenResourceClassLoaction.Tag != null)
            {
                System.Diagnostics.Process.Start("Explorer.exe", btn_OpenResourceClassLoaction.Tag.ToString());
            }
            else
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择文件路径";
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    btn_OpenResourceClassLoaction.Tag = dialog.SelectedPath;
                }
            }
        }

        private void chec_IsShareLocation_CheckedChanged(object sender, EventArgs e)
        {
            btn_OpenResourceClassLoaction.Enabled = chec_IsShareLocation.Checked;
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
