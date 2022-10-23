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

        protected override void BalanceReport( Account personalAccount, float administrationFee ) {
            base.BalanceReport(personalAccount, administrationFee);
        }

        protected override void CostAdministrationFee( Account personalAccount, float administrationFee ){
            // Calculates the administration fee and the sample
            DateTime today = DateTime.Now;
            TimeSpan interval = today - dayCreateAccount;
            double month;

            if (interval.Days >= 30) {

                month = Math.Truncate((double) interval.Days / 30);
                personalAccount.Balance -= administrationFee * month;

                Console.WriteLine($"Administration Fee: {administrationFee * month}");

            }
        }
    }
}


// Check if the amount is less than the balance
// Check if the amount is less than the overdraft quota
// Check if the amount is less than the operations limit