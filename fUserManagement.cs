using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class fUserManagement : Form
    {
        private readonly DataProvider _dataProvider;

        public fUserManagement(DataProvider dataProvider)
        {
            InitializeComponent();
            _dataProvider = dataProvider;
        }

        private void fUserManagement_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dgvUsers);
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                DataTable dt = _dataProvider.GetUsers();
                dgvUsers.DataSource = dt;
                if (dgvUsers.Columns.Contains("userId"))
                {
                    dgvUsers.Columns["userId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 52, 98);
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(75, 135, 185);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new fUserEdit())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _dataProvider.CreateUser(form.StudentCode, form.Phone, form.FullName, form.Gender, form.Dob, form.Address, form.InitialPassword);
                        MessageBox.Show("Thêm sinh viên mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tạo người dùng mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvUsers.CurrentRow;
            using (var form = new fUserEdit(isEditMode: true))
            {
                form.UserId = Convert.ToInt32(row.Cells["userId"].Value);
                form.StudentCode = row.Cells["Mã SV"].Value.ToString();
                form.FullName = row.Cells["Họ và Tên"].Value.ToString();
                form.Phone = row.Cells["Số điện thoại"].Value.ToString();
                form.Gender = row.Cells["Giới tính"].Value.ToString();
                form.Dob = Convert.ToDateTime(row.Cells["Ngày sinh"].Value);
                form.Address = row.Cells["Địa chỉ"].Value.ToString();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _dataProvider.UpdateUser(form.UserId, form.StudentCode, form.Phone, form.FullName, form.Gender, form.Dob, form.Address);
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["userId"].Value);
            bool currentStatus = Convert.ToBoolean(dgvUsers.CurrentRow.Cells["Hoạt động"].Value);
            string actionText = currentStatus ? "vô hiệu hóa" : "kích hoạt";

            var confirm = MessageBox.Show($"Bạn có chắc muốn {actionText} tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _dataProvider.ToggleUserStatus(userId, !currentStatus);
                    MessageBox.Show($"Đã {actionText} tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi {actionText} tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để reset mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["userId"].Value);
            string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu mới:", "Reset Mật khẩu", "NewPassword123");

            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                try
                {
                    _dataProvider.ResetPassword(userId, newPassword);
                    MessageBox.Show("Reset mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi reset mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}