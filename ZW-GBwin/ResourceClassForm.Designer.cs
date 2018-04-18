namespace ZW_GBwin
{
    partial class ResourceClassForm
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
            this.chec_IsShareLocation = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lab_ResourceClassCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_OpenResourceClassLoaction = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.cobx_ResourceClassType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ResourceClassName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.btn_Save = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // chec_IsShareLocation
            // 
            // 
            // 
            // 
            this.chec_IsShareLocation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chec_IsShareLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chec_IsShareLocation.Location = new System.Drawing.Point(98, 88);
            this.chec_IsShareLocation.Name = "chec_IsShareLocation";
            this.chec_IsShareLocation.Size = new System.Drawing.Size(100, 27);
            this.chec_IsShareLocation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chec_IsShareLocation.TabIndex = 21;
            this.chec_IsShareLocation.Text = "使用共享位置";
            this.chec_IsShareLocation.CheckedChanged += new System.EventHandler(this.chec_IsShareLocation_CheckedChanged);
            // 
            // lab_ResourceClassCount
            // 
            this.lab_ResourceClassCount.AutoSize = true;
            this.lab_ResourceClassCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_ResourceClassCount.Location = new System.Drawing.Point(95, 167);
            this.lab_ResourceClassCount.Name = "lab_ResourceClassCount";
            this.lab_ResourceClassCount.Size = new System.Drawing.Size(50, 13);
            this.lab_ResourceClassCount.TabIndex = 20;
            this.lab_ResourceClassCount.Text = "          。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "资源数量:";
            // 
            // btn_OpenResourceClassLoaction
            // 
            this.btn_OpenResourceClassLoaction.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_OpenResourceClassLoaction.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_OpenResourceClassLoaction.Enabled = false;
            this.btn_OpenResourceClassLoaction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OpenResourceClassLoaction.Location = new System.Drawing.Point(148, 135);
            this.btn_OpenResourceClassLoaction.Name = "btn_OpenResourceClassLoaction";
            this.btn_OpenResourceClassLoaction.Size = new System.Drawing.Size(105, 28);
            this.btn_OpenResourceClassLoaction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_OpenResourceClassLoaction.Symbol = "";
            this.btn_OpenResourceClassLoaction.TabIndex = 18;
            this.btn_OpenResourceClassLoaction.Text = "打开位置";
            this.btn_OpenResourceClassLoaction.Click += new System.EventHandler(this.btn_OpenResourceClassLoaction_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "选择已有资源位置:";
            // 
            // cobx_ResourceClassType
            // 
            this.cobx_ResourceClassType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cobx_ResourceClassType.FormattingEnabled = true;
            this.cobx_ResourceClassType.Items.AddRange(new object[] {
            "音乐",
            "故事",
            "综合"});
            this.cobx_ResourceClassType.Location = new System.Drawing.Point(98, 55);
            this.cobx_ResourceClassType.Name = "cobx_ResourceClassType";
            this.cobx_ResourceClassType.Size = new System.Drawing.Size(155, 21);
            this.cobx_ResourceClassType.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "分类类型:";
            // 
            // txt_ResourceClassName
            // 
            this.txt_ResourceClassName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_ResourceClassName.Border.Class = "TextBoxBorder";
            this.txt_ResourceClassName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ResourceClassName.ButtonCustom.Tooltip = "";
            this.txt_ResourceClassName.ButtonCustom2.Tooltip = "";
            this.txt_ResourceClassName.DisabledBackColor = System.Drawing.Color.White;
            this.txt_ResourceClassName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ResourceClassName.ForeColor = System.Drawing.Color.Black;
            this.txt_ResourceClassName.Location = new System.Drawing.Point(98, 18);
            this.txt_ResourceClassName.Name = "txt_ResourceClassName";
            this.txt_ResourceClassName.PreventEnterBeep = true;
            this.txt_ResourceClassName.Size = new System.Drawing.Size(155, 22);
            this.txt_ResourceClassName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "分类名称:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Cancel.Location = new System.Drawing.Point(98, 194);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 28);
            this.btn_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Cancel.Symbol = "";
            this.btn_Cancel.TabIndex = 22;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Save.Location = new System.Drawing.Point(179, 194);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 28);
            this.btn_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Save.Symbol = "";
            this.btn_Save.TabIndex = 23;
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // ResourceClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 228);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.chec_IsShareLocation);
            this.Controls.Add(this.lab_ResourceClassCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_OpenResourceClassLoaction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cobx_ResourceClassType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ResourceClassName);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResourceClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "资源类别";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX chec_IsShareLocation;
        private System.Windows.Forms.Label lab_ResourceClassCount;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ButtonX btn_OpenResourceClassLoaction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cobx_ResourceClassType;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ResourceClassName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btn_Cancel;
        private DevComponents.DotNetBar.ButtonX btn_Save;
    }
}