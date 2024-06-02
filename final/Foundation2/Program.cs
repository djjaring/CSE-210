using System;
using System.Collections.Generic;

public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string Name { get => name; }
    public string ProductId { get => productId; }
    public decimal Price { get => price; }
    public int Quantity { get => quantity; }

    public decimal TotalCost()
    {
        return price * quantity;
    }

    public override string ToString()
    {
        return $"{name} (ID: {productId})";
    }
}

public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string Street { get => street; }
    public string City { get => city; }
    public string State { get => state; }
    public string Country { get => country; }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name { get => name; }
    public Address Address { get => address; }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public override string ToString()
    {
        return $"{name}\n{address}";
    }
}

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal TotalCost()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.TotalCost();
        }

        if (customer.IsInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string PackingLabel()
    {
        var label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += product + "\n";
        }

        return label;
    }

    public string ShippingLabel()
    {
        return $"Shipping Label:\n{customer}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create addresses
        var address1 = new Address("123 Apple St", "New York", "NY", "USA");
        var address2 = new Address("456 Orange Ave", "Toronto", "ON", "Canada");

        // Create customers
        var customer1 = new Customer("John Doe", address1);
        var customer2 = new Customer("Jane Smith", address2);

        // Create products
        var product1 = new Product("Laptop", "P001", 999.99m, 1);
        var product2 = new Product("Mouse", "P002", 19.99m, 2);
        var product3 = new Product("Keyboard", "P003", 49.99m, 1);
        var product4 = new Product("Monitor", "P004", 199.99m, 2);

        // Create orders
        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display order details
        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine($"Total Cost: {order1.TotalCost():C}\n");

        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"Total Cost: {order2.TotalCost():C}\n");
    }
}

