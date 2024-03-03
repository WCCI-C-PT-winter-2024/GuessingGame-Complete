using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    /// <summary>
    /// Guessing Game Code
    /// </summary>
    internal class Guessing
    {
        private const int MaxAttempts = 12;
        private const int Min = 1;
        private const int Max = 100;
        private string user;
        private int toGuess;
        private bool exitGame = false;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="user"></param>
        public Guessing(string user)
        {
            this.user = user;
            var rnd = new Random(DateTime.Now.Millisecond);
            this.toGuess = rnd.Next(Min, Max);
            OpenGame();
        }

        private void OpenGame()
        {
            Console.Clear();
            Console.WriteLine($"Can you guess the number I am thinking of.");
            Console.WriteLine($"{this.user}, you have {MaxAttempts} trys to guess the number between {Min} and {Max}.");
        }

        /// <summary>
        /// Gets the number from the user
        /// </summary>
        /// <returns></returns>
        private int GetNumber()
        {
            while (true)
            {
                int userGuess = -1;
                // Get a guess
                Console.Write($"What is you guess? ");
                string? guess = Console.ReadLine();
                if (guess == null || string.IsNullOrEmpty(guess))
                {
                    return -1;                 
                }
                //See if the key pressed is a number
                if (!int.TryParse(guess, out userGuess))
                {
                    Console.WriteLine("Invalid response.");
                    Console.WriteLine($"Please pick a number between {Min} and {Max}");
                    Console.WriteLine();
                    continue;
                }
                return userGuess;
            }
        }

        /// <summary>
        /// Main game loop
        /// </summary>
        public void Play()
        {
          
            /// you only have so many turns to get the correct answer
            for (int i = 0; i < MaxAttempts; i++)
            {
                Console.WriteLine();
                int userGuess = -1;
                while (!exitGame)
                {
                  userGuess = GetNumber();
                    if(userGuess < 0)
                    {
                        exitGame = true;
                        i = MaxAttempts;
                        break;

                    }

                    if (!exitGame && userGuess == toGuess)
                    {
                        Console.WriteLine("You Win");
                        Console.WriteLine("Press any key to return to the menu");
                        Console.ReadLine();
                        i = MaxAttempts;
                        break;
                    }else if (userGuess <= toGuess)
                    {
                        Console.WriteLine($"{user} your answer was too low");
                        continue;
                    }
                    else if (userGuess >= toGuess)
                    {
                        Console.WriteLine($"{user} your answer was too high");
                        continue;
                    }
                    break;
                }
            }
            if(exitGame)
            {
                Console.WriteLine("Sorry but you lose");
                Console.ReadLine();
            }

        }
    }
}
