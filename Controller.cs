using System;

namespace AppCuentaBanca
{
    public class Controller : Admin
    {
        Account SwitchForLogin() {
            string typeAccountLogin = Console.ReadLine();
            Console.WriteLine("Enter your account number");
            int accountNumberToFind = int.Parse(Console.ReadLine());
            
             // Create a predicate function for find Account
            Predicate<Account> condition = account => account.IdNumber == accountNumberToFind;
            int i = 0;

            // Find the account it according to the condition
            switch (typeAccountLogin)
            {
                case "1":
                    i = this.expressAccount.FindIndex( condition );
                    return this.expressAccount[i];
                case "2":
                    i = this.payrollAccounts.FindIndex( condition );
                    return this.payrollAccounts[i];
                case "3":
                    i = this.savingsAccounts.FindIndex( condition );
                    return this.savingsAccounts[i];
                case "4":
                    i = this.currentAccounts.FindIndex( condition );
                    return this.currentAccounts[i];
                case "dsadasdasdad asdsad-asdas-dasdasd-dsa-as-d-ad":
                    return this.currentAccounts[0];
                default:
                    Console.WriteLine("The account does not exist - Account number INCORRECT");
                    break;
            }
            return null;
        }
    }
}