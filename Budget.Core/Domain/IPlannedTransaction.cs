using System;

namespace Budget.Core.Domain
{
    public interface IPlannedTransaction
    { 
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        decimal Bill { get; }
        DateTime CreatedAt { get; }
        DateTime TransactionDateTime { get; }
    }
}