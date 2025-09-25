using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Vui lòng nhập đầy đủ thông tin.";
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DbConfig.GetAuthConnectionString()))
                using (SqlCommand cmd = new SqlCommand("sp_CheckLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = password;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string role = reader.GetString(1);

                            string userConnectionString = DbConfig.GetConnectionStringByRole(role);

                            // Chuyển thẳng vào fServiceDashboard
                            fServiceDashboard dashboardForm = new fServiceDashboard(userConnectionString, userId, username, role);

                            this.Hide();
                            dashboardForm.Show();
                        }
                        else
                        {
                            lblMessage.Text = "Sai tài khoản hoặc mật khẩu.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi hệ thống: " + ex.Message;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Bắt buộc phải tồn tại vì đã được gán sự kiện trong file Designer.
        }
    }
}
