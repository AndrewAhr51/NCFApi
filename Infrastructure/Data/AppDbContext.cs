using Microsoft.EntityFrameworkCore;
using NCFCore.Repositories;
using NCFApi.Domain.Entities;

namespace NCFApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ✅ Define DbSets for each entity
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}