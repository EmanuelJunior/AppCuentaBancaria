using System;

using System.Collections.Generic;
using System.Linq;

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

            this.operations += 1;
            return true;
        }
        
        // Withdraw money from the account
        public virtual bool Withdraw( float amount ) {

            if ( this.balance < amount ) {
                Console.WriteLine("The money cannot be withdrawn, the amount is greater than the available balance."); 
                return false;
            }

            this.operations += 1;
            return true;
        }

        public virtual bool Withdraw() {
            // Ask for the amount to withdraw
            int amount = Utils.CheckFieldIsNumber("How much is the amount you want to withdraw?");

            bool moneyCanBeWithdraw = this.Withdraw( amount );
            if ( !moneyCanBeWithdraw ) return false;
            
            this.balance -= amount;
            Console.WriteLine($"\nTransferred: {Utils.TransformNumberToMoney(amount)}, \nRemaining money: {Utils.TransformNumberToMoney(this.balance)}");
            Console.WriteLine("\nThe withdrawal was successful...".ToUpper());
            return true;
        }

        // Make a deposit in the account
        public virtual void MakeDeposit( int amount) {

            if (amount <= 0) {
                Console.WriteLine("\nDeposit FAILED...");
                return;
            }

            this.balance += amount;
            Console.WriteLine($"\nThe new balance is: { Utils.TransformNumberToMoney( this.balance ) }...");
        }

        // Create a function that show the account balance
        public virtual bool CheckBalance() {
            Console.Write("Are you sure to check the account balance? y/n: ");
            string answer = Console.ReadLine();
            if ( answer != "y" && answer != "Y" ){
                Console.WriteLine("\nConsultation was not performed - Exit".ToUpper());
                return false;
            } 
            Console.WriteLine($"\nThe account balance is: {Utils.TransformNumberToMoney( this.balance )}"); 

            this.operations += 1;
            return true;
        }

        // Method that calculate the CostMonthlyFee
        public virtual void CostMonthlyFee() {}


        // Method that calculate the OperationsCollection
        public virtual void OperationsCollection() {
            
            if (this.operations < operationsLimit ) return;

            int chargePerOperation = this.operations - operationsLimit;
            int collection = chargePerOperation * costOperation;
            this.balance -= collection;

            Console.WriteLine($"Number of operations executed: { this.operations }");
            Console.WriteLine($"Total cost of operations: { Utils.TransformNumberToMoney( collection ) }");
            Console.WriteLine($"New Balance: { Utils.TransformNumberToMoney( this.balance ) }");

            this.operations = operationsLimit;
        }
        
        // Allows at any time to check the available balance in the account
        public virtual void BalanceReport() {
            Console.WriteLine("\nThese are the costs generated throughout the month\n");

            CostMonthlyFee();
            OperationsCollection();
        }

        // Create function that shows all the properties of the class
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
            Console.WriteLine($"Balance: {Utils.TransformNumberToMoney( this.balance )}");
            Console.WriteLine($"Phone: {this.phone}");
        }

        /* Declaring the variables that will be used in the class. */
        protected readonly DateTime dayCreateAccount = DateTime.Now;
        public string typeAccount;

        protected int operationsLimit = 0;
        protected int costOperation = 0;

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