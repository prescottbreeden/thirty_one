using System;
using System.Collections.Generic;
using System.Linq;

namespace thirty_one
{
    public class Player
    {
        public string name;
        public int tokens;
        public List<Card> hand = new List<Card>();
        public bool isDealer;
        public int player_seat;
        public int hand_value;
        public int hearts_value {get; set; }
        public int clubs_value {get; set; }
        public int spades_value {get; set; }
        public int diamonds_value {get; set; }
        public int[] suit_values = new int[4];

        public Player(string name)
        {
            this.name = name;
            this.tokens = 3;
            this.isDealer = false;
        }

        public static void CalculateHandValue(Player player)
        {
            // build lists of each suit-type for each players hand - WORKING
            for (var i = 0; i < player.hand.Count; i++)
            {
                if (player.hand[i].suit == "Hearts")
                {
                    player.hearts_value += player.hand[i].value;
                    System.Console.WriteLine(player.hearts_value);
                }
                else if (player.hand[i].suit == "Diamonds")
                {
                    player.diamonds_value += player.hand[i].value;
                    System.Console.WriteLine(player.diamonds_value);
                }
                else if (player.hand[i].suit == "Spades")
                {
                    player.spades_value += player.hand[i].value;
                    System.Console.WriteLine(player.spades_value);
                }
                else if (player.hand[i].suit == "Clubs")
                {
                    player.clubs_value += player.hand[i].value;
                    System.Console.WriteLine(player.clubs_value);
                }
            }
            // find highest value suit - set to hand value of player - NOT WORKING
            player.suit_values[0] = player.hearts_value;
            player.suit_values[1] = player.diamonds_value;
            player.suit_values[2] = player.spades_value;
            player.suit_values[3] = player.clubs_value;
            player.hand_value = player.suit_values.Max();
        }

        public override string ToString()
        {
            return name + " in seat " + player_seat;
        }    
    }
}