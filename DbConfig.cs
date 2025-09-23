// Nhập thư viện DotNetEnv để có thể làm việc với file .env
using DotNetEnv;
using System;

namespace project
{
    /// <summary>
    /// Lớp tĩnh (static) chứa các phương thức tiện ích liên quan đến cấu hình cơ sở dữ liệu.
    /// Mục đích chính là cung cấp một cách an toàn và tập trung để lấy chuỗi kết nối (connection string)
    /// từ file môi trường (.env) thay vì viết trực tiếp trong code.
    /// Việc này giúp bảo mật thông tin nhạy cảm và dễ dàng thay đổi cấu hình cho các môi trường khác nhau (dev, production).
    /// </summary>
    public static class DbConfig
    {
        /// <summary>
        /// Lấy chuỗi kết nối cơ sở dữ liệu từ biến môi trường "DB_CONNECTION_STRING".
        /// </summary>
        /// <returns>
        /// Một chuỗi (string) chứa thông tin kết nối đến cơ sở dữ liệu.
        /// Trả về null nếu không tìm thấy biến môi trường.
        /// </returns>
        /// <remarks>
        /// Để phương thức này hoạt động, cần phải có:
        /// 1. Cài đặt thư viện `DotNetEnv`.
        /// 2. Tạo một file tên là `.env` ở thư mục gốc của project (cùng cấp với file .csproj).
        /// 3. Trong file `.env`, có một dòng định nghĩa biến: DB_CONNECTION_STRING=your_connection_string_here
        /// </remarks>
        public static string GetConnectionString()
        {
            // Tải tất cả các cặp key-value từ file .env vào các biến môi trường của tiến trình hiện tại.
            // Nếu không gọi dòng này, Environment.GetEnvironmentVariable sẽ không thể tìm thấy biến.
            Env.Load();

            // Dùng phương thức chuẩn của .NET để đọc giá trị của một biến môi trường theo tên.
            // Ở đây, ta lấy giá trị của biến có tên là "DB_CONNECTION_STRING".
            return Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        }
    }
}