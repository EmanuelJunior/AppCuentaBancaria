using System;

namespace AppCuentaBanca
{
    public class PayrollAccount : Account
    {
        string companyName;
        int companyNIT;
        readonly int operationsLimit = 6;

        public override string ToString() {
            Console.Write("Enter the name of the company: ");
            this.companyName = Console.ReadLine();

            Console.Write("Enter the NIT of the company: ");
            this.companyNIT = int.Parse( Console.ReadLine() );

            return "\nCreate successful Payroll account...\n".ToUpper();
        }
    }
}