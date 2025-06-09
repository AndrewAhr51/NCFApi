USE [NCFDonorDb]
GO

-- ✅ Seed Roles (Bulk Insert)
INSERT INTO Roles (Name, Description)
VALUES 
    ('Admin', 'Full access to manage users, permissions, and system settings'),
    ('Manager', 'Can oversee projects, manage teams, and view analytics'),
    ('Viewer', 'Can view reports and dashboards, but cannot modify data'),
    ('Donor', 'Can edit only their profile and make donations');
GO

-- ✅ Seed Permissions (Bulk Insert)
INSERT INTO Permissions (Name, Description)
VALUES 
    ('ManageUsers', 'Can create, update, and delete user accounts'),
    ('ViewReports', 'Can view analytics and reports'),
    ('EditData', 'Can modify existing records'),
    ('DeleteRecords', 'Can remove records from the system'),
    ('ManageSettings', 'Can update system configurations and settings'),
    ('EditOwnProfile', 'Allows donors to update only their own information'),
    ('MakeDonation', 'Allows donors to make financial contributions');
GO

-- ✅ Assign Permissions to Roles (Optimized Bulk Insert)
INSERT INTO RolePermissions (RoleId, PermissionId)
SELECT 
    R.Id, P.Id
FROM Roles R
JOIN Permissions P 
    ON (R.Name = 'Admin' AND P.Name IN ('ManageUsers', 'ViewReports', 'EditData', 'DeleteRecords', 'ManageSettings'))
    OR (R.Name = 'Manager' AND P.Name IN ('ViewReports', 'EditData'))
    OR (R.Name = 'Viewer' AND P.Name = 'ViewReports')
    OR (R.Name = 'Donor' AND P.Name IN ('EditOwnProfile', 'MakeDonation'))
WHERE EXISTS (SELECT 1 FROM Roles WHERE Roles.Name = R.Name)
AND EXISTS (SELECT 1 FROM Permissions WHERE Permissions.Name = P.Name);
GO

-- ✅ Insert Sample Users (Bulk Insert)
INSERT INTO Users (Username, PasswordHash, Email, RoleId, CreatedAt, UpdatedAt)
VALUES 
    ('admin', 'hashed_password_here', 'admin@nfc.com', (SELECT Id FROM Roles WHERE Name = 'Admin'), GETDATE(), GETDATE()),
    ('manager', 'hashed_password_here', 'manager@nfc.com', (SELECT Id FROM Roles WHERE Name = 'Manager'), GETDATE(), GETDATE()),
    ('viewer', 'hashed_password_here', 'viewer@nfc.com', (SELECT Id FROM Roles WHERE Name = 'Viewer'), GETDATE(), GETDATE());
GO

-- ✅ Insert Sample Donors (Bulk Insert)
INSERT INTO Donors (UserId, FirstName, LastName, Email, PhoneNumber, Address, DateOfBirth, CreatedAt, UpdatedAt)
SELECT 
    U.UserId, 'John', 'Doe', 'john.doe@example.com', '123-456-7890', '123 Main St', '1985-07-10', GETDATE(), GETDATE()
FROM Users U WHERE U.Username = 'admin'
UNION ALL
SELECT 
    U.UserId, 'Jane', 'Smith', 'jane.smith@example.com', '987-654-3210', '456 Elm St', '1990-05-25', GETDATE(), GETDATE()
FROM Users U WHERE U.Username = 'manager';
GO

-- ✅ Insert Sample Transactions (Efficient References)
INSERT INTO Transactions (DonorId, Amount, PaymentMethod, Status, ReferenceNumber, TransactionDate)
SELECT DonorId, 100.00, 'Credit Card', 'Completed', 'TXN1001', GETDATE()
FROM Donors WHERE Email = 'john.doe@example.com'
UNION ALL
SELECT DonorId, 50.00, 'PayPal', 'Completed', 'TXN1002', GETDATE()
FROM Donors WHERE Email = 'jane.smith@example.com';
GO

-- ✅ Insert Sample Campaigns
INSERT INTO Campaigns (Name, StartDate, EndDate)
VALUES 
    ('Disaster Relief Fund', '2025-01-01', '2025-12-31'),
    ('Education Support Program', '2025-03-01', '2025-08-31');
GO

-- ✅ Insert Sample Organizations
INSERT INTO Organizations (Name, ContactEmail)
VALUES 
    ('Global Aid Foundation', 'contact@gaf.org'),
    ('Education First Initiative', 'support@educationfirst.org');
GO

-- ✅ Insert Sample Payment Methods (Optimized Format)
INSERT INTO PaymentMethods (MethodName, Description, IsActive)
VALUES 
    ('Credit Card', 'Visa, Mastercard, Etc', 1),
    ('Debit Card', 'Debit Card', 1),
    ('PayPal', 'PayPal', 1),
    ('Wire Transfer', 'Wire Transfer', 1),
    ('Bank Transfer', 'Bank Transfer', 1),
    ('Check', 'Check', 1),
    ('Cryptocurrency', 'Cryptocurrency', 1),
    ('Mobile Payment', 'Mobile Payment', 1);
GO

-- ✅ Insert Sample Receipts
INSERT INTO Receipts (TransactionId, IssuedDate, ReceiptNumber)
SELECT Id, GETDATE(), 'RCP1001' FROM Transactions WHERE ReferenceNumber = 'TXN1001'
UNION ALL
SELECT Id, GETDATE(), 'RCP1002' FROM Transactions WHERE ReferenceNumber = 'TXN1002';
GO

-- ✅ Verify Data
SELECT * FROM Roles;
SELECT * FROM Permissions;
SELECT * FROM RolePermissions;
SELECT * FROM Users;
SELECT * FROM Donors;
SELECT * FROM Transactions;
SELECT * FROM Campaigns;
SELECT * FROM Organizations;
SELECT * FROM PaymentMethods;
SELECT * FROM Receipts;
GO