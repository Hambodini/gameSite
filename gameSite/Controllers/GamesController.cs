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
        public static BlackJackViewModel BJControllerModel { get; set; }

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

            BJControllerModel = Model;
            return View(BJControllerModel);
        }
        public ActionResult BlackJackDraw()
        {

            Random rnd = new Random();
            int amountOfCards;
            int randomNumber;
            if (BJControllerModel.HouseCount <= 17)
            {
                //draw a card for the house
                amountOfCards = BJControllerModel.Cards.Count - 1;
                randomNumber = rnd.Next(0, amountOfCards);
                var houseCard = BJControllerModel.Cards[randomNumber].ToString();
                BJControllerModel.Cards.RemoveAt(randomNumber);

                //add value to house set card drawn
                var houseCardValue = BJControllerModel.FindValue(houseCard);
                BJControllerModel.HouseCount += houseCardValue;
                BJControllerModel.HouseCardDrawn = houseCard;
                //Model.HouseCount = updatedHouseCount;
            }
            else
            {
                BJControllerModel.HouseCardDrawn = "nothing";
            }

            //draw a card for the player
            amountOfCards = BJControllerModel.Cards.Count - 1;
            randomNumber = rnd.Next(0, amountOfCards);
            var playerCard = BJControllerModel.Cards[randomNumber].ToString();
            BJControllerModel.Cards.RemoveAt(randomNumber);

            //add value to player and set card drawn
            var playerCardValue = BJControllerModel.FindValue(playerCard);
            BJControllerModel.PlayerCount += playerCardValue;
            BJControllerModel.PlayerCardDrawn = playerCard;

            //win check
            if (BJControllerModel.HouseCount > 21 && BJControllerModel.PlayerCount <= 21)
            {
                BJControllerModel.DidPlayerWin = true;
                BJControllerModel.GameEnd = true;

            }
            else if (BJControllerModel.HouseCount <= 21 && BJControllerModel.PlayerCount > 21)
            {
                BJControllerModel.DidPlayerWin = false;
                BJControllerModel.GameEnd = true;
            }
            else if (BJControllerModel.HouseCount == 21 && BJControllerModel.PlayerCount == 21)
            {
                BJControllerModel.WasDraw = true;
                BJControllerModel.GameEnd = true;
            }

            BJControllerModel.Round++;

            return View("BlackJackIndex", BJControllerModel);

        }

        public ActionResult BlackJackBet(string Amount)
        {
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
                BJControllerModel.PlayerBet = BetAmount;
            }

            return View("BlackJackIndex", BJControllerModel);

        }

        public ActionResult BlackJackDoubleDown()
        {

            if (BJControllerModel.PlayerBet == 0)
            {
                ViewBag.error = "You need to bet something if you want to double down";
            }
            else
            {
                BJControllerModel.PlayerBet *= 2;
                BJControllerModel.DidPlayerDoubleDown = true;
            }

            return View("BlackJackIndex", BJControllerModel);
        }
    }
}