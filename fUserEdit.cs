using System;
using System.Windows.Forms;

namespace project
{
    public partial class fUserEdit : Form
    {
        public int UserId { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string InitialPassword { get; set; }
        public bool IsEditMode { get; private set; }

        public fUserEdit(bool isEditMode = false)
        {
            InitializeComponent();
            IsEditMode = isEditMode;
        }

        private void fUserEdit_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                this.Text = "Cập nhật thông tin sinh viên";
                txtStudentCode.Text = StudentCode;
                txtFullName.Text = FullName;
                txtPhone.Text = Phone;
                cboGender.SelectedItem = Gender;
                dtpDob.Value = Dob;
                txtAddress.Text = Address;
            }
            else
            {
                this.Text = "Thêm sinh viên mới";
                cboGender.SelectedIndex = 0;
                dtpDob.Value = DateTime.Now.AddYears(-18);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentCode.Text) || string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các thông tin bắt buộc (Mã SV, Họ tên, SĐT).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StudentCode = txtStudentCode.Text.Trim();
            FullName = txtFullName.Text.Trim();
            Phone = txtPhone.Text.Trim();
            Gender = cboGender.SelectedItem.ToString();
            Dob = dtpDob.Value;
            Address = txtAddress.Text.Trim();

            if (!IsEditMode)
            {
                string password = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu ban đầu cho sinh viên:", "Mật khẩu ban đầu", "123456");
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Mật khẩu không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                InitialPassword = password;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}