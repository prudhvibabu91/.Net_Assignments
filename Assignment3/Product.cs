using System;

namespace Assignment3
{
    public class Product
    {
        // Encapsulated Fields
        private int pcode;
        private string pname = string.Empty;
        private string brand = string.Empty;
        private byte qty_in_stock;
        private byte discount_allowed;
        private float price;

        // Properties
        public int PCode => pcode;
        public string PName => pname;
        public string Brand => brand;
        public float Price => price;
        public int OrderedQty { get; set; } = 0;
        public byte Discount => discount_allowed;

        // Constructor
        public Product(int code)
        {
            pcode = code;
        }

        // Admin Inputs
        public void GetDetailsFromAdmin()
        {
            Console.Write("Enter Product Name: ");
            pname = Console.ReadLine()!;

            Console.Write("Enter Brand Name: ");
            brand = Console.ReadLine()!;

            Console.Write("Enter Quantity in Stock: ");
            qty_in_stock = byte.Parse(Console.ReadLine()!);

            Console.Write("Enter Discount Allowed (%): ");
            discount_allowed = byte.Parse(Console.ReadLine()!);

            Console.Write("Enter Product Price: ");
            price = float.Parse(Console.ReadLine()!);
        }

        public void DisplayProduct()
        {
            Console.WriteLine($"PCode: {pcode}, PName: {pname}, Brand: {brand}, Stock: {qty_in_stock}, Discount: {discount_allowed}%, Price: Rs.{price:F2}");
        }

        public bool MatchName(string name) => pname.Equals(name, StringComparison.OrdinalIgnoreCase);

        public bool OrderProduct()
        {
            Console.WriteLine($"Available stock for {pname}: {qty_in_stock}");
            Console.Write("Enter quantity to purchase: ");
            int qty = int.Parse(Console.ReadLine()!);

            if (qty <= qty_in_stock)
            {
                OrderedQty = qty;
                qty_in_stock -= (byte)qty;
                return true;
            }
            else
            {
                Console.WriteLine("Not enough stock!");
                return false;
            }
        }
    }
}
