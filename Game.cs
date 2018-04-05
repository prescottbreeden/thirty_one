using System;
using System.Collections.Generic;
using System.Linq;

namespace thirty_one
{
    public class Game
    {
        public static List<Player> Players = new List<Player>();
        public static int TokenPot;
        public static int total_players = 4;
        public static int size_of_hand = 3;
        public static int turn_counter;
        public static int next_turn;
        
        public static void CreateGame()
        {
            for(var i = 1; i <= total_players; i++)
            {
                Players.Add(new Player($"Computer {i}"));
                System.Console.WriteLine($"Making Player: Computer {i}");
            }
            
            // Place players at table
            for(var i = 0; i < Players.Count; i++)
                Players[i].player_seat = i+1;
            
            // Set first dealer
            Players[0].isDealer = true;

            // player to left of dealer starts (player 2)
            next_turn = 2;

            //Build deck
            Deck current_deck = new Deck();
            current_deck.Shuffle();
            System.Console.WriteLine("Deck Shuffled");

            // set turns to zero
            turn_counter = 0;

            //Deal 3 cards to each player
            for(var i = 0; i < size_of_hand; i++)
            {
                foreach (Player player in Players)
                    Deck.DrawFromDeck(player);
            }
        }
        public static void PrintAllHands()
        {
            foreach (Player player in Players)
            {
                System.Console.WriteLine($"{player.name}'s initial hand: ");
                for (var i = 0; i < player.hand.Count; i++)
                    System.Console.WriteLine(player.hand[i]);
            }
        }
        public static void PrintAllHandValues()
        {
            foreach (Player player in Players)
            {
                Player.CalculateHandValue(player);
                System.Console.WriteLine($"{player.name} has hand value of {player.hand_value}");
            }
        }

        public static void NextTurn()
        {
            var current_player_turn = Players[next_turn-1];
            Deck.DrawFromDeck(current_player_turn);
            System.Console.WriteLine(current_player_turn);
            System.Console.WriteLine(current_player_turn.hand_value);

        }
    }
}