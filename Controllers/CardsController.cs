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

        public IActionResult PlayerSelect()
        {
            return View();
        }
    }
}