using System.Collections.Generic;
using System;

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
        public virtual bool TransferMoney(Account personalAccount, Account targetAccount, float amount) {

            if ( amount <= 0 || personalAccount.balance < amount ) 
            {
                Console.WriteLine("\nThe transfer was erroneous...".ToUpper());
                return false;
            }

            personalAccount.balance -= amount;
            targetAccount.balance += amount;

            // Prints the result of the transfer
            Console.WriteLine($"\nAmount: {amount} - Personal Balance: {personalAccount.balance}");
            Console.WriteLine($"Amount: {amount} - Target Balance: {targetAccount.balance}");
            return true;
        }
        
        public virtual bool Withdraw( Account personalAccount, float amount ) {

            // Withdraw money from the account
            //
            if ( personalAccount.balance < amount ) {
                Console.WriteLine("The money cannot be withdrawn, the amount is greater than the available balance."); 
                return false;
            }

            return true;
        }
        public virtual bool Withdraw() { return false; }

        // Function that enter a specific amount to the personal account
        public virtual void MakeDeposit( Account personalAccount, float amount) {

            if (amount > 0) {
                personalAccount.balance += amount;
                Console.WriteLine($"\nThe new balance is: { personalAccount.balance }...");
            } 
            
            Console.WriteLine("\nDeposit FAILED...");
        }

        // create a function that show the account balance
        public virtual void CheckBalance( Account personalAccount) {
            Console.WriteLine("Are you sure to check the account balance? y/n");
            char answer = char.Parse(Console.ReadLine());
            if ( answer != 'y' || answer != 'Y' ){
                Console.WriteLine("Exit...");
                return;
            } 
            
            Console.WriteLine($"The account balance is: {personalAccount.balance}");  
        }

        protected virtual void BalanceReport( Account personalAccount, float administrationFee ) {
            Console.WriteLine("\nThese are the costs generated throughout the month");


            // Calls the OperationsCollection method
        }

        // Method that calculate the Administration Fee (only declared)
        protected virtual void CostAdministrationFee( Account personalAccount, float administrationFee){}

        protected bool OperationsCollection( Account personalAccount, short operationsLimit, float costOperation, string[] s = null ) {

            if (personalAccount.operations < operationsLimit ) {
                return false;
            }

            foreach (string i in s){
                if (true) {
                    Console.WriteLine(i);
                }
            }

            int chargePerOperation = personalAccount.operations - operationsLimit;
            float collection = chargePerOperation * costOperation;
            personalAccount.balance -= collection;
            personalAccount.operations = operationsLimit;
            
            return true;
        }

        // create function that shows all the properties of the class
        public virtual void ShowAccountData() {
            Console.WriteLine($"\nType: {this.typeAccount}");
            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"Last name: {this.lastName}");
            Console.WriteLine($"Profession: {this.profession}");
            Console.WriteLine($"Address: {this.address}");
            Console.WriteLine($"Password: {this.password}");
            Console.WriteLine($"ID number: {this.idNumber}");
            Console.WriteLine($"Account number: {this.accountNumber}");
            Console.WriteLine($"Operations: {this.operations}");
            Console.WriteLine($"Balance: {this.balance}");
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

        protected double balance { get; set; }

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
        public double Balance { get => this.balance; set => this.balance = value; }
    }
}