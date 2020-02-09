using System;

namespace Budget.Core.Domain
{
    public interface ITransaction
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        decimal Bill { get; }
        DateTime CreatedAt { get; }
        DateTime TransactionDateTime { get; }
        Guid TypeId { get; }
        bool IsPlanned { get; }
        bool IsIncome { get; }
    }
}