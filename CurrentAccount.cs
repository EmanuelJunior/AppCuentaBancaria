using System;
using System.Collections.Generic;

namespace AppCuentaBanca
{
    public class CurrentAccount : Account
    {

        List<string> paymentMethods = new List<string>();
        int overdraftQuota;

        public CurrentAccount() { this.typeAccount = "Current Account"; }

        public override string ToString() {
            this.overdraftQuota = this.CheckFieldIsNumber("How much is the overdraft?");
            int cant = this.CheckFieldIsNumber("How many payment methods do you have?");

            for ( int i = 0; i < cant; i++ ) {
                Console.Clear();
                Console.Write($"{i+1}. Payment method: ");
                this.paymentMethods.Add( Console.ReadLine() );
            }

            return "Current-account".ToUpper();
        }

        public override void ShowAccountData( bool showType = false ) {
            base.ShowAccountData();
            Console.WriteLine($"Overdraft quota: {this.overdraftQuota}");
            Console.WriteLine($"\nPayment methods: ");
            
            foreach ( string paymentMethod in this.paymentMethods ) {
                Console.WriteLine($"    - {paymentMethod}");
            }
        }

        public override bool Withdraw() {
            try {
                // Ask for the amount to withdraw
                Console.Write("How much is the amount you want to withdraw?: ");
                int amount = int.Parse(Console.ReadLine());

                bool moneyCanBeWithdraw = base.Withdraw( amount );
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
                int loanAmount = int.Parse(Console.ReadLine());

                if ( loanAmount > overdraftQuota ) { 
                    Console.Write("The loan amount is greater than the overdraft quota."); 
                    return false;
                }

                this.balance -= loanAmount;
                Console.Write(" The loan was successful");
                return true;
            }

        }

        public override TimeSpan CostAdministrationFee( ){

            TimeSpan interval = base.CostAdministrationFee();
            return interval;
        }

        // si el timespan esta entre 0 y 30 pregunta por el numero de movimientos 

    }
}