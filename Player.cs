using System;
using System.Collections.Generic;
using System.Linq;

namespace thirty_one
{
    public class Player
    {
        public string name;
        public bool isHuman;
        public int tokens;
        public List<Card> hand = new List<Card>();
        public List<Card> hearts = new List<Card>();
        public List<Card> diamonds = new List<Card>();
        public List<Card> spades = new List<Card>();
        public List<Card> clubs = new List<Card>();
        public int[] num_suits = new int[4];
        public bool isDealer;
        public int player_seat;
        public int hand_value;
        public int hearts_value {get; set; }
        public int clubs_value {get; set; }
        public int spades_value {get; set; }
        public int diamonds_value {get; set; }
        public int[] suit_values = new int[4];
        public bool knocked;

        public Player(string name)
        {
            this.name = name;
            this.tokens = 3;
            this.isDealer = false;
            this.knocked = false;
        }

        public static void CalculateHandValue(Player player)
        {
            player.hearts_value = 0;
            player.diamonds_value = 0;
            player.spades_value = 0;
            player.clubs_value = 0;

            player.hearts.Clear();
            player.diamonds.Clear();
            player.spades.Clear();
            player.clubs.Clear();

            // build lists of each suit-type for each players hand - WORKING
            for (var i = 0; i < player.hand.Count; i++)
            {
                if (player.hand[i].suit == "Hearts")
                {
                    player.hearts.Add(player.hand[i]);
                    player.hearts_value += player.hand[i].value;
                }
                else if (player.hand[i].suit == "Diamonds")
                {
                    player.diamonds.Add(player.hand[i]);
                    player.diamonds_value += player.hand[i].value;
                }
                else if (player.hand[i].suit == "Spades")
                {
                    player.spades.Add(player.hand[i]);
                    player.spades_value += player.hand[i].value;                
                }
                else if (player.hand[i].suit == "Clubs")
                {
                    player.clubs.Add(player.hand[i]);
                    player.clubs_value += player.hand[i].value;                
                }
            }
            // find highest value suit - set to hand value of player - WORKING
            player.suit_values[0] = player.hearts_value;
            player.suit_values[1] = player.diamonds_value;
            player.suit_values[2] = player.spades_value;
            player.suit_values[3] = player.clubs_value;
            player.hand_value = player.suit_values.Max();

            player.num_suits[0] = player.hearts.Count;
            player.num_suits[1] = player.diamonds.Count;
            player.num_suits[2] = player.spades.Count;
            player.num_suits[3] = player.clubs.Count;
        } 
    }
}