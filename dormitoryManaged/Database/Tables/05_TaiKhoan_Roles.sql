CREATE TABLE Accounts (
    accountID INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(100) NOT NULL UNIQUE,
    passwordHash NVARCHAR(255) NOT NULL,
    email NVARCHAR(100),
    createdAt DATETIME DEFAULT GETDATE(),
    isActive BIT DEFAULT 1
);
CREATE TABLE Roles (
    roleID INT PRIMARY KEY IDENTITY(1,1),
    roleName NVARCHAR(100) NOT NULL UNIQUE,
    description NVARCHAR(255)
);
CREATE TABLE AccountRoles (
    accountID INT FOREIGN KEY REFERENCES Accounts(accountID),
    roleID INT FOREIGN KEY REFERENCES Roles(roleID),
    PRIMARY KEY (accountID, roleID)
);