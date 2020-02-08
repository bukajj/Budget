using System;

namespace Budget.Core.Domain
{
    public interface ITransaction
    {
        Guid Id { get; }
        Decimal Bill { get; }
        DateTime CreatedAt { get; }
        DateTime TransactionDateTime { get; }
        bool IsDraft { get; }
        bool IsCyclic { get; }
        DateTime? StartDateTime { get; }
        DateTime? EndDateTime { get; }
        TransactionType Type { get; }
    }
}