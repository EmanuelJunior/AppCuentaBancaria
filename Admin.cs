using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCuentaBanca
{
    public class Admin : Account
    {
        static protected List<CurrentAccount> currentAccounts = new List<CurrentAccount>();
        static protected List<SavingsAccount> savingsAccounts = new List<SavingsAccount>();
        static protected List<PayrollAccount> payrollAccounts = new List<PayrollAccount>();
        static protected List<ExpressAccount> expressAccount = new List<ExpressAccount>();

        /* A method that is used to try to execute a code until it works, it is used to avoid errors in the
        code. */
        public static T TryCodeUntilItWorks<T>( 
            string messageError, 
            Func<string, bool, T> action, 
            Func<T> emptyAction, 
            string message = null, 
            bool returnsAnAccount = false 
        ) {
            
            bool isCorrect = false;
            T valueToReturn = default(T);

            while ( !isCorrect ) {
                try {
                    Console.Clear();

                    if ( message == null && !returnsAnAccount ) valueToReturn = emptyAction();
                    else valueToReturn = action(message, returnsAnAccount);

                    isCorrect = true;
                    return valueToReturn;
                } catch ( Exception e ) {
                    Console.Clear();
                    Console.WriteLine(messageError);
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\nPress any key to continue...".ToUpper());
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            return valueToReturn;
        }

        static void MenuAdmin() {
            Console.Clear();
            Console.WriteLine("\n-------------------------------------- ");
            Console.WriteLine("           APP Bank Account            ");
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("\n| ADMINISTRATOR ---------------------- ");
            Console.WriteLine("| 1. Create an account --------------- ");
            Console.WriteLine("| 2. Consult an account -------------- ");
            Console.WriteLine("| 3. Delete an account --------------- ");
            Console.WriteLine("| 4. Consult all accounts ------------ ");
            Console.WriteLine("| 5. Modify an accounts -------------- ");
            Console.WriteLine("| 6. Exit ---------------------------- ");
            Console.WriteLine("| ------------------------------------ ");
        }

        public static void OptionsForAdmin() {
            bool keepRunningAdmin = true;

            while( keepRunningAdmin ) {
                MenuAdmin();
                int accountType = CheckFieldIsNumber("\nSelect an option".ToUpper());

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

        static void ListAccountsChoose( string actionType ) {
            Console.Clear();
            Console.WriteLine($"\nwhat type of account do you want to {actionType}?: ".ToUpper());

            Console.WriteLine($"\n1. If you want to {actionType} an EXPRESS ACCOUNT");
            Console.WriteLine("2. If you want a PAYROLL ACCOUNT");
            Console.WriteLine("3. If you prefer a SAVINGS ACCOUNT");
            Console.WriteLine("4. If you want a CURRENT ACCOUNT\n");            
        }

        static void SelectAccountTypeAndCreate() {

            ListAccountsChoose("create");
            int accountType = CheckFieldIsNumber("Select an option".ToUpper(), "CREATE", ListAccountsChoose);
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

            account.IdNumber = CheckFieldIsNumber("Id Number");
            account.AccountNumber = CheckFieldIsNumber("Account Number");
            account.Balance = CheckFieldIsNumber("Balance");
            account.Phone = CheckFieldIsNumber("Cellphone");
            account.Operations = CheckFieldIsNumber("Operations");

            // Fill in the individual properties of each type of account
            string accountType = account.ToString();

            // Save the new user in the corresponding list
            SaveTheNewAccount( accountType, account );
        }

        static int CheckFieldIsNumber( string message, string messageForMenu = null, Action<string> showMenu = null ) {
            // Cycle to validate the field number
            bool IsCorrect = false;
            int field = 0;

            while ( !IsCorrect ) {
                try {
                    if ( field == 0 ) {
                        if ( showMenu != null && messageForMenu != null) showMenu(message);
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
            ListAccountsChoose("delete");
            int accountType = CheckFieldIsNumber("Select an option".ToUpper(), "DELETE", ListAccountsChoose);
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
                    i = expressAccount.RemoveAll( condition );
                    break;
                case 2:
                    i = payrollAccounts.RemoveAll( condition );
                    break;
                case 3:
                    i = savingsAccounts.RemoveAll( condition );
                    break;
                case 4:
                    i = currentAccounts.RemoveAll( condition );
                    break;
            }
            
            // Validate that the account has been deleted and show a message
            if ( i == 1 ) Console.WriteLine("\nThe account has been deleted...".ToUpper());
            else Console.WriteLine("\nThe account does not exist...".ToUpper());
            
            Console.WriteLine("\nPress any key to continue...".ToUpper());
            Console.ReadKey();
        }

        static void ModifyAccount() {

            // Modify an account
            ListAccountsChoose("modify");
            int accountType = CheckFieldIsNumber("Select an option".ToUpper(), "MODIFY", ListAccountsChoose);
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

            int idNumber = CheckFieldIsNumber("Enter the id number");

            // Create a predicate function for Consult Account
            Predicate<Account> condition = account => account.IdNumber == idNumber;

            // Find the account and consult it according to the condition

            // Express Account
            Account account = expressAccount.Find( condition );
            if ( account != null ) {
                if (getDataAccount) return account;

                account.ShowAccountData();
                Console.WriteLine("\nPress any key to continue...".ToUpper());
                Console.ReadKey();

                return null;
            }

            // Payroll Account
            account = payrollAccounts.Find( condition );
            if ( account != null ) {
                if (getDataAccount) return account;

                account.ShowAccountData();
                Console.WriteLine("\nPress any key to continue...".ToUpper());
                Console.ReadKey();

                return null;
            }

            // Savings Account
            account = savingsAccounts.Find( condition );
            if ( account != null ) {
                if (getDataAccount) return account;

                account.ShowAccountData();
                Console.WriteLine("\nPress any key to continue...".ToUpper());
                Console.ReadKey();

                return null;
            }

            // Current Account
            account = currentAccounts.Find( condition );
            if ( account != null ) {
                if (getDataAccount) return account;

                account.ShowAccountData();
                Console.WriteLine("\nPress any key to continue...".ToUpper());
                Console.ReadKey();

                return null;
            }
            
            Console.WriteLine("\nThe account does not exist...".ToUpper());
            Console.WriteLine("\nPress any key to continue...".ToUpper());
            return null;
        }

        static void ConsultAllAccounts() {

            // Consult all accounts
            ListAccountsChoose("list");
            int accountType = CheckFieldIsNumber("Consult All Accounts".ToUpper(), "LIST", ListAccountsChoose);

            switch (accountType)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n===== LIST OF EXPRESS ACCOUNTS =====\n".ToUpper());
                    expressAccount.ForEach( account => account.ShowAccountData() );
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n===== LIST OF PAYROLL ACCOUNTS =====\n".ToUpper());
                    payrollAccounts.ForEach( account => account.ShowAccountData() );
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("\n===== LIST OF SAVINGS ACCOUNTS =====\n".ToUpper());
                    savingsAccounts.ForEach( account => account.ShowAccountData() );
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("\n===== LIST OF CURRENT ACCOUNTS =====\n".ToUpper());
                    currentAccounts.ForEach( account => account.ShowAccountData() );
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\n===== LIST OF ALL ACCOUNTS =====\n".ToUpper());
                    expressAccount.ForEach( account => account.ShowAccountData() );
                    payrollAccounts.ForEach( account => account.ShowAccountData() );
                    savingsAccounts.ForEach( account => account.ShowAccountData() );
                    currentAccounts.ForEach( account => account.ShowAccountData() );
                    break;
            }
        }
    }
}