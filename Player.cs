using System;
using System.Collections.Generic;

namespace thirty_one
{
    public class Player
    {
        public string name;
        public int tokens;
        public List<Card> hand = new List<Card>();

        public Player(string name)
        {
            this.name = name;
            this.tokens = 3;
        }
        public static void DrawCardDeck(Player player, Deck obj) => player.hand.Add(obj.DrawFromDeck(1));
        public static void DrawCardDiscard(Player player, Deck obj) => obj.DrawFromDiscard(player);
        public static void DiscardCard(Player player, int choice) => Deck.discard_pile.Add(player.hand[choice]);
    }
}