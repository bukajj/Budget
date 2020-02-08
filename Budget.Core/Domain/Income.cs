using System;

namespace Budget.Core.Domain
{
    public class Income :ITransaction
    {
        public Guid Id { get; protected set; }
        public decimal Bill { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime TransactionDateTime { get; protected set; }
        public bool IsDraft { get; protected set;}
        public bool IsCyclic { get; protected set;}
        public DateTime? StartDateTime { get; protected set;}
        public DateTime? EndDateTime { get; protected set;}
        public TransactionType Type { get; protected set; }
    }
}