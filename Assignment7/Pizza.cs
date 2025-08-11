using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    internal class Pizza
    {
        // Private instance variables
        private string size;
        private int cheeseToppings;
        private int pepperoniToppings;
        private int hamToppings;

        // Constructor
        public Pizza(string size, int cheeseToppings, int pepperoniToppings, int hamToppings)
        {
            this.size = size;
            this.cheeseToppings = cheeseToppings;
            this.pepperoniToppings = pepperoniToppings;
            this.hamToppings = hamToppings;
        }

        // Get and Set methods
        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public int CheeseToppings
        {
            get { return cheeseToppings; }
            set { cheeseToppings = value; }
        }

        public int PepperoniToppings
        {
            get { return pepperoniToppings; }
            set { pepperoniToppings = value; }
        }

        public int HamToppings
        {
            get { return hamToppings; }
            set { hamToppings = value; }
        }

        // calcCost method
        public double CalcCost()
        {
            int totalToppings = cheeseToppings + pepperoniToppings + hamToppings;
            double basePrice = 0;

            switch (size.ToLower())
            {
                case "small":
                    basePrice = 10;
                    break;
                case "medium":
                    basePrice = 12;
                    break;
                case "large":
                    basePrice = 14;
                    break;
                default:
                    Console.WriteLine("Invalid size. Setting base price to 0.");
                    basePrice = 0;
                    break;
            }

            return basePrice + (2 * totalToppings);
        }

        // getDescription method
        public string GetDescription()
        {
            return $"Size: {size}, Cheese: {cheeseToppings}, Pepperoni: {pepperoniToppings}, Ham: {hamToppings}, Total Cost: ${CalcCost()}";
        }
    }
}