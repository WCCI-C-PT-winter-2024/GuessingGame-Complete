using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    internal class ZingBot
    {
        // Modify these values to control range and guess amount
        private const int START_RANGE = 0;
        private const int END_RANGE = 500;
        private const int GUESSES = 20;

        // The number picked by the user
        private int Picked = 0;
        private int toGuess = 0;
        // The current range
        private int Min = START_RANGE;
        private int Max = END_RANGE;

        // The winning flag
        private bool Won = false;

        //players name
        private string user;

        private string Name { get; set; } = "Zing Bot ";

        public delegate void AddScore(bool isHumanWinner);
        public event AddScore OnAddScore;

        /// <summary>
        /// Default constructor 
        /// </summary>
        /// <param name="user"></param>
        public ZingBot(string user)
        {
            this.user = user;
        }



        /// <summary>
        /// AI game play
        /// </summary>
        public void StartGame()
        {
            Console.Clear();
            ResetGame();
            Console.WriteLine($"Hello,{this.user} my name is {this.Name}\n");
            Console.WriteLine($"Welcome to the Guessing Game.");
            Console.WriteLine($"I bet if you picked a number between {START_RANGE} and {END_RANGE}");
            Console.WriteLine($"I could guess what number you picked within {GUESSES} guesses.");
            Console.WriteLine($"Can you guess the number before me?");
            Console.WriteLine($"Pick a number between {START_RANGE} - {END_RANGE}");

            // For as many guess are allowed
            for (int i = 0; i < GUESSES; i++)
            {
                int attempt = (i + 1);
                Console.WriteLine();
                Console.WriteLine();
                Console.Write($" Attempt number {attempt}: ");
                Picked = PickANumber();

                // Method that compares guess and determines if the value is higher or lower
                if (!Confirm(attempt))
                {
                    break;
                }

                // If the guess was successful max out attempts
                if (Won)
                {
                    AIBotLoses();
                    break;
                }
            }
            if (!Won)
            {
                AIBotWins();
            }
        }

     /// <summary>
     /// Check the values
     /// </summary>
     /// <param name="attempt"></param>
     /// <returns></returns>
        public bool Confirm(int attempt)
        {
            int guess = AITurn(attempt);
            if (guess < 0)
            {
                return false;
            }

            Console.WriteLine($"{Name} Guess #" + attempt + ": " + guess);

            if (toGuess < Picked)
            {
                Console.Write("Your guess was high");
            }
            else if (toGuess > Picked)
            {
                Console.Write("Your Guess was low");
            }
            else if (toGuess == Picked)
            {
                Console.WriteLine("You win");
                Won = true;
            }
            return true;
        }

        /// <summary>
        /// AI's turn
        /// </summary>
        /// <param name="attempt"></param>
        /// <returns>if < 0 AI has won </returns>
        private int AITurn(int attempt)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            int guess = rnd.Next(Min, Max);
            if (guess == toGuess) // AI guessed right
            {
                Console.WriteLine($"{Name} wins with only {attempt} tries, better luck next time");
                guess = -1;
            }
            else if (guess <= toGuess) // AI guess is less then toGuess number
            {
                int diff = (toGuess - guess) / 2;
                Min = guess + diff;
            }
            else if (guess >= toGuess) // AI guess is greater then toGuess number
            {
                int diff = (guess - toGuess) / 2;
                Max = guess - diff;
            }
            return guess;
        }

        /// <summary>
        /// Bot wins
        /// </summary>
        private void AIBotWins()
        {
            Console.WriteLine("Hahahaha! You lost to a BASIC AI like myself... wait why does that seem like a burn on me?\n");
            Console.ReadLine();
            if (OnAddScore != null)
            {
                OnAddScore(false);
            }
        }

        /// <summary>
        /// Bot Loses
        /// </summary>
        private void AIBotLoses()
        {
            Console.WriteLine("OK, OK, so you outsmarted a limited AI, I hope you're happy with yourself.\n");
            Console.ReadLine();
            if (OnAddScore != null)
            {
                OnAddScore(true);
            }
        }

        /// <summary>
        /// Reset the game
        /// </summary>
        private void ResetGame()
        {
            Min = START_RANGE;
            Max = END_RANGE;
            Won = false;
            var rnd = new Random(DateTime.Now.Millisecond);
            toGuess = rnd.Next(Min, Max);

        }

        /// <summary>
        /// Get a valid user pick
        /// </summary>
        /// <returns>int</returns>
        private int PickANumber()
        {
            int returnValue = 0;

            while (returnValue <= 0)
            {
                Console.Write(" Pick a number? ");
                if (!int.TryParse(Console.ReadLine(), out returnValue))
                {
                    Console.WriteLine("\nInvalid number. Pick again!");
                    returnValue = 0;
                }
                if (returnValue > END_RANGE || returnValue < START_RANGE)
                {
                    Console.WriteLine("\nNo fair, you're picking outside of the designated range. Pick again!");
                    returnValue = 0;
                }
            }
            return returnValue;
        }


    }
}
