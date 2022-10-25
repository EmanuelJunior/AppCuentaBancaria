using System;

namespace AppCuentaBanca
{
    public class SavingsAccount : Account
    {
        // Unique SavingsAccount features
        readonly double profitAbility = 0.01d;
        new int operationsLimit = 6;
        new int costOperation = 3000;
        DateTime lastTimeProfiAbility = DateTime.Now;

        public SavingsAccount() { 
            base.operationsLimit = operationsLimit;
            base.costOperation = costOperation;

            this.typeAccount = "Savings Account"; 
        }

        public override string ToString() {
            return "Savings-account".ToUpper();
        }

        // Logic specific of the metohd CostMonthlyFee for the SavingAccount
        // Calculate the profitAbility of the account and every minute adds up to that profitability
        public override void CostMonthlyFee(){
            
            TimeSpan timeSpan = DateTime.Now - this.lastTimeProfiAbility;
            double balanceProfitAbility = this.balance * profitAbility;

            if (timeSpan.TotalSeconds < 60) {
                Console.WriteLine("The profitAbility is not yet available.");
                return;
            }

            // Transform balanceProfitAbility to int
            int balanceProfitAbilityInt = (int)balanceProfitAbility;
            this.balance += balanceProfitAbilityInt;

            this.lastTimeProfiAbility = DateTime.Now;

            Console.WriteLine($"The profit ability in the month is: {Utils.TransformNumberToMoney(balanceProfitAbilityInt)}");
            Console.WriteLine($"The new balance is: {Utils.TransformNumberToMoney( this.balance )}\n");

        }

    }
}
