using System;

namespace AppCuentaBanca
{
    public class User
    {
        static public void ShowMenuAppForLogin() {
            Console.Clear();
            Console.WriteLine("\n=====================================");
            Console.WriteLine("           APP Bank Account          ");
            Console.WriteLine("=====================================");
            Console.WriteLine("\n| LOGIN =========================== |");

            // Console.WriteLine("\n=====================================");
            Console.WriteLine("\nSelect your account for Login");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1. If you want to login EXPRESS ACCOUNT");
            Console.WriteLine("2. If you want a PAYROLL ACCOUNT");
            Console.WriteLine("3. If you prefer a SAVINGS ACCOUNT");
            Console.WriteLine("4. If you want a CURRENT ACCOUNT\n");
        }

        static public void ShowHeaderForLogin() {
            Console.Clear();
            Console.WriteLine("\n=====================================");
            Console.WriteLine("           APP Bank Account          ");
            Console.WriteLine("=====================================");
            Console.WriteLine("\n| LOGIN =========================== |");
        }

        // Displays the menu of the logged in user with his data
        static public void ShowMenuAccount( string userName, int balance, int operations, string typeAccount) {
            Console.Clear();
            Console.WriteLine("\n=======================================");
            Console.WriteLine($"       Options - { typeAccount }      ");
            Console.WriteLine("=======================================");
            Console.WriteLine($"\n| User: {userName} ==========================");
            Console.WriteLine($"| Balance: {Utils.TransformNumberToMoney( balance )} ==========================");
            
            if ( typeAccount == "Savings Account" || typeAccount == "Current Account" || typeAccount == "Payroll Account" ) {
                Console.WriteLine($"| Operations: {operations} ==========================");
            }
            
            Console.WriteLine("\nSelect a option");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1. If you want to Transfer Money");
            Console.WriteLine("2. If you want to make a withdrawal");
            Console.WriteLine("3. If you want to make a deposit");
            Console.WriteLine("4. To check the balance of you account");
            Console.WriteLine("5. If you want to see the operations report");
            Console.WriteLine("6. If you want to log out\n");
            Console.WriteLine("7. If you want to exit\n");
        }
    }
}