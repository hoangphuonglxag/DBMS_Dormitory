--| Nhóm          | Stored Procedures                                                                                                                      |
--| ------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
--| 🧑‍💼 Nhân sự | `sp_AddStaff`, `sp_UpdateStaff`, `sp_DeleteStaff`, `sp_GetAllStaffs`, `sp_GetStaffByPosition`, `sp_SearchStaffs`, `sp_GetStaffDetails` |
--| ⏱️ Chấm công  | `sp_LogShift`, `sp_GetShiftByDate`, `sp_GetWeeklyHours`, `sp_GetMonthlyShiftReport`                                                    |
--| 💰 Lương      | `sp_CalculateMonthlySalary`, `sp_GetSalaryByStaff`, `sp_GetSalaryReport`, `sp_UpdateSalaryAdjustment`, `sp_DeleteSalaryRecord`         |
--| 👪 Thân nhân  | `sp_AddRelative`, `sp_UpdateRelative`, `sp_DeleteRelative`, `sp_GetRelativesByStaff`                                                   |
--| 📄 Hợp đồng   | `sp_AddContract`, `sp_UpdateContract`, `sp_GetContractsByStaff`, `sp_GetActiveContracts`                                               |


--============================================================================================================================
USE QLNS;
GO
USE QLNS;
GO

-- Xóa các Procedure đã tồn tại
DROP PROCEDURE IF EXISTS 
    sp_AddStaff,
    sp_UpdateStaff,
    sp_DeleteStaff,
    sp_GetAllStaffs,
    sp_GetStaffByPosition,
    sp_LogShift,
    sp_GetShiftByDate,
    sp_GetWeeklyHours,
    sp_CalculateMonthlySalary,
    sp_GetSalaryByStaff,
    sp_GetSalaryReport,
    sp_AddRelative,
    sp_UpdateRelative,
    sp_DeleteRelative,
    sp_GetRelativesByStaff,
    sp_AddContract,
    sp_UpdateContract,
    sp_GetContractsByStaff,
    sp_GetActiveContracts;
GO
-- I. Stored Procedure: Nhân sự (staffs)
-- 1. sp_AddStaff – Thêm nhân viên mới
CREATE PROCEDURE sp_AddStaff
    @FullName NVARCHAR(100),
    @Dob DATE,
    @Gender NVARCHAR(10),
    @Phone NVARCHAR(15),
    @Email NVARCHAR(100),
    @PositionId INT,
    @HireDate DATE,
    @Status NVARCHAR(20),
    @Address NVARCHAR(200),
    @IdentityNumber NVARCHAR(20),
    @MaritalStatus NVARCHAR(20)
AS
BEGIN
    INSERT INTO staffs (full_name, dob, gender, phone, email, position_id, hire_date, status, address, identity_number, marital_status)
    VALUES (@FullName, @Dob, @Gender, @Phone, @Email, @PositionId, @HireDate, @Status, @Address, @IdentityNumber, @MaritalStatus);
END;
GO

-- 2. sp_UpdateStaff – Cập nhật thông tin nhân viên
CREATE PROCEDURE sp_UpdateStaff
    @StaffId INT,
    @FullName NVARCHAR(100),
    @Dob DATE,
    @Gender NVARCHAR(10),
    @Phone NVARCHAR(15),
    @Email NVARCHAR(100),
    @PositionId INT,
    @HireDate DATE,
    @Status NVARCHAR(20),
    @Address NVARCHAR(200),
    @IdentityNumber NVARCHAR(20),
    @MaritalStatus NVARCHAR(20)
AS
BEGIN
    UPDATE staffs
    SET full_name = @FullName,
        dob = @Dob,
        gender = @Gender,
        phone = @Phone,
        email = @Email,
        position_id = @PositionId,
        hire_date = @HireDate,
        status = @Status,
        address = @Address,
        identity_number = @IdentityNumber,
        marital_status = @MaritalStatus
    WHERE staff_id = @StaffId;
