using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZW_GBwin.Model;

namespace ZW_GBwin
{
    public partial class AreaForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        ZWGB_Area _area;

        public AreaForm(ZWGB_Area area)
        {
            InitializeComponent();

            _area = area;
        }

        private void AreaForm_Load(object sender, EventArgs e)
        {
            txt_AreaName.Text = _area.AreaName;
        }

        private void btn_SaveArea_Click(object sender, EventArgs e)
        {
            if (txt_AreaName.Text.Length > 0)
            {
                _area.AreaName = txt_AreaName.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                txt_AreaName.Focus();
            }
        }
    }
}
