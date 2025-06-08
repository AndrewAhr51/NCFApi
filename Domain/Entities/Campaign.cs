using System;
using System.Collections.Generic;

namespace NCFApi.Domain.Entities
{
    public class Campaign
    {
        public int Id { get; set; }  // Unique Identifier
        public string Name { get; set; }  // Campaign Title
        public DateTime StartDate { get; set; }  // Campaign Start
        public DateTime EndDate { get; set; }  // Campaign End
        public string Description { get; set; }  // Optional Description
        public decimal GoalAmount { get; set; }  // Fundraising Target

        // ✅ Navigation Properties
        public ICollection<Transaction> Transactions { get; set; }
    }
}