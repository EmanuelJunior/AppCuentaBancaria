using System;
using System.Collections.Generic;
// using System.Linq;

namespace AppCuentaBanca
{
    public class Admin
    {
        static protected List<CurrentAccount> currentAccounts = new List<CurrentAccount>();
        static protected List<SavingsAccount> savingsAccounts = new List<SavingsAccount>();
        static protected List<PayrollAccount> payrollAccounts = new List<PayrollAccount>();
        static protected List<ExpressAccount> expressAccount = new List<ExpressAccount>();

        public static void OptionsForAdmin() {
            bool keepRunningAdmin = true;

            while( keepRunningAdmin ) {

                UiAdmin.MenuAdmin();
                int accountType = Utils.CheckFieldIsNumber("\nSelect an option".ToUpper(), null, null, UiAdmin.MenuAdmin);

                switch( accountType ) {
                    case 1:
                        Console.Clear();
                        SelectAccountTypeAndCreate();
                        break;
                    case 2:
                        // Consult an account
                        Console.Clear();
                        ConsultIndividualAccount("Consult Account");
                        break;
                    case 3:
                        Console.Clear();
                        DeleteAccount();
                        break;
                    case 4:
                        // Consult all accounts
                        Console.Clear();
                        ConsultAllAccounts();
                        break;
                    case 5:
                        // Modify an account
                        break;
                    case 6:
                        // Exit
                        keepRunningAdmin = false;
                        break;
                    default:
                        // Exit
                        keepRunningAdmin = false;
                        break;
                }
            }
        }

        static void SelectAccountTypeAndCreate() {

            UiAdmin.ListAccountsChoose("create");
            int accountType = Utils.CheckFieldIsNumber("Select an option".ToUpper(), "CREATE", UiAdmin.ListAccountsChoose);
            Console.Clear();

            // Select the account type and create the new object instance
            switch ( accountType ) {
                case 1:
                    ExpressAccount expressAccount = new ExpressAccount();
                    FillUserData( expressAccount );
                    break;
                case 2:
                    PayrollAccount payrollAccount = new PayrollAccount();
                    FillUserData( payrollAccount );
                    break;
                case 3:
                    SavingsAccount savingsAccount = new SavingsAccount();
                    FillUserData( savingsAccount );
                    break;
                case 4:
                    CurrentAccount currentAccount = new CurrentAccount();
                    FillUserData( currentAccount );
                    break;
            }
        }

        static void FillUserData( Account account ) {

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

            account.IdNumber = Utils.CheckFieldIsNumber("Id Number");
            account.AccountNumber = Utils.CheckFieldIsNumber("Account Number");
            account.Balance = Utils.CheckFieldIsNumber("Balance");
            account.Phone = Utils.CheckFieldIsNumber("Cellphone");
            account.Operations = Utils.CheckFieldIsNumber("Operations");

            // Fill in the individual properties of each type of account
            string accountType = account.ToString();

            // Save the new user in the corresponding list
            SaveTheNewAccount( accountType, account );
        }

        static bool IsInformationCorrect( Account account ) {

            Console.Clear();
            Console.WriteLine($"\n===== Account Information =====".ToUpper());
            account.ShowAccountData();

            // Ask if the information provided is correct
            Console.Write("\nIs the information correct? (y/n): ");
            string answer = Console.ReadLine();

            if ( answer == "y" || answer == "Y" ) return true;
            else return false;
        }
        
        static bool SaveTheNewAccount(string accountType, Account account) {

            bool validate = IsInformationCorrect( account );

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
                    payrollAccounts.Add( (PayrollAccount) account );
                    break;
                case "SAVINGS-ACCOUNT":
                    savingsAccounts.Add( (SavingsAccount) account );
                    break;
                case "CURRENT-ACCOUNT":
                    currentAccounts.Add( (CurrentAccount) account );
                    break;
                case "EXPRESS-ACCOUNT":
                    expressAccount.Add( (ExpressAccount) account );
                    break;
            };

            Console.WriteLine("\nAccount created successfully!\n".ToUpper());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return true;
        }

        static void DeleteAccount() {

            // Delete an account
            UiAdmin.ListAccountsChoose("delete");
            int accountType = Utils.CheckFieldIsNumber("Select an option".ToUpper(), "DELETE", UiAdmin.ListAccountsChoose);
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
                case 1: i = expressAccount.RemoveAll( condition ); break;
                case 2: i = payrollAccounts.RemoveAll( condition ); break;
                case 3: i = savingsAccounts.RemoveAll( condition ); break;
                case 4: i = currentAccounts.RemoveAll( condition ); break;
            }
            
