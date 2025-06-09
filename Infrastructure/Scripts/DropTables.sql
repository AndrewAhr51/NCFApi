USE [NCFDonorDb]
GO

-- ✅ Drop Receipts Table (Depends on Donations, Donors, Organizations, PaymentMethods, ReceiptStatuses)
DROP TABLE IF EXISTS Receipts;

-- ✅ Drop ReceiptStatuses Table (Independent Lookup)
DROP TABLE IF EXISTS ReceiptStatuses;

-- ✅ Drop Donations Table (Depends on Donors and CharitableOrganizations)
DROP TABLE IF EXISTS Donations;

-- ✅ Drop PaymentMethods Table (Independent Lookup)
DROP TABLE IF EXISTS PaymentMethods;

-- ✅ Drop CharitableOrganizations Table (Base Table for Donations)
DROP TABLE IF EXISTS CharitableOrganizations;

-- ✅ Drop Donors Table (Depends on Users)
DROP TABLE IF EXISTS Donors;

-- ✅ Drop Users Table (Base Table for Donors)
DROP TABLE IF EXISTS Users;

-- ✅ Drop RolePermissions Table (Depends on Roles and Permissions)
DROP TABLE IF EXISTS RolePermissions;

-- ✅ Drop Permissions Table (Independent Lookup)
DROP TABLE IF EXISTS Permissions;

-- ✅ Drop Roles Table (Base Table for Users & RolePermissions)
DROP TABLE IF EXISTS Roles;