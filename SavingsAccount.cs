using System;

namespace AppCuentaBanca
{
    public class SavingsAccount : Account
    {
        // Unique SavingsAccount features
        readonly float profitAbility = 0.01f;
        readonly int operationsLimit = 6;
        readonly float costOperation = 3200;

        public override string ToString() {
            return "Savings-account".ToUpper();
        }

        // Metodos
        // Execute the method of the Account class and add one for each operation.
        public override bool TransferMoney(Account personalAccount, Account targetAccount, float amount) {
            bool executeTransfer = base.TransferMoney(personalAccount, targetAccount, amount);
            if (executeTransfer != true) return false;
            
            personalAccount.Operations += 1;
            return true;
        }
        // Counts the number of operations performed after the free limit
        

    }
}
