using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentManageForm
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        //private int stuId = 0;
        //public int pubStuId = 0;

        //public AddStudentForm(int _stuId)
        //{
        //    InitializeComponent();
        //    stuId = _stuId;
        //}

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            LoadClasses();
            radioButtonMale.Checked = true;
        }

        private void LoadClasses()
        {
            string sql = "select ClassId,ClassName,GradeName from ClassInfo c,GradeInfo g where c.GradeId=g.GradeId and c.IsDeleted=0 and g.IsDeleted=0";

            //加载数据
            DataTable dtClasses = SqlHelper.GetDataTable(sql);
            //组装
            if (dtClasses.Rows.Count > 0)
            {
                foreach (DataRow dr in dtClasses.Rows)
                {
                    string className = dr["ClassName"].ToString();
                    string gradeName = dr["GradeName"].ToString();
                    dr["ClassName"] = className + " " + gradeName;
                }
            }

            comboBoxClass.DataSource = dtClasses;
            comboBoxClass.DisplayMember = "ClassName";
            comboBoxClass.ValueMember = "ClassId";
            //comboBoxClass.SelectedIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //获取页面信息
            string stuName = textBoxStuName.Text.Trim();
            int classId = (int)comboBoxClass.SelectedValue;
            string sex = radioButtonMale.Checked ? radioButtonMale.Text : radioButtonFemale.Text;
            string phone = textBoxPhone.Text.Trim();

            if (string.IsNullOrEmpty(stuName))
            {
                MessageBox.Show("姓名不能为空","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("电话不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = "select count(1) from StudentInfo where StuName=@StuName and Phone=@Phone and IsDeleted=0";
            SqlParameter[] paras =
            {
                new SqlParameter("@StuName",stuName),
                new SqlParameter("@Phone",phone)
            };

            object o = SqlHelper.ExecuteScalar(sql,paras);

            if (o==null||o==DBNull.Value||((int)o)==0)
            {
                string sqlAdd = "insert into StudentInfo(StuName,ClassId,Sex,Phone) Values(@StuName,@ClassId,@Sex,@Phone)";
                SqlParameter[] parasAdd =
                {
                    new SqlParameter("@StuName",stuName),
                    new SqlParameter("@ClassId",classId),
                    new SqlParameter("@Sex",sex),
                    new SqlParameter("@Phone",phone)
                };

                int count = SqlHelper.ExecuteNonQuery(sqlAdd,parasAdd);
                if (count>0)
                {
                    MessageBox.Show($"学生：{stuName}添加成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("该学生已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
