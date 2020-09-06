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
    public partial class GradeListForm : Form
    {
        public GradeListForm()
        {
            InitializeComponent();
        }

        private void GradeListForm_Load(object sender, EventArgs e)
        {
            LoadGradeList();
        }

        private void LoadGradeList()
        {
            string sql = "select GradeId,GradeName from GradeInfo where IsDeleted=0";
            DataTable dtGradeList = SqlHelper.GetDataTable(sql);

            dgvGradeList.DataSource = dtGradeList;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string gradeName = textBoxGrade.Text.Trim();
            if (string.IsNullOrEmpty(gradeName))
            {
                MessageBox.Show("年级名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //判断是否已存在
            string sql = "select count(1) from GradeInfo where GradeName=@GradeName and IsDeleted=0";
            SqlParameter[] para = { new SqlParameter("@GradeName", gradeName) };
            Object o = SqlHelper.ExecuteScalar(sql,para);
            if (o == null || o == DBNull.Value || ((int)o) == 0)
            {
                string sqlAdd = "insert GradeInfo(GradeName) values(@GradeName);select @@Identity";
                SqlParameter[] paraAdd = { new SqlParameter("@GradeName", gradeName) };
                Object oGrade = SqlHelper.ExecuteScalar(sqlAdd,paraAdd);
                if (oGrade !=null && int.Parse(oGrade.ToString())>0)
                {
                    MessageBox.Show($"年级：{gradeName}添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataTable dtGradeList = (DataTable)dgvGradeList.DataSource;
                    DataRow dr = dtGradeList.NewRow();
                    dr["GradeName"] = gradeName;
                    dr["GradeId"] = int.Parse(oGrade.ToString());
                    dtGradeList.Rows.Add(dr);
                    dgvGradeList.DataSource = dtGradeList;
                }
                else
                {
                    MessageBox.Show("添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("年级已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGradeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //判断获取的单元格是修改还是删除
                DataGridViewCell cell = dgvGradeList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataRow dr = (dgvGradeList.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                int gradeId = (int)dr["GradeId"];

                if (cell is DataGridViewCell && cell.FormattedValue.ToString() == "删除")
                {
                    if (MessageBox.Show("确定删除该年级及其班级和学生信息吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //删除，学生，班级，年级
                        string sqlDelStudent = "update StudentInfo set IsDeleted=1 where ClassId in (select ClassId from ClassInfo where GradeId=@GradeId)";
                        string sqlDelClass = "update ClassInfo set IsDeleted=1 where GradeId=@GradeId";
                        string sqlDelGrade = "update GradeInfo set IsDeleted=1 where GradeId=@GradeId";

                        SqlParameter[] para = { new SqlParameter("@GradeId", gradeId) };

                        List<CommandInfo> listComs = new List<CommandInfo>();

                        CommandInfo comStudent = new CommandInfo() { CommandText = sqlDelStudent, IsProc = false, Parameters = para };
                        listComs.Add(comStudent);
                        CommandInfo comClass = new CommandInfo() { CommandText = sqlDelClass, IsProc = false, Parameters = para };
                        listComs.Add(comClass);
                        CommandInfo comGrade = new CommandInfo() { CommandText = sqlDelGrade, IsProc = false, Parameters = para };
                        listComs.Add(comGrade);

                        bool bl = SqlHelper.ExecuteTrans(listComs);

                        if (bl)
                        {
                            MessageBox.Show("该年级信息删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dtGrade = (DataTable)dgvGradeList.DataSource;
                            dtGrade.Rows.Remove(dr);
                            dgvGradeList.DataSource = dtGrade;
                        }
                        else
                        {
                            MessageBox.Show("该年级信息删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            List<int> listIds = new List<int>();
            string gradeName = textBoxGrade.Text.Trim();
            for (int i = 0; i < dgvGradeList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = dgvGradeList.Rows[i].Cells["Check"] as DataGridViewCheckBoxCell;
                bool chk = Convert.ToBoolean(cell.Value);
                if (chk)
                {
                    DataRow dr = (dgvGradeList.Rows[i].DataBoundItem as DataRowView).Row;
                    int gradeId = (int)dr["GradeId"];
                    listIds.Add(gradeId);
                }
            }
            if (listIds.Count==1)
            {
                //判断年级是否为空
                if (string.IsNullOrEmpty(gradeName))
                {
                    MessageBox.Show("年级不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //判断年级时否存在
                string sql = "select count(1) From GradeInfo where GradeName=@GradeName and GradeId<>@GradeId";
                SqlParameter[] paras =
                {
                    new SqlParameter("@GradeName",gradeName),
                    new SqlParameter("@GradeId",listIds[0])
                };

                Object o = SqlHelper.ExecuteScalar(sql,paras);

                if (o == null || o == DBNull.Value || ((int)o) == 0)
                {
                    string sqlUpdate = "update GradeInfo set GradeName=@GradeName where GradeId=@GradeId";
                    SqlParameter[] parasUpdate =
                    {
                        new SqlParameter("@GradeName",gradeName),
                        new SqlParameter("@GradeId",listIds[0])
                    };

                    int count = SqlHelper.ExecuteNonQuery(sqlUpdate,parasUpdate);
                    if (count > 0)
                    {
                        MessageBox.Show($"年级：{gradeName}修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //刷新
                        DataTable dtGradeList = (DataTable)dgvGradeList.DataSource;
                        DataRow[] rows = dtGradeList.Select("GradeId=" + listIds[0]);
                        DataRow dr = rows[0];
                        dr["GradeName"] = gradeName;
                        dgvGradeList.DataSource = dtGradeList;
                    }
                    else
                    {
                        MessageBox.Show("修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("该年级已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (listIds.Count==0)
            {
                MessageBox.Show("请选择要修改的班级信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("不能同时选择修改多条班级信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            List<int> listIds = new List<int>();
            for (int i = 0; i < dgvGradeList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = dgvGradeList.Rows[i].Cells["Check"] as DataGridViewCheckBoxCell;
                bool chk = Convert.ToBoolean(cell.Value);
                if (chk)
                {
                    DataRow dr = (dgvGradeList.Rows[i].DataBoundItem as DataRowView).Row;
                    int gradeId = (int)dr["GradeId"];
                    listIds.Add(gradeId);
                }
            }

            if (listIds.Count == 0)
            {
                MessageBox.Show("请选择要删除的年级信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("确定删除该年级及其班级和学生信息吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sqlDelStudent = "update StudentInfo set IsDeleted=1 where ClassId in (select ClassId from ClassInfo where GradeId=@GradeId)";
                    string sqlDelClass = "update ClassInfo set IsDeleted=1 where GradeId=@GradeId";
                    string sqlDelGrade = "update GradeInfo set IsDeleted=1 where GradeId=@GradeId";
                    List<CommandInfo> listComs = new List<CommandInfo>();

                    foreach (int id in listIds)
                    {
                        SqlParameter[] para = { new SqlParameter("@GradeId", id) };
                        CommandInfo comStudent = new CommandInfo() { CommandText = sqlDelStudent, IsProc = false, Parameters = para };
                        listComs.Add(comStudent);
                        CommandInfo comClass = new CommandInfo() { CommandText = sqlDelClass, IsProc = false, Parameters = para };
                        listComs.Add(comClass);
                        CommandInfo comGrade = new CommandInfo() { CommandText = sqlDelGrade, IsProc = false, Parameters = para };
                        listComs.Add(comGrade);
                    }

                    bool bl = SqlHelper.ExecuteTrans(listComs);

                    if (bl)
                    {
                        MessageBox.Show("该年级及其班级和学生信息删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable dtGrade = (DataTable)dgvGradeList.DataSource;
                        string strId = string.Join(",", listIds);
                        DataRow[] rows = dtGrade.Select("GradeId in (" + strId + ")");
                        foreach (DataRow dr in rows)
                        {
                            dtGrade.Rows.Remove(dr);
                        }
                        dgvGradeList.DataSource = dtGrade;
                    }
                }
            }
        }
    }
}
