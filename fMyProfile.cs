using System;
using System.Windows.Forms;

namespace project
{
    public partial class fMyProfile : Form
    {
        private readonly int _userId;
        private readonly DataProvider _dataProvider;

        public fMyProfile(int userId, DataProvider dataProvider)
        {
            InitializeComponent();
            _userId = userId;
            _dataProvider = dataProvider;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(oldPass) || string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool success = _dataProvider.ChangePassword(_userId, oldPass, newPass);
                if (success)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}