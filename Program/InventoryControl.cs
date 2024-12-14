using System;
using System.Collections.Generic;

class InventoryControl
{
    // Class to represent a product in the inventory
    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }

    // List to store the products
    static List<Product> inventory = new List<Product>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n----- Inventory Control -----");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. List Products");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    ListProducts();
                    break;
                case "3":
                    EditProduct();
                    break;
                case "4":
                    RemoveProduct();
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Function to add a product to the inventory
    static void AddProduct()
    {
        Console.Write("Enter the product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        Console.Write("Enter the product price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Product product = new Product(name, quantity, price);
        inventory.Add(product);
        Console.WriteLine("Product added successfully.");
    }

    // Function to list all products in the inventory
    static void ListProducts()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No products in the inventory.");
        }
        else
        {
            Console.WriteLine("\nProducts in the Inventory:");
            foreach (var product in inventory)
            {
                Console.WriteLine($"Name: {product.Name}, Quantity: {product.Quantity}, Price: ${product.Price}");
            }
        }
    }

    // Function to edit the details of a product
    static void EditProduct()
    {
        ListProducts();
        Console.Write("Enter the name of the product you want to edit: ");
        string name = Console.ReadLine();

        var product = inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product != null)
        {
            Console.Write("Enter the new quantity: ");
            product.Quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter the new price: ");
            product.Price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Product edited successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    // Function to remove a product from the inventory
    static void RemoveProduct()
    {
        ListProducts();
        Console.Write("Enter the name of the product you want to remove: ");
        string name = Console.ReadLine();

        var product = inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product != null)
        {
            inventory.Remove(product);
            Console.WriteLine("Product removed successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}
