using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

public class Cart
{
    public void AddProduct(List<Product> products, Product product)
    {
        products.Add(product);
        Console.WriteLine($"{product.Name} added to cart at PKR {product.Price}.");
    }

    public void RemoveProduct(List<Product> products, string productName)
    {
        Product productToRemove = products.Find(p => p.Name == productName);
        if (productToRemove != null)
        {
            products.Remove(productToRemove);
            Console.WriteLine($"{productName} removed from cart.");
        }
        else
        {
            Console.WriteLine($"{productName} not found in cart.");
        }
    }

    public void ViewCart(List<Product> products)
    {
        Console.WriteLine("\nShopping Cart:");
        if (products.Count == 0)
        {
            Console.WriteLine("Cart is empty.");
            return;
        }

        decimal total = 0;
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name}: PKR {product.Price}");
            total += product.Price;
        }
        Console.WriteLine($"Total Cost: PKR {total}\n");
    }

    public void Checkout(List<Product> products)
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Your cart is empty. Please add products before checking out.");
            return;
        }
        Console.WriteLine("Proceeding to checkout...");
        Console.WriteLine($"Total Amount Due: PKR {CalculateTotal(products)}");
    }

    private decimal CalculateTotal(List<Product> products)
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.Price;
        }
        return total;
    }
}

class Program
{
    static void Main()
    {
        Cart cart = new Cart();
        List<Product> products = new List<Product>();
        bool running = true;

        // Display a welcome message with a decorative border
        Console.WriteLine("**********************************************");
        Console.WriteLine("             WELCOME TO THE CART             ");
        Console.WriteLine("**********************************************\n");

        while (running)
        {
            // Display a bordered menu with centered options
            Console.WriteLine("**********************************************");
            Console.WriteLine("               Select an Option               ");
            Console.WriteLine("**********************************************");
            Console.WriteLine("               1. Add Product                 ");
            Console.WriteLine("               2. Remove Product              ");
            Console.WriteLine("               3. View Cart                   ");
            Console.WriteLine("               4. Checkout                    ");
            Console.WriteLine("               5. Exit                        ");
            Console.WriteLine("**********************************************");
            Console.Write("               Your Choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine("**********************************************\n");

            switch (choice)
            {
                case "1":
                    Console.Write("\nEnter product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter product price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    cart.AddProduct(products, new Product(name, price));
                    break;
                case "2":
                    Console.Write("\nEnter product name to remove: ");
                    string productName = Console.ReadLine();
                    cart.RemoveProduct(products, productName);
                    break;
                case "3":
                    cart.ViewCart(products);
                    break;
                case "4":
                    cart.Checkout(products);
                    running = false; // Exit after checkout
                    break;
                case "5":
                    Console.WriteLine("\nThank you for visiting! Have a great day!");
                    running = false; // Exit program
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}