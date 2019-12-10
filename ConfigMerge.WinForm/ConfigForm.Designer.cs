namespace ConfigMerge.WinForm
{
    partial class ConfigForm
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
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.btnBrowInputFile = new System.Windows.Forms.Button();
            this.btnBrowOutputFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnMerge = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtInputFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(248, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "分类";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "输入目录";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "输出文件";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(79, 24);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(458, 21);
            this.txtType.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 69);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(458, 21);
            this.txtName.TabIndex = 2;
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Location = new System.Drawing.Point(78, 160);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.ReadOnly = true;
            this.txtOutputFile.Size = new System.Drawing.Size(458, 21);
            this.txtOutputFile.TabIndex = 2;
            // 
            // btnBrowInputFile
            // 
            this.btnBrowInputFile.Location = new System.Drawing.Point(542, 113);
            this.btnBrowInputFile.Name = "btnBrowInputFile";
            this.btnBrowInputFile.Size = new System.Drawing.Size(30, 23);
            this.btnBrowInputFile.TabIndex = 0;
            this.btnBrowInputFile.Text = "...";
            this.btnBrowInputFile.UseVisualStyleBackColor = true;
            this.btnBrowInputFile.Click += new System.EventHandler(this.btnBrowInputFile_Click);
            // 
            // btnBrowOutputFile
            // 
            this.btnBrowOutputFile.Location = new System.Drawing.Point(542, 158);
            this.btnBrowOutputFile.Name = "btnBrowOutputFile";
            this.btnBrowOutputFile.Size = new System.Drawing.Size(30, 23);
            this.btnBrowOutputFile.TabIndex = 0;
            this.btnBrowOutputFile.Text = "...";
            this.btnBrowOutputFile.UseVisualStyleBackColor = true;
            this.btnBrowOutputFile.Click += new System.EventHandler(this.btnBrowOutputFile_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Web.config";
            this.saveFileDialog1.Filter = "配置文件|*.config";
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(248, 216);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 0;
            this.btnMerge.Text = "合并";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtInputFolder
            // 
            this.txtInputFolder.Location = new System.Drawing.Point(78, 115);
            this.txtInputFolder.Name = "txtInputFolder";
            this.txtInputFolder.ReadOnly = true;
            this.txtInputFolder.Size = new System.Drawing.Size(458, 21);
            this.txtInputFolder.TabIndex = 2;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "请配置配置文件目录，其中应该包括配置文件";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 263);
            this.Controls.Add(this.txtInputFolder);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowOutputFile);
            this.Controls.Add(this.btnBrowInputFile);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnSave);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.Button btnBrowInputFile;
        private System.Windows.Forms.Button btnBrowOutputFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtInputFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}