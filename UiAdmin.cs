using System;

namespace AppCuentaBanca
{
    public class UiAdmin
    {
        public static void MenuAdmin() {
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

        public static void ListAccountsChoose( string actionType ) {
            Console.Clear();
            Console.WriteLine($"\nwhat type of account do you want to {actionType}?: ".ToUpper());

            Console.WriteLine($"\n1. If you want to {actionType} an EXPRESS ACCOUNT");
            Console.WriteLine("2. If you want a PAYROLL ACCOUNT");
            Console.WriteLine("3. If you prefer a SAVINGS ACCOUNT");
            Console.WriteLine("4. If you want a CURRENT ACCOUNT\n");            
        }
    }
}