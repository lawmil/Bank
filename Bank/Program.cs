using System;
using System.Collections.Generic;

namespace Bank
{
    class Person
    {
        protected string firstName;
        protected string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;

        }

    }
    class Account
    {
        // properties
        protected int accountId;
        protected Person owner;
        public double balance;

        public Account(int accountId, Person owner, int balance)
        {
            this.accountId = accountId;
            this.owner = owner;
            this.balance = balance;
        }
        public Account() { }
        //Operation
        public void Deposit(double amount)
        {
            this.balance += amount;
        }
        public bool Withdraw(double amount)
        {
            if (amount > this.balance)
            {
                Console.WriteLine("Operation not allowed.");
                return false;
            }
            else
            {
                this.balance -= amount;
                return true;
            }
        }
        public bool Transfer(Account transferTo, double amount)
        {
            var total = amount;
            if (total > this.balance)
            {
                Console.WriteLine("Insufficient Funds");
                return false;
            }
            else
            {
                this.balance -= total;
                transferTo.balance += amount;
                Console.WriteLine("Funds Transfered");
                return true;
            }
        }
    }
    class Bank
    {
        public string name;
        private protected List<Account> accounts;
        public Bank(string name, List<Account> accounts)
        {
            this.name = name;
            this.accounts = accounts;
        }
    }
        class InvestmentAccount : Account {
           
    }
        class CheckingAccount : Account { 
        
    }

        class IndividualAccount : InvestmentAccount
        {
            //500 withdraw limit
            public bool Withdraw(double amount)
            {
                if (amount > this.balance || amount >= 500)
                {
                    Console.WriteLine("Reach Account Limit");
                    return false;
                }
                else
                {
                    this.balance -= amount;
                    return true;
                }
            }
        }
        class CorporateAccount : InvestmentAccount { }

        class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person("Law", "Mil");
            var person2 = new Person("Trey", "Milly");

            var account1 = new Account(1, person1, 600);
            var account2 = new Account(2, person2, 700);

            var bank = new Bank("A sample bank", new List<Account> { account1, account2 });

            account1.Deposit(200);

            account1.Withdraw(100);

            account1.Transfer(account2, 200);
            Console.WriteLine("Account 1 has:" + account1.balance);

        }
    }
}
