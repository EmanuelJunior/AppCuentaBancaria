using System;

namespace AppCuentaBanca
{
    public class ExpressAccount : Account
    {
        readonly int administrationFee = 12500;
        
        public ExpressAccount() { this.typeAccount = "Express Account"; }

        public override string ToString() {
            return "Express-account".ToUpper();
        }

        // Count of operations (TransferMoney)
        public override bool TransferMoney(Account targetAccount, int amount) {
            bool executeTransfer = base.TransferMoney( targetAccount, amount);
            if (executeTransfer != true) return false;
            
            this.Operations += 1;
            return true;
        }

        public override bool Withdraw() {
            // Ask for the amount to withdraw
            Console.Write("How much is the amount you want to withdraw?: ");
            int amount = int.Parse(Console.ReadLine());

            bool moneyCanBeWithdraw = base.Withdraw( amount );
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

            Console.WriteLine($"The number of operations executed is: {this.operations}");
            
            // Calculate the number of months
            if (interval.Seconds >= 60) {
                month = Math.Truncate((double) interval.Seconds / 60);
                this.balance -= administrationFee * int.Parse( month.ToString() );

                Console.WriteLine($"\nAdministration fee charged every minute (1)");
                Console.WriteLine($"\nAdministration Fee: {administrationFee * month}");
                Console.WriteLine($"\nNew Balance: {this.balance}");
            }   
            else { 
                Console.WriteLine($"\n{60 - interval.Seconds} seconds left to collect the fee");
                Console.WriteLine("\nNo outstanding dues".ToUpper());
            }

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