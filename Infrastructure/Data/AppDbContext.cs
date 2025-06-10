using Microsoft.EntityFrameworkCore;
using NCFApi.Domain.Entities;

namespace NCFApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ✅ Define DbSets for each entity
        public DbSet<Donor> Donors { get; set; }
        public DbSet<CharitableOrganization> CharitableOrganizations { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptStatus> ReceiptStatuses { get; set; } // ✅ Fixed plural naming
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; } // ✅ Fixed singular naming
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

    }
}