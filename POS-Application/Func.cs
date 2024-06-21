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
            var user1 = new User(1, "admin", "admin@gmail.com", "adminPassword", "admin");
            context.Users.Add(user1);
            context.SaveChanges();
            var user2 = new User(2, "cashier1", "cashier1@gmail.com", "cashier1Password", "cashier");
            context.Users.Add(user2);
            context.SaveChanges();
            var user3 = new User(3, "cashier2", "cashier2@gmail.com", "cashier2Password", "cashier");
            context.Users.Add(user3);
            context.SaveChanges();
            var user4 = new User(4, "cashier3", "cashier3@gmail.com", "cashier3Password", "cashier");
            context.Users.Add(user4);
            context.SaveChanges();
        }
        public static void AddRandomProducts()
        {
            var product1 = new Product(1, "Product1", 100, 10, "abc", "xyz");
            context.Products.Add(product1);
            context.SaveChanges();
            var product2 = new Product(2, "Product2", 100, 10, "abc", "xyz");
            context.Products.Add(product2);
            context.SaveChanges();
            var product3 = new Product(3, "Product3", 100, 10, "abc", "xyz");
            context.Products.Add(product3);
            context.SaveChanges();
            var product4 = new Product(4, "Product4", 100, 10, "abc", "xyz");
            context.Products.Add(product4);
            context.SaveChanges();
            var product5 = new Product(5, "Product5", 100, 10, "abc", "xyz");
            context.Products.Add(product5);
            context.SaveChanges();
        }
        public static void AdminMenu()
        {
            Console.WriteLine("1. Register new Cashier\t2. Add new Product\t3. Remove Product\t4. Update Product\t5. Check Inventory\t6. Check Transactions\n");
        }
        public static void CashierMenu()
        {
            Console.WriteLine("1. Check product info\t2. Add product to sale\n");
        }
        public static void DisplayMenu()
        {
            if (role == "admin")
            {
                AdminMenu();
            }
            else if (role == "cashier")
            {
                CashierMenu();
            }
        }
        public static Product CheckProductInfo()
        {
            Console.WriteLine("Enter Product ID: ");
            string productId = Console.ReadLine();
            Product product = context.Products.FirstOrDefault(product => product.Id == int.Parse(productId));
            Console.WriteLine($"------Product Info------\nId\tName\t\tPrice\tQuantity\tType\tCategory\n{product.Id}\t{product.name}\t{product.price}\t{product.quantity}\t\t{product.type}\t{product.category}");
            return product;
        }
        public static void PerformAction(int option)
        {
            if (role == "cashier")
            {
                if (option < 1 && option > 2)
                {
                    return;
                }
                else
                {
                    if (option == 1)
                    {
                        Product product = CheckProductInfo();
                    }
                    if (option == 2)
                    {
                        //add product to sale transaction
                    }
                }
            }
            if (role == "admin")
            {
                if (option < 1 && option > 6)
                {
                    return;
                }
                else
                {
                    if (option == 1)
                    {
                        // register new cashier
                    }
                    if (option == 2)
                    {
                        //add new product
                    }
                    if (option == 3)
                    {
                        //remove product
                    }
                    if (option == 4)
                    {
                        //update product
                    }
                    if (option == 5)
                    {
                        //check inventory
                    }
                    if (option == 6)
                    {
                        //check transactions
                    }
                }
            }
        }
    }
}