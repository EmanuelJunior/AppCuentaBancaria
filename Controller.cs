using System;

namespace AppCuentaBanca
{

    public class Controller : Admin
    {

        // Search for an existing account by id Number
        static public Account LoginWithAccountNumber() {
            User.ShowMenuApp();
            Console.Write("Enter the type of account: ");
            string typeAccountLogin = Console.ReadLine();

            if ( typeAccountLogin != "1" && typeAccountLogin != "2" && typeAccountLogin != "3" && typeAccountLogin != "4" && typeAccountLogin != "Juan" ) {	
                throw new Exception("\nThe account type is not valid");
            }
            
            Console.Clear();
            Console.Write("Write the id number to login: ");
            int idNumberToFind = int.Parse(Console.ReadLine());

            // Create a predicate function for find Account
            Predicate<Account> condition = account => account.IdNumber == idNumberToFind;
            Account account;
            int i = 0;

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
                case "Juan":
                    Admin.OptionsForAdmin(1);
                    break;
                default:
                    Console.WriteLine("The type of account does not exist - Account number INCORRECT");
                    break;
            }

            // Validate that the account has been deleted and show a message
            if ( i == -1 ) throw new Exception("\nThe account does not exist...".ToUpper());

            Console.WriteLine("\nyou have been successfully logged in with the account...".ToUpper());
            
            Console.WriteLine("\nPress any key to continue...".ToUpper());
            Console.ReadKey();

            return null;
        }

        // Personal account options menu
        static public void OptionsPersonalAccount(){
            Account personalAccount = Admin.TryCodeUntilItWorks<Account>( "\nPress any key to continue...".ToUpper(), "\nAn error was generated, please try again to continue".ToUpper(), LoginWithAccountNumber);

            Console.Clear();
            Console.Write("Enter the operation to do: ");
            string operationToDo = Console.ReadLine();

            switch (operationToDo)
            {
                case "1":
                    var m = Admin.ConsultIndividualAccount( "To Transfer", true );
                    // var targetAccount = Admin.TryCodeUntilItWorks<Account>( "\nPress any key to continue...".ToUpper(), "\nAn error was generated, please try again to continue".ToUpper(), m);
                    
                    Console.Clear();
                    Console.Write("Enter the amount to transfer: ");
                    int amountToTransfer = int.Parse(Console.ReadLine());
                    // personalAccount.TransferMoney( personalAccount, targetAccount, amountToTransfer );
                    break;
                case "2":
                    
                    break;
                case "3":
                    Console.Write("Enter the amount to make deposit: ");
                    int amountToDeposit = int.Parse(Console.ReadLine());
                    personalAccount.MakeDeposit( personalAccount, amountToDeposit);
                    break;
                case "4":
                    personalAccount.CheckBalance( personalAccount );
                    break;
                default:
                    
                    break;
            }
        }
    }
}