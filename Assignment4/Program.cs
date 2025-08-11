namespace Assignment4;

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
            {
                new Product(101, "Mouse", "Dell", 20, 10, 799),
                new Product(102, "Keyboard", "Logitech", 15, 5, 1199),
                new Product(103, "Monitor", "Samsung", 10, 12, 8999),
                new Product(104, "Headset", "JBL", 18, 15, 2499),
                new Product(105, "USB Cable", "Belkin", 25, 0, 299)
            };

        while (true)
        {
            Console.WriteLine("\n---- LOGIN MENU ----");
            Console.WriteLine("1. Admin Login\n2. Customer Order\n3. Exit");
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\nADMIN MENU");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display All Products");
                Console.Write("Enter choice: ");
                string? adminChoice = Console.ReadLine();

                if (adminChoice == "1")
                {
                    Console.Write("Enter new product code: ");
                    int code = int.Parse(Console.ReadLine() ?? "0");
                    Product newProduct = new Product(code);
                    newProduct.GetDetailsFromAdmin();
                    products.Add(newProduct);
                    Console.WriteLine("Product added successfully.");
                }
                else if (adminChoice == "2")
                {
                    Console.WriteLine("\n=== Available Products ===");
                    foreach (Product p in products)
                        p.DisplayProduct();
                }
                else
                {
                    Console.WriteLine("Invalid admin option.");
                }
            }
            else if (choice == "2")
            {
                List<Product> orderedProducts = new List<Product>();

                Console.Write("Enter number of products to order: ");
                int count = int.Parse(Console.ReadLine() ?? "0");

                for (int i = 0; i < count; i++)
                {
                    Console.Write("Enter product name to order: ");
                    string? name = Console.ReadLine();
                    Product? found = products.Find(p => p.MatchName(name ?? ""));

                    if (found != null && found.OrderProduct())
                    {
                        orderedProducts.Add(found);
                    }
                    else
                    {
                        Console.WriteLine("Product not found or insufficient stock.");
                    }
                }

                if (orderedProducts.Count == 0)
                {
                    Console.WriteLine("No valid products ordered.");
                    continue;
                }

                // BILL SECTION
                Console.WriteLine("\n============================= BILL =============================");
                Console.WriteLine("{0,-7} {1,-15} {2,-15} {3,-5} {4,-12} {5,-10} {6,-12}",
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

                    Console.WriteLine("{0,-7} {1,-15} {2,-15} {3,-5} Rs.{4,-8:F2} {5,-9} Rs.{6,-10:F2}",
                        product.PCode, product.PName, product.Brand,
                        qty, price, $"{discountPercent}%", finalAmount);

                    grandTotal += finalAmount;
                }

                Console.WriteLine(new string('-', 85));
                Console.WriteLine("{0,65} Rs.{1,-10:F2}", "Grand Total:", grandTotal);
            }
        }
    }
}