using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    /// <summary>
    /// Form chính hiển thị bảng điều khiển dịch vụ.
    /// Cho phép người dùng xem, đăng ký, hủy dịch vụ.
    /// Nếu người dùng là admin, sẽ có thêm các chức năng thêm, sửa, xóa dịch vụ.
    /// </summary>
    public partial class fServiceDashboard : Form
    {
        // ==========================
        // KHAI BÁO BIẾN VÀ THUỘC TÍNH
        // ==========================

        // Lưu thông tin người dùng đang đăng nhập
        private int _userId;
        private string _username;
        private string _role;

        // Đối tượng chịu trách nhiệm giao tiếp với cơ sở dữ liệu.
        private DataProvider _dataProvider;

        /// <summary>
        /// Hàm khởi tạo của form.
        /// </summary>
        /// <param name="userId">ID của người dùng đăng nhập.</param>
        /// <param name="username">Tên đăng nhập của người dùng.</param>
        /// <param name="role">Vai trò của người dùng (user/admin).</param>
        public fServiceDashboard(int userId, string username, string role)
        {
            InitializeComponent();

            // Gán thông tin người dùng từ form đăng nhập vào các biến của form này.
            _userId = userId;
            _username = username;
            _role = role;

            // Cập nhật lại tiêu đề ở Header Panel để chào mừng người dùng.
            this.lblWelcome.Text = $"Xin chào, {_username} ({_role})";

            // Khởi tạo đối tượng DataProvider với chuỗi kết nối và vai trò của người dùng.
            // Vai trò này sẽ được DataProvider sử dụng để kiểm tra quyền hạn thực hiện các thao tác.
            _dataProvider = new DataProvider(DbConfig.GetConnectionString(), _role);
        }

        // ==========================
        // SỰ KIỆN CỦA FORM
        // ==========================

        /// <summary>
        /// Xảy ra khi form được tải lên lần đầu tiên.
        /// Dùng để khởi tạo dữ liệu và cài đặt giao diện ban đầu.
        /// </summary>
        private void fServiceDashboard_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu lên các bảng (DataGridView).
            LoadAllServices();
            LoadMyServices();

            // Áp dụng style tùy chỉnh cho cả hai bảng để giao diện đẹp và đồng nhất.
            StyleDataGridView(dgvAllServices);
            StyleDataGridView(dgvMyServices);

            // Kiểm tra vai trò của người dùng. Nếu là "admin", các nút chức năng của admin sẽ hiện ra.
            // Ngược lại, các nút này sẽ bị ẩn đi.
            bool isAdmin = (_role == "admin");
            btnAddService.Visible = isAdmin;
            btnUpdateService.Visible = isAdmin;
            btnDeleteService.Visible = isAdmin;
        }

        // ==========================
        // CÁC PHƯƠNG THỨC HỖ TRỢ (HELPER METHODS)
        // ==========================

        /// <summary>
        /// Áp dụng một bộ style chung cho DataGridView để giao diện chuyên nghiệp hơn.
        /// </summary>
        /// <param name="dgv">DataGridView cần được định dạng.</param>
        private void StyleDataGridView(DataGridView dgv)
        {
            // Tùy chỉnh chung
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Chỉ hiện đường kẻ ngang
            dgv.RowHeadersVisible = false; // Ẩn cột đầu tiên bên trái
            dgv.ReadOnly = true; // Không cho người dùng sửa trực tiếp trên bảng
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn cả dòng khi click
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động co giãn cột cho vừa bảng

            // Tùy chỉnh màu sắc cho các dòng và khi được chọn
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249); // Màu nền xen kẽ cho các dòng
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 52, 98); // Màu nền khi chọn một dòng
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke; // Màu chữ khi chọn một dòng

            // Tùy chỉnh Header (tiêu đề cột)
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(75, 135, 185); // Màu nền header
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Màu chữ header
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        /// <summary>
        /// Tải danh sách tất cả các dịch vụ có sẵn lên DataGridView `dgvAllServices`.
        /// </summary>
        private void LoadAllServices()
        {
            DataTable dt = _dataProvider.GetAllServices();
            dgvAllServices.DataSource = dt;

            // Ẩn cột "service_id" vì người dùng không cần thấy ID này, nhưng chương trình cần để xử lý logic.
            if (dgvAllServices.Columns.Contains("service_id"))
                dgvAllServices.Columns["service_id"].Visible = false;
        }

        /// <summary>
        /// Tải danh sách các dịch vụ mà người dùng hiện tại đã đăng ký lên `dgvMyServices`.
        /// </summary>
        private void LoadMyServices()
        {
            DataTable dt = _dataProvider.GetRegistrationsByUser(_userId);
            dgvMyServices.DataSource = dt;

            // Ẩn các cột ID không cần thiết cho người dùng xem.
            if (dgvMyServices.Columns.Contains("service_id"))
                dgvMyServices.Columns["service_id"].Visible = false;
            if (dgvMyServices.Columns.Contains("request_id"))
                dgvMyServices.Columns["request_id"].Visible = false;
        }

        #region User actions (Hành động của người dùng thường)
        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút "Đăng ký".
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Đảm bảo rằng người dùng đã chọn một dịch vụ trên bảng `dgvAllServices`.
            if (dgvAllServices.CurrentRow != null)
            {
                // Lấy service_id từ dòng đang được chọn.
                int serviceId = Convert.ToInt32(dgvAllServices.CurrentRow.Cells["service_id"].Value);

                // Gọi phương thức đăng ký dịch vụ.
                _dataProvider.RegisterService(_userId, serviceId);
                MessageBox.Show("Đăng ký dịch vụ thành công!");

                // Tải lại danh sách dịch vụ của tôi để cập nhật thay đổi.
                LoadMyServices();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút "Hủy dịch vụ".
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Đảm bảo rằng người dùng đã chọn một dịch vụ trên bảng `dgvMyServices`.
            if (dgvMyServices.CurrentRow != null)
            {
                // Lấy request_id (ID của lượt đăng ký) từ dòng đang được chọn.
                int requestId = Convert.ToInt32(dgvMyServices.CurrentRow.Cells["request_id"].Value);

                // Gọi phương thức hủy đăng ký.
                _dataProvider.UnregisterService(requestId);
                MessageBox.Show("Đã hủy dịch vụ!");

                // Tải lại danh sách dịch vụ của tôi để cập nhật thay đổi.
                LoadMyServices();
            }
        }
        #endregion

        #region Admin actions (Hành động của quản trị viên)
        /// <summary>
        /// Mở form thêm dịch vụ mới.
        /// </summary>
        private void btnAddService_Click(object sender, EventArgs e)
        {
            // Sử dụng 'using' để đảm bảo form fServiceEdit được giải phóng tài nguyên sau khi đóng.
            using (var form = new fServiceEdit())
            {
                // Mở form dưới dạng Dialog, chương trình sẽ tạm dừng cho đến khi form này được đóng.
                // Nếu người dùng nhấn nút "Lưu" (trả về DialogResult.OK) trên form đó...
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // ...thì gọi phương thức thêm dịch vụ với dữ liệu lấy từ form.
                    _dataProvider.AddService(form.ServiceName, form.Description, form.Price, form.Unit);

                    // Tải lại danh sách tất cả dịch vụ để hiển thị dịch vụ mới thêm.
                    LoadAllServices();
                }
            }
        }

        /// <summary>
        /// Mở form để cập nhật dịch vụ đang được chọn.
        /// </summary>
        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            if (dgvAllServices.CurrentRow != null)
            {
                // Lấy ID của dịch vụ cần sửa.
                int serviceId = Convert.ToInt32(dgvAllServices.CurrentRow.Cells["service_id"].Value);

                using (var form = new fServiceEdit())
                {
                    // Điền thông tin của dịch vụ hiện tại vào form fServiceEdit trước khi hiển thị.
                    form.ServiceName = dgvAllServices.CurrentRow.Cells["service_name"].Value.ToString();
                    form.Description = dgvAllServices.CurrentRow.Cells["description"].Value.ToString();
                    form.Price = Convert.ToDecimal(dgvAllServices.CurrentRow.Cells["price"].Value);
                    form.Unit = dgvAllServices.CurrentRow.Cells["unit"].Value.ToString();

                    // Nếu người dùng nhấn "Lưu" trên form sửa...
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // ...thì gọi phương thức cập nhật dịch vụ.
                        _dataProvider.UpdateService(serviceId, form.ServiceName, form.Description, form.Price, form.Unit);
                        LoadAllServices(); // Tải lại danh sách để thấy thay đổi.
                    }
                }
            }
        }

        /// <summary>
        /// Xóa dịch vụ đang được chọn.
        /// </summary>
        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvAllServices.CurrentRow != null)
            {
                int serviceId = Convert.ToInt32(dgvAllServices.CurrentRow.Cells["service_id"].Value);

                // Hiển thị hộp thoại xác nhận trước khi thực hiện hành động xóa.
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    _dataProvider.DeleteService(serviceId);
                    LoadAllServices(); // Tải lại danh sách.
                }
            }
        }
        #endregion
    }
}