using System;
using Microsoft.EntityFrameworkCore;
using POSApp.Entities;
using POSApp.Data;

namespace POSApp
{
    public static class AppMgmt
    {
        private static readonly AppDBContext context = new AppDBContext();
        public static string hello = "hello";

        public static void AuthenticateUser(int id, string password, string role = "admin")
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                Console.WriteLine("no user so far");
            }
            /*else if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                Console.WriteLine("User authenticated");
            }*/
            else
            {
                Console.WriteLine("Authentication failed");
            }

        }
    }
}
