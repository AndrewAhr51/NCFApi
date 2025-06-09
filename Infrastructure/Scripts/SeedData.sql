USE [NCFDonorDb];
GO

-- 🔹 Insert Roles
INSERT INTO Roles (Name, Description) VALUES 
('Admin', 'Administrator with full access'),
('Donor', 'User who donates funds'),
('Organization Manager', 'Manages charitable organizations');
GO

-- 🔹 Insert Permissions
INSERT INTO Permissions (Name, Description) VALUES 
('CreateUser', 'Allows creation of users'),
('ManageDonations', 'Can process and manage donations'),
('ViewReports', 'Can access financial reports');
GO

-- 🔹 Insert Role-Permission Assignments
INSERT INTO RolePermissions (RolePermissionId, PermissionId) VALUES 
(1, 1), (1, 2), (1, 3), -- Admin
(2, 2), -- Donor
(3, 2), (3, 3); -- Organization Manager
GO

-- 🔹 Insert Users
INSERT INTO Users (Username, Email, PasswordHash, RoleId) VALUES 
('admin1', 'admin@ncfdonor.org', 'hashedpassword123', 1),
('donor1', 'donor1@example.com', 'hashedpassword456', 2),
('manager1', 'manager1@charity.org', 'hashedpassword789', 3);
GO

-- 🔹 Insert Charitable Organizations
INSERT INTO CharitableOrganizations (Name, Description, RegistrationNumber, Website, ContactEmail, ContactPhone, Address, City, State, Country, PostalCode, FoundedYear, TotalDonations, IsActive) VALUES 
('Helping Hands', 'Provides food and shelter for those in need', 'HH12345', 'https://helpinghands.org', 'info@helpinghands.org', '123-456-7890', '123 Charity St', 'New York', 'NY', 'USA', '10001', 2005, 50000, 1),
('Education First', 'Improving education access for underprivileged children', 'EF67890', 'https://educationfirst.org', 'contact@educationfirst.org', '987-654-3210', '456 Education Rd', 'San Francisco', 'CA', 'USA', '94105', 2010, 75000, 1);
GO

-- 🔹 Insert Donors
INSERT INTO Donors (UserId, FirstName, LastName, Email, PhoneNumber, StreetAddressLine1, City, State, PostalCode, Country, DateOfBirth) VALUES 
(2, 'John', 'Doe', 'john.doe@example.com', '555-111-2222', '789 Giving Ln', 'Los Angeles', 'CA', '90001', 'USA', '1985-06-15'),
(2, 'Jane', 'Smith', 'jane.smith@example.com', '555-333-4444', '321 Care Ave', 'Seattle', 'WA', '98101', 'USA', '1990-09-23');
GO

-- 🔹 Insert Donations
INSERT INTO Donations (DonorId, OrganizationId, Amount, PaymentMethod, TransactionReference, Status) VALUES 
(1, 1, 100.00, 'Credit Card', 'TXN001', 'Completed'),
(2, 2, 50.00, 'PayPal', 'TXN002', 'Pending');
GO

-- 🔹 Insert Payment Methods
INSERT INTO PaymentMethods (MethodName, Description, IsActive) VALUES 
('Credit Card', 'Payment via credit card', 1),
('PayPal', 'Online payment via PayPal', 1);
GO

-- 🔹 Insert Receipt Statuses
INSERT INTO ReceiptStatuses (StatusName, Description) VALUES 
('Pending', 'Receipt is awaiting approval'),
('Issued', 'Receipt has been issued'),
('Cancelled', 'Receipt was cancelled');
GO

-- 🔹 Insert Receipts
INSERT INTO Receipts (DonationId, DonorId, OrganizationId, PaymentMethodId, StatusId, ReceiptNumber, Amount) VALUES 
(1, 1, 1, 1, 2, 'RCPT001', 100.00),
(2, 2, 2, 2, 1, 'RCPT002', 50.00);
GO