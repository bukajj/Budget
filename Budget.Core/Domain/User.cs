using System;
using System.Collections;
using System.Collections.Generic;

namespace Budget.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Firstname { get; protected set; }
        public string Lastname { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public IEnumerable<Income> Incomes { get; protected set; }
        public IEnumerable<Expence> Expences { get; protected set; }
        
        protected User(){}

        public User(string email, string password, string salt)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }
    }
}