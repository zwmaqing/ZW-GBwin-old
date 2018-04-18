namespace ZW_GBwin
{
    partial class ResourceFilesForm
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
            this.buttonX_CancelResource = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_OpenResourceLoaction = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_SaveResource = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxEx_ResourceClass = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxX_ResourceName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.circularProgress_AddResource = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.SuspendLayout();
            // 
            // buttonX_CancelResource
            // 
            this.buttonX_CancelResource.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_CancelResource.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_CancelResource.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX_CancelResource.Location = new System.Drawing.Point(122, 189);
            this.buttonX_CancelResource.Name = "buttonX_CancelResource";
            this.buttonX_CancelResource.Size = new System.Drawing.Size(73, 28);
            this.buttonX_CancelResource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_CancelResource.Symbol = "";
            this.buttonX_CancelResource.TabIndex = 22;
            this.buttonX_CancelResource.Text = "取 消";
            this.buttonX_CancelResource.Click += new System.EventHandler(this.buttonX_CancelResource_Click);
            // 
            // buttonX_OpenResourceLoaction
            // 
            this.buttonX_OpenResourceLoaction.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_OpenResourceLoaction.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_OpenResourceLoaction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX_OpenResourceLoaction.Location = new System.Drawing.Point(102, 65);
            this.buttonX_OpenResourceLoaction.Name = "buttonX_OpenResourceLoaction";
            this.buttonX_OpenResourceLoaction.Size = new System.Drawing.Size(155, 28);
            this.buttonX_OpenResourceLoaction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_OpenResourceLoaction.Symbol = "";
            this.buttonX_OpenResourceLoaction.TabIndex = 21;
            this.buttonX_OpenResourceLoaction.Text = "选择添加的资源";
            this.buttonX_OpenResourceLoaction.Click += new System.EventHandler(this.buttonX_OpenResourceLoaction_Click);
            // 
            // buttonX_SaveResource
            // 
            this.buttonX_SaveResource.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_SaveResource.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_SaveResource.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX_SaveResource.Location = new System.Drawing.Point(201, 189);
            this.buttonX_SaveResource.Name = "buttonX_SaveResource";
            this.buttonX_SaveResource.Size = new System.Drawing.Size(76, 28);
            this.buttonX_SaveResource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_SaveResource.Symbol = "";
            this.buttonX_SaveResource.TabIndex = 20;
            this.buttonX_SaveResource.Text = "保 存";
            this.buttonX_SaveResource.Click += new System.EventHandler(this.buttonX_SaveResource_Click);
            // 
            // comboBoxEx_ResourceClass
            // 
            this.comboBoxEx_ResourceClass.DisplayMember = "Text";
            this.comboBoxEx_ResourceClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx_ResourceClass.Enabled = false;
            this.comboBoxEx_ResourceClass.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEx_ResourceClass.FormattingEnabled = true;
            this.comboBoxEx_ResourceClass.ItemHeight = 16;
            this.comboBoxEx_ResourceClass.Location = new System.Drawing.Point(102, 22);
            this.comboBoxEx_ResourceClass.Name = "comboBoxEx_ResourceClass";
            this.comboBoxEx_ResourceClass.Size = new System.Drawing.Size(155, 22);
            this.comboBoxEx_ResourceClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx_ResourceClass.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "分类名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "已选择的资源:";
            // 
            // textBoxX_ResourceName
            // 
            this.textBoxX_ResourceName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX_ResourceName.Border.Class = "TextBoxBorder";
            this.textBoxX_ResourceName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_ResourceName.ButtonCustom.Tooltip = "";
            this.textBoxX_ResourceName.ButtonCustom2.Tooltip = "";
            this.textBoxX_ResourceName.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX_ResourceName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX_ResourceName.ForeColor = System.Drawing.Color.Black;
            this.textBoxX_ResourceName.Location = new System.Drawing.Point(19, 141);
            this.textBoxX_ResourceName.Name = "textBoxX_ResourceName";
            this.textBoxX_ResourceName.PreventEnterBeep = true;
            this.textBoxX_ResourceName.ReadOnly = true;
            this.textBoxX_ResourceName.Size = new System.Drawing.Size(258, 22);
            this.textBoxX_ResourceName.TabIndex = 17;
            // 
            // circularProgress_AddResource
            // 
            // 
            // 
            // 
            this.circularProgress_AddResource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress_AddResource.Location = new System.Drawing.Point(19, 182);
            this.circularProgress_AddResource.Name = "circularProgress_AddResource";
            this.circularProgress_AddResource.Size = new System.Drawing.Size(35, 35);
            this.circularProgress_AddResource.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress_AddResource.TabIndex = 23;
            // 
            // ResourceFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 229);
            this.Controls.Add(this.circularProgress_AddResource);
            this.Controls.Add(this.buttonX_CancelResource);
            this.Controls.Add(this.buttonX_OpenResourceLoaction);
            this.Controls.Add(this.buttonX_SaveResource);
            this.Controls.Add(this.comboBoxEx_ResourceClass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxX_ResourceName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResourceFilesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "资源文件";
            this.Load += new System.EventHandler(this.ResourceFilesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX_CancelResource;
        private DevComponents.DotNetBar.ButtonX buttonX_OpenResourceLoaction;
        private DevComponents.DotNetBar.ButtonX buttonX_SaveResource;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx_ResourceClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_ResourceName;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress_AddResource;
    }
}