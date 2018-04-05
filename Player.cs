using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Player
    {
        public string name;
        public int score;
        public List<Card> hand = new List<Card>();

        public Player(string name)
        {
            this.name = name;
            this.score = 0;
        }
        public void DrawCard(Deck obj)
        {
            hand.Add(obj.DealCard(1));
        }
        public object PlayCard()
        {
            return this.hand[0];

        }    
    }
}