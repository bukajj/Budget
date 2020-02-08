using System;

namespace Budget.Core.Domain
{
    public class TransactionType
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}