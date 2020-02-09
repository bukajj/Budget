using System;

namespace Budget.Core.Domain
{
    public class TrancactionType : ITransactionType
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public bool IsIncome { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        
        protected TrancactionType(){}

        public TrancactionType(Guid id, string name, string description, bool isIncome)
        {
            Id = id;
            Name = name;
            Description = description;
            IsIncome = isIncome;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
    }
}