using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManageForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void subAddStudent_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.MdiParent = this;
            addStudentForm.Show();
        }

        private void subStudentList_Click(object sender, EventArgs e)
        {
            bool bl = FormCheck(typeof(StudentListForm).Name);
            if (!bl)                                                            //如果窗体没打开,则创建新窗体，同一窗体只允许打开单个
            {
                StudentListForm studentListForm = new StudentListForm();
                studentListForm.MdiParent = this;
                studentListForm.Show();
            }           
        }
        
        //窗体检查是否打开，同一窗体只允许打开单个
        private bool FormCheck(string formName)
        {
            bool bl = false;
            foreach (Form f in Application.OpenForms) //遍历打开的窗体
            {
                if (f.Name == formName)
                {
                    bl = true;
                    f.Activate(); //窗体已打开时，激活该窗体
                    break;        
                }
            }
            return bl;
        }

        private void subAddClass_Click(object sender, EventArgs e)    
        {
            AddClassForm addClassForm = new AddClassForm();
            addClassForm.MdiParent = this;
            addClassForm.Show();
        }

        private void subClassList_Click(object sender, EventArgs e)
        {
            bool bl = FormCheck(typeof(ClassListForm).Name);
            if (!bl)
            {
                ClassListForm classListForm = new ClassListForm();
                classListForm.MdiParent = this;
                classListForm.Show();
            }
        }

        private void subGradeLIst_Click(object sender, EventArgs e)
        {
            bool bl = FormCheck(typeof(GradeListForm).Name);
            if (!bl)
            {
                GradeListForm gradeListForm = new GradeListForm();
                gradeListForm.MdiParent = this;
                gradeListForm.Show();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确定是否退出系统？","退出提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                Application.ExitThread(); //退出当前线程的消息循环，并关闭该线程的所有窗体
            }
            else
            {
                e.Cancel = true;  //取消该事件
            }
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
