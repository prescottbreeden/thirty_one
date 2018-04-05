using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace thirty_one
{
    public class CardsController : Controller
    {
        [HttpGet]
        [Route("")]

        public IActionResult PlayerSelect() // View presenting form to create 0-4 players
        {
            return View();
        }

        [HttpPost]
        [Route("players")]
        public IActionResult CreatePlayers(string player1, string player2, string player3, string player4) // Post route to process player submission. Instantiates all players and A.I.
        {
            HttpContext.Session.SetInt32("NumPlayers", 0);
            if(player1 != null)
            {
                HttpContext.Session.SetString("player1", player1);
                int? NumPlayers = HttpContext.Session.GetInt32("NumPlayers");
                HttpContext.Session.SetInt32("NumPlayers", (int)NumPlayers+1);
            }
            if(player2 != null)
            {
                HttpContext.Session.SetString("player2", player2);
                int? NumPlayers = HttpContext.Session.GetInt32("NumPlayers");
                HttpContext.Session.SetInt32("NumPlayers", (int)NumPlayers+1);
            }
            if(player3 != null)
            {
                HttpContext.Session.SetString("player3", player3);
                int? NumPlayers = HttpContext.Session.GetInt32("NumPlayers");
                HttpContext.Session.SetInt32("NumPlayers", (int)NumPlayers+1);
            }
            if(player4 != null)
            {
                HttpContext.Session.SetString("player4", player4);
                int? NumPlayers = HttpContext.Session.GetInt32("NumPlayers");
                HttpContext.Session.SetInt32("NumPlayers", (int)NumPlayers+1);
            }
            return RedirectToAction("Main");
        }

        [HttpGet]
        [Route("gameboard")]
        public IActionResult Main()
        {
            // Initializing game
            int? NumPlayers = HttpContext.Session.GetInt32("NumPlayers");
            List<string> players = new List<string>();
            string player1 = HttpContext.Session.GetString("player1");
            if(player1 != null)
            {
                players.Add(player1);
            }
            string player2 = HttpContext.Session.GetString("player2");
            if(player2 != null)
            {
                players.Add(player2);
            }
            string player3 = HttpContext.Session.GetString("player3");
            if(player3 != null)
            {
                players.Add(player3);
            }
            string player4 = HttpContext.Session.GetString("player4");
            if(player4 != null)
            {
                players.Add(player4);
            }
            ViewBag.player1 = player1;
            ViewBag.player2 = player2;
            ViewBag.player3 = player3;
            ViewBag.player4 = player4;
            ViewBag.NumPlayers = NumPlayers;
            Game.CreateGame(players);
            // End Intitializing

            // Hands




            return View();
        }
    }
}