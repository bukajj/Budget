using System;
using System.Collections;
using System.Collections.Generic;

namespace Budget.Core.Domain
{
    public class User
    {
        private ISet<CurrentAccount> _currentAccounts = new HashSet<CurrentAccount>();
        
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Firstname { get; protected set; }
        public string Lastname { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public IEnumerable<CurrentAccount> CurrentAccounts
        {
            get { return _currentAccounts; }
            set { _currentAccounts = new HashSet<CurrentAccount>(value); }
        }
        
        protected User(){}

        public User(Guid id, string email, string password, string salt, string firstname, string lastname)
        {
            Id = id;
            Email = email;
            Password = password;
            Salt = salt;
            Firstname = firstname;
            Lastname = lastname;            
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }

        public void SetEmail(string email)
        {
            
        }
    }
}