using System;

namespace AppCuentaBanca
{
    public class SavingsAccount : Account
    {
        // Unique SavingsAccount features
        readonly float profitAbility = 0.01f;
        readonly int operationsLimit = 6;
        readonly float costOperation = 3200;

        public SavingsAccount() { this.typeAccount = "Savings Account"; }

        public override string ToString() {
            return "Savings-account".ToUpper();
        }

        // Methods

        // Counts the number of operations performed after the free limit
        public override bool TransferMoney(Account targetAccount, int amount) {
            bool executeTransfer = base.TransferMoney( targetAccount, amount);
            if (executeTransfer != true) return false;
            
            this.Operations += 1;
            return true;
        }
    }
}
