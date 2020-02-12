using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Core.Domain
{
    public class CurrentAccount
    {
        private ISet<Income> _incomes = new HashSet<Income>();
        private ISet<Expence> _expences = new HashSet<Expence>();
        private ISet<PlannedIncome> _plannedIncomes = new HashSet<PlannedIncome>();
        private ISet<PlannedExpence> _plannedExpences = new HashSet<PlannedExpence>();
        
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Balance { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public IEnumerable<Income> Incomes
        {
            get { return _incomes; }
            set { _incomes = new HashSet<Income>(value);}
        }

        public IEnumerable<Expence> Expences
        {
            get { return _expences; }
            set {_expences = new HashSet<Expence>(value);}
        }
        public IEnumerable<PlannedIncome> PlannedIncomes
        {
            get { return _plannedIncomes; }
            set {_plannedIncomes = new HashSet<PlannedIncome>(value);}
        }
        public IEnumerable<PlannedExpence> PlannedExpences
        {
            get { return _plannedExpences; }
            set {_plannedExpences = new HashSet<PlannedExpence>(value);}
        }
     
        protected CurrentAccount(){}

        protected CurrentAccount(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddIncome(Guid id, string name, string description, decimal bill, DateTime transactionDateTime,
            IncomeType type)
        {
            var income = GetIncome(id);
            if (income != null)
            {
                throw new Exception(); // TODO
            }

            _incomes.Add(Income.Create(id, name, description, bill, transactionDateTime, type));
        }

        public void AddExpence(Guid id, string name, string description, decimal bill,
            DateTime transactionDateTime, ExpenceType type)
        {
            var expence = GetExpence(id);
            if (expence != null)
            {
                throw new Exception(); // TODO
            }

            _expences.Add(Expence.Create(id, name, description, bill, transactionDateTime, type));
        }

        public void AddPlannedIncome(Guid id, string name, string description, decimal bill,
            DateTime transactionDateTime, IncomeType type)
        {
            var income = GetPlannedIncome(id);
            if (income != null)
            {
                throw new Exception(); // TODO
            }

            _plannedIncomes.Add(PlannedIncome.Create(id, name, description, bill, transactionDateTime, type));
        }

        public void AddPlannedExpence(Guid id, string name, string description, decimal bill, 
            DateTime transactionDateTime, ExpenceType type)
        {
            var expence = GetPlannedExpence(id);
            if (expence != null)
            {
                throw new Exception(); // TODO
            }

            _plannedExpences.Add(PlannedExpence.Create(id, name, description, bill, transactionDateTime, type));
        }
        
        public void RemoveIncome(Guid id)
        {
            var income = GetIncome(id);
            if (income == null)
            {
                return;
            }

            _incomes.Remove(income);
        }

        public void RemoveExpence(Guid id)
        {
            var expence = GetExpence(id);
            if (expence == null)
            {
                return;
            }

            _expences.Remove(expence);
        }

        public void RemovePlannedIncome(Guid id)
        {
            var income = GetPlannedIncome(id);
            if (income == null)
            {
                return;
            }

            _plannedIncomes.Remove(income);
        }

        public void RemovePlannedExpence(Guid id)
        {
            var expence = GetPlannedExpence(id);
            if (expence == null)
            {
                return;
            }

            _plannedExpences.Remove(expence);
        }

        private Income GetIncome(Guid id) => _incomes.SingleOrDefault(income => income.Id.Equals(id));
        
        private Expence GetExpence(Guid id) => _expences.SingleOrDefault(expence => expence.Id.Equals(id));

        private PlannedIncome GetPlannedIncome(Guid id)
            => _plannedIncomes.SingleOrDefault(income => income.Id.Equals(id));

        private PlannedExpence GetPlannedExpence(Guid id)
            => _plannedExpences.SingleOrDefault(expence => expence.Id.Equals(id));
        
        public static CurrentAccount Create(string name, decimal balance)
            => new CurrentAccount(name, balance);
    }
}