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

            Console.Write("Enter the account number to transfer: ");
            int accountNumbertoTransfer = int.Parse(Console.ReadLine());

            /* Console.WriteLine("Enter the amount to transfer");
            int amountToTransfer = int.Parse(Console.ReadLine()); */
        
            if (
                targetAccount.accountNumber != accountNumbertoTransfer 
                || amount <= 0 || personalAccount.balance - amount <= 0
            ) 
            {
                Console.WriteLine("\nThe transfer was erroneous...".ToUpper());
                return false;
            }

            personalAccount.balance -= amount;
            targetAccount.balance += amount;
            Console.WriteLine($"Fine {amount} - Personal: {personalAccount.balance}");
            Console.WriteLine($"Fine {amount} - Target: {personalAccount.balance}");
            return true;
        }
        
        protected virtual bool Withdraw( Account personalAccount, float amount ) {

            // Withdraw money from the account
            if ( personalAccount.balance < amount ) {
                Console.WriteLine("The money cannot be withdrawn, the amount is greater than the available balance."); 
                return false;
            }

            return true;
        }
        protected virtual bool Withdraw() { return false; }

        protected virtual void MakeDeposit() {}
        protected virtual void CheckBalance() {}
        protected virtual void Balance() {}

        // create function that shows all the properties of the class
        public virtual void ShowAccountData() {
            Console.WriteLine($"\nName: {this.name}");
            Console.WriteLine($"Last name: {this.lastName}");
            Console.WriteLine($"Profession: {this.profession}");
            Console.WriteLine($"Address: {this.address}");
            Console.WriteLine($"Password: {this.password}");
            Console.WriteLine($"ID number: {this.idNumber}");
            Console.WriteLine($"Account number: {this.accountNumber}");
            Console.WriteLine($"Phone: {this.phone}");
            Console.WriteLine($"Operations: {this.operations}");
        }

        public int CheckFieldIsNumber( string message) {
            // Cycle to validate the field number
            bool IsCorrect = false;
            int field = 0;

            while ( !IsCorrect ) {
                try {
                    if ( field == 0 ) {
                        Console.Write($"{message}: ");
                        field = int.Parse(Console.ReadLine());
                        Console.Clear();
                        IsCorrect = true;
                    }
                } catch ( Exception ) {
                    Console.Clear();
                    Console.WriteLine($"\nThe {message} number must be a number\n".ToUpper());
                    IsCorrect = false;
                }
            }

            return field;
        }

        /* Declaring the variables that will be used in the class. */
        public float balance = 300000.5f;

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