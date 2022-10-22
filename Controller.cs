using System;

namespace AppCuentaBanca
{
    public class Controller : Admin
    {
        // Search for an existing account by id Number
        public Account ChooseLogin( string message ) {
            string typeAccountLogin = Console.ReadLine();
            Console.Write(message);
            int accountNumberToFind = int.Parse(Console.ReadLine());
            
             // Create a predicate function for find Account
            Predicate<Account> condition = account => account.IdNumber == accountNumberToFind;
            int i = 0;

            // Find the account it according to the condition
            switch (typeAccountLogin)
            {
                case "1":
                    i = expressAccount.FindIndex( condition );
                    return Admin.expressAccount[i];
                case "2":
                    i = payrollAccounts.FindIndex( condition );
                    return Admin.payrollAccounts[i];
                case "3":
                    i = savingsAccounts.FindIndex( condition );
                    return Admin.savingsAccounts[i];
                case "4":
                    i = currentAccounts.FindIndex( condition );
                    return Admin.currentAccounts[i];
                case "Juan":
                    Admin.OptionsForAdmin(1);
                    break;
                default:
                    Console.WriteLine("The account does not exist - Account number INCORRECT");
                    break;
            }

            return null;
        }

        // Personal account options menu
        public void OptionsPersonalAccount(){
            var personalAccount = ChooseLogin("Enter your id number: ");

            Console.Write("Enter the operation to do: ");
            string operationToDo = Console.ReadLine();

            switch (operationToDo)
            {
                case "1":
                    var targetAccount = Admin.ConsultIndividualAccount( "To Transfer", true );

                    Console.Write("Enter the amount to transfer: ");
                    int amountToTransfer = int.Parse(Console.ReadLine());
                    personalAccount.TransferMoney( personalAccount, targetAccount, amountToTransfer );
                    break;
                case "2":
                    
                case "3":
                    
                case "4":
                    
                default:
                    
                    break;
            }

            // ExpressAccount firstAccount = new ExpressAccount();
            // ExpressAccount sAccount = new ExpressAccount();
            // firstAccount.balance = 1000;
            // sAccount.balance = 1000;
            // sAccount.AccountNumber = 123;

            // firstAccount.TransferMoney( firstAccount, sAccount, 200 );
            
        }
    }
}