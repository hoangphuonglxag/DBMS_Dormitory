using System;
using System.Windows.Forms;

namespace project
{
    /// <summary>
    /// Form này hoạt động như một hộp thoại (dialog) để Thêm mới hoặc Chỉnh sửa thông tin một dịch vụ.
    /// Nó được thiết kế để có thể tái sử dụng cho cả hai chức năng trên.
    /// </summary>
    public partial class fServiceEdit : Form
    {
        // ==========================
        // PROPERTIES (Thuộc tính)
        // ==========================

        /// <summary>
        /// Lấy hoặc đặt Tên dịch vụ.
        /// Dùng để truyền dữ liệu giữa form này và form Dashboard.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Lấy hoặc đặt Mô tả dịch vụ.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Lấy hoặc đặt Giá dịch vụ.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Lấy hoặc đặt Đơn vị tính của dịch vụ.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc định của form.
        /// </summary>
        public fServiceEdit()
        {
            // Phương thức này được gọi tự động, dùng để khởi tạo các thành phần giao diện (textbox, button,...)
            InitializeComponent();
        }

        // ==========================
        // FORM EVENTS (Sự kiện của Form)
        // ==========================

        /// <summary>
        /// Sự kiện này xảy ra khi form được tải lên và chuẩn bị hiển thị.
        /// </summary>
        private void fServiceEdit_Load(object sender, EventArgs e)
        {
            // Khi form được tải, gán giá trị từ các properties (được truyền từ form Dashboard) vào các control tương ứng.
            // - Nếu là chức năng "Sửa", các properties này đã chứa thông tin của dịch vụ cần sửa, và form sẽ hiển thị sẵn các thông tin đó.
            // - Nếu là chức năng "Thêm mới", các properties này sẽ là giá trị mặc định (null, 0), và form sẽ hiển thị trống.
            txtServiceName.Text = ServiceName;
            txtDescription.Text = Description;
            txtPrice.Text = Price.ToString();
            txtUnit.Text = Unit;
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút "Lưu" (hoặc "OK").
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // --- BƯỚC 1: KIỂM TRA TÍNH HỢP LỆ CỦA DỮ LIỆU (VALIDATION) ---

            // Kiểm tra xem tên dịch vụ có bị bỏ trống hay không.
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực thi và không đóng form nếu có lỗi.
            }

            // Kiểm tra xem giá dịch vụ có phải là một số hợp lệ và không âm.
            decimal priceValue;
            // decimal.TryParse cố gắng chuyển đổi chuỗi thành số, trả về true nếu thành công.
            if (!decimal.TryParse(txtPrice.Text, out priceValue) || priceValue < 0)
            {
                MessageBox.Show("Giá dịch vụ không hợp lệ. Vui lòng nhập một số lớn hơn hoặc bằng 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng thực thi.
            }

            // --- BƯỚC 2: CẬP NHẬT DỮ LIỆU VÀ ĐÓNG FORM ---

            // Nếu tất cả dữ liệu đều hợp lệ, cập nhật lại các properties của form với giá trị mới từ các textbox.
            // Hàm Trim() được dùng để loại bỏ các khoảng trắng thừa ở đầu và cuối chuỗi.
            ServiceName = txtServiceName.Text.Trim();
            Description = txtDescription.Text.Trim();
            Price = priceValue; // Gán giá trị số đã được parse thành công.
            Unit = txtUnit.Text.Trim();

            // Đặt DialogResult của form thành OK.
            // Đây là tín hiệu để form cha (fServiceDashboard) biết rằng người dùng đã hoàn tất và xác nhận thay đổi.
            this.DialogResult = DialogResult.OK;

            // Đóng form hiện tại.
            this.Close();
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút "Hủy".
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Đặt DialogResult thành Cancel để form cha biết rằng người dùng đã hủy thao tác.
            this.DialogResult = DialogResult.Cancel;

            // Đóng form mà không lưu lại thay đổi gì.
            this.Close();
        }
    }
}