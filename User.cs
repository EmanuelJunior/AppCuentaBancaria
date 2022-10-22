using System;

namespace AppCuentaBanca
{
    public class User
    {
        public void ShowMenuApp() {
            /* Console.ForegroundColor = ConsoleColor.Green; */
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("           APP Bank Account          ");
            Console.WriteLine("-------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n| Login --------------------------- |");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSelect your account for Login");
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1. If you want to login EXPRESS ACCOUNT");
            Console.WriteLine("2. If you want a PAYROLL ACCOUNT");
            Console.WriteLine("3. If you prefer a SAVINGS ACCOUNT");
            Console.WriteLine("4. If you want a CURRENT ACCOUNT\n");
        }

        public void ShowMenuAccount() {
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("       Options - Personal Account      ");
            Console.WriteLine("---------------------------------------");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSelect a option");
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1. If you want to Transfer Money");
            Console.WriteLine("2. If you want to make a withdrawal");
            Console.WriteLine("3. If you want to make a deposit");
            Console.WriteLine("4. To check the balance of you account\n");
            Console.WriteLine("3. If you want to see the operations report");
        }
    }
}