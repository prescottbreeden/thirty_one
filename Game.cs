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
        public static int player_choice;
        public static bool knock_status;
        
        public static List<Player> CreateGame(List<string> players)
        {
            GameInit.GameStatus = true;
            // generate human players in game
            foreach(string player in players)
            {
                Players.Add(new Player(player));
            }
            foreach(Player player in Players)
            {
                player.isHuman = true;
            }
            int comp_players = total_players-Players.Count;
            // fill remainder of table with computer players
            for(int i = 0; i < comp_players; i++)
            {
                Players.Add(new Player($"Computer {i+1}"));
                System.Console.WriteLine($"Making Player: Computer {i+1}");
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
            Deck.MoveTopCardToDiscardPile();
            return Players;
        }
        public static void NextTurn()
        {
             // convert seat number to player array index value
            var current_player_turn = Players[next_turn-1];
            System.Console.WriteLine($"Knocked: {current_player_turn.knocked}");
            if (current_player_turn.knocked == true)
            {
                System.Console.WriteLine("Entered true condition");
                EndRound(current_player_turn);
                return;
            }
            System.Console.WriteLine($"{current_player_turn.name}");
            System.Console.WriteLine("--");
            Deck.ShowDiscardPile();
            System.Console.WriteLine("--");

            if (current_player_turn.isHuman == true)
            {
                //call human controls
                HumanTurn(current_player_turn);
            }
            else
            {
                //call AI to play for computer turn
                if(current_player_turn.num_suits.Max() == 3)
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
                    if (Deck.discard_pile[0].suit == max_suit_type)
                    {
                        Card min = current_player_turn.hand[0];
                        foreach(Card c in current_player_turn.hand)
                        {
                            if(c.value < min.value)
                                min = c;
                        }
                        if (Deck.discard_pile[0].value > min.value)
                        {
                            Deck.DrawFromDiscard(current_player_turn);
                            System.Console.WriteLine($"{current_player_turn.name} drew from discard pile");
                        }
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
            
                System.Threading.Thread.Sleep(3000);
                
                //-------------------------//
                // Hand size is now 4 cards//
                //-------------------------//

                // Evaluate value of current hand
                Player.CalculateHandValue(current_player_turn);

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
                    System.Console.WriteLine($"{current_player_turn.name} discarded {Deck.discard_pile[0]}");  
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

                //knock check
                if (current_player_turn.hand_value > 25)
                {
                    Knock(current_player_turn);
                }
            }
            if (current_player_turn.hand_value == 31)
            {
                LayDown(current_player_turn);
            }
            else
            {
                turn_counter++;
                next_turn++;
                if (next_turn == 5)
                    next_turn = 1;
                System.Threading.Thread.Sleep(3000);
            }
        }
        public static void HumanTurn(Player player)
        {
            PrintCurrentHand(player);
                System.Console.WriteLine("Select an Option");
                System.Console.WriteLine("1. Draw from Deck");
                System.Console.WriteLine("2. Draw from discard pile");
                if (Game.knock_status == false)
                {
                    System.Console.WriteLine("3. Knock");
                }
                player_choice = Int32.Parse(Console.ReadLine());
                switch(player_choice)
                {
                    case 1:
                        Deck.DrawFromDeck(player);
                        break;
                    case 2:
                        Deck.DrawFromDiscard(player);
                        break;
                    case 3:
                        Knock(player);
                        break;
                }
                if (player.knocked == true)
                {
                    System.Console.WriteLine();
                }
                else
                {    
                    System.Console.WriteLine("Select a card to discard");
                    for(var i = 1; i <= player.hand.Count; i++)
                    {
                        System.Console.WriteLine($"{i}. {player.hand[i-1]}");
                    }
                    player_choice = Int32.Parse(Console.ReadLine());
                    player_choice = player_choice-1;
                    Deck.discard_pile.Insert(0, player.hand[player_choice]);
                    player.hand.Remove(player.hand[player_choice]);
                    System.Console.WriteLine($"{player.name} discarded {Deck.discard_pile[0]}.");
                    System.Console.WriteLine($"{player.name}'s hand value is now {player.hand_value}.");
                }
        }
        public static void Knock(Player knocker)
        {
            System.Console.WriteLine($"{knocker} is a knocker... that's kinda weird...");
            Game.knock_status = true;
            knocker.knocked = true;
        }
        public static void LayDown(Player winner)
        {
            System.Console.WriteLine($"{winner.name} wins the round!");
            foreach (Player player in Players)
            {
               if (player != winner)
               {
                   player.tokens--;
               }
            }
            GameInit.MainMenu();
        }
        public static void EndRound(Player knocker)
        {
            System.Console.WriteLine("Entered 'End Round' Ivocation");
            foreach (Player player in Players)
            {
                if (player != knocker)
                {
                    if (player.hand_value > knocker.hand_value)
                    {
                        knocker.tokens--;
                        return;
                    }
                }
                else
                {
                    int lowest_hand = knocker.hand_value;
                    foreach(Player p in Players)
                    {
                        if(p.hand_value < lowest_hand)
                            lowest_hand = p.hand_value;
                    }
                    foreach(Player p in Players)
                    {
                        if (p.hand_value == lowest_hand)
                        {
                            p.tokens--;
                        }
                    }
                }
            }
            System.Console.WriteLine("##########################");
            System.Console.WriteLine($"##### Knocker had {knocker.hand_value} #####");
            System.Console.WriteLine("##########################");
            System.Console.WriteLine("\n");
            System.Console.WriteLine("\n");
            System.Console.WriteLine(@" /-------------------------------\");                
            System.Console.WriteLine(@"| ****** Results from Game ****** |");
            System.Console.WriteLine(@" \-------------------------------/");
            System.Console.WriteLine("|    Name    | Hand Value | Tokens |");
            foreach(Player p in Players)
            {
                System.Console.WriteLine($"{p.name}  -  {p.hand_value}  -  {p.tokens}");
            }
            GameInit.GameStatus = false;
            GameInit.MainMenu();
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