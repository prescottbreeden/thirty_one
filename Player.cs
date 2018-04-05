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
        public void DrawCard(Player player, Deck obj)
        {
            player.hand.Add(obj.DrawCard(1));
        }
        public void DiscardCard(Player player)
        {
            Deck.DiscardPile.Add(player.hand[0]);
        }
    }
}