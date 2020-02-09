using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
            SetEmail(email);
            SetPassword(password);
            Salt = salt;
            Firstname = firstname;
            Lastname = lastname;            
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return;
            }
            
            var isValid = new EmailAddressAttribute().IsValid(email);
            if (!isValid)
            {
                return;
            }

            if (Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return;
            }

            var isValid = !password.Contains(" ");
            if (!isValid)
            {
                return;
            }

            if (Password == password)
            {
                return;
            }

            if (password.Length < 8 || password.Length > 50)
            {
                throw new Exception("Password should contain more than 8 and less than 50 charcters.");
            }

            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
        
        
    }
}