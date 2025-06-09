USE [NCFDonorDb]
GO

-- ✅ Recreate tables safely in the correct order

-- 🔹 Create Roles Table
CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255) NULL
);
GO

-- 🔹 Create Permissions Table
CREATE TABLE Permissions (
    PermissionId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255) NULL
);
GO

-- 🔹 Create RolePermissions Table
CREATE TABLE RolePermissions (
    RolePermissionId INT NOT NULL,
    PermissionId INT NOT NULL,
    PRIMARY KEY (RolePermissionId, PermissionId),
    FOREIGN KEY (RolePermissionId) REFERENCES Roles(RoleId) ON DELETE CASCADE,
    FOREIGN KEY (PermissionId) REFERENCES Permissions(PermissionId) ON DELETE CASCADE
);
GO

-- 🔹 Create Users Table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    RoleId INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME DEFAULT GETUTCDATE(),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId) ON DELETE CASCADE
);
GO

-- 🔹 Create SystemUsers Table
CREATE TABLE SystemUsers (
    SystemUserId INT PRIMARY KEY,
    Username NVARCHAR(255),
    Email NVARCHAR(255),
    PasswordHash NVARCHAR(255),
    RoleId INT,
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);
GO

-- 🔹 Create Donors Table
CREATE TABLE Donors (
    DonorId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(20),
    StreetAddressLine1 NVARCHAR(255),  -- ✅ First street address line
    StreetAddressLine2 NVARCHAR(255),  -- ✅ Second street address line
    City NVARCHAR(100),
    State NVARCHAR(100),
    PostalCode NVARCHAR(20),
    Country NVARCHAR(100),
    DateOfBirth DATE,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);
GO
GO

-- 🔹 Create Transactions Table
CREATE TABLE Transactions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DonorId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    TransactionDate DATETIME DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(50) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    ReferenceNumber NVARCHAR(50) UNIQUE NOT NULL,
    FOREIGN KEY (DonorId) REFERENCES Donors(DonorId) ON DELETE CASCADE
);
GO

-- 🔹 Create Campaigns Table
CREATE TABLE Campaigns (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);
GO

-- 🔹 Create Organizations Table
CREATE TABLE Organizations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    ContactEmail NVARCHAR(255) UNIQUE NOT NULL
);
GO

-- 🔹 Create PaymentMethods Table
CREATE TABLE PaymentMethods (
    Id INT PRIMARY KEY IDENTITY(1,1),
    MethodName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL
);
GO

-- 🔹 Create Receipts Table
CREATE TABLE Receipts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TransactionId INT NOT NULL,
    IssuedDate DATETIME DEFAULT GETDATE(),
    ReceiptNumber NVARCHAR(50) UNIQUE NOT NULL,
    FOREIGN KEY (TransactionId) REFERENCES Transactions(Id) ON DELETE CASCADE
);
GO

-- ✅ Create Indexes for Faster Queries
CREATE INDEX IX_Donors_Email ON Donors(Email);
CREATE INDEX IX_Transactions_ReferenceNumber ON Transactions(ReferenceNumber);
CREATE INDEX IX_Users_Username ON Users(Username);
GO