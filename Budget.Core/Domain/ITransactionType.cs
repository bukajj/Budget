﻿using System;

namespace Budget.Core.Domain
{
    public interface ITransactionType
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
    }
}