namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Check Admission Eligibility");
                Console.WriteLine("2. Calculate Electricity Bill");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine()!); 

                switch (choice)
                {
                    case 1:
                        CheckAdmissionEligibility();
                        break;

                    case 2:
                        CalculateElectricityBill();
                        break;

                    case 0:
                        Console.WriteLine("Exiting the program. Thank you!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 0);
        }

        static void CheckAdmissionEligibility()
        {
            int physics, chemistry, maths, total, mathPhyTotal;

            Console.Write("Enter marks in Physics: ");
            physics = Convert.ToInt32(Console.ReadLine()!);

            Console.Write("Enter marks in Chemistry: ");
            chemistry = Convert.ToInt32(Console.ReadLine()!);

            Console.Write("Enter marks in Mathematics: ");
            maths = Convert.ToInt32(Console.ReadLine()!);

            total = physics + chemistry + maths;
            mathPhyTotal = maths + physics;

            if (maths >= 65 && physics >= 55 && chemistry >= 50 && (total >= 180 || mathPhyTotal >= 140))
            {
                    Console.WriteLine("The candidate is eligible for admission.");
                }
                else
                {
                    Console.WriteLine("The candidate is not eligible for admission.");
                }
            }
            
        static void CalculateElectricityBill()
        {
            int customerId, units;
            string customerName;
            double amount, chargePerUnit, surcharge = 0, netAmount;

            Console.Write("Enter Customer ID: ");
            customerId = Convert.ToInt32(Console.ReadLine()!);

            Console.Write("Enter Customer Name: ");
            customerName = Console.ReadLine()!;

            Console.Write("Enter Units Consumed: ");
            units = Convert.ToInt32(Console.ReadLine()!);

            if (units < 200)
                chargePerUnit = 1.20;
            else if (units < 400)
                chargePerUnit = 1.50;
            else if (units < 600)
                chargePerUnit = 1.80;
            else
                chargePerUnit = 2.00;

            amount = units * chargePerUnit;

            if (amount > 400)
            {
                surcharge = amount * 0.15;
            }

            netAmount = amount + surcharge;

            if (netAmount < 100)
            {
                netAmount = 100;
            }

            Console.WriteLine("\n--- Electricity Bill ---");
            Console.WriteLine("Customer IDNO       : " + customerId);
            Console.WriteLine("Customer Name       : " + customerName);
            Console.WriteLine("Units Consumed      : " + units);
            Console.WriteLine("Amount @ Rs. " + chargePerUnit + " per unit: " + amount.ToString("0.00"));
            Console.WriteLine("Surcharge Amount    : " + surcharge.ToString("0.00"));
            Console.WriteLine("Net Amount to Pay   : " + netAmount.ToString("0.00"));
        }
    }
}
