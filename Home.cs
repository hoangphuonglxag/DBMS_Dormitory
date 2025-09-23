using System;
using System.Windows.Forms;

namespace project
{
    /// <summary>
    /// Form Home là màn hình chính sau khi người dùng đăng nhập thành công.
    /// Nó hoạt động như một trung tâm điều hướng, cho phép người dùng truy cập các chức năng khác của ứng dụng.
    /// </summary>
    public partial class Home : Form
    {
        // ==========================
        // KHAI BÁO BIẾN
        // ==========================

        // Các biến private này dùng để lưu trữ thông tin của người dùng đang đăng nhập trong suốt phiên làm việc trên form Home.
        private int _userId;      // ID của người dùng
        private string _username; // Tên đăng nhập
        private string _role;     // Vai trò (ví dụ: 'admin', 'user')

        /// <summary>
        /// Hàm khởi tạo (Constructor) của form Home.
        /// Được gọi khi một đối tượng Home mới được tạo ra.
        /// </summary>
        /// <param name="userId">ID của người dùng được truyền từ form đăng nhập.</param>
        /// <param name="username">Tên đăng nhập được truyền từ form đăng nhập.</param>
        /// <param name="role">Vai trò của người dùng được truyền từ form đăng nhập.</param>
        public Home(int userId, string username, string role)
        {
            // Lệnh bắt buộc để khởi tạo các thành phần giao diện đã được thiết kế (nút bấm, nhãn,...).
            InitializeComponent();

            // Gán các giá trị được truyền vào cho các biến nội bộ của form.
            _userId = userId;
            _username = username;
            _role = role;

            // Cập nhật tiêu đề của cửa sổ form để hiển thị thông tin người dùng, tạo trải nghiệm cá nhân hóa.
            this.Text = $"Home - Chào mừng {_username} ({_role})";
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn vào nút "Quản lý Dịch vụ".
        /// </summary>
        private void btnManageServices_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện (instance) mới của form fServiceDashboard.
            // Quan trọng: Truyền thông tin của người dùng hiện tại (_userId, _username, _role) sang form mới.
            // Điều này đảm bảo form fServiceDashboard biết ai đang sử dụng nó và có quyền gì.
            fServiceDashboard serviceForm = new fServiceDashboard(_userId, _username, _role);

            // Hiển thị form fServiceDashboard.
            // .Show() sẽ mở form mới dưới dạng một cửa sổ độc lập (non-modal),
            // cho phép người dùng vẫn có thể tương tác với form Home này.
            serviceForm.Show();
        }
    }
}