using System;

class Program
{
    static void Main(string[] args)
    {
  
        // Order 1

        Address address1 = new Address(
            "123 Main Street",
            "Seattle",
            "Washington",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Product product1 = new Product(
            "Laptop",
            "L100",
            899.99,
            1
        );

        Product product2 = new Product(
            "Wireless Mouse",
            "M200",
            25.50,
            2
        );

        Product product3 = new Product(
            "Keyboard",
            "K300",
            45.00,
            1
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Order 2

        Address address2 = new Address(
            "Rua das Flores, 456",
            "Natal",
            "Rio Grande do Norte",
            "Brazil"
        );

        Customer customer2 = new Customer(
            "Maria Silva",
            address2
        );

        Product product4 = new Product(
            "Headphones",
            "H400",
            75.00,
            1
        );

        Product product5 = new Product(
            "USB Cable",
            "U500",
            10.00,
            3
        );

        Product product6 = new Product(
            "Webcam",
            "W600",
            60.00,
            1
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        // Order 1 display

        Console.WriteLine("==============================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("==============================");

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");

        // Order 2 display

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("==============================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("==============================");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
