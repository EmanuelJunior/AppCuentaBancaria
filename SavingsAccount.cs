using System;

namespace AppCuentaBanca
{
    public class SavingsAccount : Account
    {
        // Unique SavingsAccount features
        readonly float profitAbility = 0.01f;
        readonly int operationsLimit = 6;
        readonly int costOperation = 3200;

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

        public override void OperationsCollection(){
            if (this.operations < operationsLimit ) {return;}

            int chargePerOperation = this.operations - operationsLimit;
            int collection = chargePerOperation * costOperation;
            this.balance -= collection;
            Console.WriteLine($"Number of operations executed: { this.operations }");
            Console.WriteLine($"Total cost of operations: { collection }");
            Console.WriteLine($"New Balance: { this.balance }");
            this.operations = operationsLimit;   
        }
    }
}
