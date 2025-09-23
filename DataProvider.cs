using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    /// <summary>
    /// Lớp DataProvider cung cấp các phương thức để tương tác với cơ sở dữ liệu.
    /// Bao gồm các hoạt động CRUD (Create, Read, Update, Delete) cho dịch vụ và quản lý đăng ký dịch vụ.
    /// Lớp này cũng thực hiện việc kiểm tra quyền truy cập dựa trên vai trò của người dùng.
    /// </summary>
    public class DataProvider
    {
        // Chuỗi kết nối đến SQL Server, được đọc từ bên ngoài.
        private readonly string _connectionString;

        // Lưu vai trò của người dùng hiện tại ('admin' hoặc 'user') để kiểm tra quyền.
        private readonly string _role;

        /// <summary>
        /// Khởi tạo một instance mới của lớp DataProvider.
        /// </summary>
        /// <param name="connectionString">Chuỗi kết nối đến cơ sở dữ liệu.</param>
        /// <param name="role">Vai trò của người dùng đang đăng nhập (ví dụ: "admin", "user").</param>
        public DataProvider(string connectionString, string role)
        {
            _connectionString = connectionString;
            _role = role;
        }

        // ==========================
        // Lấy tất cả dịch vụ (user/admin đều được xem)
        // ==========================
        /// <summary>
        /// Lấy danh sách tất cả các dịch vụ từ cơ sở dữ liệu.
        /// </summary>
        /// <returns>Một DataTable chứa thông tin của tất cả các dịch vụ.</returns>
        public DataTable GetAllServices()
        {
            // Sử dụng 'using' để đảm bảo rằng các đối tượng IDisposable (như SqlConnection, SqlCommand)
            // sẽ được giải phóng tài nguyên một cách tự động ngay cả khi có lỗi xảy ra.
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAllServices", conn))
            {
                // Chỉ định rằng command là một Stored Procedure, không phải là một câu lệnh SQL text.
                cmd.CommandType = CommandType.StoredProcedure;

                // SqlDataAdapter được dùng để lấy dữ liệu từ database và điền vào một DataTable.
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    // Phương thức Fill sẽ mở kết nối, thực thi command, lấy dữ liệu, và đóng kết nối.
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // ==========================
        // Lấy dịch vụ đã đăng ký theo user
        // ==========================
        /// <summary>
        /// Lấy danh sách các dịch vụ mà một người dùng cụ thể đã đăng ký.
        /// </summary>
        /// <param name="userId">ID của người dùng cần truy vấn.</param>
        /// <returns>Một DataTable chứa thông tin các dịch vụ đã đăng ký bởi người dùng.</returns>
        public DataTable GetRegistrationsByUser(int userId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetServicesByUser", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                // Thêm tham số @userId vào Stored Procedure để lọc kết quả.
                cmd.Parameters.AddWithValue("@userId", userId);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // ==========================
        // Đăng ký dịch vụ (user role)
        // ==========================
        /// <summary>
        /// Thực hiện đăng ký một dịch vụ cho một người dùng.
        /// </summary>
        /// <param name="userId">ID của người dùng đăng ký.</param>
        /// <param name="serviceId">ID của dịch vụ được đăng ký.</param>
        /// <exception cref="UnauthorizedAccessException">Ném ra khi người dùng không có quyền thực hiện hành động này.</exception>
        public void RegisterService(int userId, int serviceId)
        {
            // Kiểm tra quyền: Chỉ 'user' hoặc 'admin' mới có quyền đăng ký dịch vụ.
            // Điều này ngăn chặn các vai trò khác (nếu có) thực hiện hành động này.
            if (_role != "user" && _role != "admin")
                throw new UnauthorizedAccessException("Bạn không có quyền đăng ký dịch vụ.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_RegisterService", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@serviceId", serviceId);

                // Mở kết nối đến database.
                conn.Open();
                // Thực thi command. ExecuteNonQuery dùng cho các câu lệnh không trả về tập kết quả (INSERT, UPDATE, DELETE).
                // Nó trả về số dòng bị ảnh hưởng.
                cmd.ExecuteNonQuery();
                // Kết nối sẽ được đóng tự động bởi khối 'using'.
            }
        }

        // ==========================
        // Hủy đăng ký dịch vụ (user role)
        // ==========================
        /// <summary>
        /// Hủy một lượt đăng ký dịch vụ.
        /// </summary>
        /// <param name="requestId">ID của yêu cầu đăng ký cần hủy.</param>
        /// <exception cref="UnauthorizedAccessException">Ném ra khi người dùng không có quyền thực hiện hành động này.</exception>
        public void UnregisterService(int requestId)
        {
            // Kiểm tra quyền tương tự như khi đăng ký.
            if (_role != "user" && _role != "admin")
                throw new UnauthorizedAccessException("Bạn không có quyền hủy dịch vụ.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UnregisterService", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@requestId", requestId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ==========================
        // Admin-only: thêm/xóa/sửa dịch vụ
        // ==========================
        /// <summary>
        /// Thêm một dịch vụ mới vào cơ sở dữ liệu. Chỉ dành cho admin.
        /// </summary>
        /// <param name="name">Tên của dịch vụ.</param>
        /// <param name="description">Mô tả chi tiết về dịch vụ.</param>
        /// <param name="price">Giá của dịch vụ.</param>
        /// <param name="unit">Đơn vị tính (ví dụ: "tháng", "lần").</param>
        /// <exception cref="UnauthorizedAccessException">Ném ra khi người dùng không phải là 'admin'.</exception>
        public void AddService(string name, string description, decimal price, string unit)
        {
            // Kiểm tra quyền nghiêm ngặt: Chỉ 'admin' mới được phép thêm dịch vụ.
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới được thêm dịch vụ.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_AddService", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@service_name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@unit", unit);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Cập nhật thông tin của một dịch vụ đã có. Chỉ dành cho admin.
        /// </summary>
        /// <param name="serviceId">ID của dịch vụ cần cập nhật.</param>
        /// <param name="name">Tên mới của dịch vụ.</param>
        /// <param name="description">Mô tả mới của dịch vụ.</param>
        /// <param name="price">Giá mới của dịch vụ.</param>
        /// <param name="unit">Đơn vị tính mới.</param>
        /// <exception cref="UnauthorizedAccessException">Ném ra khi người dùng không phải là 'admin'.</exception>
        public void UpdateService(int serviceId, string name, string description, decimal price, string unit)
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới được cập nhật dịch vụ.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateService", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@service_id", serviceId);
                cmd.Parameters.AddWithValue("@service_name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@unit", unit);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Xóa một dịch vụ khỏi cơ sở dữ liệu. Chỉ dành cho admin.
        /// </summary>
        /// <param name="serviceId">ID của dịch vụ cần xóa.</param>
        /// <exception cref="UnauthorizedAccessException">Ném ra khi người dùng không phải là 'admin'.</exception>
        public void DeleteService(int serviceId)
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới được xóa dịch vụ.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_DeleteService", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@service_id", serviceId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}