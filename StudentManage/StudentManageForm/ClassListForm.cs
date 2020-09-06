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
    public partial class ClassListForm : Form
    {
        public ClassListForm()
        {
            InitializeComponent();
        }

        private Action reLoad = null;

        private void ClassListForm_Load(object sender, EventArgs e)
        {
            InitGrades();//加载年级列表
            InitClasses();//加载班级列表
        }

        private void InitClasses()
        {
            string sql = "select ClassId,ClassName,GradeName,Remark from ClassInfo c inner join GradeInfo g on c.GradeId = g.GradeId where c.IsDeleted=0 and g.IsDeleted=0";
            DataTable dtClasses = SqlHelper.GetDataTable(sql);

            dgvClassList.DataSource = dtClasses;
        }

        private void InitGrades()
        {
            string sql = "select GradeId,GradeName from GradeInfo where Isdeleted=0";
            DataTable dtGradeList = SqlHelper.GetDataTable(sql);

            //添加一个“请选择”相，但不加进数据库
            DataRow dataRow = dtGradeList.NewRow();//添加行
            dataRow["GradeId"] = 0;
            dataRow["GradeName"] = "请选择";
            //dtGradeList.Rows.Add(dataRow);//添加到最后一行
            dtGradeList.Rows.InsertAt(dataRow,0);//添加到指定行

            comboBoxGrade.DataSource = dtGradeList;//年级数据--相绑定
            comboBoxGrade.DisplayMember = "GradeName";//显示的内容
            comboBoxGrade.ValueMember = "GradeId";//值

            comboBoxGrade.SelectedIndex = 0;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            int gradeId = (int)comboBoxGrade.SelectedValue;
            string className = textBoxClass.Text.Trim();

            string sql = "select ClassId,ClassName,GradeName,Remark from ClassInfo c inner join GradeInfo g on c.GradeId = g.GradeId";
            sql += " where 1=1 and c.Isdeleted=0 and g.IsDeleted=0 ";
            if (gradeId>0)
            {
                sql += " and c.GradeId=@GradeId";
            }

            if (!string.IsNullOrEmpty(className))
            {
                sql += " and ClassName like @ClassName";
            }

            SqlParameter[] paras =
            {
                new SqlParameter("@GradeId",gradeId),
                new SqlParameter("@ClassName","%"+className+"%")
            };

            DataTable dtClasses = SqlHelper.GetDataTable(sql,paras);

            dgvClassList.DataSource = dtClasses;

        }

        private void dgvClassList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                //判断获取的单元格是修改还是删除
                DataGridViewCell cell = dgvClassList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataRow dr = (dgvClassList.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                int classId = (int)dr["ClassId"];

                if (cell is DataGridViewCell && cell.FormattedValue.ToString()=="修改")
                {
                    reLoad = InitClasses;
                    ClassEditForm classEditForm = new ClassEditForm();
                    classEditForm.Tag = new TagObject(){ ReLoad=this.reLoad,EditId=classId};
                    classEditForm.MdiParent = this.MdiParent;
                    classEditForm.Show();
                }
                else if (cell is DataGridViewCell && cell.FormattedValue.ToString() == "删除")
                {
                    if (MessageBox.Show("确定删除该班级及其学生信息吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //假删除
                        string sqlDelStu = "update StudentInfo set IsDeleted=1 where ClassId=@ClassId";
                        string sqlDelClass = "update ClassInfo set IsDeleted=1 where ClassId=@ClassId";
                        //string sqlDelClass = "delete from ClassInfo where ClassId=@ClassId";//真删除
                        //string sqlDelStu = "delete from StudentInfo where ClassId=@ClassId";
                        SqlParameter[] para = { new SqlParameter("@ClassId", classId) };
                        List<CommandInfo> listComs = new List<CommandInfo>();
                        CommandInfo comStudent = new CommandInfo() { CommandText = sqlDelStu, IsProc = false, Parameters = para };
                        listComs.Add(comStudent);
                        CommandInfo comClass = new CommandInfo() { CommandText = sqlDelClass, IsProc = false, Parameters = para };
                        listComs.Add(comClass);
                        bool bl = SqlHelper.ExecuteTrans(listComs);

                        if (bl)
                        {
                            MessageBox.Show("该班级信息删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dtClass = (DataTable)dgvClassList.DataSource;
                            dtClass.Rows.Remove(dr);
                            dgvClassList.DataSource = dtClass;
                        }
                        else
                        {
                            MessageBox.Show("该班级信息删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void buttonDeleted_Click(object sender, EventArgs e)
        {
            List<int> listIds = new List<int>();
            for (int i = 0; i < dgvClassList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = dgvClassList.Rows[i].Cells["Check"] as DataGridViewCheckBoxCell;
                bool chk = Convert.ToBoolean(cell.Value);
                if (chk)
                {
                    DataRow dr = (dgvClassList.Rows[i].DataBoundItem as DataRowView).Row;
                    int classId = (int)dr["ClassId"];
                    listIds.Add(classId);
                }
            }

            if (listIds.Count == 0)
            {
                MessageBox.Show("请选择要删除的班级信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("确定删除该班级及其学生信息吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sqlDelStu = "update StudentInfo set IsDeleted=1 where ClassId=@ClassId";
                    string sqlDelClass = "update ClassInfo set IsDeleted=1 where ClassId=@ClassId";
                    List<CommandInfo> listComs = new List<CommandInfo>();

                    foreach (int id in listIds)
                    {
                        SqlParameter[] para = { new SqlParameter("@ClassId",id) };
                        CommandInfo comStudent = new CommandInfo() { CommandText = sqlDelStu, IsProc = false, Parameters = para };
                        listComs.Add(comStudent);
                        CommandInfo comClass = new CommandInfo() { CommandText = sqlDelClass, IsProc = false, Parameters = para };
                        listComs.Add(comClass);
                    }

                    bool bl = SqlHelper.ExecuteTrans(listComs);

                    if (bl)
                    {
                        MessageBox.Show("该班级及其学生信息删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable dtClass = (DataTable)dgvClassList.DataSource;
                        string strId = string.Join(",", listIds);
                        DataRow[] rows = dtClass.Select("ClassId in (" + strId + ")");
                        foreach (DataRow dr in rows)
                        {
                            dtClass.Rows.Remove(dr);
                        }
                        dgvClassList.DataSource = dtClass;
                    }
                }
            }
        }
    }
}
