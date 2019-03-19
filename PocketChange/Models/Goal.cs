using System;
using System.Data;

namespace PocketChange.Models
{
    public class Goal
    {
        public Goal(DataRow dr)
        {
            GoalId = dr.Field<Guid>("GoalId");
            UserId = dr.Field<Guid>("UserId");
            GoalTypeId = dr.Field<int>("GoalTypeId");
            AccountType = dr.Field<int>("AccountType");
            CreatedOn = dr.Field<DateTime>("CreatedOn");
            Deadline = dr.Field<DateTime>("Deadline");
        }
        
        public Guid GoalId { get; }
        public Guid UserId { get; }
        public int GoalTypeId { get; }
        public int AccountType { get; }
        public DateTime CreatedOn { get; }
        public DateTime Deadline { get; }
    }
}