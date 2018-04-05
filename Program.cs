using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace thirty_one
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            // game logic testing below:
            // Game.CreateGame();
            // Game.PrintAllHands();
            // while(Deck.current_card<52)
            // {
            //     Game.PrintAllHandValues();
            //     Game.NextTurn();
            //     System.Console.WriteLine("Top card in discard pile stack:");
            //     System.Console.WriteLine(Deck.discard_pile[0].suit);
            //     System.Console.WriteLine("Turn Counter: " + Game.turn_counter);
            // }
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
