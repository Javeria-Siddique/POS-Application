using System;
using Microsoft.EntityFrameworkCore;
using POSApp.Entities;
using POSApp.Data;
using System.Security.Principal;
using System.ComponentModel.Design;

namespace POSApp
{
    public static class AppMgmt
    {
        private static readonly AppDBContext context = new AppDBContext();
        public static string role = "admin";
        public static int ID;
        private static int usersCount = 1;
        private static int productsCount = 1;
        private static int salesCount = 1;
        private static int productsSalesCount = 1;

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
                    ID = id;
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
            var user1 = new User(usersCount, "admin", "admin@gmail.com", "adminPassword", "admin");
            usersCount++;
            context.Users.Add(user1);
            context.SaveChanges();
            var user2 = new User(usersCount, "cashier1", "cashier1@gmail.com", "cashier1Password", "cashier");
            usersCount++;
            context.Users.Add(user2);
            context.SaveChanges();
            var user3 = new User(usersCount, "cashier2", "cashier2@gmail.com", "cashier2Password", "cashier");
            usersCount++;
            context.Users.Add(user3);
            context.SaveChanges();
            var user4 = new User(usersCount, "cashier3", "cashier3@gmail.com", "cashier3Password", "cashier");
            usersCount++;
            context.Users.Add(user4);
            context.SaveChanges();
        } 
        public static void AddRandomProducts()
        {
            var product1 = new Product(productsCount, "Product1", 100, 10, "abc", "xyz");
            productsCount++;
            context.Products.Add(product1);
            context.SaveChanges();
            var product2 = new Product(productsCount, "Product2", 100, 10, "abc", "xyz");
            productsCount++;
            context.Products.Add(product2);
            context.SaveChanges();
            var product3 = new Product(productsCount, "Product3", 100, 10, "abc", "xyz");
            productsCount++;
            context.Products.Add(product3);
            context.SaveChanges();
            var product4 = new Product(productsCount, "Product4", 100, 10, "abc", "xyz");
            productsCount++;
            context.Products.Add(product4);
            context.SaveChanges();
            var product5 = new Product(productsCount, "Product5", 100, 10, "abc", "xyz");
            productsCount++;
            context.Products.Add(product5);
            context.SaveChanges();
        }
        public static void AdminMenu()
        {
            Console.WriteLine("1. Register new Cashier\t2. Add new Product\t3. Remove Product\t4. Update Product\t5. Check Inventory\t6. Check Sales\n");
        }
        public static void CashierMenu()
        {
            Console.WriteLine("1. Check product info\t2. Add product to sale\n3. Generate Receipt");
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
        public static Product CheckProductInfo(bool check = true)
        {
            Console.WriteLine("Enter Product ID: ");
            string productId = Console.ReadLine();
            Product product = context.Products.FirstOrDefault(product => product.Id == int.Parse(productId));
            if (check)
            {
                Console.WriteLine($"------Product Info------\nId\tName\t\tPrice\tQuantity\tType\tCategory\n{product.Id}\t{product.name}\t{product.price}\t{product.quantity}\t\t{product.type}\t{product.category}");
            }
            return product;
        }
        public static void RegisterNewCashier()
        {
            Console.WriteLine("Enter cashier's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter cashier's email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter cashier's password: ");
            string password = Console.ReadLine();
            var user = new User(usersCount, name, email, password, "cashier");
            usersCount++;
            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine("Cashier Added successfully");
        }
        public static void AddNewProduct()
        {
            Console.WriteLine("Enter product name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product price: ");
            string price = Console.ReadLine();
            Console.WriteLine("Enter product quantity: ");
            string quantity = Console.ReadLine();
            Console.WriteLine("Enter product's type: ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter product's category: ");
            string category = Console.ReadLine();
            var product = new Product(productsCount, name, Convert.ToDecimal(price), int.Parse(quantity), type, category);
            productsCount++;
            context.Products.Add(product);
            context.SaveChanges();
            Console.WriteLine("Product Added successfully");
        }
        public static void RemoveProduct()
        {
            var product = CheckProductInfo(false);
            context.Products.Remove(product);
            context.SaveChanges();
            Console.WriteLine("Product removed");
        }
        public static void UpdateProduct()
        {
            var product = CheckProductInfo();
            Console.WriteLine("Enter new price (enter - if you want to keep it same): ");
            string price = Console.ReadLine();
            if (price != "-")
            {
                product.price = Convert.ToDecimal(price);
            }
            Console.WriteLine("Enter new quantity (enter - if you want to keep it same): ");
            string quantity = Console.ReadLine();
            if (quantity != "-")
            {
                product.quantity = int.Parse(quantity);
            }
            Console.WriteLine("Enter new type (enter - if you want to keep it same): ");
            string type = Console.ReadLine();
            if (type != "-")
            {
                product.type = type;
            }
            Console.WriteLine("Enter new category (enter - if you want to keep it same): ");
            string category = Console.ReadLine();
            if (category != "-")
            {
                product.category = category;
            }
            Console.WriteLine("Product updated!");
        }
        public static void CheckInventory()
        {
            Console.WriteLine($"------Inventory------\nId\tName\t\tPrice\tQuantity\tType\tCategory\n");
            for (int i = 0; i < productsCount; i++)
            {
                Product product = context.Products.FirstOrDefault(product => product.Id == i);
                if (product != null) 
                {
                    Console.WriteLine($"{product.Id}\t{product.name}\t{product.price}\t{product.quantity}\t\t{product.type}\t{product.category}");
                }
            }
            Console.WriteLine("\n");
        }
        public static void CheckSales()
        {
            Console.WriteLine("------Sales------");
            for (int i = 0; i < salesCount; i++)
            {
                var sale = context.Sales.FirstOrDefault(s => s.Id == i);
                if (sale != null)
                {
                    Console.WriteLine("Cashier ID: ", sale.cashierId);
                    Console.WriteLine("ID\tName\tQuantity\tPrice");
                    for (int j=0; j< sale.Items.Count; j++)
                    {
                        Console.WriteLine($"{sale.Items[j].productId}\t{sale.Items[j].productName}\t{sale.Items[j].quantity}\t{sale.Items[j].price}");
                    }
                }
            }
        }
        public static void AddProductToSale()
        {
            CheckInventory();
            addProducts:
            var product = CheckProductInfo(false);
            Console.WriteLine("Enter quantity: ");
            string quantity = Console.ReadLine();
            if (int.Parse(quantity) > product.quantity)
            {
                Console.WriteLine($"Not enough products available. Adding {product.quantity} items in cart");
                quantity = product.quantity.ToString();
            }
            var purchase = new Purchase(productsSalesCount, product.Id, product.name, int.Parse(quantity), product.price * int.Parse(quantity));
            productsSalesCount++;
            product.quantity -= int.Parse(quantity);
            var sale = context.Sales.FirstOrDefault(s => s.Id == salesCount);
            if (sale == null)
            {
                sale = new Sale(salesCount, ID);
                sale.Items.Add(purchase);
                context.Sales.Add(sale);
                context.SaveChanges();
                Console.WriteLine("Product added in sale!");
            }
            else
            {
                sale.Items.Add(purchase);
                Console.WriteLine("Product added in sale!");
            }
            Console.WriteLine("Enter 1 if you want to add more products to current sale, otherwise enter 0: ");
            string cont = Console.ReadLine();
            if (cont == "1")
            {
                goto addProducts;
            }
            else
            {
                return;
            }
        }
        public static void GenerateReceipt()
        {
            var sale = context.Sales.FirstOrDefault(s => s.Id == salesCount);
            if (sale == null)
            {
                Console.WriteLine("No purchase in this sale so far");
            }
            else
            {
                decimal totalBill = 0;
                Console.WriteLine("sr.\tID: Name\tQuantity\tPrice");
                for (int i = 0; i < sale.Items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}\t{sale.Items[i].productId}:{sale.Items[i].productName}\t{sale.Items[i].quantity}\t\t{sale.Items[i].price}");
                    totalBill += sale.Items[i].price;
                }
                Console.WriteLine($"Total Bill: \t\t\t{totalBill}");
                salesCount++;
            }
        }
        public static void PerformAction(int option)
        {
            if (role == "cashier")
            {
                if (option < 1 && option > 3)
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
                        AddProductToSale();
                    }
                    if (option == 3)
                    {
                        GenerateReceipt();
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
                        RegisterNewCashier();
                    }
                    if (option == 2)
                    {
                        AddNewProduct();
                    }
                    if (option == 3)
                    {
                        RemoveProduct();
                    }
                    if (option == 4)
                    {
                        UpdateProduct();
                    }
                    if (option == 5)
                    {
                        CheckInventory();
                    }
                    if (option == 6)
                    {
                        CheckSales();
                    }
                }
            }
        }
    }
}