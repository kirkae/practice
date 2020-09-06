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
    public partial class AddClassForm : Form
    {
        public AddClassForm()
        {
            InitializeComponent();
        }

        private void AddClassForm_Load(object sender, EventArgs e)
        {
            InitGradeList();
        }

        private void InitGradeList()
        {
            string sql = "select GradeId,GradeName from GradeInfo where IsDeleted=0";
            DataTable dtGradeList = SqlHelper.GetDataTable(sql);

            comboBoxGrade.DataSource = dtGradeList;//年级数据--相绑定
            comboBoxGrade.DisplayMember = "GradeName";//显示的内容
            comboBoxGrade.ValueMember = "GradeId";//值

            //comboBoxGrade.SelectedIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //信息获取
            string className = textBoxClassName.Text.Trim();
            int gradeId = (int)comboBoxGrade.SelectedValue;
            string remark = textBoxRemark.Text.Trim();
            //判断是否为空
            if (string.IsNullOrEmpty(className))
            {
                MessageBox.Show("班级名称不能为空","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //判断是否存在
            {
                string sql = "select count(1) from ClassInfo where ClassName=@ClassName and GradeId=@GradeId and IsDeleted=0";
                SqlParameter[] paras =
                {
                    new SqlParameter("@ClassName",className),
                    new SqlParameter("@GradeId",gradeId)
                };
                object oCount = SqlHelper.ExecuteScalar(sql,paras);
                if (oCount==null||oCount==DBNull.Value||((int)oCount)==0)
                {
                    //添加操作
                    string sqlAdd = "insert into ClassInfo(ClassName,GradeId,Remark) values(@ClassName,@GradeId,@Remark)";
                    SqlParameter[] parasAdd =
                    {
                        new SqlParameter("@ClassName",className),
                        new SqlParameter("@GradeId",gradeId),
                        new SqlParameter("@Remark",remark)
                    };
                    //执行并返回值
                    int count = SqlHelper.ExecuteNonQuery(sqlAdd,parasAdd);
                    if (count>0)
                    {
                        MessageBox.Show($"班级：{className}添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("班级已存在","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
