namespace StudentManageForm
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.subAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.subStudentList = new System.Windows.Forms.ToolStripMenuItem();
            this.miClass = new System.Windows.Forms.ToolStripMenuItem();
            this.subAddClass = new System.Windows.Forms.ToolStripMenuItem();
            this.subClassList = new System.Windows.Forms.ToolStripMenuItem();
            this.miGrade = new System.Windows.Forms.ToolStripMenuItem();
            this.subGradeLIst = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStudent,
            this.miClass,
            this.miGrade,
            this.miExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miStudent
            // 
            this.miStudent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subAddStudent,
            this.subStudentList});
            this.miStudent.Name = "miStudent";
            this.miStudent.Size = new System.Drawing.Size(68, 21);
            this.miStudent.Text = "学生管理";
            // 
            // subAddStudent
            // 
            this.subAddStudent.Name = "subAddStudent";
            this.subAddStudent.Size = new System.Drawing.Size(180, 22);
            this.subAddStudent.Text = "新增学生";
            this.subAddStudent.Click += new System.EventHandler(this.subAddStudent_Click);
            // 
            // subStudentList
            // 
            this.subStudentList.Name = "subStudentList";
            this.subStudentList.Size = new System.Drawing.Size(180, 22);
            this.subStudentList.Text = "学生列表";
            this.subStudentList.Click += new System.EventHandler(this.subStudentList_Click);
            // 
            // miClass
            // 
            this.miClass.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subAddClass,
            this.subClassList});
            this.miClass.Name = "miClass";
            this.miClass.Size = new System.Drawing.Size(68, 21);
            this.miClass.Text = "班级管理";
            // 
            // subAddClass
            // 
            this.subAddClass.Name = "subAddClass";
            this.subAddClass.Size = new System.Drawing.Size(180, 22);
            this.subAddClass.Text = "新增班级";
            this.subAddClass.Click += new System.EventHandler(this.subAddClass_Click);
            // 
            // subClassList
            // 
            this.subClassList.Name = "subClassList";
            this.subClassList.Size = new System.Drawing.Size(180, 22);
            this.subClassList.Text = "班级列表";
            this.subClassList.Click += new System.EventHandler(this.subClassList_Click);
            // 
            // miGrade
            // 
            this.miGrade.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subGradeLIst});
            this.miGrade.Name = "miGrade";
            this.miGrade.Size = new System.Drawing.Size(68, 21);
            this.miGrade.Text = "年级管理";
            // 
            // subGradeLIst
            // 
            this.subGradeLIst.Name = "subGradeLIst";
            this.subGradeLIst.Size = new System.Drawing.Size(180, 22);
            this.subGradeLIst.Text = "年级列表";
            this.subGradeLIst.Click += new System.EventHandler(this.subGradeLIst_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(68, 21);
            this.miExit.Text = "退出系统";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "学生管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miStudent;
        private System.Windows.Forms.ToolStripMenuItem subAddStudent;
        private System.Windows.Forms.ToolStripMenuItem subStudentList;
        private System.Windows.Forms.ToolStripMenuItem miClass;
        private System.Windows.Forms.ToolStripMenuItem subAddClass;
        private System.Windows.Forms.ToolStripMenuItem subClassList;
        private System.Windows.Forms.ToolStripMenuItem miGrade;
        private System.Windows.Forms.ToolStripMenuItem subGradeLIst;
        private System.Windows.Forms.ToolStripMenuItem miExit;
    }
}