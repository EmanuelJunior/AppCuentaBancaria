using System;

namespace AppCuentaBanca
{
    public class PayrollAccount : Account
    {
        string companyName;
        int companyNIT;
        readonly int operationsLimit = 6;
        readonly float costOperation = 3000;

        public PayrollAccount() { this.typeAccount = "Payroll Account"; }

        public override void ShowAccountData( bool showType = false ) {
            base.ShowAccountData();
            Console.WriteLine($"Company name: {this.companyName}");
            Console.WriteLine($"Company NIT: {this.companyNIT}");
        }

        public override string ToString() {
            Console.Clear();
            Console.Write("Enter the name of the company: ");
            this.companyName = Console.ReadLine();

            this.companyNIT = this.CheckFieldIsNumber("Enter the NIT of the company: ");
            return "Payroll-account".ToUpper();
        }

    }
}