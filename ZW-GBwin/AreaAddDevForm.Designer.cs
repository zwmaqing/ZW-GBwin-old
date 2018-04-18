namespace ZW_GBwin
{
    partial class AreaAddDevForm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.listBox_device = new DevComponents.DotNetBar.ListBoxAdv();
            this.listBox_AddDevice = new DevComponents.DotNetBar.ListBoxAdv();
            this.btn_Save = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(140, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "可添加的设备：";
            // 
            // listBox_device
            // 
            this.listBox_device.AutoScroll = true;
            // 
            // 
            // 
            this.listBox_device.BackgroundStyle.Class = "ListBoxAdv";
            this.listBox_device.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listBox_device.CheckStateMember = null;
            this.listBox_device.ContainerControlProcessDialogKey = true;
            this.listBox_device.DragDropSupport = true;
            this.listBox_device.Location = new System.Drawing.Point(12, 29);
            this.listBox_device.Name = "listBox_device";
            this.listBox_device.Size = new System.Drawing.Size(160, 200);
            this.listBox_device.TabIndex = 2;
            this.listBox_device.Text = "listBoxAdv1";
            this.listBox_device.ItemClick += new System.EventHandler(this.listBox_device_ItemClick);
            this.listBox_device.ItemDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_device_ItemDoubleClick);
            // 
            // listBox_AddDevice
            // 
            this.listBox_AddDevice.AutoScroll = true;
            // 
            // 
            // 
            this.listBox_AddDevice.BackgroundStyle.Class = "ListBoxAdv";
            this.listBox_AddDevice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listBox_AddDevice.CheckStateMember = null;
            this.listBox_AddDevice.ContainerControlProcessDialogKey = true;
            this.listBox_AddDevice.DragDropSupport = true;
            this.listBox_AddDevice.Location = new System.Drawing.Point(269, 29);
            this.listBox_AddDevice.Name = "listBox_AddDevice";
            this.listBox_AddDevice.Size = new System.Drawing.Size(160, 200);
            this.listBox_AddDevice.TabIndex = 3;
            this.listBox_AddDevice.Text = "listBoxAdv1";
            this.listBox_AddDevice.ItemDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_AddDevice_ItemDoubleClick);
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Save.Location = new System.Drawing.Point(354, 251);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 28);
            this.btn_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Save.Symbol = "";
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(269, 0);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(140, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "已添加的设备：";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(178, 103);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(85, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "双击添加/移除";
            // 
            // AreaAddDevForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 286);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.listBox_AddDevice);
            this.Controls.Add(this.listBox_device);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AreaAddDevForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "向区域添加设备终端";
            this.Load += new System.EventHandler(this.AreaAddDevForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ListBoxAdv listBox_device;
        private DevComponents.DotNetBar.ListBoxAdv listBox_AddDevice;
        private DevComponents.DotNetBar.ButtonX btn_Save;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}