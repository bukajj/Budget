using System;

namespace Budget.Core.Domain
{
    public interface IPlannedTransaction
    { 
        Guid Id { get; }
        string name { get; }
        string description { get; }
        DateTime CreatedAt { get; }
        DateTime TransactionDateTime { get; }
        
    }
}