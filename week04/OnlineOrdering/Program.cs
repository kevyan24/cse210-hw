using System;

namespace OnlineOrdering  
{
  class Program
  {
    static void Main(string[] args) 
    {
      Address usaAddress = new Address("123 Main St", "Anytown", "CA", "USA");
      Address internationalAddress = new Address("456 Elm Ave", "London", "England", "UK");

      Customer usaCustomer = new Customer("John Doe", usaAddress);
      Customer internationalCustomer = new Customer("Jane Smith", internationalAddress);

      Product product1 = new Product("T-Shirt", 1, 10.00, 2);
      Product product2 = new Product("Mug", 2, 5.00, 3);
      Product product3 = new Product("Hat", 3, 15.00, 1);
      Product product4 = new Product("Socks", 4, 7.00, 4);

      Order order1 = new Order(usaCustomer);
      order1.AddProduct(product1);
      order1.AddProduct(product2);

      Order order2 = new Order(internationalCustomer);
      order2.AddProduct(product3);
      order2.AddProduct(product4);

      Console.WriteLine(order1.GetPackingLabel());
      Console.WriteLine(order1.GetShippingLabel());
      Console.WriteLine($"Order 1 Total Cost: ${order1.GetTotalCost():F2}\n");

      Console.WriteLine(order2.GetPackingLabel());
      Console.WriteLine(order2.GetShippingLabel());
      Console.WriteLine($"Order 2 Total Cost: ${order2.GetTotalCost():F2}");

      Console.ReadKey();
    }
  }
}