-- ========================================
-- MODULE HR - QUẢN LÝ NHÂN SỰ KÝ TÚC XÁ
-- ========================================
USE QLNS;
GO
-- DROP TABLES (nếu cần làm mới lại)
-- Lưu ý: Xoá theo đúng thứ tự phụ thuộc
-- DROP TABLE users, job_history, contracts, salaries, shift_logs, relatives, staffs, positions;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS job_history;
DROP TABLE IF EXISTS contracts;
DROP TABLE IF EXISTS salaries;
DROP TABLE IF EXISTS shift_logs;
DROP TABLE IF EXISTS relatives;
DROP TABLE IF EXISTS staffs;
DROP TABLE IF EXISTS positions;
-- ======================
-- 1. BẢNG CHỨC VỤ
-- ======================
CREATE TABLE positions (
    position_id INT PRIMARY KEY IDENTITY,
    position_name NVARCHAR(50) NOT NULL,
    base_salary DECIMAL(10, 2) NOT NULL
);

-- ======================
-- 2. BẢNG NHÂN VIÊN
-- ======================
CREATE TABLE staffs (
    staff_id INT PRIMARY KEY IDENTITY,
    full_name NVARCHAR(100) NOT NULL,
    dob DATE,
    gender NVARCHAR(10),
    phone NVARCHAR(15),
    email NVARCHAR(100),
    position_id INT FOREIGN KEY REFERENCES positions(position_id),
    hire_date DATE,
    status NVARCHAR(20), -- Active, Inactive, Suspended
    address NVARCHAR(200), -- Bổ sung
    identity_number NVARCHAR(20), -- CCCD/CMND
    marital_status NVARCHAR(20) -- Độc thân, Đã kết hôn
);

-- ======================
-- 3. BẢNG THÂN NHÂN
-- ======================
CREATE TABLE relatives (
    relative_id INT PRIMARY KEY IDENTITY,
    staff_id INT FOREIGN KEY REFERENCES staffs(staff_id),
    relative_name NVARCHAR(100),
    relationship NVARCHAR(50),
    phone NVARCHAR(15),
    note NVARCHAR(100)
);

-- ======================
-- 4. BẢNG CHẤM CÔNG (THEO GIỜ - CA)
-- ======================
CREATE TABLE shift_logs (
    log_id INT PRIMARY KEY IDENTITY,
    staff_id INT FOREIGN KEY REFERENCES staffs(staff_id),
    work_date DATE NOT NULL,
    check_in TIME,
    check_out TIME,
    shift NVARCHAR(20), -- Morning, Afternoon, Evening, Night
    note NVARCHAR(100)
);

-- ======================
-- 5. BẢNG LƯƠNG
-- ======================
CREATE TABLE salaries (
    salary_id INT PRIMARY KEY IDENTITY,
    staff_id INT FOREIGN KEY REFERENCES staffs(staff_id),
    month INT,
    year INT,
    salary_period NVARCHAR(20) DEFAULT 'month', -- month / week
    base_salary DECIMAL(10,2),
    bonus DECIMAL(10,2),
    deduction DECIMAL(10,2),
    total_salary AS (base_salary + bonus - deduction) PERSISTED
);

-- ======================
-- 6. BẢNG HỢP ĐỒNG
-- ======================
CREATE TABLE contracts (
    contract_id INT PRIMARY KEY IDENTITY,
    staff_id INT FOREIGN KEY REFERENCES staffs(staff_id),
    start_date DATE,
    end_date DATE,
    contract_type NVARCHAR(50), -- Thử việc, Chính thức, Thời vụ
    salary DECIMAL(10,2),
    note NVARCHAR(100)
);

-- ======================
-- 7. BẢNG LỊCH SỬ CÔNG VIỆC
-- ======================
CREATE TABLE job_history (
    history_id INT PRIMARY KEY IDENTITY,
    staff_id INT FOREIGN KEY REFERENCES staffs(staff_id),
    old_position_id INT FOREIGN KEY REFERENCES positions(position_id),
    new_position_id INT FOREIGN KEY REFERENCES positions(position_id),
    change_date DATE,
    reason NVARCHAR(100)
);

-- ======================
-- 8. BẢNG NGƯỜI DÙNG (USER & PHÂN QUYỀN)
-- ======================
CREATE TABLE users (
    user_id INT PRIMARY KEY IDENTITY,
    staff_id INT FOREIGN KEY REFERENCES staffs(staff_id),
    username NVARCHAR(50) UNIQUE NOT NULL,
    password_hash NVARCHAR(100) NOT NULL,
    role NVARCHAR(50) -- Admin, HR, StudentManager, RoomManager
);

-- ======================
-- DỮ LIỆU MẪU
-- ======================

-- Thêm chức vụ
INSERT INTO positions (position_name, base_salary)
VALUES 
('Quản lý', 10000000),
('Bảo vệ', 7000000),
('Kỹ thuật', 8000000),
('Tạp vụ', 6000000);

-- Thêm nhân viên
INSERT INTO staffs (full_name, dob, gender, phone, email, position_id, hire_date, status, address, identity_number, marital_status)
VALUES 
(N'Nguyễn Văn A', '1990-05-12', N'Nam', '0123456789', 'nva@example.com', 1, '2020-01-15', 'Active', N'123 Lê Lợi, Q1', '012345678', N'Độc thân');

-- Thêm thân nhân
INSERT INTO relatives (staff_id, relative_name, relationship, phone, note)
VALUES (1, N'Trần Thị B', N'Vợ', '0987654321', N'Liên hệ trong trường hợp khẩn cấp');

-- Thêm dữ liệu chấm công
INSERT INTO shift_logs (staff_id, work_date, check_in, check_out, shift, note)
VALUES 
(1, '2025-09-10', '08:00', '17:00', N'Morning', N'Làm việc bình thường');

-- Thêm lương
INSERT INTO salaries (staff_id, month, year, base_salary, bonus, deduction)
VALUES 
(1, 9, 2025, 10000000, 1000000, 500000);

-- Thêm hợp đồng
INSERT INTO contracts (staff_id, start_date, end_date, contract_type, salary, note)
VALUES 
(1, '2023-01-01', '2025-12-31', N'Chính thức', 10000000, N'Hợp đồng 3 năm');

-- Thêm lịch sử thay đổi công việc
INSERT INTO job_history (staff_id, old_position_id, new_position_id, change_date, reason)
VALUES 
(1, 2, 1, '2024-06-01', N'Thăng chức lên Quản lý');

-- Thêm tài khoản người dùng
INSERT INTO users (staff_id, username, password_hash, role)
VALUES 
(1, 'admin_hr', HASHBYTES('SHA2_256', '123456'), 'HR');

-- File .sql để import vào SQL Server

-- Stored Procedure mẫu tính lương/thưởng

-- View thống kê giờ làm theo tuần/tháng

-- ERD diagram

USE QLNS;
GO

SELECT * FROM sys.tables;
