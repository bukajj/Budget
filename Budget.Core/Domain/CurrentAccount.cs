using System;
using System.Collections;
using System.Collections.Generic;

namespace Budget.Core.Domain
{
    public class CurrentAccount
    {
        public Guid Id { get; protected set; }
        public Decimal Balance { get; protected set; }
        public IEnumerable<Income> Incomes { get; protected set; }
        public IEnumerable<Expence> Expences { get; protected set; }
        public IEnumerable<PlannedIncome> PlannedIncomes { get; protected set; }
        public IEnumerable<PlannedExpence> PlannedExpences { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        
        protected CurrentAccount(){}

        public CurrentAccount(Guid id, Decimal balance)
        {
            Id = id;
            Balance = balance;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
    }
}