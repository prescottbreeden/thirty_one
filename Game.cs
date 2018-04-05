using System;
using System.Collections.Generic;
using System.Linq;

namespace thirty_one
{
    public class Game
    {
        public static List<Player> Players = new List<Player>();
        public static int TokenPot;
        public static int total_players = 4;
        public static int size_of_hand = 3;
        public static int turn_counter;
        public static int next_turn;
        public static string max_suit_type;
        
        public static List<Player> CreateGame(List<string> players)
        {
            // generate human players in game
            foreach(string player in players)
            {
                Players.Add(new Player(player));
            }
            foreach(Player player in Players)
            {
                player.isHuman = true;
            }
            
            // fill remainder of table with computer players
            for(var i = 1; i <= total_players-Players.Count + 1; i++)
            {
                Players.Add(new Player($"Computer {i}"));
                System.Console.WriteLine($"Making Player: Computer {i}");
            }
            
            // Place players at table
            for(var i = 0; i < Players.Count; i++)
                Players[i].player_seat = i+1;
            
            // Set first dealer
            Players[0].isDealer = true;

            // player to left of dealer starts (player 2)
            next_turn = 2;

            //Build deck
            Deck current_deck = new Deck();
            current_deck.Shuffle();
            System.Console.WriteLine("Deck Shuffled");

            // set turns to zero
            turn_counter = 1;

            //Deal 3 cards to each player
            for(var i = 0; i < size_of_hand; i++)
            {
                foreach (Player player in Players)
                    Deck.DrawFromDeck(player);
            }
            return Players;
        }


        public static void NextTurn()
        {
             // convert seat number to player array index value
            var current_player_turn = Players[next_turn-1];
            System.Console.WriteLine($"{current_player_turn}");
            System.Console.WriteLine("--");
            Deck.ShowDiscardPile();
            System.Console.WriteLine("--");
            if (current_player_turn.isHuman == true)
            {
                //call human controls
                System.Console.WriteLine("is human");
            }
            else
            {
                if(turn_counter == 0)
                { 
                    if (current_player_turn.hand_value == 31)
                        System.Console.WriteLine("Winning condition met"); //LayDown()
                    
                    // Draw a card
                    Deck.DrawFromDeck(current_player_turn);   
                }
                else if(current_player_turn.num_suits.Max() == 3)
                {
                    int max_Suit_Index = current_player_turn.num_suits.ToList().IndexOf(3);
                    // hearts == 0
                    // diamonds == 1
                    // spades == 2
                    // clubs == 3
                    switch(max_Suit_Index)
                    {
                        case 0:
                            max_suit_type = "Hearts";
                            break;
                        case 1:
                            max_suit_type = "Diamonds";
                            break;
                        case 2:
                            max_suit_type = "Spades";
                            break;
                        case 3:
                            max_suit_type = "Clubs";
                            break;
                    }
                    if (Deck.discard_pile[0].suit == max_suit_type && Deck.discard_pile.Count > 0)
                    {
                        Deck.DrawFromDiscard(current_player_turn);
                        System.Console.WriteLine($"{current_player_turn.name} drew from discard pile");
                    }
                    else
                    {
                        Deck.DrawFromDeck(current_player_turn);
                    }
                }
                else
                {
                    Deck.DrawFromDeck(current_player_turn);
                    System.Console.WriteLine($"{current_player_turn.name} drew from deck");
                }
            }
            System.Threading.Thread.Sleep(3000);
            // Hand size should be 4 now

            // Evaluate value of hand
            Player.CalculateHandValue(current_player_turn);
            System.Console.WriteLine(current_player_turn.hand_value);

            // choose card to discard
            if (current_player_turn.num_suits.Max() == 4)
            {
                Card min = current_player_turn.hand[0];
                foreach(Card c in current_player_turn.hand)
                {
                    if(c.value < min.value)
                        min = c;
                }
                Deck.discard_pile.Insert(0, min);
                current_player_turn.hand.Remove(min);
                System.Console.WriteLine($"{current_player_turn.name} discarded {min}");  
            }
            else if (current_player_turn.num_suits.Max() == 3)
            {
                int min_Suit_Index = current_player_turn.num_suits.ToList().IndexOf(1);
                Deck.discard_pile.Insert(0, current_player_turn.hand[min_Suit_Index]);
                current_player_turn.hand.RemoveAt(min_Suit_Index);
                System.Console.WriteLine($"{current_player_turn.name} discarded {Deck.discard_pile[0]}.");  
            }
            else
            {
                Card min = current_player_turn.hand[0];
                foreach(Card c in current_player_turn.hand)
                {
                    if(c.value < min.value)
                        min = c;
                }
                Deck.discard_pile.Insert(0, min);
                current_player_turn.hand.Remove(min);
                System.Console.WriteLine($"{current_player_turn} discarded {min}");
            }
            turn_counter++;
            next_turn++;
            if (next_turn == 5)
                next_turn = 1;
            System.Threading.Thread.Sleep(3000);
        }
        public static void HumanTurn(Player player)
        {
            PrintCurrentHand(player);
        }
        public static void PrintAllHands()
        {
            foreach (Player player in Players)
            {
                System.Console.WriteLine($"{player.name}'s initial hand: ");
                for (var i = 0; i < player.hand.Count; i++)
                    System.Console.WriteLine(player.hand[i]);
            }
        }
        public static void PrintAllHandValues()
        {
            foreach (Player player in Players)
            {
                Player.CalculateHandValue(player);
                System.Console.WriteLine($"{player.name} has hand value of {player.hand_value}");
            }
        }
        public static void PrintCurrentHand(Player player)
        {
            System.Console.WriteLine($"{player.name}'s current hand: ");
            for (var i = 0; i < player.hand.Count; i++)
                System.Console.WriteLine(player.hand[i]);
        }
    }
}