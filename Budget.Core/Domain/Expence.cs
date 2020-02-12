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
        public ExpenceType Type { get; protected set; }
        
        protected Expence(){}

        protected Expence(Guid id, string name, string description, decimal bill, DateTime transactionDateTime,
            ExpenceType type)
        {
            Id = id;
            Name = name;
            Description = description;
            SetBill(bill);
            Type = type;
            TransactionDateTime = transactionDateTime;
            CreatedAt = DateTime.UtcNow;
        }
        
        private void SetBill(decimal bill)
        {
            if (bill <= 0)
            {
                throw new Exception(); // TODO
            }

            Bill = bill;
        }
        
        public static Expence Create(Guid id, string name, string description, decimal bill, DateTime transactionDateTime,
            ExpenceType type) 
            => new Expence(id, name, description, bill, transactionDateTime, type);
    }
}