using System;
using System.Collections.Generic;

namespace InventorySystem
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public void Display()
        {
            Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Qty: {Quantity}, Price: ${Price}");
        }
    }

    class Program
    {
        
        static Dictionary<int, Product> inventory = new Dictionary<int, Product>();

        static void Main(string[] args)
        {

            AddProduct(1, "Laptop", 10, 1200);
            AddProduct(2, "Mouse", 50, 25);
            AddProduct(3, "Keyboard", 30, 45);
            DisplayAll();

            UpdateProduct(2, 100, 25);

            DeleteProduct(3);

            Console.WriteLine("\nUpdated Inventory:");
            DisplayAll();
        }

        static void AddProduct(int id, string name, int qty, decimal price)
        {
            if (!inventory.ContainsKey(id))
            {
                Product newProduct = new Product()
                {
                    ProductId = id,
                    ProductName = name,
                    Quantity = qty,
                    Price = price
                };
                inventory[id] = newProduct;
                Console.WriteLine($"Product added: {name}");
            }
            else
            {
                Console.WriteLine("Product ID already exists.");
            }
        }

        static void UpdateProduct(int id, int newQty, decimal newPrice)
        {
            if (inventory.ContainsKey(id))
            {
                inventory[id].Quantity = newQty;
                inventory[id].Price = newPrice;
                Console.WriteLine($"Product updated: {inventory[id].ProductName}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void DeleteProduct(int id)
        {
            if (inventory.ContainsKey(id))
            {
                Console.WriteLine($"Product deleted: {inventory[id].ProductName}");
                inventory.Remove(id);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void DisplayAll()
        {
            foreach (var product in inventory.Values)
            {
                product.Display();
            }
        }
    }
}
