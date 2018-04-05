using System;
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
            if(player1 != null)
            {
                HttpContext.Session.SetString("player1", player1);
            }
            if(player2 != null)
            {
                HttpContext.Session.SetString("player2", player2);
            }
            if(player3 != null)
            {
                HttpContext.Session.SetString("player3", player3);
            }
            if(player4 != null)
            {
                HttpContext.Session.SetString("player4", player4)
            }
            return RedirectToAction("Main");
        }

        [HttpGet]
        [Route("gameboard")]
        public IActionResult Main()
        {
            return View();
        }
    }
}