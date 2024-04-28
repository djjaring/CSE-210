using System;

class Program
{
    static void Main(string[] args)
 {
        string response;

        do
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101);
            int guess;
            int guessCount = 0;

            do
            {
                Console.Write("What is your guess? ");
                guess = Convert.ToInt32(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
            } while (guess != magicNumber);

            Console.WriteLine($"You guessed it! It took you {guessCount} guesses.");

            Console.Write("Do you want to play again? (yes/no): ");
            response = Console.ReadLine();
        } while (response.ToLower() == "yes");
    }
}