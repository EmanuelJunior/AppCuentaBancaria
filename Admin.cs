using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCuentaBanca
{
    public class Admin
    {
        
        protected List<CurrentAccount> currentAccounts = new List<CurrentAccount>();
        protected List<SavingsAccount> savingsAccounts = new List<SavingsAccount>();
        protected List<PayrollAccount> payrollAccounts = new List<PayrollAccount>();
        protected List<ExpressAccount> expressAccount = new List<ExpressAccount>();

        public void Nav( int option ) {
            switch( option ) {
                case 1:
                    Console.Clear();
                    this.SelectAccountTypeAndCreate();
                    break;
                case 2:
                    Console.Clear();
                    this.DeleteAccount();
                    break;
                case 3:
                    // Modify an account
                    break;
                case 4:
                    // Consult an account
                    break;
                case 5:
                    // Consult all accounts
                    break;
                default:
                    // Exit
                    break;
            }
        }

        void ListAccountsChoose( string actionType ) {

            Console.WriteLine($"\nwhat type of account do you want to {actionType}?: ".ToUpper());

            Console.WriteLine($"\n1. If you want to {actionType} an EXPRESS ACCOUNT");
            Console.WriteLine("2. If you want a PAYROLL ACCOUNT");
            Console.WriteLine("3. If you prefer a SAVINGS ACCOUNT");
            Console.WriteLine("4. If you want a CURRENT ACCOUNT\n");
            
            Console.Write("select an option: ".ToUpper());
        }

        void SelectAccountTypeAndCreate() {

            this.ListAccountsChoose("create");
            int accountType = int.Parse(Console.ReadLine());
            Console.Clear();

            // Select the account type and create the new object instance
            switch ( accountType ) {
                case 1:
                    ExpressAccount expressAccount = new ExpressAccount();
                    this.FillUserData( expressAccount );
                    break;
                case 2:
                    PayrollAccount payrollAccount = new PayrollAccount();
                    this.FillUserData( payrollAccount );
                    break;
                case 3:
                    SavingsAccount savingsAccount = new SavingsAccount();
                    this.FillUserData( savingsAccount );
                    break;
                case 4:
                    CurrentAccount currentAccount = new CurrentAccount();
                    this.FillUserData( currentAccount );
                    break;
            }
        }

        void FillUserData( Account account ) {

            // Fill in the account details
            Console.Clear();
            Console.Write("Name: ");
            account.Name = Console.ReadLine();

            Console.Clear();
            Console.Write("Last name: ");
            account.LastName = Console.ReadLine();

            Console.Clear();
            Console.Write("Profession: ");
            account.Profession = Console.ReadLine();

            Console.Clear();
            Console.Write("Address: ");
            account.Address = Console.ReadLine();

            Console.Clear();
            Console.Write("Password: ");
            account.Password = Console.ReadLine();
            Console.Clear();

            account.IdNumber = CheckFieldIsNumber("Id Number");
            account.AccountNumber = CheckFieldIsNumber("Account Number");
            account.Phone = CheckFieldIsNumber("Cellphone");

            // Fill in the individual properties of each type of account
            string accountType = account.ToString();

            // Save the new user in the corresponding list
            this.SaveTheNewAccount( accountType, account );
        }

        int CheckFieldIsNumber( string message) {
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

        bool IsInformationCorrect( Account account ) {

            Console.Clear();
            Console.WriteLine($"\n===== Account Information =====".ToUpper());
            account.ShowAccountData();

            // Ask if the information provided is correct
            Console.Write("\nIs the information correct? (y/n): ");
            string answer = Console.ReadLine();

            if ( answer == "y" || answer == "Y" ) return true;
            else return false;
        }
        
        bool SaveTheNewAccount(string accountType, Account account) {

            bool validate = this.IsInformationCorrect( account );

            /* Validating that the information provided by the user is incorrect. */
            if ( !validate ) {
                Console.WriteLine("\nAccount creation failed!\n".ToUpper());
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return false;
            }

            /* Based on what the ToString() returns add the user to 
            their respective account ( express, payroll, savings and current ) */
            switch( accountType ) {
                case "PAYROLL-ACCOUNT":
                    this.payrollAccounts.Add( (PayrollAccount) account );
                    break;
                case "SAVINGS-ACCOUNT":
                    this.savingsAccounts.Add( (SavingsAccount) account );
                    break;
                case "CURRENT-ACCOUNT":
                    this.currentAccounts.Add( (CurrentAccount) account );
                    break;
                case "EXPRESS-ACCOUNT":
                    this.expressAccount.Add( (ExpressAccount) account );
                    break;
            };

            Console.WriteLine("\nAccount created successfully!\n".ToUpper());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return true;
        }

        void DeleteAccount() {

            // Delete an account
            this.ListAccountsChoose("delete");
            int accountType = int.Parse(Console.ReadLine());
            Console.Clear();

            // Ask the administrator for the id of the user you want to delete
            Console.Write("Enter the id of the user you want to delete: ");
            int idToDelete = int.Parse(Console.ReadLine());
            
            int i = 0;

            // Create a predicate function for Delete Account
            Predicate<Account> condition = account => account.IdNumber == idToDelete;

            // Find the account and delete it according to the condition
            switch (accountType)
            {
                case 1:
                    i = this.expressAccount.RemoveAll( condition );
                    break;
                case 2:
                    i = this.payrollAccounts.RemoveAll( condition );
                    break;
                case 3:
                    i = this.savingsAccounts.RemoveAll( condition );
                    break;
                case 4:
                    i = this.currentAccounts.RemoveAll( condition );
                    break;
            }
            
            // Validate that the account has been deleted and show a message
            if ( i == 1 ) Console.WriteLine("\nThe account has been deleted...".ToUpper());
            else Console.WriteLine("\nThe account does not exist...".ToUpper());
            
            Console.WriteLine("\nPress any key to continue...".ToUpper());
            Console.ReadKey();
        }

        void ModifyAccount() {

            // Modify an account
        }

        void ConsultAccount() {

            // Consult an account
        }

        void ConsultAllAccounts() {

            // Consult all accounts
            this.ListAccountsChoose("list");
            int accountType = int.Parse(Console.ReadLine());
            Console.Clear();
        }
    }
}