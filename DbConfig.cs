using DotNetEnv;
using System;

public static class DbConfig
{
    // Static constructor này sẽ tự động chạy một lần duy nhất
    // khi lớp DbConfig được sử dụng lần đầu tiên.
    static DbConfig()
    {
        // Tải các biến môi trường từ file .env
        Env.Load();
    }

    /// <summary>
    /// Lấy chuỗi kết nối dùng riêng cho việc xác thực đăng nhập.
    /// </summary>
    public static string GetAuthConnectionString()
    {
        return Environment.GetEnvironmentVariable("AUTH_DB_CONNECTION_STRING");
    }

    /// <summary>
    /// Lấy chuỗi kết nối phù hợp với vai trò (role) của người dùng.
    /// </summary>
    public static string GetConnectionStringByRole(string role)
    {
        if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
        {
            // Nếu là admin, trả về chuỗi kết nối của admin
            return Environment.GetEnvironmentVariable("ADMIN_DB_CONNECTION_STRING");
        }
        else
        {
            // Nếu là user (hoặc vai trò khác), trả về chuỗi kết nối của user
            return Environment.GetEnvironmentVariable("USER_DB_CONNECTION_STRING");
        }
    }
}