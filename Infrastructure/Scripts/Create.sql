USE [NCFDonorDb]

GO

CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE,  -- Role Name (Admin, Manager, Viewer, etc.)
    Description NVARCHAR(255) NULL  -- Optional description
);

GO

CREATE TABLE Permissions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE,  -- Permission Name (e.g., "CanEditUsers", "CanDeleteRecords")
    Description NVARCHAR(255) NULL  -- Optional description
);

GO

CREATE TABLE RolePermissions (
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,
    PRIMARY KEY (RoleId, PermissionId),
    FOREIGN KEY (RoleId) REFERENCES Roles(Id) ON DELETE CASCADE,
    FOREIGN KEY (PermissionId) REFERENCES Permissions(Id) ON DELETE CASCADE
);

GO

-- ✅ Create Donors Table
CREATE TABLE Donors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(255),
    DateOfBirth DATE,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

GO

-- ✅ Create Transactions Table
CREATE TABLE Transactions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DonorId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    TransactionDate DATETIME DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(50) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    ReferenceNumber NVARCHAR(50) UNIQUE NOT NULL,
    FOREIGN KEY (DonorId) REFERENCES Donors(Id) ON DELETE CASCADE
);

GO

-- ✅ Create Campaigns Table
CREATE TABLE Campaigns (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);

GO

-- ✅ Create Organizations Table
CREATE TABLE Organizations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    ContactEmail NVARCHAR(255) UNIQUE NOT NULL
);
GO
-- ✅ Create PaymentMethods Table
CREATE TABLE PaymentMethods (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MethodName NVARCHAR(100) NOT NULL UNIQUE,
	Description NVARCHAR(100) NOT NULL,
	IsActive bit NOT NULL
);

GO

-- ✅ Create Receipts Table
CREATE TABLE Receipts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TransactionId INT NOT NULL,
    IssuedDate DATETIME DEFAULT GETDATE(),
    ReceiptNumber NVARCHAR(50) UNIQUE NOT NULL,
    FOREIGN KEY (TransactionId) REFERENCES Transactions(Id) ON DELETE CASCADE
);

GO

-- ✅ Create Users Table (For Authentication & Roles)
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    RoleId INT NOT NULL,  -- Foreign Key to Roles Table
    CreatedAt DATETIME DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME DEFAULT GETUTCDATE(),

    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleId)
    REFERENCES Roles(Id) ON DELETE CASCADE
);
GO

-- ✅ Create Indexes for Faster Queries
CREATE INDEX IX_Donors_Email ON Donors(Email);
CREATE INDEX IX_Transactions_ReferenceNumber ON Transactions(ReferenceNumber);
CREATE INDEX IX_Users_Username ON Users(Username);
