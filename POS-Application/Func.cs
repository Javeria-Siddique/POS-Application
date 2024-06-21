using System;
using Microsoft.EntityFrameworkCore;
using POSApp.Entities;
using POSApp.Data;
using System.Security.Principal;

namespace POSApp
{
    public static class AppMgmt
    {
        private static readonly AppDBContext context = new AppDBContext();
        public static string hello = "hello";
        public static string role = "admin";

        public static User AuthenticateUser(int id, string password, string userRole = "admin")
        {
            if (userRole == "cashier")
            {
                role = "cashier";
            }
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.password))
                {
                    Console.WriteLine("User authenticated");
                    return user;
                }
                else
                {
                    Console.WriteLine("Authentication failed");
                    return null;
                }
            }
            return null;
        }
        public static void AddRandomUsers()
        {
            var user1 = new User ( 1, "admin", "admin@gmail.com", "adminPassword", "admin" );
            context.Users.Add(user1);
            context.SaveChanges();
            var user2 = new User ( 2, "cashier1", "cashier1@gmail.com", "cashier1Password", "cashier" );
            context.Users.Add(user2);
            context.SaveChanges();
            var user3 = new User ( 3, "cashier2", "cashier2@gmail.com", "cashier2Password", "cashier" );
            context.Users.Add(user3);
            context.SaveChanges();
            var user4 = new User ( 4, "cashier3", "cashier3@gmail.com", "cashier3Password", "cashier" );
            context.Users.Add(user4);
            context.SaveChanges();
        }
    }
}
