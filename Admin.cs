using System;
using System.Collections.Generic;

namespace AppCuentaBanca
{
    public class Admin
    {
        List<CurrentAccount> currentAccounts = new List<CurrentAccount>();
        List<SavingsAccount> savingsAccounts = new List<SavingsAccount>();
        List<PayrollAccount> payrollAccounts = new List<PayrollAccount>();

        public void Nav( int option ) {
            switch( option ) {
                case 1:
                    // Create a new account
                    this.SelectAccountTypeAndCreate();
                    break;
                case 2:
                    // Delete an account
                    break;
                case 3:
                    // Modify an account
                    break;
                case 4:
                    // Consult an account
                    break;
                case 5:
                    // Consult all accounts
                    break;
                default:
                    // Exit
                    break;
            }
        }

        void SelectAccountTypeAndCreate() {

            Console.WriteLine("\nwhat type of account do you want to create?: ".ToUpper());

            Console.WriteLine("\n1. If you want to create an express account");
            Console.WriteLine("2. If you want a payroll account");
            Console.WriteLine("3. If you prefer a savings");
            Console.WriteLine("4. If you want a current account\n");

            Console.Write("select an option: ".ToUpper());
            int accountType = int.Parse(Console.ReadLine());

            switch ( accountType ) {
                case 1:
                    ExpressAccount expressAccount = new ExpressAccount();
                    this.CreateAccount( expressAccount );
                    break;
                case 2:
                    PayrollAccount payrollAccount = new PayrollAccount();
                    this.CreateAccount( payrollAccount );
                    break;
                case 3:
                    SavingsAccount savingsAccount = new SavingsAccount();
                    this.CreateAccount( savingsAccount );
                    break;
                case 4:
                    CurrentAccount currentAccount = new CurrentAccount();
                    this.CreateAccount( currentAccount );
                    break;
            }
        }

        void CreateAccount( Account account ) {

            // Create a new account
            Console.Write("\nName: ");
            account.Name = Console.ReadLine();

            Console.Write("Last name: ");
            account.LastName = Console.ReadLine();

            Console.Write("Profession: ");
            account.Profession = Console.ReadLine();

            Console.Write("Address: ");
            account.Address = Console.ReadLine();

            Console.Write("Password: ");
            account.Password = Console.ReadLine();

            Console.Write("ID number: ");
            account.IdNumber = int.Parse(Console.ReadLine());

            Console.Write("Account number: ");
            account.AccountNumber = int.Parse(Console.ReadLine());

            Console.Write("Phone: ");
            account.Phone = int.Parse(Console.ReadLine());

            Console.WriteLine( account );
        }

        void DeleteAccount() {
            // Delete an account
        }

        void ModifyAccount() {
            // Modify an account
        }

        void ConsultAccount() {
            // Consult an account
        }

        void ConsultAllAccounts() {
            // Consult all accounts
        }
    }
}