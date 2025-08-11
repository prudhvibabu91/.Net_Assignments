using System;

class GuessingGame 
{
    static void Main(string[] args) 
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 10);
        Console.Write("Guess a number between 1 and 10: ");
        int guess = Convert.ToInt32(Console.ReadLine());

        if (guess == secretNumber) 
        {
            Console.WriteLine("You won!");
        } 
        else 
        {
            Console.WriteLine("Sorry, the number was " + secretNumber);
        }
    }
}
