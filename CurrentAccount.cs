using System;
using System.Collections.Generic;

namespace AppCuentaBanca
{
    public class CurrentAccount : Account
    {
        // Unique SavingsAccount features
        List<string> paymentMethods = new List<string>();
        int overdraftQuota;
        

        // To reset the time (1 min) needed to complete the "month".
        DateTime lastTimeOperationCollection = DateTime.Now;

        public CurrentAccount() { this.typeAccount = "Current Account"; }

        public override string ToString() {
            this.overdraftQuota = Utils.CheckFieldIsNumber("How much is the overdraft?");
            int cant = Utils.CheckFieldIsNumber("How many payment methods do you have?");

            for ( int i = 0; i < cant; i++ ) {
                Console.Clear();
                Console.Write($"{i+1}. Payment method: ");
                this.paymentMethods.Add( Console.ReadLine() );
            }

            return "Current-account".ToUpper();
        }

        // Show info of the Current Account
        public override void ShowAccountData( bool showType = false ) {
            base.ShowAccountData( showType );
            Console.WriteLine($"Overdraft quota: {Utils.TransformNumberToMoney( this.overdraftQuota )}");
            Console.WriteLine($"\nPayment methods: ");
            
            foreach ( string paymentMethod in this.paymentMethods ) {
                Console.WriteLine($"    - {paymentMethod}");
            }
        }
        
        // Withdraw() method overwritten
        public override bool Withdraw() {

            // Ask for the amount to withdraw
            int amount = Utils.CheckFieldIsNumber("How much is the amount you want to withdraw?");

            try {
                // This is the normal withdraw, without overdraftQuota balance         
                bool moneyCanBeWithdraw = base.Withdraw( amount );
                if ( !moneyCanBeWithdraw ) throw new Exception("\nThe money cannot be withdrawn, the amount is greater than the available balance.\n");
                
                this.balance -= amount;
                return true;

            } catch (Exception e) {

                // Ask if you wish to use the available quota
                Console.Clear();
                Console.WriteLine(e.Message);
                bool balanceIsZero = false;

                Console.WriteLine("Overdraft quota: {0}".ToUpper(), Utils.TransformNumberToMoney( this.overdraftQuota ));

                Console.Write("\nWant to make a loan with the available overdraft of your account? (y/n): ");
                string answer = Console.ReadLine();

                if (  answer != "y" && answer != "Y"  ) {
                    Console.Write("\nThe withdrawal of money could not be carried out".ToUpper());
                    return false;
                }

                Console.Clear();

                // If the amount is greater than the balance, but there is money in the quota

                if ( this.balance == 0 ) balanceIsZero = true;

                if ( balanceIsZero && amount > this.overdraftQuota ) { 
                    Console.Write("The loan amount is greater than the overdraft quota."); 
                    return false;
                }

                if ( amount > this.overdraftQuota + this.balance ) { 
                    Console.Write("The loan amount is greater than the overdraft quota."); 
                    return false;
                }

                amount -= this.balance;
                this.balance = 0;

                this.overdraftQuota -= amount;

                Console.Clear();
                Console.WriteLine("The loan was successful...");
                Console.WriteLine("\nOverdraft quota is: {0}", Utils.TransformNumberToMoney( this.overdraftQuota ));
                Console.WriteLine("The new balance is: {0}", Utils.TransformNumberToMoney( this.balance ));
                return true;
            }

        }

        // Charges per minute (monthly fee) depending on number of operations
        public override void CostMonthlyFee() {
            
            // Counter: resets in one minute
            TimeSpan timeSpan = DateTime.Now - this.lastTimeOperationCollection;
            if (timeSpan.TotalSeconds < 60) return;

            int costOperation = 0;

            if (this.operations > 0 && this.operations <= 10) {
                costOperation = 8500;
                this.balance -= costOperation;
            } else if (this.operations > 10 && this.operations <= 20) {
                costOperation = 14900;
                this.balance -= costOperation;
            } else if (this.operations > 20) {
                costOperation = 19800;
            }
            this.balance -= costOperation;

            Console.WriteLine($"The cost operation is: { costOperation }");
            Console.WriteLine($"Total Number of operations: { this.operations }");

            // Resets the number of operations every minute

            this.operations = 0;
            this.lastTimeOperationCollection = DateTime.Now;
        }

    }
}