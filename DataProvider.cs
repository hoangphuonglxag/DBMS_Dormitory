using System;
using System.Data;
using System.Data.SqlClient;

namespace project
{
    public class DataProvider
    {
        private readonly string _connectionString;
        private readonly string _role;

        public DataProvider(string connectionString, string role)
        {
            _connectionString = connectionString;
            _role = role;
        }

        #region Service, Request, Billing Management
        public DataTable GetAllServices()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAllServices", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetRegistrationsByUser(int userId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetServicesByUser", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetUsersByService(int serviceId)
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới có quyền xem thông tin này.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetUsersByService", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@serviceId", serviceId);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void RegisterService(int userId, int serviceId, int quantity = 1)
        {
            if (_role != "user" && _role != "admin")
                throw new UnauthorizedAccessException("Bạn không có quyền đăng ký dịch vụ.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_RegisterService", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@serviceId", serviceId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UnregisterService(int requestId)
        {
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

        public DataTable GetPendingRequests()
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới có quyền xem thông tin này.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetPendingRequests", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void ApproveRequest(int requestId)
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới có quyền duyệt yêu cầu.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ApproveRequest", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@requestId", requestId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RejectRequest(int requestId)
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới có quyền từ chối yêu cầu.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_RejectRequest", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@requestId", requestId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void GenerateMonthlyUsage(int month, int year)
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới có quyền chốt số hóa đơn.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GenerateMonthlyUsage", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetUserBill(int userId, int month, int year)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetUserBill", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        #endregion

        #region User Management
        public DataTable GetUsers()
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới có quyền xem thông tin này.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetUsers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void CreateUser(string studentCode, string phone, string fullName, string gender, DateTime dob, string address, string initialPassword)
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới có quyền tạo người dùng.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_CreateUser", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@student_code", studentCode);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@initialPassword", initialPassword);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUser(int userId, string studentCode, string phone, string fullName, string gender, DateTime dob, string address)
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới có quyền cập nhật người dùng.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@student_code", studentCode);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@address", address);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ToggleUserStatus(int userId, bool isActive)
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới có quyền thay đổi trạng thái người dùng.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ToggleUserStatus", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ResetPassword(int userId, string newPassword)
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException("Chỉ admin mới có quyền đặt lại mật khẩu.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ResetPassword", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@newPassword", newPassword);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ChangePassword", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@oldPassword", oldPassword);
                cmd.Parameters.AddWithValue("@newPassword", newPassword);

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                int result = (int)returnParameter.Value;
                return result == 1;
            }
        }
        #endregion

        #region Admin Service CRUD
        public void AddService(string name, string description, decimal price, string unit)
        {
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
        #endregion

        public DataTable GetAvailableServices(int userId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAvailableServices", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}