namespace ZW_GBwin
{
    partial class AreaForm
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
            this.txt_AreaName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_SaveArea = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 27);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "区域名称：";
            // 
            // txt_AreaName
            // 
            this.txt_AreaName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_AreaName.Border.Class = "TextBoxBorder";
            this.txt_AreaName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_AreaName.ButtonCustom.Tooltip = "";
            this.txt_AreaName.ButtonCustom2.Tooltip = "";
            this.txt_AreaName.DisabledBackColor = System.Drawing.Color.White;
            this.txt_AreaName.ForeColor = System.Drawing.Color.Black;
            this.txt_AreaName.Location = new System.Drawing.Point(93, 27);
            this.txt_AreaName.Name = "txt_AreaName";
            this.txt_AreaName.PreventEnterBeep = true;
            this.txt_AreaName.Size = new System.Drawing.Size(162, 21);
            this.txt_AreaName.TabIndex = 1;
            this.txt_AreaName.WatermarkText = "区域名称";
            // 
            // btn_SaveArea
            // 
            this.btn_SaveArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_SaveArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_SaveArea.Location = new System.Drawing.Point(188, 88);
            this.btn_SaveArea.Name = "btn_SaveArea";
            this.btn_SaveArea.Size = new System.Drawing.Size(67, 28);
            this.btn_SaveArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_SaveArea.Symbol = "";
            this.btn_SaveArea.TabIndex = 2;
            this.btn_SaveArea.Text = "保存";
            this.btn_SaveArea.Click += new System.EventHandler(this.btn_SaveArea_Click);
            // 
            // AreaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 119);
            this.Controls.Add(this.btn_SaveArea);
            this.Controls.Add(this.txt_AreaName);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AreaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "区域";
            this.Load += new System.EventHandler(this.AreaForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_AreaName;
        private DevComponents.DotNetBar.ButtonX btn_SaveArea;
    }
}