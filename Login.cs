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
            this.btnLogin.MouseEnter += (s, e) => { this.btnLogin.BackColor = System.Drawing.Color.FromArgb(41, 52, 98); };
            this.btnLogin.MouseLeave += (s, e) => { this.btnLogin.BackColor = System.Drawing.Color.FromArgb(75, 135, 185); };
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

                    // SỬA Ở ĐÂY: Chỉ định rõ SqlDbType để đảm bảo khớp với Stored Procedure
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = password;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string role = reader.GetString(1); // "admin" hoặc "user"

                            // Lưu thông tin người dùng hiện tại
                            CurrentUserSession.UserId = userId;
                            CurrentUserSession.Username = username;
                            CurrentUserSession.Role = role;

                            // Mở Dashboard
                            fServiceDashboard dashboard = new fServiceDashboard(userId, username, role);
                            dashboard.Show();
                            this.Hide();
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

    // Static class lưu thông tin user hiện tại
    public static class CurrentUserSession
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
    }
}
