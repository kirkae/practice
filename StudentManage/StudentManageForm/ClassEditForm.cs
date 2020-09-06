using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManageForm
{
    public partial class ClassEditForm : Form
    {
        public ClassEditForm()
        {
            InitializeComponent();
        }

        private int classId = 0;
        private Action reLoad = null;

        private void ClassEditForm_Load(object sender, EventArgs e)
        {
            InitGradeList();
            InitClassInf();
        }

        private void InitClassInf()
        {
            if (this.Tag != null)
            {
                TagObject tagObject = (TagObject)this.Tag;
                classId = tagObject.EditId;
                reLoad = tagObject.ReLoad;
            }

            string sql = "select ClassName,GradeId,Remark from ClassInfo where ClassId=@ClassId";
            SqlParameter paraId = new SqlParameter("@ClassId", classId);
            SqlDataReader dr = SqlHelper.ExecuteReader(sql, paraId);
            //读取数据，读一条，丢一条
            if (dr.Read())
            {
                textBoxClassName.Text = dr["ClassName"].ToString();
                textBoxRemark.Text = dr["Remark"].ToString();           
                int gradeId = (int)dr["GradeId"];
                comboBoxGrade.SelectedValue = gradeId;
            }
            dr.Close();
        }

        private void InitGradeList()
        {
            string sql = "select GradeId,GradeName from GradeInfo";
            DataTable dtGradeList = SqlHelper.GetDataTable(sql);

            comboBoxGrade.DataSource = dtGradeList;//年级数据--相绑定
            comboBoxGrade.DisplayMember = "GradeName";//显示的内容
            comboBoxGrade.ValueMember = "GradeId";//值
        }

        private void buttonAEdit_Click(object sender, EventArgs e)
        {
            string className = textBoxClassName.Text.Trim();
            int gradeId = (int)comboBoxGrade.SelectedValue;
            string remark = textBoxRemark.Text.Trim();

            //判断班级是否为空
            if (string.IsNullOrEmpty(className))
            {
                MessageBox.Show("班级不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //判断班级是否存在
            string sql = "select count(1) from ClassInfo where ClassName=@ClassName and GradeId=@GradeId and ClassId<>@ClassId";
            SqlParameter[] paras =
            {
                new SqlParameter("@ClassName",className),
                new SqlParameter("@ClassId",classId),
                new SqlParameter("@GradeId",gradeId)
            };

            Object o = SqlHelper.ExecuteScalar(sql,paras);

            if (o == null || o == DBNull.Value || ((int)o) == 0)
            {
                //修改
                string sqlUpdate = "update ClassInfo set ClassName=@ClassName,GradeId=@GradeId,Remark=@Remark where ClassId=@ClassId";
                SqlParameter[] parasUpdate =
                {
                    new SqlParameter("@ClassName",className),
                    new SqlParameter("@GradeId",gradeId),
                    new SqlParameter("@Remark",remark),
                    new SqlParameter("@ClassId",classId)
                };

                int count = SqlHelper.ExecuteNonQuery(sqlUpdate,parasUpdate);
                if (count>0)
                {
                    MessageBox.Show($"班级：{className}修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //提示成功后，刷新班级列表，列表页数据刷新方法赋给委托，值传委托后，修改页面后，调用委托，
                    reLoad.Invoke();
                }
                else
                {
                    MessageBox.Show("添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("该班级已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
