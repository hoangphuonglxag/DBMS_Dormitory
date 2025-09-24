using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class fServiceDashboard : Form
    {
        private int _userId;
        private string _username;
        private string _role;
        private DataProvider _dataProvider;

        public fServiceDashboard(int userId, string username, string role)
        {
            InitializeComponent();
            _userId = userId;
            _username = username;
            _role = role;
            this.lblWelcome.Text = $"Xin chào, {_username} ({_role})";
            _dataProvider = new DataProvider(DbConfig.GetConnectionString(), _role);
        }

        private void fServiceDashboard_Load(object sender, EventArgs e)
        {
            LoadAllServices();
            LoadMyServices();

            StyleDataGridView(dgvAllServices);
            StyleDataGridView(dgvMyServices);
            StyleDataGridView(dgvUsersByService);
            StyleDataGridView(dgvPendingRequests);

            bool isAdmin = (_role == "admin");
            btnAddService.Visible = isAdmin;
            btnUpdateService.Visible = isAdmin;
            btnDeleteService.Visible = isAdmin;
            groupUsersByService.Visible = isAdmin;
            groupPendingRequests.Visible = isAdmin;
            btnGenerateBill.Visible = isAdmin;
            btnUserManagement.Visible = isAdmin;

            btnViewMyBill.Visible = !isAdmin;
            btnMyProfile.Visible = !isAdmin;

            if (isAdmin)
            {
                LoadPendingRequests();
            }

            dgvAllServices.SelectionChanged += dgvAllServices_SelectionChanged;
        }

        #region Helper Methods
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

        private void LoadAllServices()
        {
            DataTable dt = _dataProvider.GetAllServices();
            dgvAllServices.DataSource = dt;
            if (dgvAllServices.Columns.Contains("service_id"))
                dgvAllServices.Columns["service_id"].Visible = false;
            if (dgvAllServices.Columns.Contains("is_quantifiable"))
                dgvAllServices.Columns["is_quantifiable"].Visible = false;
        }

        private void LoadMyServices()
        {
            DataTable dt = _dataProvider.GetRegistrationsByUser(_userId);
            dgvMyServices.DataSource = dt;
            if (dgvMyServices.Columns.Contains("service_id"))
                dgvMyServices.Columns["service_id"].Visible = false;
            if (dgvMyServices.Columns.Contains("request_id"))
                dgvMyServices.Columns["request_id"].Visible = false;
        }

        private void LoadPendingRequests()
        {
            if (_role != "admin") return;
            try
            {
                DataTable dt = _dataProvider.GetPendingRequests();
                dgvPendingRequests.DataSource = dt;
                if (dgvPendingRequests.Columns.Contains("request_id"))
                {
                    dgvPendingRequests.Columns["request_id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chờ duyệt: " + ex.Message);
            }
        }
        #endregion

        #region Event Handlers
        private void dgvAllServices_SelectionChanged(object sender, EventArgs e)
        {
            if (_role == "admin" && dgvAllServices.CurrentRow != null)
            {
                try
                {
                    int serviceId = Convert.ToInt32(dgvAllServices.CurrentRow.Cells["service_id"].Value);
                    DataTable dt = _dataProvider.GetUsersByService(serviceId);
                    dgvUsersByService.DataSource = dt;
                    string serviceName = dgvAllServices.CurrentRow.Cells["service_name"].Value.ToString();
                    groupUsersByService.Text = $"Sinh viên đã đăng ký: {serviceName}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message);
                }
            }
        }

        private void txtSearchService_TextChanged(object sender, EventArgs e)
        {
            var dt = dgvAllServices.DataSource as DataTable;
            if (dt != null)
            {
                string searchText = txtSearchService.Text.Trim().Replace("'", "''");
                if (!string.IsNullOrEmpty(searchText))
                {
                    dt.DefaultView.RowFilter = $"service_name LIKE '%{searchText}%'";
                }
                else
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPendingRequests.CurrentRow != null)
            {
                int requestId = Convert.ToInt32(dgvPendingRequests.CurrentRow.Cells["request_id"].Value);
                try
                {
                    _dataProvider.ApproveRequest(requestId);
                    MessageBox.Show("Đã phê duyệt yêu cầu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPendingRequests();
                    LoadMyServices();
                    dgvAllServices_SelectionChanged(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi phê duyệt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvPendingRequests.CurrentRow != null)
            {
                int requestId = Convert.ToInt32(dgvPendingRequests.CurrentRow.Cells["request_id"].Value);
                try
                {
                    _dataProvider.RejectRequest(requestId);
                    MessageBox.Show("Đã từ chối yêu cầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPendingRequests();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi từ chối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (dgvAllServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dịch vụ từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvAllServices.SelectedRows.Count > 1)
            {
                RegisterMultipleServices();
            }
            else if (dgvAllServices.SelectedRows.Count == 1)
            {
                RegisterSingleService();
            }
        }

        private void btnViewMyBill_Click(object sender, EventArgs e)
        {
            fMyBill billForm = new fMyBill(_userId, _dataProvider);
            billForm.ShowDialog();
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            var today = DateTime.Now;
            var confirm = MessageBox.Show($"Bạn có chắc muốn chốt số và tạo hóa đơn cho tháng {today.Month}/{today.Year}?\n\nLưu ý: Hành động này sẽ xóa và tạo lại toàn bộ dữ liệu hóa đơn của tháng này.",
                                         "Xác nhận chốt số",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _dataProvider.GenerateMonthlyUsage(today.Month, today.Year);
                    MessageBox.Show("Đã chốt số và tạo hóa đơn tháng này thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            fUserManagement userManagementForm = new fUserManagement(_dataProvider);
            userManagementForm.ShowDialog();
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            if (_role == "user")
            {
                fMyProfile profileForm = new fMyProfile(_userId, _dataProvider);
                profileForm.ShowDialog();
            }
        }

        private void RegisterSingleService()
        {
            DataGridViewRow selectedRow = dgvAllServices.SelectedRows[0];
            int serviceId = Convert.ToInt32(selectedRow.Cells["service_id"].Value);
            bool isQuantifiable = Convert.ToBoolean(selectedRow.Cells["is_quantifiable"].Value);
            int quantity = 1;

            if (isQuantifiable)
            {
                string serviceName = selectedRow.Cells["service_name"].Value.ToString();
                string unit = selectedRow.Cells["unit"].Value.ToString();
                string input = Microsoft.VisualBasic.Interaction.InputBox($"Vui lòng nhập số lượng ({unit}):", $"Đăng ký dịch vụ: {serviceName}", "1");

                if (string.IsNullOrWhiteSpace(input)) return;

                if (!int.TryParse(input, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập một số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                _dataProvider.RegisterService(_userId, serviceId, quantity);
                MessageBox.Show("Yêu cầu đăng ký đã được gửi đi và đang chờ phê duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterMultipleServices()
        {
            var confirmResult = MessageBox.Show($"Bạn có chắc muốn đăng ký {dgvAllServices.SelectedRows.Count} dịch vụ đã chọn?\n\n(Lưu ý: Các dịch vụ cần số lượng sẽ được đăng ký với số lượng mặc định là 1)",
                                                 "Xác nhận đăng ký",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvAllServices.SelectedRows)
                    {
                        int serviceId = Convert.ToInt32(row.Cells["service_id"].Value);
                        _dataProvider.RegisterService(_userId, serviceId, 1);
                    }
                    MessageBox.Show("Yêu cầu đăng ký các dịch vụ đã được gửi đi và đang chờ phê duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvMyServices.CurrentRow != null)
            {
                int requestId = Convert.ToInt32(dgvMyServices.CurrentRow.Cells["request_id"].Value);
                _dataProvider.UnregisterService(requestId);
                MessageBox.Show("Đã hủy dịch vụ!");
                LoadMyServices();
            }
        }
        #endregion

        #region Admin actions
        private void btnAddService_Click(object sender, EventArgs e)
        {
            using (var form = new fServiceEdit())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _dataProvider.AddService(form.ServiceName, form.Description, form.Price, form.Unit);
                    LoadAllServices();
                }
            }
        }

        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            if (dgvAllServices.CurrentRow != null)
            {
                int serviceId = Convert.ToInt32(dgvAllServices.CurrentRow.Cells["service_id"].Value);
                using (var form = new fServiceEdit())
                {
                    form.ServiceName = dgvAllServices.CurrentRow.Cells["service_name"].Value.ToString();
                    form.Description = dgvAllServices.CurrentRow.Cells["description"].Value.ToString();
                    form.Price = Convert.ToDecimal(dgvAllServices.CurrentRow.Cells["price"].Value);
                    form.Unit = dgvAllServices.CurrentRow.Cells["unit"].Value.ToString();

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _dataProvider.UpdateService(serviceId, form.ServiceName, form.Description, form.Price, form.Unit);
                        LoadAllServices();
                    }
                }
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvAllServices.CurrentRow != null)
            {
                int serviceId = Convert.ToInt32(dgvAllServices.CurrentRow.Cells["service_id"].Value);
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    _dataProvider.DeleteService(serviceId);
                    LoadAllServices();
                }
            }
        }
        #endregion
    }
}