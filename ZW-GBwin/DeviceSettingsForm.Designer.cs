namespace ZW_GBwin
{
    partial class DeviceSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.swBtn_IsDHCP = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lab_DevSN = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txt_DevAliasName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.ipIn_DevIPV4 = new DevComponents.Editors.IpAddressInput();
            this.ipIn_SubnetMask = new DevComponents.Editors.IpAddressInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.ipIn_Gateway = new DevComponents.Editors.IpAddressInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.ipIn_DNS = new DevComponents.Editors.IpAddressInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txt_LoginName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_LoginPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.btn_Setting = new DevComponents.DotNetBar.ButtonX();
            this.btn_Cancel = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.ipIn_DevIPV4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipIn_SubnetMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipIn_Gateway)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipIn_DNS)).BeginInit();
            this.SuspendLayout();
            // 
            // swBtn_IsDHCP
            // 
            // 
            // 
            // 
            this.swBtn_IsDHCP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.swBtn_IsDHCP.Location = new System.Drawing.Point(154, 41);
            this.swBtn_IsDHCP.Name = "swBtn_IsDHCP";
            this.swBtn_IsDHCP.OffText = "否";
            this.swBtn_IsDHCP.OnText = "是";
            this.swBtn_IsDHCP.Size = new System.Drawing.Size(66, 22);
            this.swBtn_IsDHCP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.swBtn_IsDHCP.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 40);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(136, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "使用DHCP自动获取IP";
            // 
            // lab_DevSN
            // 
            // 
            // 
            // 
            this.lab_DevSN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lab_DevSN.Location = new System.Drawing.Point(12, 5);
            this.lab_DevSN.Name = "lab_DevSN";
            this.lab_DevSN.Size = new System.Drawing.Size(326, 29);
            this.lab_DevSN.TabIndex = 2;
            this.lab_DevSN.Text = "SN";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 79);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(136, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "设备别名：";
            // 
            // txt_DevAliasName
            // 
            this.txt_DevAliasName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_DevAliasName.Border.Class = "TextBoxBorder";
            this.txt_DevAliasName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_DevAliasName.ButtonCustom.Tooltip = "";
            this.txt_DevAliasName.ButtonCustom2.Tooltip = "";
            this.txt_DevAliasName.DisabledBackColor = System.Drawing.Color.White;
            this.txt_DevAliasName.ForeColor = System.Drawing.Color.Black;
            this.txt_DevAliasName.Location = new System.Drawing.Point(154, 79);
            this.txt_DevAliasName.Name = "txt_DevAliasName";
            this.txt_DevAliasName.PreventEnterBeep = true;
            this.txt_DevAliasName.Size = new System.Drawing.Size(191, 21);
            this.txt_DevAliasName.TabIndex = 4;
            this.txt_DevAliasName.WatermarkText = "该终端设备的别名";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(12, 117);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(136, 23);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "IP地址：";
            // 
            // ipIn_DevIPV4
            // 
            this.ipIn_DevIPV4.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipIn_DevIPV4.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipIn_DevIPV4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipIn_DevIPV4.ButtonClear.Tooltip = "";
            this.ipIn_DevIPV4.ButtonCustom.Tooltip = "";
            this.ipIn_DevIPV4.ButtonCustom2.Tooltip = "";
            this.ipIn_DevIPV4.ButtonDropDown.Tooltip = "";
            this.ipIn_DevIPV4.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipIn_DevIPV4.ButtonFreeText.Tooltip = "";
            this.ipIn_DevIPV4.ButtonFreeText.Visible = true;
            this.ipIn_DevIPV4.Location = new System.Drawing.Point(154, 119);
            this.ipIn_DevIPV4.Name = "ipIn_DevIPV4";
            this.ipIn_DevIPV4.Size = new System.Drawing.Size(191, 21);
            this.ipIn_DevIPV4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipIn_DevIPV4.TabIndex = 6;
            // 
            // ipIn_SubnetMask
            // 
            this.ipIn_SubnetMask.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipIn_SubnetMask.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipIn_SubnetMask.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipIn_SubnetMask.ButtonClear.Tooltip = "";
            this.ipIn_SubnetMask.ButtonCustom.Tooltip = "";
            this.ipIn_SubnetMask.ButtonCustom2.Tooltip = "";
            this.ipIn_SubnetMask.ButtonDropDown.Tooltip = "";
            this.ipIn_SubnetMask.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipIn_SubnetMask.ButtonFreeText.Tooltip = "";
            this.ipIn_SubnetMask.ButtonFreeText.Visible = true;
            this.ipIn_SubnetMask.Location = new System.Drawing.Point(154, 159);
            this.ipIn_SubnetMask.Name = "ipIn_SubnetMask";
            this.ipIn_SubnetMask.Size = new System.Drawing.Size(191, 21);
            this.ipIn_SubnetMask.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipIn_SubnetMask.TabIndex = 8;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(12, 157);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(136, 23);
            this.labelX5.TabIndex = 7;
            this.labelX5.Text = "子网掩码：";
            // 
            // ipIn_Gateway
            // 
            this.ipIn_Gateway.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipIn_Gateway.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipIn_Gateway.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipIn_Gateway.ButtonClear.Tooltip = "";
            this.ipIn_Gateway.ButtonCustom.Tooltip = "";
            this.ipIn_Gateway.ButtonCustom2.Tooltip = "";
            this.ipIn_Gateway.ButtonDropDown.Tooltip = "";
            this.ipIn_Gateway.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipIn_Gateway.ButtonFreeText.Tooltip = "";
            this.ipIn_Gateway.ButtonFreeText.Visible = true;
            this.ipIn_Gateway.Location = new System.Drawing.Point(154, 200);
            this.ipIn_Gateway.Name = "ipIn_Gateway";
            this.ipIn_Gateway.Size = new System.Drawing.Size(191, 21);
            this.ipIn_Gateway.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipIn_Gateway.TabIndex = 10;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(12, 198);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(136, 23);
            this.labelX6.TabIndex = 9;
            this.labelX6.Text = "网关地址：";
            // 
            // ipIn_DNS
            // 
            this.ipIn_DNS.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipIn_DNS.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipIn_DNS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipIn_DNS.ButtonClear.Tooltip = "";
            this.ipIn_DNS.ButtonCustom.Tooltip = "";
            this.ipIn_DNS.ButtonCustom2.Tooltip = "";
            this.ipIn_DNS.ButtonDropDown.Tooltip = "";
            this.ipIn_DNS.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipIn_DNS.ButtonFreeText.Tooltip = "";
            this.ipIn_DNS.ButtonFreeText.Visible = true;
            this.ipIn_DNS.Location = new System.Drawing.Point(154, 238);
            this.ipIn_DNS.Name = "ipIn_DNS";
            this.ipIn_DNS.Size = new System.Drawing.Size(191, 21);
            this.ipIn_DNS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipIn_DNS.TabIndex = 12;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(12, 236);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(136, 23);
            this.labelX7.TabIndex = 11;
            this.labelX7.Text = "DNS地址：";
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(12, 282);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(63, 21);
            this.labelX8.TabIndex = 13;
            this.labelX8.Text = "用户名：";
            // 
            // txt_LoginName
            // 
            this.txt_LoginName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_LoginName.Border.Class = "TextBoxBorder";
            this.txt_LoginName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_LoginName.ButtonCustom.Tooltip = "";
            this.txt_LoginName.ButtonCustom2.Tooltip = "";
            this.txt_LoginName.DisabledBackColor = System.Drawing.Color.White;
            this.txt_LoginName.ForeColor = System.Drawing.Color.Black;
            this.txt_LoginName.Location = new System.Drawing.Point(81, 282);
            this.txt_LoginName.Name = "txt_LoginName";
            this.txt_LoginName.PreventEnterBeep = true;
            this.txt_LoginName.Size = new System.Drawing.Size(80, 21);
            this.txt_LoginName.TabIndex = 14;
            this.txt_LoginName.WatermarkText = "登录用户名";
            // 
            // txt_LoginPass
            // 
            this.txt_LoginPass.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_LoginPass.Border.Class = "TextBoxBorder";
            this.txt_LoginPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_LoginPass.ButtonCustom.Tooltip = "";
            this.txt_LoginPass.ButtonCustom2.Tooltip = "";
            this.txt_LoginPass.DisabledBackColor = System.Drawing.Color.White;
            this.txt_LoginPass.ForeColor = System.Drawing.Color.Black;
            this.txt_LoginPass.Location = new System.Drawing.Point(265, 282);
            this.txt_LoginPass.Name = "txt_LoginPass";
            this.txt_LoginPass.PasswordChar = '*';
            this.txt_LoginPass.PreventEnterBeep = true;
            this.txt_LoginPass.Size = new System.Drawing.Size(80, 21);
            this.txt_LoginPass.TabIndex = 16;
            this.txt_LoginPass.WatermarkText = "登录密码";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(210, 282);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(49, 21);
            this.labelX9.TabIndex = 15;
            this.labelX9.Text = "密码：";
            // 
            // btn_Setting
            // 
            this.btn_Setting.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Setting.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Setting.Location = new System.Drawing.Point(247, 327);
            this.btn_Setting.Name = "btn_Setting";
            this.btn_Setting.Size = new System.Drawing.Size(98, 23);
            this.btn_Setting.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Setting.TabIndex = 17;
            this.btn_Setting.Text = "修改设备配置";
            this.btn_Setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Cancel.Location = new System.Drawing.Point(166, 327);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Cancel.TabIndex = 18;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // DeviceSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 362);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Setting);
            this.Controls.Add(this.txt_LoginPass);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.txt_LoginName);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.ipIn_DNS);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.ipIn_Gateway);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.ipIn_SubnetMask);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.ipIn_DevIPV4);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txt_DevAliasName);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.lab_DevSN);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.swBtn_IsDHCP);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设备终端配置";
            this.Load += new System.EventHandler(this.DeviceSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ipIn_DevIPV4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipIn_SubnetMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipIn_Gateway)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipIn_DNS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.SwitchButton swBtn_IsDHCP;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lab_DevSN;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_DevAliasName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.IpAddressInput ipIn_DevIPV4;
        private DevComponents.Editors.IpAddressInput ipIn_SubnetMask;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.IpAddressInput ipIn_Gateway;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.IpAddressInput ipIn_DNS;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_LoginName;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_LoginPass;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.ButtonX btn_Setting;
        private DevComponents.DotNetBar.ButtonX btn_Cancel;
    }
}