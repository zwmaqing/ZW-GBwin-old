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
    public partial class TaskProjectForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        private DbDataService _dbHelper;
        private System.Windows.Forms.BindingSource _resourcesClass = new BindingSource();
        private System.Windows.Forms.BindingSource _resources = new BindingSource();

        Int64 taskID;
        //

        public TaskProjectForm(BindingSource resourcesClass, BindingSource resources, DbDataService dbHelper)
        {
            InitializeComponent();

            _dbHelper = dbHelper;
            _resourcesClass = resourcesClass;
            _resources = resources;
        }

        private void TaskProjectForm_Load(object sender, EventArgs e)
        {
            loadResourcesClassToUi();
        }

        private void loadResourcesClass()
        {
            _resourcesClass.DataSource = _dbHelper.GetResourcesClass();
            _resourcesClass.DataMember = "Table0";
            _resourcesClass.Sort = "ClassAlias";
        }

        private void loadResourcesClassToUi()
        {
            loadResourcesClass();//获取数据

            if (_resourcesClass != null && advTree_ResourceClass != null)
            {
                advTree_ResourceClass.DataSource = _resourcesClass;
                advTree_ResourceClass.DisplayMembers = "ClassAlias";
                advTree_ResourceClass.GroupingMembers = "ClassifyName";

                if (advTree_ResourceClass.Columns.Count > 0)
                    advTree_ResourceClass.Columns[0].Text = "资源分类";
                // comboBoxEx_ResourceClass.DataSource = resourcesClass;
                // comboBoxEx_ResourceClass.DisplayMember = "ClassAlias";
            }
        }

        private void loadResourcesForResourcesClass(long resourcesClassId)
        {
            _resources.DataSource = _dbHelper.GetResourcesForClass(resourcesClassId);
            _resources.DataMember = "Table0";
            _resources.Sort = "FileName";
        }

        private void loadResourcesForClassToDataGridUi(DataRowView resourcesClassInfoRow)
        {
            long classId = DataHelper.DataTypeConvert.GetTheObjectInt64(resourcesClassInfoRow["RID"]);
            loadResourcesForResourcesClass(classId);
            dataGridViewX_ResourceProject.DataSource = _resources;
            setResourcesInfoGridViewColumns();
        }

        private void setResourcesInfoGridViewColumns()
        {
            if (dataGridViewX_ResourceProject.Tag != null)
            {
                return;
            }
            for (int i = 0; i < dataGridViewX_ResourceProject.Columns.Count; i++)
            {
                dataGridViewX_ResourceProject.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                switch (dataGridViewX_ResourceProject.Columns[i].Name)
                {
                    case "FileName":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "资源名称";
                            break;
                        }
                    case "DurationTime":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "时长";

                            break;
                        }
                    case "IsExist":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "存在";
                            break;
                        }
                    case "IsUsed":
                        {
                            dataGridViewX_ResourceProject.Columns[i].HeaderText = "已引用";
                            break;
                        }
                    default:
                        {
                            dataGridViewX_ResourceProject.Columns[i].Visible = false;
                            break;
                        }
                }
            }
            dataGridViewX_ResourceProject.Tag = true;
        }

        private void advTree_ResourceClass_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            loadResourcesForClassToDataGridUi((DataRowView)_resourcesClass.Current);
        }

        private void btn_SaveAndSync_Click(object sender, EventArgs e)
        {
            circularProgress1.IsRunning = true;
        }

        private void dataGridViewX_ResourceProject_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          //  e.RowIndex

        }

        private void listBoxAdv1_ItemDoubleClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
