using System;

namespace AppCuentaBanca
{

    public class Controller : Admin
    {

        // Search for an existing account by id Number
        static protected Account LoginWithAccountNumber() {

            bool isLoggedIn = false;
            int i = 0;
            Account account = new Account();

            while( !isLoggedIn ) {
                
                User.ShowMenuAppForLogin();
                Console.Write("Enter the type of account: ");
                string typeAccountLogin = Console.ReadLine();

                if ( typeAccountLogin != "1" && typeAccountLogin != "2" && typeAccountLogin != "3" && typeAccountLogin != "4" && typeAccountLogin != "root" ) {	
                    throw new Exception("\nThe account type is not valid");
                }
                
                int idNumberToFind;
                Predicate<Account> condition = null;
                
                if ( typeAccountLogin != "root" ) {

                    Console.Clear();
                    Console.Write("Write the id number to login: ");
                    idNumberToFind = int.Parse(Console.ReadLine());

                    // Create a predicate function for find Account
                    condition = account => account.IdNumber == idNumberToFind;
                    isLoggedIn = true;
                    i = 0;
                }

                // Find the account it according to the condition
                switch (typeAccountLogin)
                {
                    case "1":
                        i = expressAccount.FindIndex( condition );
                        account = Admin.expressAccount[i];
                        break;
                    case "2":
                        i = payrollAccounts.FindIndex( condition );
                        account = Admin.payrollAccounts[i];
                        break;
                    case "3":
                        i = savingsAccounts.FindIndex( condition );
                        account = Admin.savingsAccounts[i];
                        break;
                    case "4":
                        i = currentAccounts.FindIndex( condition );
                        account = Admin.currentAccounts[i];
                        break;
                    case "root":
                        Admin.OptionsForAdmin();
                        isLoggedIn = false;
                        break;
                    default:
                        Console.WriteLine("The type of account does not exist - Account number INCORRECT");
                        break;
                }

                // Validate that the account has been deleted and show a message
                if ( i == -1 ) throw new Exception("\nThe account does not exist...".ToUpper());
            }

            Console.WriteLine("\nYou have been successfully logged in with the account...".ToUpper());
            
            Console.WriteLine("\nPress any key to continue...".ToUpper());
            Console.ReadKey();

            return account;
        }

        // Personal account options menu
        public static void OptionsPersonalAccount() {

            // login to a personal account, if you don't find an account, ask for the info again
            Account personalAccount = Utils.TryCodeUntilItWorks<Account>( "\nAn error was generated, please try again to continue".ToUpper(), null, LoginWithAccountNumber);
            bool continueRunning = true;
            bool hidePressKey = false;

            while ( continueRunning ) {

                Console.Clear();
                User.ShowMenuAccount( personalAccount.Name, personalAccount.Balance );
                Console.Write("\nEnter the operation to do: ");
                string operationToDo = Console.ReadLine();

                switch (operationToDo)
                {
                    case "1":
                        // Find the destination account to transfer money to
                        Account targetAccount = Utils.TryCodeUntilItWorks<Account>( "\nAn error was generated, please try again to continue".ToUpper(), Admin.ConsultIndividualAccount, null, "Consult Account", true);

                        Console.Clear();
                        Console.Write("Enter the amount to transfer: ");

                        int amountToTransfer = int.Parse(Console.ReadLine());
                        personalAccount.TransferMoney( targetAccount, amountToTransfer );
                        break;
                    case "2":
                        // Calls the method that performs a withdrawal 
                        personalAccount.Withdraw( 100f );
                        break;
                    case "3":
                        // Calls the method that performs a deposit
                        Console.Clear();
                        Console.Write("Enter the amount to make deposit: ");
                        int amountToDeposit = int.Parse(Console.ReadLine());

                        personalAccount.MakeDeposit( amountToDeposit);
                        break;
                    case "4":
                        // Calls the method that show the account balance
                        Console.Clear();
                        personalAccount.CheckBalance();
                        break;
                    case "5":
                        // Calls the method that show the account balance
                        Console.Clear();
                        personalAccount.CostAdministrationFee();
                        break;
                    case "6":
                        // if you want to log out
                        personalAccount = Utils.TryCodeUntilItWorks<Account>( "\nAn error was generated, please try again to continue".ToUpper(), null, LoginWithAccountNumber);
                        hidePressKey = true;
                        break;
                    case "7":
                        // if you want to exit the app
                        continueRunning = false;
                        break;
                    default: 
                        Console.WriteLine("The operation does not exist");
                        break;
                }
                
                if ( !hidePressKey ) {
                    Console.WriteLine("\nPress any key to continue...".ToUpper());
                    Console.ReadKey();
                }
            }
        }
    }
}