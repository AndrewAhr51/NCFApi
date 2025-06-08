USE [NCFDonorDb]

INSERT INTO Roles (Name, Description) VALUES 
('Admin', 'Full access to manage users, permissions, and system settings'),
('Manager', 'Can oversee projects, manage teams, and view analytics'),
('Viewer', 'Can view reports and dashboards, but cannot modify data');
GO

-- Insert permissions
INSERT INTO Permissions (Name, Description) VALUES 
('ManageUsers', 'Can create, update, and delete user accounts'),
('ViewReports', 'Can view analytics and reports'),
('EditData', 'Can modify existing records'),
('DeleteRecords', 'Can remove records from the system'),
('ManageSettings', 'Can update system configurations and settings');

-- Assign permissions to roles
INSERT INTO RolePermissions (RoleId, PermissionId) VALUES
-- Admin Role: Full access
(1, 1),  -- ManageUsers
(1, 2),  -- ViewReports
(1, 3),  -- EditData
(1, 4),  -- DeleteRecords
(1, 5),  -- ManageSettings
-- Manager Role: Limited admin capabilities
(2, 2),  -- ViewReports
(2, 3),  -- EditData
-- Viewer Role: Read-only access
(3, 2);  -- ViewReports

-- ✅ Insert Sample Donors
INSERT INTO Donors (FirstName, LastName, Email, PhoneNumber, Address, DateOfBirth)
VALUES
('John', 'Doe', 'john.doe@example.com', '123-456-7890', '123 Main St', '1985-07-10'),
('Jane', 'Smith', 'jane.smith@example.com', '987-654-3210', '456 Elm St', '1990-05-25');

GO

-- ✅ Insert Sample Transactions
INSERT INTO Transactions (DonorId, Amount, PaymentMethod, Status, ReferenceNumber, TransactionDate)
VALUES
(1, 100.00, 'Credit Card', 'Completed', 'TXN1001', GETDATE()),
(2, 50.00, 'PayPal', 'Completed', 'TXN1002', GETDATE());

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

-- ✅ Insert Sample Payment Methods
INSERT INTO PaymentMethods (MethodName, Description, IsActive)
VALUES
('Credit Card','Visa, Mastercard, Etc',1),
('Debit Card','Debit Card', 1),
('PayPal', 'PayPal', 1),
('Wire Transfer', 'Wire Transfer', 1),
('Bank Transfer', 'Bank Transfer',1),
('Check', 'Check', 1 ),
('Cryptocurrency', 'Cryptocurrency', 1),
('Mobile Payment', 'Mobile Payment', 1);

GO

-- ✅ Insert Sample Receipts
INSERT INTO Receipts (TransactionId, IssuedDate, ReceiptNumber)
VALUES
(1, GETDATE(), 'RCP1001'),
(2, GETDATE(), 'RCP1002');

GO

-- ✅ Insert Sample Users (For Authentication)
INSERT INTO Users (Username, PasswordHash, Email, Role)
VALUES
('admin', 'hashed_password_here', 'admin@nfc.com','Admin'),
('manager', 'hashed_password_here', 'manager@nfc.com', 'Manager'),
('viewer', 'hashed_password_here', 'viewer@nfc.com','Viewer');

GO

-- ✅ Verify Data
SELECT * FROM Donors;
SELECT * FROM Transactions;
SELECT * FROM Campaigns;
SELECT * FROM Organizations;
SELECT * FROM PaymentMethods;
SELECT * FROM Receipts;
SELECT * FROM Users;