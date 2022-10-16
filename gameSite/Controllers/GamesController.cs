using gameSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gameSite.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        [HttpGet]
        public ActionResult BlackJackIndex()
        {
            BlackJackViewModel Model = new BlackJackViewModel();
            Model.Round = 1;
            return View(Model);
        }
        [HttpPost]
        public ActionResult BlackJackIndex(BlackJackViewModel Model)
        {
            Model.Round += 1;
            return View(Model);
        }
    }
}