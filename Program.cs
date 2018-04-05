using System;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Player lawdog = new Player("Lawdog");
            Player prescott = new Player("Prescott");
            Deck deck1 = new Deck();
            deck1.Shuffle();
            System.Console.WriteLine("Deck shuffled");
            for (var i = 0; i < 26; i++)
            {
                prescott.DrawCard(deck1);
                lawdog.DrawCard(deck1);
            }
            for (var round = 1; round <= 10; round++)
            {
                if (prescott.hand[0] is Card)
                {
                    System.Console.WriteLine("------------");
                    System.Console.WriteLine("Round {0}...", round);
                    System.Console.WriteLine("------------");
                    object p1_card = prescott.PlayCard();
                    object p2_card = lawdog.PlayCard();
                    System.Console.WriteLine("prescott plays " + p1_card);
                    System.Console.WriteLine("lawdog plays " + p2_card);
                    if ((int)prescott.hand[0].value > (int)lawdog.hand[0].value)
                    {
                        System.Console.WriteLine("Prescott Wins the Round");
                        prescott.score += 1;
                    }
                    if ((int)prescott.hand[0].value < (int)lawdog.hand[0].value)
                    {
                        System.Console.WriteLine("Lawdog Wins the Round");
                        lawdog.score += 1;
                    }
                    if ((int)prescott.hand[0].value == (int)lawdog.hand[0].value)
                    {
                        deck1.War(prescott, lawdog);
                    }
                    prescott.hand.Remove(prescott.hand[0]);
                    lawdog.hand.Remove(lawdog.hand[0]);
                }
                else
                {
                    System.Console.WriteLine("Ran out of cards!!");
                    break;
                }
            }  
            System.Console.WriteLine("------------");
            System.Console.WriteLine("------------");
            System.Console.WriteLine("Total Score~~> Prescott: {0}, Lawdog: {1}", prescott.score,lawdog.score);
            if (prescott.score > lawdog.score)
                System.Console.WriteLine("Prescott wins!");
            if (prescott.score < lawdog.score)
                System.Console.WriteLine("Lawdog wins!");
            if (prescott.score == lawdog.score)
                System.Console.WriteLine("Game is a Draw... Play again?");
            System.Console.WriteLine("------------");
            System.Console.WriteLine("------------");
        }
    }
}
