using System;
using System.Collections.Generic;
using Assignment3;

namespace Assignment3
{
    class Program
    {
        static void Main()
        {
            List<Product> products = new List<Product>();
            List<Product> orderedProducts = new List<Product>();

            while (true)
            {
                Console.WriteLine("\n---- LOGIN DETAILS ----");
                Console.WriteLine("1. Admin login\n2. Customer login\n3. Exit");
                Console.Write("Enter choice: ");
                int role = int.Parse(Console.ReadLine()!);

                if (role == 1)
                {
                    Console.WriteLine("\n1. Add Product\n2. Display Products");
                    Console.Write("Enter choice: ");
                    int adminChoice = int.Parse(Console.ReadLine()!);

                    if (adminChoice == 1)
                    {
                        Console.Write("Enter Product Code: ");
                        int code = int.Parse(Console.ReadLine()!);
                        Product p = new Product(code);
                        p.GetDetailsFromAdmin();
                        products.Add(p);
                    }
                    else if (adminChoice == 2)
                    {
                        foreach (var p in products)
                            p.DisplayProduct();
                    }
                }
                else if (role == 2)
                {
                    Console.Write("How many products you want to order? ");
                    int count = int.Parse(Console.ReadLine()!);

                    for (int i = 0; i < count; i++)
                    {
                        Console.Write("Enter Product Name to order: ");
                        string name = Console.ReadLine()!;
                        var found = products.Find(p => p.MatchName(name));
                        if (found != null && found.OrderProduct())
                        {
                            orderedProducts.Add(found);
                        }
                    }

                    // Generate Bill
                    Console.WriteLine("\n============================= BILL =============================");
                    Console.WriteLine("{0,-7} {1,-15} {2,-15} {3,-5} {4,-10} {5,-10} {6,-10}",
    "PCode", "PName", "Brand", "Qty", "Price", "Discount", "Total");
                    Console.WriteLine(new string('-', 85));

                    float grandTotal = 0;
                    bool isFestival = (DateTime.Today.Day == 26 && DateTime.Today.Month == 1);

                    foreach (var product in orderedProducts)
                    {
                        float price = product.Price;
                        int qty = product.OrderedQty;
                        float total = price * qty;

                        float discountPercent = isFestival ? 50 : product.Discount;
                        float discountAmount = total * discountPercent / 100;
                        float finalAmount = total - discountAmount;

                        Console.WriteLine("{0,-7} {1,-15} {2,-15} {3,-5} {4,-10} {5,-10} {6,-10}",
                            product.PCode, product.PName, product.Brand,
                            qty, $"Rs.{price:F2}", $"{discountPercent:0}%", $"Rs.{finalAmount:F2}");

                        grandTotal += finalAmount;
                    }

                    Console.WriteLine(new string('-', 85));
                    Console.WriteLine("{0,65} {1,-10}", "Grand Total:", $"Rs.{grandTotal:F2}");
                }
            }
        }
    }
}
                