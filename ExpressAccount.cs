using System;

namespace AppCuentaBanca
{
    public class ExpressAccount : Account
    {
        // Unique SavingsAccount features
        readonly int administrationFee = 12500;

        // To reset the time (1 min) needed to complete the "month"
        DateTime lastTimeAdministrationFee = DateTime.Now;
        
        public ExpressAccount() { this.typeAccount = "Express Account"; }

        public override string ToString() {
            return "Express-account".ToUpper();
        }

        // Logic specific of the metohd CostMonthlyFee for the ExpressAcount
        // Every minute account management fee is collected        
        public override void CostMonthlyFee(){
            
            TimeSpan timeSpan = DateTime.Now - this.lastTimeAdministrationFee;
            Console.WriteLine($"{Math.Truncate(timeSpan.TotalSeconds)} second");
            if (timeSpan.TotalSeconds < 60) return;

            this.balance -= administrationFee;
            this.lastTimeAdministrationFee = DateTime.Now;

            Console.WriteLine($"The Administration Fee is: { Utils.TransformNumberToMoney(administrationFee) }");
        }
    }
}