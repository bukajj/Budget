using System;

namespace Budget.Core.Domain
{
    public interface ITransactionType
    {
        string Name { get; }
        string Description { get; }
    }
}