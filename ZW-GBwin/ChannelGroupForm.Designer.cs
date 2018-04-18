namespace ZW_GBwin
{
    partial class ChannelGroupForm
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
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.listBox_PlayDeviceChannels = new System.Windows.Forms.CheckedListBox();
            this.textBoxX_CHGroupName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Save = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(12, 49);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(111, 23);
            this.labelX3.TabIndex = 28;
            this.labelX3.Text = "选择包含分区：";
            // 
            // listBox_PlayDeviceChannels
            // 
            this.listBox_PlayDeviceChannels.BackColor = System.Drawing.Color.White;
            this.listBox_PlayDeviceChannels.ForeColor = System.Drawing.Color.Black;
            this.listBox_PlayDeviceChannels.FormattingEnabled = true;
            this.listBox_PlayDeviceChannels.Location = new System.Drawing.Point(129, 49);
            this.listBox_PlayDeviceChannels.Name = "listBox_PlayDeviceChannels";
            this.listBox_PlayDeviceChannels.Size = new System.Drawing.Size(203, 276);
            this.listBox_PlayDeviceChannels.TabIndex = 27;
            // 
            // textBoxX_CHGroupName
            // 
            this.textBoxX_CHGroupName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX_CHGroupName.Border.Class = "TextBoxBorder";
            this.textBoxX_CHGroupName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_CHGroupName.ButtonCustom.Tooltip = "";
            this.textBoxX_CHGroupName.ButtonCustom2.Tooltip = "";
            this.textBoxX_CHGroupName.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX_CHGroupName.ForeColor = System.Drawing.Color.Black;
            this.textBoxX_CHGroupName.Location = new System.Drawing.Point(129, 7);
            this.textBoxX_CHGroupName.Name = "textBoxX_CHGroupName";
            this.textBoxX_CHGroupName.PreventEnterBeep = true;
            this.textBoxX_CHGroupName.Size = new System.Drawing.Size(203, 21);
            this.textBoxX_CHGroupName.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "分区分组名称：";
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Save.Location = new System.Drawing.Point(244, 346);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(65, 28);
            this.btn_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Save.Symbol = "";
            this.btn_Save.TabIndex = 29;
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // ChannelGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 382);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.listBox_PlayDeviceChannels);
            this.Controls.Add(this.textBoxX_CHGroupName);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分区设备-分组管理";
            this.Load += new System.EventHandler(this.ChannelGroupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.CheckedListBox listBox_PlayDeviceChannels;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_CHGroupName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btn_Save;
    }
}