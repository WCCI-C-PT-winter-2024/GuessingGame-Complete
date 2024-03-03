using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    internal class GuessingMenu
    {
        private int AiWins=0;
        private int humanWins=0;
        public void MainMenu(string user)
        {
            int value = 0;
            while (value == 0)
            {
                Console.Clear();
                Console.WriteLine($"Human wins {humanWins}, AI wins {AiWins}");
                Console.WriteLine();
                                Console.WriteLine("Game Menu");
                Console.WriteLine();
                Console.WriteLine("1. Guess the Number");
                Console.WriteLine("2. Beat the AI");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Select option? ");
                string? option = Console.ReadLine();
                if (!int.TryParse(option, out value))
                {
                    value = 0;
                    Console.WriteLine($"Invalid reponse, try again");
                }
                if (value == 3)
                {
                    break;
                } else if (value == 2)
                {
                    PlayAI(user);
                }
                else if (value == 1)
                {
                    PlayGame(user);
                }
                value = 0;
            }
            Console.WriteLine("Thank you for using the We Can Code It Guessing Game application.");
            Console.WriteLine("Press any key to close this console window.");
            Console.ReadKey();
        }

        private void PlayGame(string user)
        {
            Guessing game = new Guessing(user);
            game.Play();
        }
        private void PlayAI(string user)
        {
            ZingBot game = new ZingBot(user);
            game.OnAddScore += Game_OnAddScore;

            game.StartGame();

        }

        private void Game_OnAddScore(bool isHumanWinner)
        {
            if (isHumanWinner)
            {
                humanWins++;
            }
            else
            {
                AiWins++;
            }
        }
    }
}
  

