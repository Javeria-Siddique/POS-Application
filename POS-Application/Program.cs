using System;
using Microsoft.EntityFrameworkCore;
using POSApp.Entities;
using POSApp.Data;
using System.Runtime.CompilerServices;

namespace POSApp
{
    class Program
    {
        public static User user = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Application starting");
            AppMgmt.AddRandomUsers();
            AppMgmt.AddRandomProducts();
            option1:
            Console.WriteLine("Choose the action:\n1. Login Admin 2. Login Cashier");
            string login = Console.ReadLine();
            if (login != null)
            {
                if (int.Parse(login) == 1)
                {
                    wrongPassword:
                    Console.WriteLine("Enter Password");
                    string pass = Console.ReadLine();
                    if (pass != null) {
                        user = AppMgmt.AuthenticateUser(1, pass);
                        if (user == null)
                        {
                            goto wrongPassword;
                        }
                    }
                }
                else if (int.Parse(login) == 2)
                {
                    wrongCredentials:
                    Console.WriteLine("Enter ID: ");
                    string id = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    string pass = Console.ReadLine();
                    if (pass != null)
                    {
                        user = AppMgmt.AuthenticateUser(int.Parse(id), pass, "cashier");
                        if (user == null)
                        {
                            goto wrongCredentials;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    goto option1;
                }
                option2:
                Console.WriteLine("Choose the action: \n");
                AppMgmt.DisplayMenu();
                string action = Console.ReadLine();
                if (action != null)
                {
                    AppMgmt.PerformAction(int.Parse(action));
                    goto option2;
                }
                else
                {
                    goto option2;
                }
            }
            else
            {
                Console.WriteLine("Invalid option");
                goto option1;
            }
            string x = Console.ReadLine();
        }
    }
}