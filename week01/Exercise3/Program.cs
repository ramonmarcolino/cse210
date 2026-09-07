using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        string playAgain = "yes";
        while (playAgain.ToLower() == "yes")
        {
            int magicNumber = randomGenerator.Next(1, 101);

            int userGuess = -1;
            int attempts = 1;

            while (userGuess != magicNumber)
            {
                Console.Write("Guess the number: ");
                userGuess = int.Parse(Console.ReadLine());


                if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"You guessed it! It took you {attempts} attempts!");
                }
                attempts = attempts + 1;
            }
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();
        }
        
        Console.WriteLine("Thanks for playing!");
    }
}
