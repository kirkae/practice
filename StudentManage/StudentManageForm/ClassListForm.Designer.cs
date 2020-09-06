namespace StudentManageForm
{
    partial class ClassListForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeleted = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxGrade = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvClassList = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ClassId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonDeleted);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.textBoxClass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxGrade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件：";
            // 
            // buttonDeleted
            // 
            this.buttonDeleted.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDeleted.Location = new System.Drawing.Point(514, 35);
            this.buttonDeleted.Name = "buttonDeleted";
            this.buttonDeleted.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleted.TabIndex = 5;
            this.buttonDeleted.Text = "删除";
            this.buttonDeleted.UseVisualStyleBackColor = false;
            this.buttonDeleted.Click += new System.EventHandler(this.buttonDeleted_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonFind.Location = new System.Drawing.Point(423, 35);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 4;
            this.buttonFind.Text = "查询";
            this.buttonFind.UseVisualStyleBackColor = false;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // textBoxClass
            // 
            this.textBoxClass.Location = new System.Drawing.Point(273, 36);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.Size = new System.Drawing.Size(127, 21);
            this.textBoxClass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "班级：";
            // 
            // comboBoxGrade
            // 
            this.comboBoxGrade.FormattingEnabled = true;
            this.comboBoxGrade.Location = new System.Drawing.Point(59, 38);
            this.comboBoxGrade.Name = "comboBoxGrade";
            this.comboBoxGrade.Size = new System.Drawing.Size(138, 20);
            this.comboBoxGrade.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "年级：";
            // 
            // dgvClassList
            // 
            this.dgvClassList.AllowUserToAddRows = false;
            this.dgvClassList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.ClassId,
            this.CLassName,
            this.GradeName,
            this.Remark,
            this.Edit,
            this.Delete});
            this.dgvClassList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvClassList.Location = new System.Drawing.Point(0, 122);
            this.dgvClassList.Name = "dgvClassList";
            this.dgvClassList.RowTemplate.Height = 23;
            this.dgvClassList.Size = new System.Drawing.Size(631, 283);
            this.dgvClassList.TabIndex = 1;
            this.dgvClassList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassList_CellContentClick);
            // 
            // Check
            // 
            this.Check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Check.HeaderText = "选择";
            this.Check.Name = "Check";
            this.Check.Width = 35;
            // 
            // ClassId
            // 
            this.ClassId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClassId.DataPropertyName = "ClassId";
            this.ClassId.HeaderText = "编号";
            this.ClassId.Name = "ClassId";
            this.ClassId.ReadOnly = true;
            this.ClassId.Width = 54;
            // 
            // CLassName
            // 
            this.CLassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CLassName.DataPropertyName = "CLassName";
            this.CLassName.HeaderText = "班名";
            this.CLassName.Name = "CLassName";
            this.CLassName.ReadOnly = true;
            this.CLassName.Width = 54;
            // 
            // GradeName
            // 
            this.GradeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GradeName.DataPropertyName = "GradeName";
            this.GradeName.HeaderText = "年级";
            this.GradeName.Name = "GradeName";
            this.GradeName.ReadOnly = true;
            this.GradeName.Width = 54;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "描述";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.NullValue = "修改";
            this.Edit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Edit.HeaderText = "修改";
            this.Edit.Name = "Edit";
            this.Edit.Width = 35;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.NullValue = "删除";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Delete.HeaderText = "删除";
            this.Delete.Name = "Delete";
            this.Delete.Width = 35;
            // 
            // ClassListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 405);
            this.Controls.Add(this.dgvClassList);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClassListForm";
            this.Text = "班级列表";
            this.Load += new System.EventHandler(this.ClassListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxGrade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvClassList;
        private System.Windows.Forms.Button buttonDeleted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}