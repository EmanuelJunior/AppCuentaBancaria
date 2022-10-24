using System.Collections.Generic;
using System;

using System.Threading;
using System.Threading.Tasks;

// Directive for use Anonymous
using System.Linq;

// Directive for use the class Random
using System.Security.Cryptography;

// Directive for use the class Stopwatch
using System.Diagnostics;

// Directive for use the class DateTime
using System.Globalization;

namespace AppCuentaBanca
{
    public class Account
    {
        public Account() { this.typeAccount = "Account"; }

        // Documentar
        public override string ToString() {
            return "Account";
        }

        // Transfer money from one account to another
        public virtual bool TransferMoney(Account targetAccount, int amount) {

            if ( amount <= 0 || this.balance < amount ) 
            {
                Console.WriteLine("\nThe transfer was erroneous...".ToUpper());
                return false;
            }

            this.balance -= amount;
            targetAccount.balance += amount;

            // Prints the result of the transfer
            Console.WriteLine($"\nAmount: {amount} - Personal Balance: {this.balance}");
            Console.WriteLine($"Amount: {amount} - Target Balance: {targetAccount.balance}");
            return true;
        }
        
        public virtual bool Withdraw( float amount ) {

            // Withdraw money from the account
            //
            if ( this.balance < amount ) {
                Console.WriteLine("The money cannot be withdrawn, the amount is greater than the available balance."); 
                return false;
            }

            return true;
        }
        public virtual bool Withdraw() { return false; }

        // Function that enter a specific amount to the personal account
        public virtual void MakeDeposit( int amount) {

            if (amount <= 0) {
                Console.WriteLine("\nDeposit FAILED...");
                return;
            }

            this.balance += amount;
            Console.WriteLine($"\nThe new balance is: ${ Utils.TransformNumberToMoney( this.balance ) }...");
        }

        // create a function that show the account balance
        public virtual void CheckBalance() {
            Console.Write("Are you sure to check the account balance? y/n: ");
            string answer = Console.ReadLine();
            if ( answer != "y" && answer != "Y" ){
                Console.WriteLine("Exit...");
                return;
            } 
            Console.WriteLine($"\nThe account balance is: ${Utils.TransformNumberToMoney( this.balance )}"); 
        }

        // Method that calculate the Administration Fee (only declared)
        public virtual TimeSpan CostAdministrationFee() {
            // Calculates the administration fee and the sample
            DateTime today = DateTime.Now;
            TimeSpan interval = today - dayCreateAccount;

            return interval;
        }

        // Method that calculate the OperationsCollection
        public virtual void OperationsCollection() { }
        public virtual void BalanceReport() {
            Console.WriteLine("\nThese are the costs generated throughout the month");

            // Calls the CostAdministrationFee method
            CostAdministrationFee();
            OperationsCollection();
        }

        // create function that shows all the properties of the class
        public virtual void ShowAccountData( bool showType = false ) {
            if ( showType ) Console.WriteLine($"\nType: ".ToUpper() + this.typeAccount);
            Console.WriteLine($"\nCreation Date: {this.dayCreateAccount}");
            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"Last name: {this.lastName}");
            Console.WriteLine($"Profession: {this.profession}");
            Console.WriteLine($"Address: {this.address}");
            Console.WriteLine($"Password: { Utils.ReplaceLettersWithAsterisks( this.password ) }");
            Console.WriteLine($"ID number: {this.idNumber}");
            Console.WriteLine($"Account number: {this.accountNumber}");
            Console.WriteLine($"Operations: {this.operations}");
            Console.WriteLine($"Balance: ${Utils.TransformNumberToMoney( this.balance )}");
            Console.WriteLine($"Phone: {this.phone}");
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
        protected readonly DateTime dayCreateAccount = DateTime.Now;
        protected string typeAccount;

        protected int balance { get; set; }

        protected string name { get; set; }
        protected string lastName { get; set; }
        protected string profession { get; set; }
        protected string address { get; set; }
        protected string password { get; set; }

        protected int idNumber { get; set; }
        protected Int64 accountNumber { get; set; }
        protected int phone { get; set; }
        protected Int32 operations { get; set; }

        public string Name { get => this.name; set => this.name = value; }
        public string LastName { get => this.lastName; set => this.lastName = value; }
        public string Profession { get => this.profession; set => this.profession = value; }
        public string Address { get => this.address; set => this.address = value; }
        public string Password { get => this.password; set => this.password = value; }

        public int IdNumber { get => this.idNumber; set => this.idNumber = value; }
        public Int64 AccountNumber { get => this.accountNumber; set => this.accountNumber = value; }
        public int Phone { get => this.phone; set => this.phone = value; }
        public Int32 Operations { get => this.operations; set => this.operations = value; }
        public int Balance { get => this.balance; set => this.balance = value; }
    }
}