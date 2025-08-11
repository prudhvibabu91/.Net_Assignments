namespace Assignment7
{
    class Program
    {
        static void Main()
        {
            // List to store Pizza objects
            List<Pizza> pizzaOrders = new List<Pizza>();

            // Add sample records
            pizzaOrders.Add(new Pizza("Small", 1, 1, 1));
            pizzaOrders.Add(new Pizza("Medium", 2, 2, 1));
            pizzaOrders.Add(new Pizza("Large", 3, 3, 3));

            // Display records
            Console.WriteLine("Pizza Orders:");
            foreach (Pizza p in pizzaOrders)
            {
                Console.WriteLine(p.GetDescription());
            }
        }
    }
}
