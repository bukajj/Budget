using System;

namespace Budget.Core.Domain
{
    public class ExpenceType : ITransactionType
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected ExpenceType(){}

        protected ExpenceType(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        public static ExpenceType Create(string name, string description)
            => new ExpenceType(name, description);
    }
}