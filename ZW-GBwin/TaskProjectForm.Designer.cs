namespace ZW_GBwin
{
    partial class TaskProjectForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.listBoxAdv1 = new DevComponents.DotNetBar.ListBoxAdv();
            this.dataGridViewX_ResourceProject = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.advTree_ResourceClass = new DevComponents.AdvTree.AdvTree();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.richText_log = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.btn_SaveAndSync = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_ResourceProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree_ResourceClass)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.listBoxAdv1);
            this.panelEx1.Controls.Add(this.dataGridViewX_ResourceProject);
            this.panelEx1.Controls.Add(this.advTree_ResourceClass);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(865, 354);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            this.panelEx1.Text = "panelEx1";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(611, 8);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(223, 23);
            this.labelX1.TabIndex = 16;
            this.labelX1.Text = "任务的播放曲目：(双击添加/移除)";
            // 
            // listBoxAdv1
            // 
            this.listBoxAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAdv1.AutoScroll = true;
            // 
            // 
            // 
            this.listBoxAdv1.BackgroundStyle.Class = "ListBoxAdv";
            this.listBoxAdv1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listBoxAdv1.ContainerControlProcessDialogKey = true;
            this.listBoxAdv1.DragDropSupport = true;
            this.listBoxAdv1.Location = new System.Drawing.Point(611, 37);
            this.listBoxAdv1.Name = "listBoxAdv1";
            this.listBoxAdv1.Size = new System.Drawing.Size(251, 314);
            this.listBoxAdv1.TabIndex = 15;
            this.listBoxAdv1.Text = "listBoxAdv1";
            this.listBoxAdv1.ItemDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxAdv1_ItemDoubleClick);
            // 
            // dataGridViewX_ResourceProject
            // 
            this.dataGridViewX_ResourceProject.AllowUserToAddRows = false;
            this.dataGridViewX_ResourceProject.AllowUserToDeleteRows = false;
            this.dataGridViewX_ResourceProject.AllowUserToResizeRows = false;
            this.dataGridViewX_ResourceProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewX_ResourceProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewX_ResourceProject.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX_ResourceProject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX_ResourceProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX_ResourceProject.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX_ResourceProject.EnableHeadersVisualStyles = false;
            this.dataGridViewX_ResourceProject.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridViewX_ResourceProject.Location = new System.Drawing.Point(193, 0);
            this.dataGridViewX_ResourceProject.MultiSelect = false;
            this.dataGridViewX_ResourceProject.Name = "dataGridViewX_ResourceProject";
            this.dataGridViewX_ResourceProject.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX_ResourceProject.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX_ResourceProject.RowHeadersVisible = false;
            this.dataGridViewX_ResourceProject.RowHeadersWidth = 20;
            this.dataGridViewX_ResourceProject.RowTemplate.Height = 23;
            this.dataGridViewX_ResourceProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX_ResourceProject.ShowCellErrors = false;
            this.dataGridViewX_ResourceProject.ShowEditingIcon = false;
            this.dataGridViewX_ResourceProject.ShowRowErrors = false;
            this.dataGridViewX_ResourceProject.Size = new System.Drawing.Size(412, 354);
            this.dataGridViewX_ResourceProject.TabIndex = 14;
            this.dataGridViewX_ResourceProject.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX_ResourceProject_CellDoubleClick);
            // 
            // advTree_ResourceClass
            // 
            this.advTree_ResourceClass.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree_ResourceClass.AllowDrop = true;
            this.advTree_ResourceClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.advTree_ResourceClass.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.advTree_ResourceClass.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree_ResourceClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree_ResourceClass.Columns.Add(this.columnHeader1);
            this.advTree_ResourceClass.ForeColor = System.Drawing.Color.Black;
            this.advTree_ResourceClass.Location = new System.Drawing.Point(0, 0);
            this.advTree_ResourceClass.Name = "advTree_ResourceClass";
            this.advTree_ResourceClass.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTree_ResourceClass.NodesConnector = this.nodeConnector1;
            this.advTree_ResourceClass.NodeStyle = this.elementStyle1;
            this.advTree_ResourceClass.PathSeparator = ";";
            this.advTree_ResourceClass.Size = new System.Drawing.Size(197, 354);
            this.advTree_ResourceClass.Styles.Add(this.elementStyle1);
            this.advTree_ResourceClass.TabIndex = 13;
            this.advTree_ResourceClass.Text = "advTree1";
            this.advTree_ResourceClass.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree_ResourceClass_NodeClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.StretchToFill = true;
            this.columnHeader1.Text = "资源分类";
            this.columnHeader1.Width.Absolute = 150;
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "node1";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(135)))));
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.Color.Black;
            // 
            // richText_log
            // 
            this.richText_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.richText_log.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richText_log.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richText_log.Location = new System.Drawing.Point(0, 360);
            this.richText_log.Name = "richText_log";
            this.richText_log.ReadOnly = true;
            this.richText_log.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs18\\par\r\n}\r\n";
            this.richText_log.Size = new System.Drawing.Size(605, 98);
            this.richText_log.TabIndex = 1;
            this.richText_log.TabStop = false;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(752, 379);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(100, 32);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "   取  消";
            // 
            // circularProgress1
            // 
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(611, 360);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.Size = new System.Drawing.Size(104, 98);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 3;
            this.circularProgress1.TabStop = false;
            // 
            // btn_SaveAndSync
            // 
            this.btn_SaveAndSync.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_SaveAndSync.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_SaveAndSync.Location = new System.Drawing.Point(752, 421);
            this.btn_SaveAndSync.Name = "btn_SaveAndSync";
            this.btn_SaveAndSync.Size = new System.Drawing.Size(100, 32);
            this.btn_SaveAndSync.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_SaveAndSync.Symbol = "";
            this.btn_SaveAndSync.TabIndex = 4;
            this.btn_SaveAndSync.Text = "保存并同步";
            this.btn_SaveAndSync.Click += new System.EventHandler(this.btn_SaveAndSync_Click);
            // 
            // TaskProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 456);
            this.Controls.Add(this.btn_SaveAndSync);
            this.Controls.Add(this.circularProgress1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.richText_log);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "任务曲目管理";
            this.Load += new System.EventHandler(this.TaskProjectForm_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_ResourceProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree_ResourceClass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.AdvTree.AdvTree advTree_ResourceClass;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX_ResourceProject;
        private DevComponents.DotNetBar.ListBoxAdv listBoxAdv1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx richText_log;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        private DevComponents.DotNetBar.ButtonX btn_SaveAndSync;
    }
}