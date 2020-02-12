using System;

namespace Budget.Core.Domain
{
    public class PlannedIncome : IPlannedTransaction
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Bill { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime TransactionDateTime { get; protected set; }
        public IncomeType Type { get; protected set; }
        
        protected PlannedIncome(){}
        
        protected PlannedIncome(Guid id, string name, string description, decimal bill, DateTime transactionDateTime,
            IncomeType type)
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
        
        public static PlannedIncome Create(Guid id, string name, string description, decimal bill, DateTime transactionDateTime,
            IncomeType type) 
            => new PlannedIncome(id, name, description, bill, transactionDateTime, type);
    }
}