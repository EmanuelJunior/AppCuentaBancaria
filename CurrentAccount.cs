using System;
using System.Collections.Generic;

namespace AppCuentaBanca
{
    public class CurrentAccount : Account
    {
        List<string> paymentMethods = new List<string>();
        int overdraftQuota;

        public override string ToString() {
            
            Console.Write("How much is the overdraft?: ");
            this.overdraftQuota = int.Parse( Console.ReadLine() );

            Console.Write("How many payment methods do you have?: ");
            int cant = int.Parse( Console.ReadLine() );

            for ( int i = 0; i < cant; i++ ) {
                Console.Write("Payment method: ");
                this.paymentMethods.Add( Console.ReadLine() );
            }

            return "\nCreate successful Current account...\n".ToUpper();
        }

        public override bool Withdraw() {
            try {
                // Ask for the amount to withdraw
                Console.Write("How much is the amount you want to withdraw?: ");
                float amount = float.Parse(Console.ReadLine());

                bool moneyCanBeWithdraw = base.Withdraw( this, amount );
                if ( !moneyCanBeWithdraw ) throw new Exception("The money cannot be withdrawn, the amount is greater than the available balance.");
                
                this.balance -= amount;
                return true;

            } catch (Exception e) {

                Console.WriteLine(e.Message);

                Console.Write("Want to make a loan with the available overdraft of your account?");
                bool answer = bool.Parse(Console.ReadLine());

                if ( !answer ) {
                    Console.Write("The withdrawal of money could not be carried out");
                    return false;
                }

                Console.Write("How much is the amount you want to loan?: ");
                float loanAmount = float.Parse(Console.ReadLine());

                if ( loanAmount > overdraftQuota ) { 
                    Console.Write("The loan amount is greater than the overdraft quota."); 
                    return false;
                }

                this.balance -= loanAmount;
                Console.Write(" The loan was successful");
                return true;
            }

        }
    }
}