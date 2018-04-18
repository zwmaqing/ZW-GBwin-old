namespace ZW_GBwin
{
    partial class TimerTaskForm
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
            this.grp_TaskBaseInfoEdit = new System.Windows.Forms.GroupBox();
            this.crumbBar_Area = new DevComponents.DotNetBar.CrumbBar();
            this.richText_log = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.switchButton1 = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.pan_TaskBaseInfoSave = new DevComponents.DotNetBar.PanelEx();
            this.lab_notice = new DevComponents.DotNetBar.LabelX();
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.btn_SaveTaskBaseInfo = new DevComponents.DotNetBar.ButtonX();
            this.btn_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.lab_taskDefaultChannelSet = new System.Windows.Forms.Label();
            this.lab_taskDayOffWeek = new System.Windows.Forms.Label();
            this.chk_taskIsSunday = new System.Windows.Forms.CheckBox();
            this.chk_taskIsSaturday = new System.Windows.Forms.CheckBox();
            this.slider_TaskEndVolume = new DevComponents.DotNetBar.Controls.Slider();
            this.chk_taskIsFriday = new System.Windows.Forms.CheckBox();
            this.lab_TaskEndVolume = new System.Windows.Forms.Label();
            this.chk_taskIsThursday = new System.Windows.Forms.CheckBox();
            this.slider_TaskStartVolume = new DevComponents.DotNetBar.Controls.Slider();
            this.chk_taskIsWednesday = new System.Windows.Forms.CheckBox();
            this.lab_TaskStartVolume = new System.Windows.Forms.Label();
            this.chk_taskIsTuesday = new System.Windows.Forms.CheckBox();
            this.timeInput_TaskEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.chk_taskIsMonday = new System.Windows.Forms.CheckBox();
            this.lab_TaskEndTime = new System.Windows.Forms.Label();
            this.timeInput_TaskStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lab_TaskStartTime = new System.Windows.Forms.Label();
            this.textBoxX_TaskName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lab_taskName = new System.Windows.Forms.Label();
            this.lab_oldAreaFullPath = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.grp_TaskBaseInfoEdit.SuspendLayout();
            this.pan_TaskBaseInfoSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeInput_TaskEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeInput_TaskStart)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_TaskBaseInfoEdit
            // 
            this.grp_TaskBaseInfoEdit.BackColor = System.Drawing.Color.White;
            this.grp_TaskBaseInfoEdit.Controls.Add(this.labelX2);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.lab_oldAreaFullPath);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.crumbBar_Area);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.richText_log);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.switchButton1);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.pan_TaskBaseInfoSave);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.lab_taskDefaultChannelSet);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.lab_taskDayOffWeek);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.chk_taskIsSunday);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.chk_taskIsSaturday);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.slider_TaskEndVolume);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.chk_taskIsFriday);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.lab_TaskEndVolume);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.chk_taskIsThursday);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.slider_TaskStartVolume);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.chk_taskIsWednesday);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.lab_TaskStartVolume);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.chk_taskIsTuesday);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.timeInput_TaskEnd);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.chk_taskIsMonday);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.lab_TaskEndTime);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.timeInput_TaskStart);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.lab_TaskStartTime);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.textBoxX_TaskName);
            this.grp_TaskBaseInfoEdit.Controls.Add(this.lab_taskName);
            this.grp_TaskBaseInfoEdit.ForeColor = System.Drawing.Color.Black;
            this.grp_TaskBaseInfoEdit.Location = new System.Drawing.Point(8, 8);
            this.grp_TaskBaseInfoEdit.Name = "grp_TaskBaseInfoEdit";
            this.grp_TaskBaseInfoEdit.Size = new System.Drawing.Size(588, 358);
            this.grp_TaskBaseInfoEdit.TabIndex = 8;
            this.grp_TaskBaseInfoEdit.TabStop = false;
            this.grp_TaskBaseInfoEdit.Text = "任务基本信息";
            // 
            // crumbBar_Area
            // 
            this.crumbBar_Area.AutoSize = true;
            this.crumbBar_Area.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.crumbBar_Area.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.crumbBar_Area.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.crumbBar_Area.BackgroundStyle.BorderBottomWidth = 1;
            this.crumbBar_Area.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(89)))), ((int)(((byte)(94)))));
            this.crumbBar_Area.BackgroundStyle.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(180)))), ((int)(((byte)(191)))));
            this.crumbBar_Area.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.crumbBar_Area.BackgroundStyle.BorderLeftWidth = 1;
            this.crumbBar_Area.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.crumbBar_Area.BackgroundStyle.BorderRightWidth = 1;
            this.crumbBar_Area.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.crumbBar_Area.BackgroundStyle.BorderTopWidth = 1;
            this.crumbBar_Area.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.crumbBar_Area.ContainerControlProcessDialogKey = true;
            this.crumbBar_Area.ForeColor = System.Drawing.Color.Black;
            this.crumbBar_Area.Location = new System.Drawing.Point(116, 102);
            this.crumbBar_Area.Name = "crumbBar_Area";
            this.crumbBar_Area.PathSeparator = ";";
            this.crumbBar_Area.Size = new System.Drawing.Size(447, 22);
            this.crumbBar_Area.TabIndex = 42;
            this.crumbBar_Area.SelectedItemChanged += new DevComponents.DotNetBar.CrumBarSelectionEventHandler(this.crumbBar_Area_SelectedItemChanged);
            // 
            // richText_log
            // 
            this.richText_log.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.richText_log.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richText_log.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richText_log.ForeColor = System.Drawing.Color.Black;
            this.richText_log.Location = new System.Drawing.Point(10, 221);
            this.richText_log.Name = "richText_log";
            this.richText_log.ReadOnly = true;
            this.richText_log.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs18\\par\r\n}\r\n";
            this.richText_log.Size = new System.Drawing.Size(553, 88);
            this.richText_log.TabIndex = 41;
            this.richText_log.TabStop = false;
            // 
            // switchButton1
            // 
            this.switchButton1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.switchButton1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton1.ForeColor = System.Drawing.Color.Black;
            this.switchButton1.Location = new System.Drawing.Point(383, 30);
            this.switchButton1.Name = "switchButton1";
            this.switchButton1.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.switchButton1.OffText = "顺序";
            this.switchButton1.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.switchButton1.OnText = "随机";
            this.switchButton1.OnTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.switchButton1.Size = new System.Drawing.Size(76, 19);
            this.switchButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton1.SwitchBackColor = System.Drawing.Color.Gray;
            this.switchButton1.TabIndex = 40;
            // 
            // pan_TaskBaseInfoSave
            // 
            this.pan_TaskBaseInfoSave.CanvasColor = System.Drawing.SystemColors.Control;
            this.pan_TaskBaseInfoSave.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pan_TaskBaseInfoSave.Controls.Add(this.lab_notice);
            this.pan_TaskBaseInfoSave.Controls.Add(this.circularProgress1);
            this.pan_TaskBaseInfoSave.Controls.Add(this.btn_SaveTaskBaseInfo);
            this.pan_TaskBaseInfoSave.Controls.Add(this.btn_Cancel);
            this.pan_TaskBaseInfoSave.DisabledBackColor = System.Drawing.Color.Empty;
            this.pan_TaskBaseInfoSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_TaskBaseInfoSave.Location = new System.Drawing.Point(3, 316);
            this.pan_TaskBaseInfoSave.Name = "pan_TaskBaseInfoSave";
            this.pan_TaskBaseInfoSave.Size = new System.Drawing.Size(582, 39);
            this.pan_TaskBaseInfoSave.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pan_TaskBaseInfoSave.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pan_TaskBaseInfoSave.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pan_TaskBaseInfoSave.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pan_TaskBaseInfoSave.Style.BorderWidth = 0;
            this.pan_TaskBaseInfoSave.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pan_TaskBaseInfoSave.Style.GradientAngle = 90;
            this.pan_TaskBaseInfoSave.TabIndex = 37;
            // 
            // lab_notice
            // 
            // 
            // 
            // 
            this.lab_notice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lab_notice.ForeColor = System.Drawing.Color.Black;
            this.lab_notice.Location = new System.Drawing.Point(7, 9);
            this.lab_notice.Name = "lab_notice";
            this.lab_notice.Size = new System.Drawing.Size(287, 23);
            this.lab_notice.TabIndex = 32;
            // 
            // circularProgress1
            // 
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(302, 3);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.Size = new System.Drawing.Size(47, 33);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 31;
            this.circularProgress1.TabStop = false;
            // 
            // btn_SaveTaskBaseInfo
            // 
            this.btn_SaveTaskBaseInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_SaveTaskBaseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveTaskBaseInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_SaveTaskBaseInfo.Location = new System.Drawing.Point(472, 8);
            this.btn_SaveTaskBaseInfo.Name = "btn_SaveTaskBaseInfo";
            this.btn_SaveTaskBaseInfo.Size = new System.Drawing.Size(104, 28);
            this.btn_SaveTaskBaseInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_SaveTaskBaseInfo.Symbol = "";
            this.btn_SaveTaskBaseInfo.TabIndex = 27;
            this.btn_SaveTaskBaseInfo.Text = "发布并保存";
            this.btn_SaveTaskBaseInfo.Click += new System.EventHandler(this.btn_SaveTaskBaseInfo_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Cancel.Location = new System.Drawing.Point(362, 7);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(104, 28);
            this.btn_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Cancel.Symbol = "";
            this.btn_Cancel.TabIndex = 30;
            this.btn_Cancel.Text = " 取消更改";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lab_taskDefaultChannelSet
            // 
            this.lab_taskDefaultChannelSet.AutoSize = true;
            this.lab_taskDefaultChannelSet.BackColor = System.Drawing.Color.White;
            this.lab_taskDefaultChannelSet.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_taskDefaultChannelSet.ForeColor = System.Drawing.Color.Black;
            this.lab_taskDefaultChannelSet.Location = new System.Drawing.Point(6, 102);
            this.lab_taskDefaultChannelSet.Name = "lab_taskDefaultChannelSet";
            this.lab_taskDefaultChannelSet.Size = new System.Drawing.Size(101, 19);
            this.lab_taskDefaultChannelSet.TabIndex = 36;
            this.lab_taskDefaultChannelSet.Text = "收听区域/设备:";
            // 
            // lab_taskDayOffWeek
            // 
            this.lab_taskDayOffWeek.AutoSize = true;
            this.lab_taskDayOffWeek.BackColor = System.Drawing.Color.White;
            this.lab_taskDayOffWeek.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_taskDayOffWeek.ForeColor = System.Drawing.Color.Black;
            this.lab_taskDayOffWeek.Location = new System.Drawing.Point(6, 199);
            this.lab_taskDayOffWeek.Name = "lab_taskDayOffWeek";
            this.lab_taskDayOffWeek.Size = new System.Drawing.Size(68, 19);
            this.lab_taskDayOffWeek.TabIndex = 28;
            this.lab_taskDayOffWeek.Text = "使用任务:";
            // 
            // chk_taskIsSunday
            // 
            this.chk_taskIsSunday.AutoSize = true;
            this.chk_taskIsSunday.BackColor = System.Drawing.Color.White;
            this.chk_taskIsSunday.ForeColor = System.Drawing.Color.Black;
            this.chk_taskIsSunday.Location = new System.Drawing.Point(503, 199);
            this.chk_taskIsSunday.Name = "chk_taskIsSunday";
            this.chk_taskIsSunday.Size = new System.Drawing.Size(60, 16);
            this.chk_taskIsSunday.TabIndex = 19;
            this.chk_taskIsSunday.Text = "星期日";
            this.chk_taskIsSunday.UseVisualStyleBackColor = false;
            // 
            // chk_taskIsSaturday
            // 
            this.chk_taskIsSaturday.AutoSize = true;
            this.chk_taskIsSaturday.BackColor = System.Drawing.Color.White;
            this.chk_taskIsSaturday.ForeColor = System.Drawing.Color.Black;
            this.chk_taskIsSaturday.Location = new System.Drawing.Point(437, 199);
            this.chk_taskIsSaturday.Name = "chk_taskIsSaturday";
            this.chk_taskIsSaturday.Size = new System.Drawing.Size(60, 16);
            this.chk_taskIsSaturday.TabIndex = 18;
            this.chk_taskIsSaturday.Text = "星期六";
            this.chk_taskIsSaturday.UseVisualStyleBackColor = false;
            // 
            // slider_TaskEndVolume
            // 
            this.slider_TaskEndVolume.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.slider_TaskEndVolume.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.slider_TaskEndVolume.ForeColor = System.Drawing.Color.Black;
            this.slider_TaskEndVolume.LabelWidth = 20;
            this.slider_TaskEndVolume.Location = new System.Drawing.Point(371, 154);
            this.slider_TaskEndVolume.Name = "slider_TaskEndVolume";
            this.slider_TaskEndVolume.Size = new System.Drawing.Size(145, 23);
            this.slider_TaskEndVolume.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.slider_TaskEndVolume.TabIndex = 18;
            this.slider_TaskEndVolume.Value = 75;
            // 
            // chk_taskIsFriday
            // 
            this.chk_taskIsFriday.AutoSize = true;
            this.chk_taskIsFriday.BackColor = System.Drawing.Color.White;
            this.chk_taskIsFriday.Checked = true;
            this.chk_taskIsFriday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_taskIsFriday.ForeColor = System.Drawing.Color.Black;
            this.chk_taskIsFriday.Location = new System.Drawing.Point(371, 199);
            this.chk_taskIsFriday.Name = "chk_taskIsFriday";
            this.chk_taskIsFriday.Size = new System.Drawing.Size(60, 16);
            this.chk_taskIsFriday.TabIndex = 17;
            this.chk_taskIsFriday.Text = "星期五";
            this.chk_taskIsFriday.UseVisualStyleBackColor = false;
            // 
            // lab_TaskEndVolume
            // 
            this.lab_TaskEndVolume.AutoSize = true;
            this.lab_TaskEndVolume.BackColor = System.Drawing.Color.White;
            this.lab_TaskEndVolume.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TaskEndVolume.ForeColor = System.Drawing.Color.Black;
            this.lab_TaskEndVolume.Location = new System.Drawing.Point(273, 158);
            this.lab_TaskEndVolume.Name = "lab_TaskEndVolume";
            this.lab_TaskEndVolume.Size = new System.Drawing.Size(68, 19);
            this.lab_TaskEndVolume.TabIndex = 17;
            this.lab_TaskEndVolume.Text = "结束音量:";
            // 
            // chk_taskIsThursday
            // 
            this.chk_taskIsThursday.AutoSize = true;
            this.chk_taskIsThursday.BackColor = System.Drawing.Color.White;
            this.chk_taskIsThursday.Checked = true;
            this.chk_taskIsThursday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_taskIsThursday.ForeColor = System.Drawing.Color.Black;
            this.chk_taskIsThursday.Location = new System.Drawing.Point(305, 199);
            this.chk_taskIsThursday.Name = "chk_taskIsThursday";
            this.chk_taskIsThursday.Size = new System.Drawing.Size(60, 16);
            this.chk_taskIsThursday.TabIndex = 16;
            this.chk_taskIsThursday.Text = "星期四";
            this.chk_taskIsThursday.UseVisualStyleBackColor = false;
            // 
            // slider_TaskStartVolume
            // 
            this.slider_TaskStartVolume.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.slider_TaskStartVolume.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.slider_TaskStartVolume.ForeColor = System.Drawing.Color.Black;
            this.slider_TaskStartVolume.LabelWidth = 20;
            this.slider_TaskStartVolume.Location = new System.Drawing.Point(99, 158);
            this.slider_TaskStartVolume.Name = "slider_TaskStartVolume";
            this.slider_TaskStartVolume.Size = new System.Drawing.Size(154, 23);
            this.slider_TaskStartVolume.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.slider_TaskStartVolume.TabIndex = 16;
            this.slider_TaskStartVolume.Value = 75;
            // 
            // chk_taskIsWednesday
            // 
            this.chk_taskIsWednesday.AutoSize = true;
            this.chk_taskIsWednesday.BackColor = System.Drawing.Color.White;
            this.chk_taskIsWednesday.Checked = true;
            this.chk_taskIsWednesday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_taskIsWednesday.ForeColor = System.Drawing.Color.Black;
            this.chk_taskIsWednesday.Location = new System.Drawing.Point(237, 199);
            this.chk_taskIsWednesday.Name = "chk_taskIsWednesday";
            this.chk_taskIsWednesday.Size = new System.Drawing.Size(60, 16);
            this.chk_taskIsWednesday.TabIndex = 15;
            this.chk_taskIsWednesday.Text = "星期三";
            this.chk_taskIsWednesday.UseVisualStyleBackColor = false;
            // 
            // lab_TaskStartVolume
            // 
            this.lab_TaskStartVolume.AutoSize = true;
            this.lab_TaskStartVolume.BackColor = System.Drawing.Color.White;
            this.lab_TaskStartVolume.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TaskStartVolume.ForeColor = System.Drawing.Color.Black;
            this.lab_TaskStartVolume.Location = new System.Drawing.Point(6, 158);
            this.lab_TaskStartVolume.Name = "lab_TaskStartVolume";
            this.lab_TaskStartVolume.Size = new System.Drawing.Size(68, 19);
            this.lab_TaskStartVolume.TabIndex = 15;
            this.lab_TaskStartVolume.Text = "开始音量:";
            // 
            // chk_taskIsTuesday
            // 
            this.chk_taskIsTuesday.AutoSize = true;
            this.chk_taskIsTuesday.BackColor = System.Drawing.Color.White;
            this.chk_taskIsTuesday.Checked = true;
            this.chk_taskIsTuesday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_taskIsTuesday.ForeColor = System.Drawing.Color.Black;
            this.chk_taskIsTuesday.Location = new System.Drawing.Point(167, 199);
            this.chk_taskIsTuesday.Name = "chk_taskIsTuesday";
            this.chk_taskIsTuesday.Size = new System.Drawing.Size(60, 16);
            this.chk_taskIsTuesday.TabIndex = 14;
            this.chk_taskIsTuesday.Text = "星期二";
            this.chk_taskIsTuesday.UseVisualStyleBackColor = false;
            // 
            // timeInput_TaskEnd
            // 
            this.timeInput_TaskEnd.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.timeInput_TaskEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.timeInput_TaskEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.timeInput_TaskEnd.ButtonClear.Tooltip = "";
            this.timeInput_TaskEnd.ButtonClear.Visible = true;
            this.timeInput_TaskEnd.ButtonCustom.DisplayPosition = 1;
            this.timeInput_TaskEnd.ButtonCustom.Tooltip = "";
            this.timeInput_TaskEnd.ButtonCustom.Visible = true;
            this.timeInput_TaskEnd.ButtonCustom2.Tooltip = "";
            this.timeInput_TaskEnd.ButtonDropDown.Tooltip = "";
            this.timeInput_TaskEnd.ButtonDropDown.Visible = true;
            this.timeInput_TaskEnd.ButtonFreeText.Tooltip = "";
            this.timeInput_TaskEnd.FocusHighlightEnabled = true;
            this.timeInput_TaskEnd.ForeColor = System.Drawing.Color.Black;
            this.timeInput_TaskEnd.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime;
            this.timeInput_TaskEnd.IsPopupCalendarOpen = false;
            this.timeInput_TaskEnd.Location = new System.Drawing.Point(347, 69);
            // 
            // 
            // 
            this.timeInput_TaskEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.timeInput_TaskEnd.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.timeInput_TaskEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.timeInput_TaskEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.timeInput_TaskEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.timeInput_TaskEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.timeInput_TaskEnd.MonthCalendar.DisplayMonth = new System.DateTime(2007, 10, 1, 0, 0, 0, 0);
            this.timeInput_TaskEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.timeInput_TaskEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.timeInput_TaskEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.timeInput_TaskEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.timeInput_TaskEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.timeInput_TaskEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.timeInput_TaskEnd.MonthCalendar.TodayButtonVisible = true;
            this.timeInput_TaskEnd.MonthCalendar.Visible = false;
            this.timeInput_TaskEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.timeInput_TaskEnd.Name = "timeInput_TaskEnd";
            this.timeInput_TaskEnd.Size = new System.Drawing.Size(142, 21);
            this.timeInput_TaskEnd.TabIndex = 12;
            // 
            // chk_taskIsMonday
            // 
            this.chk_taskIsMonday.AutoSize = true;
            this.chk_taskIsMonday.BackColor = System.Drawing.Color.White;
            this.chk_taskIsMonday.Checked = true;
            this.chk_taskIsMonday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_taskIsMonday.ForeColor = System.Drawing.Color.Black;
            this.chk_taskIsMonday.Location = new System.Drawing.Point(99, 199);
            this.chk_taskIsMonday.Name = "chk_taskIsMonday";
            this.chk_taskIsMonday.Size = new System.Drawing.Size(60, 16);
            this.chk_taskIsMonday.TabIndex = 13;
            this.chk_taskIsMonday.Text = "星期一";
            this.chk_taskIsMonday.UseVisualStyleBackColor = false;
            // 
            // lab_TaskEndTime
            // 
            this.lab_TaskEndTime.AutoSize = true;
            this.lab_TaskEndTime.BackColor = System.Drawing.Color.White;
            this.lab_TaskEndTime.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TaskEndTime.ForeColor = System.Drawing.Color.Black;
            this.lab_TaskEndTime.Location = new System.Drawing.Point(273, 71);
            this.lab_TaskEndTime.Name = "lab_TaskEndTime";
            this.lab_TaskEndTime.Size = new System.Drawing.Size(68, 19);
            this.lab_TaskEndTime.TabIndex = 11;
            this.lab_TaskEndTime.Text = "结束时间:";
            // 
            // timeInput_TaskStart
            // 
            this.timeInput_TaskStart.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.timeInput_TaskStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.timeInput_TaskStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.timeInput_TaskStart.ButtonClear.Tooltip = "";
            this.timeInput_TaskStart.ButtonClear.Visible = true;
            this.timeInput_TaskStart.ButtonCustom.DisplayPosition = 1;
            this.timeInput_TaskStart.ButtonCustom.Tooltip = "";
            this.timeInput_TaskStart.ButtonCustom.Visible = true;
            this.timeInput_TaskStart.ButtonCustom2.Tooltip = "";
            this.timeInput_TaskStart.ButtonDropDown.Tooltip = "";
            this.timeInput_TaskStart.ButtonDropDown.Visible = true;
            this.timeInput_TaskStart.ButtonFreeText.Tooltip = "";
            this.timeInput_TaskStart.FocusHighlightEnabled = true;
            this.timeInput_TaskStart.ForeColor = System.Drawing.Color.Black;
            this.timeInput_TaskStart.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime;
            this.timeInput_TaskStart.IsPopupCalendarOpen = false;
            this.timeInput_TaskStart.Location = new System.Drawing.Point(113, 68);
            // 
            // 
            // 
            this.timeInput_TaskStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.timeInput_TaskStart.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.timeInput_TaskStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.timeInput_TaskStart.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.timeInput_TaskStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.timeInput_TaskStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.timeInput_TaskStart.MonthCalendar.DisplayMonth = new System.DateTime(2007, 10, 1, 0, 0, 0, 0);
            this.timeInput_TaskStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.timeInput_TaskStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.timeInput_TaskStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.timeInput_TaskStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.timeInput_TaskStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.timeInput_TaskStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.timeInput_TaskStart.MonthCalendar.TodayButtonVisible = true;
            this.timeInput_TaskStart.MonthCalendar.Visible = false;
            this.timeInput_TaskStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.timeInput_TaskStart.Name = "timeInput_TaskStart";
            this.timeInput_TaskStart.Size = new System.Drawing.Size(132, 21);
            this.timeInput_TaskStart.TabIndex = 10;
            // 
            // lab_TaskStartTime
            // 
            this.lab_TaskStartTime.AutoSize = true;
            this.lab_TaskStartTime.BackColor = System.Drawing.Color.White;
            this.lab_TaskStartTime.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TaskStartTime.ForeColor = System.Drawing.Color.Black;
            this.lab_TaskStartTime.Location = new System.Drawing.Point(6, 71);
            this.lab_TaskStartTime.Name = "lab_TaskStartTime";
            this.lab_TaskStartTime.Size = new System.Drawing.Size(68, 19);
            this.lab_TaskStartTime.TabIndex = 4;
            this.lab_TaskStartTime.Text = "开始时间:";
            // 
            // textBoxX_TaskName
            // 
            this.textBoxX_TaskName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX_TaskName.Border.Class = "TextBoxBorder";
            this.textBoxX_TaskName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_TaskName.ButtonCustom.Tooltip = "";
            this.textBoxX_TaskName.ButtonCustom2.Tooltip = "";
            this.textBoxX_TaskName.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX_TaskName.ForeColor = System.Drawing.Color.Black;
            this.textBoxX_TaskName.Location = new System.Drawing.Point(113, 29);
            this.textBoxX_TaskName.Name = "textBoxX_TaskName";
            this.textBoxX_TaskName.PreventEnterBeep = true;
            this.textBoxX_TaskName.Size = new System.Drawing.Size(132, 21);
            this.textBoxX_TaskName.TabIndex = 3;
            this.textBoxX_TaskName.WatermarkText = "输入任务名称";
            // 
            // lab_taskName
            // 
            this.lab_taskName.AutoSize = true;
            this.lab_taskName.BackColor = System.Drawing.Color.White;
            this.lab_taskName.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_taskName.ForeColor = System.Drawing.Color.Black;
            this.lab_taskName.Location = new System.Drawing.Point(6, 32);
            this.lab_taskName.Name = "lab_taskName";
            this.lab_taskName.Size = new System.Drawing.Size(68, 19);
            this.lab_taskName.TabIndex = 2;
            this.lab_taskName.Text = "任务名称:";
            // 
            // lab_oldAreaFullPath
            // 
            this.lab_oldAreaFullPath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lab_oldAreaFullPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lab_oldAreaFullPath.ForeColor = System.Drawing.Color.Black;
            this.lab_oldAreaFullPath.Location = new System.Drawing.Point(116, 130);
            this.lab_oldAreaFullPath.Name = "lab_oldAreaFullPath";
            this.lab_oldAreaFullPath.Size = new System.Drawing.Size(447, 23);
            this.lab_oldAreaFullPath.TabIndex = 43;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(10, 130);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(97, 23);
            this.labelX2.TabIndex = 33;
            this.labelX2.Text = "原选定区域：";
            // 
            // TimerTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 368);
            this.Controls.Add(this.grp_TaskBaseInfoEdit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimerTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "定时任务参数配置";
            this.Load += new System.EventHandler(this.TimerTaskForm_Load);
            this.grp_TaskBaseInfoEdit.ResumeLayout(false);
            this.grp_TaskBaseInfoEdit.PerformLayout();
            this.pan_TaskBaseInfoSave.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeInput_TaskEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeInput_TaskStart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_TaskBaseInfoEdit;
        private DevComponents.DotNetBar.PanelEx pan_TaskBaseInfoSave;
        private DevComponents.DotNetBar.ButtonX btn_SaveTaskBaseInfo;
        private DevComponents.DotNetBar.ButtonX btn_Cancel;
        private System.Windows.Forms.Label lab_taskDefaultChannelSet;
        private System.Windows.Forms.Label lab_taskDayOffWeek;
        private System.Windows.Forms.CheckBox chk_taskIsSunday;
        private System.Windows.Forms.CheckBox chk_taskIsSaturday;
        private DevComponents.DotNetBar.Controls.Slider slider_TaskEndVolume;
        private System.Windows.Forms.CheckBox chk_taskIsFriday;
        private System.Windows.Forms.Label lab_TaskEndVolume;
        private System.Windows.Forms.CheckBox chk_taskIsThursday;
        private DevComponents.DotNetBar.Controls.Slider slider_TaskStartVolume;
        private System.Windows.Forms.CheckBox chk_taskIsWednesday;
        private System.Windows.Forms.Label lab_TaskStartVolume;
        private System.Windows.Forms.CheckBox chk_taskIsTuesday;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput timeInput_TaskEnd;
        private System.Windows.Forms.CheckBox chk_taskIsMonday;
        private System.Windows.Forms.Label lab_TaskEndTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput timeInput_TaskStart;
        private System.Windows.Forms.Label lab_TaskStartTime;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_TaskName;
        private System.Windows.Forms.Label lab_taskName;
        private DevComponents.DotNetBar.Controls.SwitchButton switchButton1;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx richText_log;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        private DevComponents.DotNetBar.CrumbBar crumbBar_Area;
        private DevComponents.DotNetBar.LabelX lab_notice;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lab_oldAreaFullPath;
    }
}