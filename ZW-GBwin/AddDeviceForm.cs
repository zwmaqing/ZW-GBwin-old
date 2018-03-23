using DataHelper;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ZW_GBwin
{
    public partial class AddDeviceForm : MetroForm
    {
        ClientAsync tcpClient;

        public AddDeviceForm(ClientAsync client)
        {
            tcpClient = client;
            InitializeComponent();
        }


        private void btn_AddDevice_Click(object sender, EventArgs e)
        {

            if (ipAddressInput1.Value == null)
            {
                ipAddressInput1.Focus();
                return;
            }
            IPAddress ipAddress = null;
            try
            {
                ipAddress = IPAddress.Parse(ipAddressInput1.Value);
            }
            catch (Exception)
            {
                labelX2.Text = "ip地址格式不正确，请使用正确的ip地址！";
                return;
            }
            tcpClient.ConnectAsync(ipAddress.ToString(), 65005);

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void AddDeviceForm_Load(object sender, EventArgs e)
        {
            ini();
        }

        private void ini()
        {
            tcpClient.Completed += new Action<TcpClient, EnSocketAction>((c, enAction) =>
            {
                switch (enAction)
                {
                    case EnSocketAction.ConnectTimeOut:
                        {
                            labelX2.Invoke(new MethodInvoker(
                               delegate
                               {
                                   labelX2.Text = "连接服务端超时!";
                               }
                               ));
                            break;
                        }
                }
            });
        }
    }
}
