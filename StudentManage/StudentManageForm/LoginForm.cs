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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string uName = textUserName.Text.Trim();//trim去空格，输入账号，密码
            string uPwd = textUserPwd.Text.Trim();

            if (string.IsNullOrEmpty(uName))
            {
                MessageBox.Show("请输入账号","登录提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(uPwd))
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textUserPwd.Focus();
                return;
            }

            {
                //Windows身份验证
                //string connString = "Data Source=(local);Initial Catalog=StudentDB;Integrated Security=True";
                ////连接数据库
                //SqlConnection conn = new SqlConnection(connString);
                //查询语句
                string sql = "select count(1) from UserInfo where UserName=@UserName and UserPwd=@UserPwd";
                //添加参数
                //SqlParameter paraUName = new SqlParameter("@UserName",uName);
                //SqlParameter paraUPwd = new SqlParameter("@UserPwd",uPwd);
                SqlParameter[] paras =
                {
                    new SqlParameter("@UserName",uName),
                    new SqlParameter("@UserPwd",uPwd)
                };
                //创建Command对象
                //SqlCommand cmd = new SqlCommand(sql,conn);
                ////cmd.CommandType = CommandType.StoredProcedure;//存储过程
                //cmd.Parameters.Clear();
                ////cmd.Parameters.Add(paraUName);
                ////cmd.Parameters.Add(paraUPwd);
                //cmd.Parameters.AddRange(paras);
                ////打开连接
                //conn.Open();
                ////执行命令
                //object o = cmd.ExecuteScalar(); //返回结果第一行第一列
                ////关闭
                //conn.Close();

                object o = SqlHelper.ExecuteScalar(sql,paras);
                
                //处理结果
                if (o==null||(o==DBNull.Value)||((int)o)==0)
                {
                    MessageBox.Show("密码或账号有错，请检查", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("登录成功", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //转到主页面
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
