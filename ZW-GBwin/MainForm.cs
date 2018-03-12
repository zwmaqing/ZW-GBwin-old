using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZW_GBwin
{
    public partial class MainForm : MetroForm
    {
        private bool isClosing = false;
        private string todayWeekString = "";


        public MainForm()
        {
            InitializeComponent();
        }

        #region 点击panelEx_Title控件移动窗口

        Point downPoint;
        private void panelEx_Title_MouseDown(object sender, MouseEventArgs e)
        {
            downPoint = new Point(e.X, e.Y);
        }

        private void panelEx_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - downPoint.X,
                    this.Location.Y + e.Y - downPoint.Y);
            }
        }


        #endregion

        private void btn_CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Max_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btn_Mix_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelEx_Title_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_Max_Click(sender, e);
        }

        private void timerSecond_Tick(object sender, EventArgs e)
        {
            if (!isClosing && lab_TodayDateTime != null)
            {
                DateTime theTine = DateTime.Now;
                if (String.IsNullOrEmpty(todayWeekString) || (theTine.Hour == 0 && theTine.TimeOfDay.Minutes == 0 && theTine.Second == 0))
                {
                    todayWeekString = DataHelper.DataTypeConvert.DateTimeToWeekCNStr(theTine.DayOfWeek);
                }
                if (lab_TodayDateTime.Size.Width > 200)
                {
                    lab_TodayDateTime.Text = todayWeekString + "  " + theTine.ToString("yyyy年MM月dd日 HH:mm:ss");
                }
                else
                {
                    lab_TodayDateTime.Text = todayWeekString + "  " + theTine.ToLongTimeString();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer_Second.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
