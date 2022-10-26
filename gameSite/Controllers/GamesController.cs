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
        public ActionResult BlackJackIndex(BlackJackViewModel Model)
        {
            if (Model == null)
            {
                Model = new BlackJackViewModel
                {
                    HouseCount = 0,
                    HouseCardDrawn = "nothing",
                    PlayerCount = 0,
                    PlayerCardDrawn = "nothing",
                    Round = 1
                };
            }

            return View(Model);
        }
        public ActionResult BlackJackDraw(BlackJackViewModel Model)
        {

            Model.Round++;

            Random rnd = new Random();

            //draw a card for the house
            int amountOfCards = Model.Cards.Count - 1;
            int randomNumber = rnd.Next(0, amountOfCards);
            String card = Model.Cards[randomNumber].ToString();
            Model.Cards.RemoveAt(randomNumber);

            //add value to house set card drawn
            Model.HouseCardDrawn = card;
            Model.HouseCount += Model.FindValue(card);

            //draw a card for the player
            amountOfCards = Model.Cards.Count - 1;
            randomNumber = rnd.Next(0, amountOfCards);
            card = Model.Cards[randomNumber].ToString();
            Model.Cards.RemoveAt(randomNumber);

            //add value to player and set card drawn
            Model.PlayerCardDrawn = card;
            Model.PlayerCount += Model.FindValue(card);

            //increment round
            Model.Round++;

            //win check
            if (Model.HouseCount > 21 && Model.PlayerCount < 21)
            {
                Model.DidPlayerWin = true;
                Model.GameEnd = true;

            }
            else if (Model.HouseCount < 21 && Model.PlayerCount > 21)
            {
                Model.DidPlayerWin = false;
                Model.GameEnd = true;
            }

            return View("BlackJackIndex", Model);

        }

        public ActionResult BlackJackStand(BlackJackViewModel Model)
        {
            Model.Round++;
            Model.DidPlayerStand = true;

            Random rnd = new Random();

            //draw a card for the house
            int amountOfCards = Model.Cards.Count - 1;
            int randomNumber = rnd.Next(0, amountOfCards);
            String card = Model.Cards[randomNumber].ToString();
            Model.Cards.RemoveAt(randomNumber);

            //add value to house set card drawn
            Model.HouseCardDrawn = card;
            Model.HouseCount += Model.FindValue(card);

            //win check
            if (Model.HouseCount > Model.PlayerCount)
            {
                Model.DidPlayerWin = false;
            }
            else
            {
                Model.DidPlayerWin = true;
                Model.GameEnd = true;
            }

            return View("BlackJackIndex", Model);

        }

        public ActionResult BlackJackBet(BlackJackViewModel Model)
        {
            String betString = Request.QueryString["amount"];
            int bet = 0;

            try
            {
                bet = int.Parse(betString);
            }
            catch (Exception)
            {
            }
            if (bet != 0)
            {
                Model.DidPlayerBet = true;
                Model.PlayerBet = bet;
            }

            return View("BlackJackIndex", Model);

        }

        public ActionResult BlackJackDoubleDown(BlackJackViewModel Model)
        {

            if (Model.DidPlayerBet == true)
            {
                Model.PlayerBet *= 2;
                Model.DidPlayerDoubleDown = true;
            }

            return View("BlackJackIndex", Model);

        }
    }
}