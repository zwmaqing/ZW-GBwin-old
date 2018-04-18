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
    public partial class ChannelGroupForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        CHGroup _group;
        public ChannelGroupForm(CHGroup group)
        {
            InitializeComponent();

            _group = group;
        }

        private void ChannelGroupForm_Load(object sender, EventArgs e)
        {
            listBox_PlayDeviceChannels.Items.Clear();
            for (int i = 1; i < 17; i++)
            {
                listBox_PlayDeviceChannels.Items.Add(i + " 号 输出分区通道");
            }

            loadPlayDeviceInfoToInputUi(_group);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (textBoxX_CHGroupName.Text.Length < 1)
            {
                textBoxX_CHGroupName.Focus();
                return;
            }
            _group.ChannelList = getSelectPlayDeviceChannels().ToArray();
            if (_group.ChannelList.Length < 1)
            {
                MessageBox.Show("需要现在该分组包含的分区！");
                return;
            }
            _group.GroupName = textBoxX_CHGroupName.Text;
            this.DialogResult = DialogResult.OK;
        }

        private List<int> getSelectPlayDeviceChannels()
        {
            List<int> channels = new List<int>();
            for (int i = 0; i < listBox_PlayDeviceChannels.Items.Count; i++)
            {
                if (listBox_PlayDeviceChannels.GetItemChecked(i))
                {
                    channels.Add(i + 1);
                }
            }
            return channels;
        }

        private void loadPlayDeviceInfoToInputUi(CHGroup group)
        {
            textBoxX_CHGroupName.Text = group.GroupName;
            if (group.ChannelList != null)
                foreach (int chanael in group.ChannelList)
                {
                    if (chanael < 17)
                    {
                        listBox_PlayDeviceChannels.SetItemChecked(chanael - 1, true);
                    }
                }
        }
    }
}
