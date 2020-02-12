using System;

namespace Budget.Core.Domain
{
    public class IncomeType : ITransactionType
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected IncomeType(){}

        protected IncomeType(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        public static IncomeType Create(string name, string description)
            => new IncomeType(name, description);
    }
}