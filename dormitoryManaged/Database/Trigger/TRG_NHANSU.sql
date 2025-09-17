-- TRIGGER CHO UẢN LÝ NHÂN SỰ

USE QLNS;
GO

DROP TRIGGER IF EXITS
    trg_UpdateContractStatusOnStaffInactive;
GO

CREATE TRIGGER trg_UpdateContractStatusOnStaffInactive
ON staffs
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật trạng thái hợp đồng sang 'Inactive' nếu nhân viên bị set status 'Inactive'
    UPDATE c
    SET c.status = 'Inactive'
    FROM contracts c
    JOIN inserted i ON c.staff_id = i.staff_id
    JOIN deleted d ON i.staff_id = d.staff_id
    WHERE i.status = 'Inactive' AND d.status <> 'Inactive'; -- chỉ khi status đổi từ khác 'Inactive' sang 'Inactive'
END;
GO
