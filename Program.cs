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
            // BuildWebHost(args).Run();

            // game logic testing below:
            GameInit.GameInitialization();
            List<string> player_names = GameInit.CreatePlayers();
            Game.CreateGame(player_names);
            while(GameInit.GameStatus == true)
            {
                System.Console.WriteLine("--------------------");
                System.Console.WriteLine("Turn Counter: " + Game.turn_counter);
                System.Console.WriteLine("--------------------");
                Game.NextTurn();
                
            }
        }
        // public static IWebHost BuildWebHost(string[] args) =>
        //     WebHost.CreateDefaultBuilder(args)
        //         .UseStartup<Startup>()
        //         .Build();
    }
}