END;
GO

-- 3. sp_DeleteStaff – Xoá nhân viên (xóa mềm)
CREATE PROCEDURE sp_DeleteStaff
    @StaffId INT
AS
BEGIN
    UPDATE staffs SET status = 'Inactive' WHERE staff_id = @StaffId;
END;
GO

-- 4. sp_GetAllStaffs – Lấy toàn bộ danh sách nhân viên
CREATE PROCEDURE sp_GetAllStaffs
AS
BEGIN
    SELECT s.*, p.position_name
    FROM staffs s
    JOIN positions p ON s.position_id = p.position_id;
END;
GO

-- 5. sp_GetStaffByPosition – Lọc theo chức vụ
CREATE PROCEDURE sp_GetStaffByPosition
    @PositionId INT
AS
BEGIN
    SELECT s.*, p.position_name
    FROM staffs s
    JOIN positions p ON s.position_id = p.position_id
    WHERE s.position_id = @PositionId;
END;
GO


-- II. Stored Procedure: Chấm công (shift_logs)
-- 6. sp_LogShift – Ghi nhận chấm công
CREATE PROCEDURE sp_LogShift
    @StaffId INT,
    @WorkDate DATE,
    @CheckIn TIME,
    @CheckOut TIME,
    @Shift NVARCHAR(20),
    @Note NVARCHAR(100)
AS
BEGIN
    INSERT INTO shift_logs (staff_id, work_date, check_in, check_out, shift, note)
    VALUES (@StaffId, @WorkDate, @CheckIn, @CheckOut, @Shift, @Note);
END;
GO

-- 7. sp_GetShiftByDate – Xem chấm công theo ngày
CREATE PROCEDURE sp_GetShiftByDate
    @WorkDate DATE
AS
BEGIN
    SELECT s.full_name, l.*
    FROM shift_logs l
    JOIN staffs s ON l.staff_id = s.staff_id
    WHERE l.work_date = @WorkDate;
END;
GO

-- 8. sp_GetWeeklyHours – Tổng giờ làm theo tuần
CREATE PROCEDURE sp_GetWeeklyHours
    @StaffId INT,
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT s.staff_id, s.full_name,
           SUM(DATEDIFF(MINUTE, check_in, check_out)) / 60.0 AS TotalHours
    FROM shift_logs l
    JOIN staffs s ON l.staff_id = s.staff_id
    WHERE l.staff_id = @StaffId
      AND l.work_date BETWEEN @StartDate AND @EndDate
    GROUP BY s.staff_id, s.full_name;
END;
GO


-- III. Stored Procedure: Lương (salaries)
-- 9. sp_CalculateMonthlySalary – Tính lương tháng
CREATE PROCEDURE sp_CalculateMonthlySalary
    @StaffId INT,
    @Month INT,
    @Year INT,
    @Bonus DECIMAL(10,2) = 0,
    @Deduction DECIMAL(10,2) = 0
AS
BEGIN
    DECLARE @BaseSalary DECIMAL(10,2);

    SELECT @BaseSalary = p.base_salary
    FROM staffs s
    JOIN positions p ON s.position_id = p.position_id
    WHERE s.staff_id = @StaffId;

    INSERT INTO salaries (staff_id, month, year, base_salary, bonus, deduction)
    VALUES (@StaffId, @Month, @Year, @BaseSalary, @Bonus, @Deduction);
END;
GO

-- 10. sp_GetSalaryByStaff – Xem lương của 1 nhân viên
CREATE PROCEDURE sp_GetSalaryByStaff
    @StaffId INT
AS
BEGIN
    SELECT * FROM salaries
    WHERE staff_id = @StaffId
    ORDER BY year DESC, month DESC;
END;
GO

-- 11. sp_GetSalaryReport – Báo cáo tổng lương theo tháng/năm
CREATE PROCEDURE sp_GetSalaryReport
    @Month INT,
    @Year INT
