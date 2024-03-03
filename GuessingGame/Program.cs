// See https://aka.ms/new-console-template for more information
using GuessingGame;

GuessingMenu  guessingMenu = new GuessingMenu();
Console.Clear();
Console.WriteLine("Welcome to the guessing game");
Console.Write("What is your name? ");
string? user = Console.ReadLine();
guessingMenu.MainMenu(user);


