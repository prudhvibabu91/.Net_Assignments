using System;

namespace Assignment4
{
    public class Product
    {
        private int pcode;
        private string pname;
        private string brand;
        private byte qty_in_stock;
        private byte discount_allowed;
        private float price;

        public int PCode => pcode;
        public string PName => pname;
        public string Brand => brand;
        public float Price => price;
        public int OrderedQty { get; set; }
        public byte Discount => discount_allowed;

        public Product(int code, string name, string brand, byte stock, byte discount, float price)
        {
            this.pcode = code;
            this.pname = name;
            this.brand = brand;
            this.qty_in_stock = stock;
            this.discount_allowed = discount;
            this.price = price;
        }

        public Product(int code)
        {
            this.pcode = code;
            this.pname = "";
            this.brand = "";
        }

        public void GetDetailsFromAdmin()
        {
            Console.Write("Enter Product Name: ");
            pname = Console.ReadLine() ?? "";

            Console.Write("Enter Brand Name: ");
            brand = Console.ReadLine() ?? "";

            Console.Write("Enter Quantity in Stock: ");
            qty_in_stock = byte.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Discount Allowed (%): ");
            discount_allowed = byte.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Product Price: ");
            price = float.Parse(Console.ReadLine() ?? "0");
        }

        public void DisplayProduct()
        {
            Console.WriteLine($"PCode: {pcode}, PName: {pname}, Brand: {brand}, Stock: {qty_in_stock}, Discount: {discount_allowed}%, Price: Rs.{price:F2}");
        }

        public bool MatchName(string name)
        {
            return pname.Equals(name, StringComparison.OrdinalIgnoreCase);
        }

        public bool OrderProduct()
        {
            Console.WriteLine($"Available stock for {pname}: {qty_in_stock}");
            Console.Write("Enter quantity to purchase: ");
            int qty = int.Parse(Console.ReadLine() ?? "0");

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