AS
BEGIN
    SELECT s.staff_id, st.full_name, SUM(total_salary) AS TotalSalary
    FROM salaries s
    JOIN staffs st ON s.staff_id = st.staff_id
    WHERE s.month = @Month AND s.year = @Year
    GROUP BY s.staff_id, st.full_name
    ORDER BY TotalSalary DESC;
END;
GO


-- IV. Stored Procedure: Thân nhân (relatives)
-- 12. sp_AddRelative – Thêm thân nhân
CREATE PROCEDURE sp_AddRelative
    @StaffId INT,
    @RelativeName NVARCHAR(100),
    @Relationship NVARCHAR(50),
    @Phone NVARCHAR(15),
    @Note NVARCHAR(100)
AS
BEGIN
    INSERT INTO relatives (staff_id, relative_name, relationship, phone, note)
    VALUES (@StaffId, @RelativeName, @Relationship, @Phone, @Note);
END;
GO

-- 13. sp_UpdateRelative – Cập nhật thông tin thân nhân
CREATE PROCEDURE sp_UpdateRelative
    @RelativeId INT,
    @RelativeName NVARCHAR(100),
    @Relationship NVARCHAR(50),
    @Phone NVARCHAR(15),
    @Note NVARCHAR(100)
AS
BEGIN
    UPDATE relatives
    SET relative_name = @RelativeName,
        relationship = @Relationship,
        phone = @Phone,
        note = @Note
    WHERE relative_id = @RelativeId;
END;
GO

-- 14. sp_DeleteRelative – Xoá thân nhân
CREATE PROCEDURE sp_DeleteRelative
    @RelativeId INT
AS
BEGIN
    DELETE FROM relatives
    WHERE relative_id = @RelativeId;
END;
GO

-- 15. sp_GetRelativesByStaff – Lấy danh sách thân nhân theo nhân viên
CREATE PROCEDURE sp_GetRelativesByStaff
    @StaffId INT
AS
BEGIN
    SELECT * FROM relatives
    WHERE staff_id = @StaffId;
END;
GO


-- V. Stored Procedure: Hợp đồng (contracts)
-- 16. sp_AddContract – Thêm hợp đồng mới
CREATE PROCEDURE sp_AddContract
    @StaffId INT,
    @StartDate DATE,
    @EndDate DATE,
    @ContractType NVARCHAR(50),
    @Salary DECIMAL(10,2),
    @Note NVARCHAR(100)
AS
BEGIN
    INSERT INTO contracts (staff_id, start_date, end_date, contract_type, salary, note)
    VALUES (@StaffId, @StartDate, @EndDate, @ContractType, @Salary, @Note);
END;
GO

-- 17. sp_UpdateContract – Cập nhật hợp đồng
CREATE PROCEDURE sp_UpdateContract
    @ContractId INT,
    @StartDate DATE,
    @EndDate DATE,
    @ContractType NVARCHAR(50),
    @Salary DECIMAL(10,2),
    @Note NVARCHAR(100)
AS
BEGIN
    UPDATE contracts
    SET start_date = @StartDate,
        end_date = @EndDate,
        contract_type = @ContractType,
        salary = @Salary,
        note = @Note
    WHERE contract_id = @ContractId;
END;
GO

-- 18. sp_GetContractsByStaff – Lấy danh sách hợp đồng của một nhân viên
CREATE PROCEDURE sp_GetContractsByStaff
    @StaffId INT
AS
BEGIN
    SELECT * FROM contracts
    WHERE staff_id = @StaffId;
END;
GO

-- 19. sp_GetActiveContracts – Lấy các hợp đồng còn hiệu lực (hôm nay nằm trong khoảng thời gian)
CREATE PROCEDURE sp_GetActiveContracts
AS
BEGIN
    SELECT c.*, s.full_name
    FROM contracts c
    JOIN staffs s ON c.staff_id = s.staff_id
    WHERE GETDATE() BETWEEN start_date AND end_date;
END;
GO