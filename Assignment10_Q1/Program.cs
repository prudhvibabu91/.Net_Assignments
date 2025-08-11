using System;

namespace Assignment10_Q1
{
    public class Operations
    {
        public void Sum(params int[] numbers)
        {
            int total = 0;
            foreach (int num in numbers)
                total += num;
            Console.WriteLine("Sum: " + total);
        }

        public void Subtract(int a, int b)
        {
            Console.WriteLine("Subtract: " + (a - b));
        }

        public void Product(params int[] numbers)
        {
            int result = 1;
            foreach (int num in numbers)
                result *= num;
            Console.WriteLine("Product: " + result);
        }

        public void Min(params int[] numbers)
        {
            int min = numbers[0];
            foreach (int num in numbers)
                if (num < min)
                    min = num;
            Console.WriteLine("Min: " + min);
        }

        public void Max(params int[] numbers)
        {
            int max = numbers[0];
            foreach (int num in numbers)
                if (num > max)
                    max = num;
            Console.WriteLine("Max: " + max);
        }

        public void IsEven(int number)
        {
            if (number % 2 == 0)
                Console.WriteLine("Even");
            else
                Console.WriteLine("Not Even");
        }

        public void IsOdd(int number)
        {
            if (number % 2 != 0)
                Console.WriteLine("Odd");
            else
                Console.WriteLine("Not Odd");
        }

        public void IsPrime(int number)
        {
            if (number < 2)
            {
                Console.WriteLine("Not Prime");
                return;
            }

            bool prime = true;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    prime = false;
                    break;
                }
            }

            Console.WriteLine(prime ? "Prime" : "Not Prime");
        }
    }

    public static class OperationExtensions
    {
        public static void DisplayEvenInRange(this Operations op, int start, int end)
        {
            Console.WriteLine("Even Numbers:");
            for (int i = start; i <= end; i++)
                if (i % 2 == 0)
                    Console.Write(i + " ");
            Console.WriteLine();
        }

        public static void DisplayOddInRange(this Operations op, int start, int end)
        {
            Console.WriteLine("Odd Numbers:");
            for (int i = start; i <= end; i++)
                if (i % 2 != 0)
                    Console.Write(i + " ");
            Console.WriteLine();
        }

        public static void DisplayPrimeInRange(this Operations op, int start, int end)
        {
            Console.WriteLine("Prime Numbers:");
            for (int i = start; i <= end; i++)
            {
                if (i < 2) continue;
                bool prime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                    if (i % j == 0)
                    {
                        prime = false;
                        break;
                    }
                if (prime) Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static void DisplayTable(this Operations op, int number)
        {
            for (int i = 1; i <= 10; i++)
                Console.WriteLine(number + " x " + i + " = " + (number * i));
        }

        public static void DisplayTables1To10InRange(this Operations op, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine("Table of " + i);
                op.DisplayTable(i);
            }
        }

        public static void ReverseNumber(this Operations op, int number)
        {
            int reversed = 0;
            int n = number;
            while (n > 0)
            {
                reversed = reversed * 10 + n % 10;
                n = n / 10;
            }
            Console.WriteLine("Reversed: " + reversed);
        }

        public static void DisplayTablesInRange(this Operations op, int from, int to, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine("Table of " + i + " from " + from + " to " + to);
                for (int j = from; j <= to; j++)
                    Console.WriteLine(i + " x " + j + " = " + (i * j));
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Operations op = new Operations();

            // Normal methods
            op.Sum(1, 2, 3, 4);
            op.Subtract(10, 4);
            op.Product(2, 3, 4);
            op.Min(3, 5, 1, 9);
            op.Max(3, 5, 1, 9);
            op.IsEven(6);
            op.IsOdd(7);
            op.IsPrime(11);

            // Extension methods on Operations
            op.DisplayEvenInRange(1, 10);
            op.DisplayOddInRange(1, 10);
            op.DisplayPrimeInRange(1, 20);
            op.DisplayTable(5);
            op.DisplayTables1To10InRange(2, 4);
            op.DisplayTablesInRange(3, 5, 2, 3);
            op.ReverseNumber(12345);
        }
    }
}
