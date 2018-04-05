using System;

namespace deck_of_cards
{
    public class Deck
    {
        private Card[] deck;
        private int currentCard;
        private const int NUMBER_OF_CARDS = 52;
        private Random ranNum;

        public Deck()
        {
            string[] faces = {"Two", "Three", "Four", "Five", "Six", "Seven",
                            "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};
            string[] suits = {"Hearts", "Clubs", "Spades", "Diamonds"};
            int[] values = {2,3,4,5,6,7,8,9,10,11,12,13,14};
            deck = new Card[NUMBER_OF_CARDS];
            currentCard = 0;
            ranNum = new Random();
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
        public Card DealCard(int num)
        {
            if (currentCard < NUMBER_OF_CARDS)
                return deck[currentCard++];
            else
                return null;
        }
        public void War(Player p1, Player p2)
        {
            System.Console.WriteLine("Prescott and Lawdog tie - WAR!!");
            for(var war = 0; war < 3; war++)
            {
                System.Console.WriteLine("Prescott discards: {0}", p1.hand[0]);
                p1.hand.Remove(p1.hand[0]);
            }
            for(var war = 0; war < 3; war++)
            {
                System.Console.WriteLine("Lawdog discards: {0}", p2.hand[0]);
                p2.hand.Remove(p2.hand[0]);
            }
            object p1_card = p1.PlayCard();
            object p2_card = p2.PlayCard();
            System.Console.WriteLine("prescott plays " + p1_card);
            System.Console.WriteLine("lawdog plays " + p2_card);
            if ((int)p1.hand[0].value > (int)p2.hand[0].value)
            {
                System.Console.WriteLine("Prescott Wins the Round");
                p1.score += 1;
            }
            if ((int)p1.hand[0].value < (int)p2.hand[0].value)
            {
                System.Console.WriteLine("Lawdog Wins the Round");
                p2.score += 1;
            }
            if ((int)p1.hand[0].value == (int)p2.hand[0].value) 
            {
                p1.score += 1;
                p2.score += 1;
                System.Console.WriteLine("Another tie?! Screw it you both get points...");
            }
        }
    }
}