using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigMerge.WinForm
{
    public partial class MainForm : FormBase
    {
        RecipeService service = new RecipeService();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var dlg = new ConfigForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            dataGridView1.DataSource = service.Get();
            entity = null;
            SetButtonEnable(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitGridView(dataGridView1);
            LoadData();
        }

        private void InitGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
           var column = Create(dgv, "编号", "Id");
            column.Visible = false;
            Create(dgv, "分类", "Classify");
            Create(dgv, "名称", "Name");
            Create(dgv, "输入目录", "InputConfigFolder", 300);
            Create(dgv, "输出文件", "OutputConfigFile",300);
        }
        private DataGridViewColumn Create(DataGridView dgv,string header,string propertyName,int size = 100)
        {
            var column = new DataGridViewTextBoxColumn();
            column.HeaderText = header;
            column.DataPropertyName = propertyName;
            column.Width = size;
            column.ReadOnly = true;
            dgv.Columns.Add(column);
            return column;
        }
        RecipeConfigEntity entity;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }
            var row = dataGridView1.Rows[e.RowIndex];
            row.Selected = true;
            entity = (RecipeConfigEntity)row.DataBoundItem;
            SetButtonEnable(true);
        }
        private void SetButtonEnable(bool enable)
        {
            btnDelete.Enabled = enable;
            btnEdit.Enabled = enable;
            btnExcute.Enabled = enable;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var dlg = new ConfigForm(service.Get(entity.Id));
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认删除当前选中的记录？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                service.Delete(entity.Id);
                LoadData();
            }
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {

            var dlg = new ConfigForm(service.Get(entity.Id), null);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //LoadData();
            }
        }
    }
}
