using System;
using System.Collections.Generic;

namespace thirty_one
{
    public class GameInit
    {
        public static int num_players;
        public static bool GameStatus;
        public static string choice;
        public static List<string> player_names = new List<string>();
        public static void GameInitialization()
        {
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("≈≈≈≈≈≈≈ Welcome to '31 by 3'! ≈≈≈≈≈≈≈");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("Copyright 2018© JP,LH,PB");
            System.Console.WriteLine("\v");
            System.Console.WriteLine("\v");
        }
        public static List<string> CreatePlayers()
        {
            System.Console.WriteLine("Select Number of Human Players");
            num_players = Int32.Parse(Console.ReadLine());
            for(var i = 0; i < num_players; i++)
            {
                System.Console.WriteLine($"Choose a name for player {i+1}");
                choice = Console.ReadLine();
                player_names.Add(choice);
            }
            return player_names;
        }
        public static void MainMenu()
        {
            System.Console.WriteLine("Would you like to play again?");
            System.Console.WriteLine("1. Yes.");
            System.Console.WriteLine("2. No, I hate fun.");
            choice = System.Console.ReadLine();
            switch(choice)
            {
                case "1":
                    GameInitialization();
                    break;
                case "2":
                    System.Console.WriteLine("Thanks for playing, grumpy-pants!");
                    break;
            }
        }
    }
    
}