using DataHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZW_GBwin
{
    public partial class AreaAddDevForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        List<deviceInfo> _devList;
        List<deviceInfo> _addedDevList;


        public AreaAddDevForm( List<deviceInfo> devList, List<deviceInfo> addedDevList)
        {
            InitializeComponent();

            _devList = devList;
            _addedDevList = addedDevList;

        }

        private void AreaAddDevForm_Load(object sender, EventArgs e)
        {
            listBox_device.DataSource = _devList;
            listBox_device.DisplayMember = "AliasName";

            listBox_AddDevice.DataSource = _addedDevList;
            listBox_AddDevice.DisplayMember = "AliasName";
        }

        private void listBox_device_ItemClick(object sender, EventArgs e)
        {

        }

        private void listBox_device_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            _addedDevList.Add(_devList[listBox_device.SelectedIndex]);
            _devList.RemoveAt(listBox_device.SelectedIndex);

            listBox_AddDevice.RefreshItems();

            if(_devList.Count>0)
            {
                listBox_device.RefreshItems();
            }
            else
            {
                try
                {
                    listBox_device.Items.Clear();
                }
                catch
                {

                }
            }
        }

        private void listBox_AddDevice_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            _devList.Add(_addedDevList[listBox_AddDevice.SelectedIndex]);
            _addedDevList .RemoveAt(listBox_AddDevice.SelectedIndex);

            listBox_device.RefreshItems();

            if (_addedDevList.Count > 0)
            {
                listBox_AddDevice.RefreshItems();
            }
            else
            {
                try
                {
                    listBox_AddDevice.Items.Clear();
                }
                catch
                {

                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
