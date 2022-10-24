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

            Model.HouseCount = 0;
            Model.HouseCardDrawn = "nothing";

            Model.PlayerCount = 0;
            Model.PlayerCardDrawn = "nothing";

            Model.Round = 1;
            return View(Model);
        }
        [HttpPost]
        public ActionResult BlackJackIndex(BlackJackViewModel Model)
        {
            String action = Request["action"];
            
            if (action == "stand")
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

            } else if (action == "bet")
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

            }
            else if (action == "dd")
            {
                if (Model.DidPlayerBet == true)
                {
                    Model.PlayerBet *= 2;
                    Model.DidPlayerDoubleDown = true;
                }
            }

            if (Model.HouseCount > Model.PlayerCount)
            {
                Model.DidPlayerWin = false;
            }
            else
            {
                Model.DidPlayerWin = true;
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

            return View("BlackJackIndex", Model);

        }
    }
}