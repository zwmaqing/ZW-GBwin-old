using DataHelper;
using DevComponents.DotNetBar.Metro;
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
    public partial class DeviceSettingsForm : MetroForm
    {
        deviceInfo theDev;
        MainForm.ChangeDevIpHandler changeIPMethod;

        public DeviceSettingsForm(deviceInfo dev, MainForm.ChangeDevIpHandler changeIP)
        {
            InitializeComponent();
            theDev = dev;
            changeIPMethod = changeIP;
        }

        private void DeviceSettingsForm_Load(object sender, EventArgs e)
        {
            swBtn_IsDHCP.Value = theDev.IsDHCP;
            lab_DevSN.Text = "该设备SN:" + theDev.SN;
            txt_DevAliasName.Text = theDev.AliasName;
            ipIn_DevIPV4.Value = theDev.IPV4;
            ipIn_SubnetMask.Value = theDev.SubnetMask;
            ipIn_Gateway.Value = theDev.Gateway;
            ipIn_DNS.Value = theDev.DNS;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Setting_Click(object sender, EventArgs e)
        {
            if (txt_DevAliasName.Text == "") { txt_DevAliasName.Focus(); return; }

            if (ipIn_DevIPV4.Value == null || ipIn_SubnetMask.Value == null || ipIn_Gateway.Value == null || ipIn_DNS.Value == null)
            {
                return;
            }

            if (txt_LoginName.Text == "") { txt_LoginName.Focus(); return; }
            if (txt_LoginPass.Text == "") { txt_LoginPass.Focus(); return; }

            ChangeDevIPData parameters = new ChangeDevIPData();
            parameters.SN = theDev.SN;//获取选择设备的SN
            parameters.Switch = swBtn_IsDHCP.Value;//
            parameters.newIP = ipIn_DevIPV4.Value;
            parameters.newmask = ipIn_SubnetMask.Value;
            parameters.newgateway = ipIn_Gateway.Value;
            parameters.newdnsweb = ipIn_DNS.Value;
            parameters.aliasName = txt_DevAliasName.Text;
            parameters.userName = txt_LoginName.Text;
            parameters.password = txt_LoginPass.Text;

            changeIPMethod(theDev.IPV4, parameters);
            this.DialogResult = DialogResult.OK;
        }
    }
}
