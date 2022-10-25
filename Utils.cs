using System;

using System.Collections.Generic;
using System.Linq;

namespace AppCuentaBanca
{
    public class Utils
    {        
        // Replace letters with asterisks and return it
        public static string ReplaceLettersWithAsterisks( string text ) {
            string textWithAsterisks = "";

            for (int i = 0; i < text.Length; i++) textWithAsterisks += "*";
            return textWithAsterisks;
        }

        // Detect that it is being written by console with Console.ReadKey and replace letters with asterisks and the letters will be saved in a new string that will be returned
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter) {
                    password += key.KeyChar;
                    Console.Write("*");
                } else {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0) {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            return password;
        }

        // Transform a number to money format 
        static public string TransformNumberToMoney( int num ) {

            string money = "";
            string numString = num.ToString();
            int cant = numString.Length;
            int count = 0;

            // remove the hyphen "-"
            if ( numString[0] == '-' ) {
                numString = numString.Substring(1);
                cant--;
            }

            for (int i = cant - 1; i >= 0; i--) {
                money += numString[i];
                count++;

                if (count == 3 && i != 0) {
                    money += ".";
                    count = 0;
                }
            }

            string moneyReverse = "";
            for (int i = money.Length - 1; i >= 0; i--) moneyReverse += money[i];

            if ( num < 0 ) moneyReverse = moneyReverse.Insert(0, "- $");
            else moneyReverse = moneyReverse.Insert(0, "$");

            return moneyReverse;
        }

        /* A method that is used to try to execute a code until it works, it is used to avoid errors in the
        code. */
        public static T TryCodeUntilItWorks<T>( 
            string messageError, 
            Func<string, bool, string, T> action, 
            Func<T> emptyAction, 
            string message = null, 
            bool returnsAnAccount = false,
            string typeAccount = null
        ) {
            bool isCorrect = false;
            T valueToReturn = default(T);

            while ( !isCorrect ) {
                try {
                    Console.Clear();

                    if ( message == null && !returnsAnAccount ) valueToReturn = emptyAction();
                    else valueToReturn = action(message, returnsAnAccount, typeAccount);

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

        // Check if the field is a number
        public static int CheckFieldIsNumber( string message, string messageForMenu = null, Action<string> showMenu = null, Action showMenuWithoutParameters = null) {
            // Cycle to validate the field number
            bool IsCorrect = false;
            int field = 0;

            while ( !IsCorrect ) {
                try {
                    if ( field == 0 ) {
                        if ( showMenu != null && messageForMenu != null) showMenu(messageForMenu);
                        else if ( showMenuWithoutParameters != null ) showMenuWithoutParameters();
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

        // Validate that when creating an account the idNumber is unique in all accounts
        public static int ValidateIdNumber<T>( int idNumber, List<T> accounts ) where T: Account {
            bool isCorrect = false;

            while ( !isCorrect ) {
                try {
                    foreach ( T account in accounts ) {
                        if ( account.IdNumber == idNumber ) throw new Exception("The id number is already registered");
                    }

                    isCorrect = true;
                } catch ( Exception e ) {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\nPress any key to continue...".ToUpper());
                    Console.ReadKey();
                    Console.Clear();

                    idNumber = CheckFieldIsNumber("Id number");
                }
            }

            return idNumber;
        }
    }
}