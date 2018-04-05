using System;
using System.Collections.Generic;

namespace thirty_one
{
    public class GameInit
    {
        public List<Player> Players = new List<Player>();
        public int TokenPot;
        public int total_players = 4;
        public int size_of_hand = 3;
        
        public GameInit()
        {
            for(var i = 1; i <= total_players; i++)
            {
                Players.Add(new Player($"Computer {i}"));
                System.Console.WriteLine($"Making Player: Computer {i}");
            }
            Deck deck1 = new Deck();
            deck1.Shuffle();
            System.Console.WriteLine("Deck Shuffled");
            for(var i = 0; i < size_of_hand; i++)
            {
                foreach (Player player in Players)
                    Player.DrawCardDeck(player, deck1);
            }
            foreach (Player player in Players)
            {
                System.Console.WriteLine($"{player.name}'s initial hand");
                for (var i = 0; i < player.hand.Count; i++)
                    System.Console.WriteLine(player.hand[i]);
            }



        }
    }
}