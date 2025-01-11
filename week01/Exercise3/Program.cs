using System;

class Program
{
    static void Main(string[] args)
    {
        string answer = "y";

        while (answer == "y") {
            int magicNumber = new Random().Next(1, 100);
            int guess = 0;
            int attempts = 0;

            while (guess != magicNumber) {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (guess < magicNumber) {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber) {
                    Console.WriteLine("Lower");
                }
            }
            Console.WriteLine($"You guessed it in {attempts} tries"); 

            Console.Write("Do you want to play again? (y/n) ");
            answer = Console.ReadLine().ToLower();  
        }
        Console.WriteLine("Goodbye!");
    }
}