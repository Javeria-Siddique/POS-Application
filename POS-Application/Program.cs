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
            Console.WriteLine("Users added");
            Console.WriteLine("Choose the action:\n1. Login Admin 2. Login Cashier");
            string login = Console.ReadLine();
            if (login != null)
            {
                if (int.Parse(login) == 1)
                {
                    Console.WriteLine("Enter Password");
                    string pass = Console.ReadLine();
                    if (pass != null) {
                        user = AppMgmt.AuthenticateUser(1, pass);
                        if (user != null)
                        {
                            Console.WriteLine($"user: {user.name}");
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if (int.Parse(login) == 2)
                {
                    Console.WriteLine("Enter ID: ");
                    string id = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    string pass = Console.ReadLine();
                    if (pass != null)
                    {
                        user = AppMgmt.AuthenticateUser(int.Parse(id), pass, "cashier");
                        if (user != null)
                        {
                            Console.WriteLine($"user: {user.name}");
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    return;
                }
            }
            string x = Console.ReadLine();
        }
    }
}