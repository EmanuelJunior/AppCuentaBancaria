using System.Collections.Generic;
using System;

namespace AppCuentaBanca
{
    internal class Program
    {
        static void Main()
        {


            // User menuUser = new User();
            // menuUser.ShowMenuApp();
            Admin root = new Admin();
            root.Nav(1);
            root.Nav(2);


            // ExpressAccount firstAccount = new ExpressAccount();
            // ExpressAccount sAccount = new ExpressAccount();
            // firstAccount.balance = 1000;
            // sAccount.balance = 1000;
            // sAccount.AccountNumber = 123;

            // firstAccount.TransferMoney( firstAccount, sAccount, 200 );
        }
    }
}
