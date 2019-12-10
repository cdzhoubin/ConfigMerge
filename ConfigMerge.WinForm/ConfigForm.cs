using ConfigMerge.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigMerge.WinForm
{
    public partial class ConfigForm : DialogFormBase
    {
        public ConfigForm()
        {
            Entity = new RecipeConfigEntity();
            InitializeComponent();
            this.Text = "新增配置";
            _isEdit = false;
        }
        public ConfigForm(RecipeConfigEntity entity, bool? isEdit = true)
        {
            InitializeComponent();
            Entity = entity;
            _isEdit = isEdit;
            this.Text = isEdit == null ? "执行合并" : (isEdit.Value ? "修改配置" : "新增配置");

        }
        private bool? _isEdit;
        private RecipeConfigEntity Entity { get; set; }
        private Dictionary<string, Control> dic = new Dictionary<string, Control>();

        private void btnBrowInputFile_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Entity.InputConfigFolder;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.config");
                if (files.Any())
                {
                    Entity.InputConfigFolder = folderBrowserDialog1.SelectedPath;
                    StringBuilder sb = new StringBuilder("你已经成功选择路径：");
                    sb.AppendLine(Entity.InputConfigFolder);
                    sb.AppendLine("文件合并将按如下顺序进行：");
                    foreach(var file in files.OrderBy(p => p))
                    {
                        sb.AppendLine(file.Replace(Entity.InputConfigFolder,""));
                    }
                    MessageBox.Show(sb.ToString());
                } else
                {
                    MessageBox.Show("选择的路径中没有.config文件。");
                }
            }
        }

        private void btnBrowOutputFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Entity.OutputConfigFile = saveFileDialog1.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                return;
            }
            RecipeService service = new RecipeService();
            var result = service.Save(Entity);
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result, "错误");
                return;
            }
            MessageBox.Show(result);
            DialogResult = DialogResult.OK;
        }

        private bool Valid()
        {
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(Entity, null, null);
            Validator.TryValidateObject(Entity, context, errors, true);

            foreach (var keypair in dic)
            {
                errorProvider1.SetError(keypair.Value, "");
            }
            if (errors.Any())
            {
                errors.ForEach(p =>
                {
                    foreach (var w in p.MemberNames)
                    {
                        errorProvider1.SetError(dic[w], p.ErrorMessage);
                    }
                }
                );
                return false;
            }
            return true;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            BindTextBox(txtName, "Name");
            BindTextBox(txtType, "Classify");
            BindTextBox(txtOutputFile, "OutputConfigFile");
            Binding bingding = BindTextBox(txtInputFolder, "InputConfigFolder");
           

            btnSave.Visible = _isEdit != null;
            btnMerge.Visible = _isEdit == null;
            if(_isEdit == null)
            {
                this.Width -= 25;
                btnBrowInputFile.Visible = false;
                btnBrowOutputFile.Visible = false;
                txtName.ReadOnly = true;
                txtType.ReadOnly = true;
            }
        }

        //private void Bingding_Parse(object sender, ConvertEventArgs e)
        //{
        //    List<string> list = new List<string>();
        //    if (e.Value != null)
        //    {
        //        var strs = e.Value.ToString().Replace("\r", "").Split('\n').ToList();

        //        strs.ForEach(p =>
        //        {
        //            if (string.IsNullOrWhiteSpace(p))
        //            {
        //                return;
        //            }
        //            list.Add(p);
        //        });
        //    }
        //    e.Value = list;
        //}

        //private void Bingding_Format(object sender, ConvertEventArgs e)
        //{
        //    if (e.Value == null)
        //    {
        //        e.Value = "";
        //        return;
        //    }
        //    var list = (List<string>)e.Value;
        //    StringBuilder sb = new StringBuilder();
        //    list.ForEach(p => sb.AppendFormat("{0}\n", p));
        //    e.Value = sb.ToString();
        //}

        private Binding BindTextBox(TextBoxBase txt, string propertyName)
        {
            dic.Add(propertyName, txt);
            Binding bingding = new Binding("Text", Entity, propertyName);
            txt.DataBindings.Add(bingding);
            txt.Tag = propertyName;
            return bingding;
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            RecipeService recipeService = new RecipeService();
            string result;
            try
            {
               result = recipeService.Merge(Entity);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result);
                return;
            }
            MessageBox.Show("文件创建成功：" + Entity.OutputConfigFile);
            DialogResult = DialogResult.OK;
        }

        
    }
}
