namespace ZW_GBwin
{
    partial class DelTimerTaskForm
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
            this.lab_msg = new DevComponents.DotNetBar.LabelX();
            this.richTxt_Log = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.btn_Del = new DevComponents.DotNetBar.ButtonX();
            this.btn_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.prog_timer = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.SuspendLayout();
            // 
            // lab_msg
            // 
            // 
            // 
            // 
            this.lab_msg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lab_msg.Location = new System.Drawing.Point(12, 12);
            this.lab_msg.Name = "lab_msg";
            this.lab_msg.Size = new System.Drawing.Size(470, 23);
            this.lab_msg.TabIndex = 0;
            this.lab_msg.Text = "确实要删除定时播放任务:";
            // 
            // richTxt_Log
            // 
            // 
            // 
            // 
            this.richTxt_Log.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richTxt_Log.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richTxt_Log.Location = new System.Drawing.Point(12, 41);
            this.richTxt_Log.Name = "richTxt_Log";
            this.richTxt_Log.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs18\\par\r\n}\r\n";
            this.richTxt_Log.Size = new System.Drawing.Size(478, 84);
            this.richTxt_Log.TabIndex = 1;
            // 
            // btn_Del
            // 
            this.btn_Del.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Del.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Del.Location = new System.Drawing.Point(415, 134);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(75, 28);
            this.btn_Del.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Del.Symbol = "";
            this.btn_Del.TabIndex = 2;
            this.btn_Del.Text = "删除";
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Cancel.Location = new System.Drawing.Point(334, 134);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 28);
            this.btn_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Cancel.Symbol = "";
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // prog_timer
            // 
            // 
            // 
            // 
            this.prog_timer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.prog_timer.Location = new System.Drawing.Point(294, 134);
            this.prog_timer.Name = "prog_timer";
            this.prog_timer.Size = new System.Drawing.Size(32, 32);
            this.prog_timer.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.prog_timer.TabIndex = 4;
            // 
            // DelTimerTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 169);
            this.Controls.Add(this.prog_timer);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.richTxt_Log);
            this.Controls.Add(this.lab_msg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DelTimerTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "删除定时播放任务";
            this.Load += new System.EventHandler(this.DelTimerTaskForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lab_msg;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx richTxt_Log;
        private DevComponents.DotNetBar.ButtonX btn_Del;
        private DevComponents.DotNetBar.ButtonX btn_Cancel;
        private DevComponents.DotNetBar.Controls.CircularProgress prog_timer;
    }
}