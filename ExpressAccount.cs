using System;

namespace AppCuentaBanca
{
    public class ExpressAccount : Account
    {
        readonly float administrationFee = 12500f;
        
        public ExpressAccount() { this.typeAccount = "Express Account"; }

        public override string ToString() {
            return "Express-account".ToUpper();
        }

        public override bool Withdraw() {
            // Ask for the amount to withdraw
            Console.Write("How much is the amount you want to withdraw?: ");
            float amount = float.Parse(Console.ReadLine());

            bool moneyCanBeWithdraw = base.Withdraw( this, amount );
            if ( !moneyCanBeWithdraw ) return false;
            
            this.balance -= amount;
            Console.WriteLine($"\nTransferred: {amount}, Remaining money: {this.balance}");
            Console.WriteLine("\nThe withdrawal was successful...\n".ToUpper());
            return true;
        }        

        // Logic specific of the metohd ConstAdmistrationFee for the ExpressAcount
        public override TimeSpan CostAdministrationFee( ){

            TimeSpan interval = base.CostAdministrationFee();
            double month = 0;

            // Calculate the number of months
            if (interval.Seconds >= 60) {
                month = Math.Truncate((double) interval.Seconds / 60);
                this.balance -= administrationFee * month;
                Console.WriteLine($"\nAdministration fee charged every minute (1)");
                Console.WriteLine($"\nAdministration Fee: {administrationFee * month}");
                Console.WriteLine($"\nNew Balance: {this.balance}");
                
            } else { Console.WriteLine("No outstanding dues"); }

            return interval;
        }
        
        /* protected override void BalanceReport( Account personalAccount, float administrationFee ) {
            base.BalanceReport(personalAccount, administrationFee);
        } */

    }
}


// Check if the amount is less than the balance
// Check if the amount is less than the overdraft quota
// Check if the amount is less than the operations limit