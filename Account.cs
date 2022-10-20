using System.Collections.Generic;
using System;

namespace AppCuentaBanca
{
    public class Account
    {

        // Documentar
        public override string ToString() {
            return "Account";
        }

        public virtual bool TransferMoney(Account personalAccount, Account targetAccount, float amount) {

            Console.WriteLine("Enter the account number to transfer");
            int accountNumbertoTransfer = int.Parse(Console.ReadLine());

            /* Console.WriteLine("Enter the amount to transfer");
            int amountToTransfer = int.Parse(Console.ReadLine()); */
        
            if (
                targetAccount.accountNumber != accountNumbertoTransfer 
                || amount <= 0 || personalAccount.balance - amount <= 0
            ) 
            {
                Console.WriteLine("The transfer was erroneous");
                return false;
            }

            personalAccount.balance -= amount;
            targetAccount.balance += amount;
            Console.WriteLine("Fine " + amount + personalAccount.balance);
            return true;
        }
        
        public virtual bool Withdraw( Account personalAccount, float amount ) {

            // Withdraw money from the account
            if ( personalAccount.balance < amount ) {
                Console.WriteLine("The money cannot be withdrawn, the amount is greater than the available balance."); 
                return false;
            }

            return true;
        }
        public virtual bool Withdraw() { return false; }

        protected virtual void MakeDeposit() {}
        protected virtual void CheckBalance() {}
        protected virtual void Balance() {}






        /* Declaring the variables that will be used in the class. */
        protected float balance = 300000.5f;

        protected string name { get; set; }
        protected string lastName { get; set; }
        protected string profession { get; set; }
        protected string address { get; set; }
        protected string password { get; set; }

        protected int idNumber { get; set; }
        protected int accountNumber { get; set; }
        protected int phone { get; set; }
        protected int operations { get; set; }

        public string Name { get => this.name; set => this.name = value; }
        public string LastName { get => this.lastName; set => this.lastName = value; }
        public string Profession { get => this.profession; set => this.profession = value; }
        public string Address { get => this.address; set => this.address = value; }
        public string Password { get => this.password; set => this.password = value; }

        public int IdNumber { get => this.idNumber; set => this.idNumber = value; }
        public int AccountNumber { get => this.accountNumber; set => this.accountNumber = value; }
        public int Phone { get => this.phone; set => this.phone = value; }
        public int Operations { get => this.operations; set => this.operations = value; }
    }
}