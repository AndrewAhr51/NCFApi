using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Data;

namespace NCFApi.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<AppDbContext>())
            {
                context.Database.Migrate(); // Ensure DB is up to date

                // ✅ Seed Donors if Database is Empty
                if (!context.Donors.Any())
                {
                    context.Donors.AddRange(
                        new Donor { FirstName = "John", LastName = "Doe", Email = "john@example.com", PhoneNumber = "123-456-7890", Address = "123 Main St" },
                        new Donor { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", PhoneNumber = "987-654-3210", Address = "456 Elm St" }
                    );
                }

                // ✅ Seed Transactions if Database is Empty
                if (!context.Transactions.Any())
                {
                    context.Transactions.AddRange(
                        new Transaction { DonorId = 1, Amount = 100, PaymentMethod = "Credit Card", Status = "Completed", ReferenceNumber = "TXN1001", TransactionDate = DateTime.UtcNow },
                        new Transaction { DonorId = 2, Amount = 50, PaymentMethod = "PayPal", Status = "Completed", ReferenceNumber = "TXN1002", TransactionDate = DateTime.UtcNow }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}