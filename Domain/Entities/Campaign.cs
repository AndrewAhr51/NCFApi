using System;
using System.Collections.Generic;

namespace NCFApi.Domain.Entities
{
    public class Campaign
    {
        public int Id { get; set; }  // Unique Identifier
        public required string Name { get; set; }  // Campaign Title
        public required DateTime StartDate { get; set; }  // Campaign Start
        public required DateTime EndDate { get; set; }  // Campaign End
        public required string Description { get; set; }  // Optional Description
        public required decimal GoalAmount { get; set; }  // Fundraising Target

        // ✅ Navigation Properties
        public required ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}