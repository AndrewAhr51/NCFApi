USE [NCFDonorDb]
GO
-- ✅ Drop tables in the correct order to avoid constraint errors
DROP TABLE IF EXISTS Receipts;           -- Depends on Transactions
DROP TABLE IF EXISTS Transactions;       -- Depends on Donors
DROP TABLE IF EXISTS Donors;             -- Depends on Users
DROP TABLE IF EXISTS Users;              -- Depends on Roles
DROP TABLE IF EXISTS SystemUsers;        -- Depends on Roles
DROP TABLE IF EXISTS RolePermissions;    -- Depends on Roles and Permissions
DROP TABLE IF EXISTS Permissions;        -- No dependencies
DROP TABLE IF EXISTS Roles;              -- No dependencies
DROP TABLE IF EXISTS PaymentMethods;     -- Standalone table
DROP TABLE IF EXISTS Organizations;      -- Standalone table
DROP TABLE IF EXISTS Campaigns;          -- Standalone table
GO