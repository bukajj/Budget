using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Budget.Core.Domain
{
    public class User
    {
        private ISet<CurrentAccount> _currentAccounts = new HashSet<CurrentAccount>();
        private ISet<IncomeType> _incomeTypes = new HashSet<IncomeType>();
        private ISet<ExpenceType> _expenceTypes = new HashSet<ExpenceType>();
        
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

        public IEnumerable<IncomeType> IncomeTypes
        {
            get { return _incomeTypes; }
            set { _incomeTypes = new HashSet<IncomeType>(value); }
        }

        public IEnumerable<ExpenceType> ExpenceTypes
        {
            get { return _expenceTypes; }
            set { _expenceTypes = new HashSet<ExpenceType>(value); }
        }
        
        protected User(){}

        public User(Guid id, string email, string password, string salt, string firstname, string lastname)
        {
            Id = id;
            SetEmail(email);
            SetPassword(password, salt);
            SetFirstname(firstname);
            SetLastname(lastname);            
            CreatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception(); // TODO
            }
            
            var isValid = new EmailAddressAttribute().IsValid(email);
            if (!isValid)
            {
                throw new Exception(); // TODO
            }

            if (Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception(); // TODO
            }

            if (password.Length < 6 || password.Length > 50)
            {
                throw new Exception(); // TODO
            }

            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetFirstname(string firstname)
        {
            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new Exception(); // TODO
            }

            Firstname = firstname;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLastname(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new Exception(); // TODO
            }

            Lastname = lastname;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddCurrnetAccount(string name, decimal balance)
        {
            var account = GetCurrentAccount(name);
            if (account != null)
            {
                throw new Exception(); // TODO
            }

            _currentAccounts.Add(CurrentAccount.Create(name, balance));
        }
        
        public void RemoveCurrnetAccount(string name)
        {
            var account = GetCurrentAccount(name);
            if (account == null)
            {
                return;                
            }

            _currentAccounts.Remove(account);
        }

        public void AddIncomeType(string name, string description)
        {
            var type = GetIncomeType(name);
            if (type != null)
            {
                throw new Exception(); // TODO
            }

            _incomeTypes.Add(IncomeType.Create(name, description));
        }
        
        public void AddExpenceType(string name, string description)
        {
            var type = GetExpenceType(name);
            if (type != null)
            {
                throw new Exception(); // TODO
            }

            _expenceTypes.Add(ExpenceType.Create(name, description));
        }
        
        public void RemoveIncomeType(string name)
        {
            var type = GetIncomeType(name);
            if (type == null)
            {
                return;
            }

            _incomeTypes.Remove(type);
        }
        
        public void RemoveExpenceType(string name)
        {
            var type = GetExpenceType(name);
            if (type == null)
            {
                return;
            }

            _expenceTypes.Remove(type);
        }

        private CurrentAccount GetCurrentAccount(string name)
            => _currentAccounts.SingleOrDefault(account => account.Name == name);

        private IncomeType GetIncomeType(string name)
            => _incomeTypes.SingleOrDefault(type => type.Name == name);

        private ExpenceType GetExpenceType(string name)
            => _expenceTypes.SingleOrDefault(type => type.Name == name); }
}