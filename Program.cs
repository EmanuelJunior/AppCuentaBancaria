using System.Collections.Generic;
using System;

namespace AppCuentaBanca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Account cuentaUno = new Account();
            // Account cuentaDos = new Account();
            // cuentaDos.AccountNumber = 12345;

            // cuentaUno.TransferMoney(cuentaUno, cuentaDos, 200);

            Admin root = new Admin();
            root.Nav(1);
        
            /* ExpressAccount cuentaExpress = new ExpressAccount();
            cuentaExpress.Withdraw(); */
        }
    }
}