            // Validate that the account has been deleted and show a message
            if ( i == 1 ) Console.WriteLine("\nThe account has been deleted...".ToUpper());
            else Console.WriteLine("\nThe account does not exist...".ToUpper());
            
            Console.WriteLine("\nPress any key to continue...".ToUpper());
            Console.ReadKey();
        }

        static void ModifyAccount() {

            // Modify an account
            UiAdmin.ListAccountsChoose("modify");
            int accountType = Utils.CheckFieldIsNumber("Select an option".ToUpper(), "MODIFY", UiAdmin.ListAccountsChoose);
            Console.Clear();

            // Ask the administrator for the id of the user you want to modify
            Console.Write("Enter the id of the user you want to modify: ");
            int idToModify = int.Parse(Console.ReadLine());
            Console.Clear();

            // Create a predicate function for Modify Account
            Predicate<Account> condition = account => account.IdNumber == idToModify;

            // Find the account and modify it according to the condition
            switch (accountType)
            {
                case 1:
                    // this.expressAccount.Find( condition ).ModifyAccount();
                    break;
                case 2:
                    // this.payrollAccounts.Find( condition ).ModifyAccount();
                    break;
                case 3:
                    // this.savingsAccounts.Find( condition ).ModifyAccount();
                    break;
                case 4:
                    // this.currentAccounts.Find( condition ).ModifyAccount();
                    break;
            }

            Console.WriteLine("\nPress any key to continue...".ToUpper());
            Console.ReadKey();
        }

        public static Account ConsultIndividualAccount( string message, bool getDataAccount = false ) {
            
            // Consult an account
            Console.Clear();
            Console.WriteLine($"\n===== { message } =====\n".ToUpper());

            int idNumber = Utils.CheckFieldIsNumber("Enter the id number");
            bool foundTheAccount = false;

            // Create a predicate function for Consult Account
            Predicate<Account> condition = account => account.IdNumber == idNumber;

            // Find the account and consult it according to the condition
            Account account = expressAccount.Find( condition );

            account = account == null ? payrollAccounts.Find( condition ) : account;
            account = account == null ? savingsAccounts.Find( condition ) : account;
            account = account == null ? currentAccounts.Find( condition ) : account;

            // Validate that the account has been found
            foundTheAccount = account != null && foundTheAccount == false ? true : false;

            // Validate that the account has been found and show a message
            if ( account == null && foundTheAccount == false) {
                Console.WriteLine("\nThe account does not exist...".ToUpper());
                Console.WriteLine("\nPress any key to continue...".ToUpper());
                Console.ReadKey();
                return null;
            }

            // Return the account data
            if (getDataAccount) return account;
            
            Console.WriteLine("\nThe account has been found...".ToUpper());
            account.ShowAccountData();
            Console.WriteLine("\nPress any key to continue...".ToUpper());
            Console.ReadKey();
            return null;
        }

        static void ConsultAllAccounts() {

            // Consult all accounts
            UiAdmin.ListAccountsChoose("list");
            int accountType = Utils.CheckFieldIsNumber("Consult All Accounts".ToUpper(), "LIST", UiAdmin.ListAccountsChoose);

            switch (accountType)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n===== LIST OF EXPRESS ACCOUNTS =====".ToUpper());
                    expressAccount.ForEach( account => account.ShowAccountData() );
                    Console.WriteLine("\nPress any key to continue...".ToUpper());
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n===== LIST OF PAYROLL ACCOUNTS =====".ToUpper());
                    payrollAccounts.ForEach( account => account.ShowAccountData() );
                    Console.WriteLine("\nPress any key to continue...".ToUpper());
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("\n===== LIST OF SAVINGS ACCOUNTS =====".ToUpper());
                    savingsAccounts.ForEach( account => account.ShowAccountData() );
                    Console.WriteLine("\nPress any key to continue...".ToUpper());
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("\n===== LIST OF CURRENT ACCOUNTS =====".ToUpper());
                    currentAccounts.ForEach( account => account.ShowAccountData() );
                    Console.WriteLine("\nPress any key to continue...".ToUpper());
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("\n===== LIST OF ALL ACCOUNTS =====".ToUpper());
                    expressAccount.ForEach( account => account.ShowAccountData( true ) );
                    payrollAccounts.ForEach( account => account.ShowAccountData( true ) );
                    savingsAccounts.ForEach( account => account.ShowAccountData( true ) );
                    currentAccounts.ForEach( account => account.ShowAccountData( true ) );
                    Console.WriteLine("\nPress any key to continue...".ToUpper());
                    Console.ReadKey();
                    break;
            }
        }
    }
}