using System;

namespace Budget.Core.Domain
{
    public class Expence : ITransaction
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Bill { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime TransactionDateTime { get; protected set; }
        public Guid TypeId { get; protected set; }
        
        protected Expence(){}

        public Expence(Guid id, string name, string description, decimal bill, DateTime transactionDateTime,
            Guid typeId)
        {
            Id = id;
            Name = name;
            Description = description;
            Bill = bill;
            TransactionDateTime = transactionDateTime;
            CreatedAt = DateTime.UtcNow;
            TypeId = typeId;
        }
    }
}