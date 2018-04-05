using System;
using System.Collections.Generic;

namespace thirty_one
{
    public class Deck
    {
        public Card[] deck;
        public int currentCard;
        public const int NUMBER_OF_CARDS = 52;
        public static List<Card> DiscardPile = new List<Card>();
        public Random ranNum;

        public Deck()
        {
            string[] faces = {"Two", "Three", "Four", "Five", "Six", "Seven",
                            "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};
            string[] suits = {"Hearts", "Clubs", "Spades", "Diamonds"};
            int[] values = {2,3,4,5,6,7,8,9,10,11,12,13,14};
            deck = new Card[NUMBER_OF_CARDS];
            currentCard = 0;
            for(int count = 0; count < deck.Length; count++)
                deck[count] = new Card(faces[count % 13], suits[count / 13], values[count % 13]);

        }
        public void Shuffle()
        {
            currentCard = 0;
            for (int first = 0; first < deck.Length; first++)
            {
                int second = ranNum.Next(NUMBER_OF_CARDS);
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }
        public Card DrawCard(int num)
        {
            if (currentCard < NUMBER_OF_CARDS)
                return deck[currentCard++];
            else
                return null;
        }
            

    }
}