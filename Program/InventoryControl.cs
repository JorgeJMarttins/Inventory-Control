using System;
using System.Collections.Generic;

class InventoryControl
{
    // Class to represent a product in the inventory
    class Product
    {
        // Properties to hold the product's name, quantity, and price
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Constructor to initialize the product with name, quantity, and price
        public Product(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }

    // List to store the products in memory
    static List<Product> inventory = new List<Product>();

    static void Main()
    {
        // Main loop of the application that keeps the program running
        while (true)
        {
            // Display the menu options for the user
            Console.WriteLine("\n----- Inventory Control -----");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. List Products");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            // Read the user's input
            string option = Console.ReadLine();

            // Switch case to handle the user's chosen option
            switch (option)
            {
                case "1":
                    // Call AddProduct method to add a product to the inventory
                    AddProduct();
                    break;
                case "2":
                    // Call ListProducts method to list all products in the inventory
                    ListProducts();
                    break;
                case "3":
                    // Call EditProduct method to modify an existing product's details
                    EditProduct();
                    break;
                case "4":
                    // Call RemoveProduct method to remove a product from the inventory
                    RemoveProduct();
                    break;
                case "5":
                    // Exit the program
                    Console.WriteLine("Exiting...");
                    return; // Exit the program loop
                default:
                    // Handle invalid options
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Function to add a product to the inventory
    static void AddProduct()
    {
        // Ask the user for the product name
        Console.Write("Enter the product name: ");
        string name = Console.ReadLine();

        // Ask the user for the quantity of the product
        Console.Write("Enter the quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        // Ask the user for the price of the product
        Console.Write("Enter the product price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        // Create a new product object with the provided details
        Product product = new Product(name, quantity, price);
        
        // Add the new product to the inventory list
        inventory.Add(product);
        
        // Confirm that the product was added successfully
        Console.WriteLine("Product added successfully.");
    }

    // Function to list all products in the inventory
    static void ListProducts()
    {
        // Check if there are any products in the inventory
        if (inventory.Count == 0)
        {
            // Inform the user if the inventory is empty
            Console.WriteLine("No products in the inventory.");
        }
        else
        {
            // Display the details of each product in the inventory
            Console.WriteLine("\nProducts in the Inventory:");
            foreach (var product in inventory)
            {
                // Print the product's name, quantity, and price
                Console.WriteLine($"Name: {product.Name}, Quantity: {product.Quantity}, Price: ${product.Price}");
            }
        }
    }

    // Function to edit the details of a product in the inventory
    static void EditProduct()
    {
        // List all products before editing
        ListProducts();
        
        // Ask the user for the product name they wish to edit
        Console.Write("Enter the name of the product you want to edit: ");
        string name = Console.ReadLine();

        // Search for the product by name, ignoring case
        var product = inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        
        // If the product is found, allow the user to edit its details
        if (product != null)
        {
            // Ask for the new quantity
            Console.Write("Enter the new quantity: ");
            product.Quantity = int.Parse(Console.ReadLine());

            // Ask for the new price
            Console.Write("Enter the new price: ");
            product.Price = decimal.Parse(Console.ReadLine());

            // Confirm that the product was edited successfully
            Console.WriteLine("Product edited successfully.");
        }
        else
        {
            // If the product was not found, inform the user
            Console.WriteLine("Product not found.");
        }
    }

    // Function to remove a product from the inventory
    static void RemoveProduct()
    {
        // List all products before removing one
        ListProducts();
        
        // Ask the user for the product name they want to remove
        Console.Write("Enter the name of the product you want to remove: ");
        string name = Console.ReadLine();

        // Search for the product by name, ignoring case
        var product = inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        
        // If the product is found, remove it from the inventory
        if (product != null)
        {
            // Remove the product from the list
            inventory.Remove(product);
            // Confirm that the product was removed successfully
            Console.WriteLine("Product removed successfully.");
        }
        else
        {
            // If the product was not found, inform the user
            Console.WriteLine("Product not found.");
        }
    }
}
