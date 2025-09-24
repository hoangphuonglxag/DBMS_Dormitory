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
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DbConfig.GetConnectionString()))
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

                            CurrentUserSession.UserId = userId;
                            CurrentUserSession.Username = username;
                            CurrentUserSession.Role = role;

                            fServiceDashboard dashboard = new fServiceDashboard(userId, username, role);
                            this.Hide();
                            dashboard.Show();

                            // Xử lý việc đóng form:
                            // Chỉ đóng form Login gốc (và thoát chương trình)
                            // khi người dùng KHÔNG chủ động đăng xuất (tức là bấm nút X).
                            dashboard.FormClosed += (s, args) =>
                            {
                                if (dashboard.isLoggingOut == false)
                                {
                                    this.Close();
                                }
                            };
                        }
                        else
                        {
                            lblMessage.Text = "Sai tài khoản hoặc mật khẩu.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi kết nối: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Không cần xử lý
        }
    }

    public static class CurrentUserSession
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
    }
}