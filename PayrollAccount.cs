using System;

namespace AppCuentaBanca
{
    public class PayrollAccount : Account
    {
        // Unique SavingsAccount features
        string companyName;
        int companyNIT;
        new int operationsLimit = 8;
        new int costOperation = 3200;

        public PayrollAccount() { 
            base.operationsLimit = operationsLimit;
            base.costOperation = costOperation;
            
            this.typeAccount = "Payroll Account"; 
        }

        public override void ShowAccountData( bool showType = false ) {
            base.ShowAccountData( showType );
            Console.WriteLine($"Company name: {this.companyName}");
            Console.WriteLine($"Company NIT: {this.companyNIT}");
        }

        public override string ToString() {
            Console.Clear();
            Console.Write("Enter the name of the company: ");
            this.companyName = Console.ReadLine();

            this.companyNIT = Utils.CheckFieldIsNumber("Enter the NIT of the company: ");
            return "Payroll-account".ToUpper();
        }
    }
}