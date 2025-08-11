using System;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Display Hello Message");
                Console.WriteLine("2. Perform Arithmetic Operations");
                Console.WriteLine("3. Calculator Based on Choice");
                Console.WriteLine("4. Display Your Name 10 Times");
                Console.WriteLine("5. Display Even Numbers (do-while, while, for)");
                Console.WriteLine("6. Display Odd Numbers (do-while, while, for)");
                Console.WriteLine("7. Display Table of a Number");
                Console.WriteLine("8. Display Numbers from 100 to 5 with Gap of 3");
                Console.WriteLine("9. Display Variables in One Line");
                Console.WriteLine("10. Display Variables in Separate Lines");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                string? choiceInput = Console.ReadLine();

                if (!int.TryParse(choiceInput, out choice))
                {
                    Console.WriteLine("Invalid choice input!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Hello!");
                        break;

                    case 2:
                        {
                            Console.Write("Enter first number: ");
                            string? aStr = Console.ReadLine();
                            Console.Write("Enter second number: ");
                            string? bStr = Console.ReadLine();

                            if (int.TryParse(aStr, out int a) && int.TryParse(bStr, out int b))
                            {
                                Console.WriteLine($"Addition: {a + b}");
                                Console.WriteLine($"Subtraction: {a - b}");
                                Console.WriteLine($"Product: {a * b}");
                                Console.WriteLine(b != 0 ? $"Quotient: {a / b}" : "Division by zero is not allowed.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid number input!");
                            }
                            break;
                        }

                    case 3:
                        {
                            Console.Write("Enter first number: ");
                            string? n1Str = Console.ReadLine();
                            Console.Write("Enter second number: ");
                            string? n2Str = Console.ReadLine();
                            Console.Write("Enter operation (1-Add, 2-Sub, 3-Mul, 4-Div): ");
                            string? opStr = Console.ReadLine();

                            if (int.TryParse(n1Str, out int n1) &&
                                int.TryParse(n2Str, out int n2) &&
                                int.TryParse(opStr, out int op))
                            {
                                switch (op)
                                {
                                    case 1: Console.WriteLine("Addition: " + (n1 + n2)); break;
                                    case 2: Console.WriteLine("Subtraction: " + (n1 - n2)); break;
                                    case 3: Console.WriteLine("Multiplication: " + (n1 * n2)); break;
                                    case 4:
                                        if (n2 != 0)
                                            Console.WriteLine("Division: " + (n1 / n2));
                                        else
                                            Console.WriteLine("Division by zero.");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid operation.");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                            break;
                        }

                    case 4:
                        {
                            Console.Write("Enter your name: ");
                            string? name = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(name))
                            {
                                for (int j = 1; j <= 10; j++)
                                    Console.WriteLine(name);
                            }
                            else
                            {
                                Console.WriteLine("Name cannot be empty.");
                            }
                            break;
                        }

                    case 5:
                        {
                            Console.Write("Enter upper limit for even numbers: ");
                            string? limitStr = Console.ReadLine();
                            if (int.TryParse(limitStr, out int limit))
                            {
                                Console.WriteLine("Even numbers using do-while:");
                                int j = 2;
                                do { Console.Write(j + " "); j += 2; } while (j <= limit);

                                Console.WriteLine("\nEven numbers using while:");
                                j = 2;
                                while (j <= limit) { Console.Write(j + " "); j += 2; }

                                Console.WriteLine("\nEven numbers using for:");
                                for (j = 2; j <= limit; j += 2)
                                    Console.Write(j + " ");
                            }
                            else
                            {
                                Console.WriteLine("Invalid number.");
                            }
                            break;
                        }

                    case 6:
                        {
                            Console.Write("Enter upper limit for odd numbers: ");
                            string? limitStr = Console.ReadLine();
                            if (int.TryParse(limitStr, out int limit))
                            {
                                Console.WriteLine("Odd numbers using do-while:");
                                int j = 1;
                                do { Console.Write(j + " "); j += 2; } while (j <= limit);

                                Console.WriteLine("\nOdd numbers using while:");
                                j = 1;
                                while (j <= limit) { Console.Write(j + " "); j += 2; }

                                Console.WriteLine("\nOdd numbers using for:");
                                for (j = 1; j <= limit; j += 2)
                                    Console.Write(j + " ");
                            }
                            else
                            {
                                Console.WriteLine("Invalid number.");
                            }
                            break;
                        }

                    case 7:
                        {
                            Console.Write("Enter number for table: ");
                            string? tableStr = Console.ReadLine();
                            if (int.TryParse(tableStr, out int table))
                            {
                                Console.WriteLine("Using for loop:");
                                for (int j = 1; j <= 10; j++)
                                    Console.WriteLine($"{table} x {j} = {table * j}");

                                Console.WriteLine("Using while loop:");
                                int j2 = 1;
                                while (j2 <= 10)
                                {
                                    Console.WriteLine($"{table} x {j2} = {table * j2}");
                                    j2++;
                                }

                                Console.WriteLine("Using do-while loop:");
                                int j3 = 1;
                                do
                                {
                                    Console.WriteLine($"{table} x {j3} = {table * j3}");
                                    j3++;
                                } while (j3 <= 10);
                            }
                            else
                            {
                                Console.WriteLine("Invalid number.");
                            }
                            break;
                        }

                    case 8:
                        {
                            Console.WriteLine("Numbers from 100 to 5 with gap of 3:");
                            for (int j = 100; j >= 5; j -= 3)
                                Console.Write(j + " ");
                            break;
                        }

                    case 9:
                        {
                            Console.Write("Enter 3 integers (space-separated): ");
                            string? input = Console.ReadLine();
                            if (input != null)
                            {
                                string[] parts = input.Split();
                                if (parts.Length == 3 &&
                                    int.TryParse(parts[0], out int x) &&
                                    int.TryParse(parts[1], out int y) &&
                                    int.TryParse(parts[2], out int z))
                                {
                                    Console.WriteLine($"Values in one line: {x}, {y}, {z}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid format.");
                                }
                            }
                            break;
                        }

                    case 10:
                        {
                            Console.Write("Enter 3 integers (space-separated): ");
                            string? input = Console.ReadLine();
                            if (input != null)
                            {
                                string[] parts = input.Split();
                                if (parts.Length == 3 &&
                                    int.TryParse(parts[0], out int p) &&
                                    int.TryParse(parts[1], out int q) &&
                                    int.TryParse(parts[2], out int r))
                                {
                                    Console.WriteLine("Values in separate lines:");
                                    Console.WriteLine(p);
                                    Console.WriteLine(q);
                                    Console.WriteLine(r);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid format.");
                                }
                            }
                            break;
                        }

                    case 0:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
