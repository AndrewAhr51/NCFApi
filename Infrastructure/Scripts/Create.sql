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

-- 🔹 Create CharitableOrganizations Table
CREATE TABLE CharitableOrganizations (
    OrganizationId INT PRIMARY KEY IDENTITY(1,1),  -- ✅ Unique ID (Auto Increment)
    Name NVARCHAR(255) NOT NULL,                   -- ✅ Organization Name
    Description NVARCHAR(MAX),                      -- ✅ Brief Description
    RegistrationNumber NVARCHAR(50) UNIQUE NOT NULL, -- ✅ Legal Registration Number
    Website NVARCHAR(255),                          -- ✅ Website URL
    ContactEmail NVARCHAR(255) UNIQUE,              -- ✅ Contact Email
    ContactPhone NVARCHAR(20),                      -- ✅ Contact Phone
    Address NVARCHAR(255),                          -- ✅ Physical Address
    City NVARCHAR(100),                             -- ✅ City
    State NVARCHAR(100),                            -- ✅ State / Region
    Country NVARCHAR(100),                          -- ✅ Country
    PostalCode NVARCHAR(20),                        -- ✅ ZIP / Postal Code
    FoundedYear INT,                                -- ✅ Year Founded
    TotalDonations DECIMAL(18,2),                   -- ✅ Total Donation Received
    IsActive BIT DEFAULT 1,                         -- ✅ Organization Status (Active/Inactive)
    CreatedAt DATETIME DEFAULT GETDATE(),           -- ✅ Record Created Timestamp
    UpdatedAt DATETIME DEFAULT GETDATE()            -- ✅ Last Update Timestamp
);

GO

-- 🔹 Create Donations Table
CREATE TABLE Donations (
    DonationId INT PRIMARY KEY IDENTITY(1,1),  -- ✅ Unique Donation ID
    DonorId INT NOT NULL,  -- ✅ Links to Donors table
    OrganizationId INT NOT NULL,  -- ✅ Links to CharitableOrganizations table
    Amount DECIMAL(18,2) NOT NULL,  -- ✅ Donation amount
    DonationDate DATETIME DEFAULT GETDATE(),  -- ✅ Timestamp of donation
    PaymentMethod NVARCHAR(50) NOT NULL,  -- ✅ Payment method (Credit Card, PayPal, etc.)
    TransactionReference NVARCHAR(100) UNIQUE NOT NULL,  -- ✅ Unique transaction ID
    Status NVARCHAR(20) DEFAULT 'Completed',  -- ✅ Payment Status (Completed, Pending, Failed)
    Notes NVARCHAR(MAX),  -- ✅ Optional notes about the donation
    
    -- 🔹 Foreign Key Relationships
    FOREIGN KEY (DonorId) REFERENCES Donors(DonorId) ON DELETE CASCADE,
    FOREIGN KEY (OrganizationId) REFERENCES CharitableOrganizations(OrganizationId) ON DELETE CASCADE
);

-- 🔹 Create PaymentMethods Table
CREATE TABLE PaymentMethods (
    Id INT PRIMARY KEY IDENTITY(1,1),
    MethodName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL
);
GO

-- 🔹 Create ReceiptStatuses Table
CREATE TABLE ReceiptStatuses (
    StatusId INT PRIMARY KEY IDENTITY(1,1),  -- ✅ Unique ID for each status
    StatusName NVARCHAR(50) NOT NULL UNIQUE,  -- ✅ Standardized status name
    Description NVARCHAR(255) NOT NULL  -- ✅ Additional details about the status
);
GO
-- 🔹 Create Receipts Table
CREATE TABLE Receipts (
    ReceiptId INT PRIMARY KEY IDENTITY(1,1),  
    DonationId INT NOT NULL,  
    DonorId INT NOT NULL,  
    OrganizationId INT NOT NULL,  
    PaymentMethodId INT NOT NULL,  
    StatusId INT NOT NULL,  -- ✅ Links to ReceiptStatuses table
    IssuedDate DATETIME DEFAULT GETDATE(),  
    ReceiptNumber NVARCHAR(50) UNIQUE NOT NULL,  
    Amount DECIMAL(18,2) NOT NULL,  
    Notes NVARCHAR(MAX),  
    
    -- 🔹 Foreign Key Relationships
    FOREIGN KEY (DonationId) REFERENCES Donations(DonationId),
    FOREIGN KEY (DonorId) REFERENCES Donors(DonorId),
    FOREIGN KEY (OrganizationId) REFERENCES CharitableOrganizations(OrganizationId),
    FOREIGN KEY (PaymentMethodId) REFERENCES PaymentMethods(Id),
    FOREIGN KEY (StatusId) REFERENCES ReceiptStatuses(StatusId)
);
GO
-- ✅ Index for faster donor lookup
CREATE INDEX IDX_Donors_Email ON Donors(Email);
CREATE INDEX IDX_Donors_UserId ON Donors(UserId);

-- ✅ Index for quick organization searches
CREATE INDEX IDX_CharitableOrganizations_RegistrationNumber ON CharitableOrganizations(RegistrationNumber);
CREATE INDEX IDX_CharitableOrganizations_Name ON CharitableOrganizations(Name);

-- ✅ Index for efficient donation tracking
CREATE INDEX IDX_Donations_DonorId ON Donations(DonorId);
CREATE INDEX IDX_Donations_OrganizationId ON Donations(OrganizationId);
CREATE INDEX IDX_Donations_TransactionReference ON Donations(TransactionReference);

-- ✅ Index for fast receipts retrieval
CREATE INDEX IDX_Receipts_ReceiptNumber ON Receipts(ReceiptNumber);

-- ✅ Index for payment method efficiency
CREATE INDEX IDX_PaymentMethods_MethodName ON PaymentMethods(MethodName);

-- ✅ Index for receipt status filtering
CREATE INDEX IDX_ReceiptStatuses_StatusName ON ReceiptStatuses(StatusName);
