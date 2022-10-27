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
            BlackJackViewModel Model = new BlackJackViewModel
            {
                Cards = new List<String> { "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "sj", "sq", "sk", "sa", "h2", "h3", "h4", "h5", "h6", "h7", "h8", "h9", "h10", "hj", "hq", "hk", "ha", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10", "cj", "cq", "ck", "ca", "d2", "d3", "d4", "d5", "d6", "d7", "d8", "d9", "d10", "dj", "dq", "dk", "da" },
                DidPlayerWin = false,
                DidPlayerStand = false,
                DidPlayerDoubleDown = false,
                GameEnd = false,
                HouseCount = 0,
                PlayerCount = 0,
                Round = 1
            };

            return View(Model);
        }
        // POST: Games
        [HttpPost]
        public ActionResult BlackJackIndex(BlackJackViewModel Model)
        {

            return View(Model);
        }
        public ActionResult BlackJackDraw(BlackJackViewModel Model, int playerCount, int houseCount, int Round, int betAmount)
        {

            Random rnd = new Random();
            int amountOfCards;
            int randomNumber;
            int updatedHouseCount = houseCount;
            if (houseCount <= 17)
            {
                //draw a card for the house
                amountOfCards = Model.Cards.Count - 1;
                randomNumber = rnd.Next(0, amountOfCards);
                var houseCard = Model.Cards[randomNumber].ToString();
                Model.Cards.RemoveAt(randomNumber);

                //add value to house set card drawn
                var houseCardValue = Model.FindValue(houseCard);
                var oldHouseCount = houseCount;
                updatedHouseCount = oldHouseCount + houseCardValue;
                Model.HouseCardDrawn = houseCard;
                //Model.HouseCount = updatedHouseCount;
            }
            else
            {
                Model.HouseCardDrawn = "nothing";
            }

            //draw a card for the player
            amountOfCards = Model.Cards.Count - 1;
            randomNumber = rnd.Next(0, amountOfCards);
            var playerCard = Model.Cards[randomNumber].ToString();
            Model.Cards.RemoveAt(randomNumber);

            //add value to player and set card drawn
            var playerCardValue = Model.FindValue(playerCard);
            var oldPlayerCount = playerCount;
            var updatedPlayerCount = oldPlayerCount + playerCardValue;
            Model.PlayerCardDrawn = playerCard;

            var bjvm = new BlackJackViewModel();

            //win check
            if (updatedHouseCount > 21 && updatedPlayerCount < 21)
            {
                bjvm.DidPlayerWin = true;
                bjvm.GameEnd = true;

            }
            else if (updatedHouseCount < 21 && updatedPlayerCount > 21)
            {
                bjvm.DidPlayerWin = false;
                bjvm.GameEnd = true;
            }
            else if (updatedHouseCount > 21 && updatedPlayerCount > 21)
            {
                bjvm.WasDraw = true;
                bjvm.GameEnd = true;
            }


            bjvm.Cards = Model.Cards;
            bjvm.HouseCount = updatedHouseCount;
            bjvm.HouseCardDrawn = Model.HouseCardDrawn;
            bjvm.DidPlayerDoubleDown = Model.DidPlayerDoubleDown;
            bjvm.PlayerCount = updatedPlayerCount;
            bjvm.PlayerBet = betAmount;
            bjvm.PlayerCardDrawn = Model.PlayerCardDrawn;
            Round++;
            bjvm.Round = Round;


            return View("BlackJackIndex", bjvm);

        }

        public ActionResult BlackJackBet(BlackJackViewModel Model, int playerCount, int houseCount, int Round, string Amount, string HouseCardDrawn, string CardDrawn)
        {
            var bjvm = new BlackJackViewModel();
            int BetAmount = 0;
            try
            {
                BetAmount = int.Parse(Amount);
            }
            catch (Exception)
            {
                ViewBag.error = "Your bet has to be a whole number";
            }

            if (BetAmount != 0)
            {
                bjvm.PlayerBet = BetAmount;
            }

            bjvm.Cards = Model.Cards;
            bjvm.HouseCount = houseCount;
            bjvm.HouseCardDrawn = Model.HouseCardDrawn;
            bjvm.PlayerCount = playerCount;
            bjvm.PlayerCardDrawn = Model.PlayerCardDrawn;
            bjvm.Round = Round;


            return View("BlackJackIndex", bjvm);

        }

        public ActionResult BlackJackDoubleDown(BlackJackViewModel Model, int playerCount, int houseCount, int Round, int betAmount)
        {
            var bjvm = new BlackJackViewModel();

            if (betAmount == 0)
            {
                ViewBag.error = "You need to bet something if you want to double down";
            }
            else
            {
                betAmount *= 2;
                bjvm.PlayerBet = betAmount;
                bjvm.DidPlayerDoubleDown = true;
            }

            bjvm.Cards = Model.Cards;
            bjvm.HouseCount = houseCount;
            bjvm.HouseCardDrawn = Model.HouseCardDrawn;
            bjvm.PlayerCount = playerCount;
            bjvm.PlayerCardDrawn = Model.PlayerCardDrawn;
            bjvm.Round = Round;


            return View("BlackJackIndex", bjvm);
        }
    }
}