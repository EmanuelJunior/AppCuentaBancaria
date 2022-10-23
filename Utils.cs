using System;

namespace AppCuentaBanca
{
    public class Utils
    {
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

        public static int CheckFieldIsNumber( string message, string messageForMenu = null, Action<string> showMenu = null ) {
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
    }
}