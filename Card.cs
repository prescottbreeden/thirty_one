using System;
using System.Collections.Generic;

namespace thirty_one
{
    public class Card
    {
        public string face;
        public string suit;
        public int value;
        public Card(string face, string suit, int value)
        {
            this.face = face;
            this.suit = suit;
            this.value = value;
        }
        public override string ToString()
        {
            return face + " of " + suit;
        }    
    }
    
}