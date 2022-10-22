using System.Collections.Generic;
using System;

namespace AppCuentaBanca
{
    internal class Program
    {
        static void Main()
        {
            Admin.OptionsForAdmin(1);
            Admin.OptionsForAdmin(1);
            Controller.OptionsPersonalAccount();

            // ExpressAccount firstAccount = new ExpressAccount();
            // ExpressAccount sAccount = new ExpressAccount();
            // firstAccount.balance = 1000;
            // sAccount.balance = 1000;
            // sAccount.AccountNumber = 123;

            // firstAccount.TransferMoney( firstAccount, sAccount, 200 );

            
        }
    }
}
