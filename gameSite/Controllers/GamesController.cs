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

            Random rnd = new Random();

            //draw a card for the house
            int amountOfCards = Model.Cards.Count - 1;
            int randomNumber = rnd.Next(0, amountOfCards);
            String card = Model.Cards[randomNumber].ToString();
            Model.HouseCount = Model.FindValue(card);
            Model.Cards.RemoveAt(randomNumber);

            //draw a card for the player
            amountOfCards = Model.Cards.Count - 1;
            randomNumber = rnd.Next(0, amountOfCards);
            card = Model.Cards[randomNumber].ToString();
            Model.PlayerCount = Model.FindValue(card);
            Model.Cards.RemoveAt(randomNumber);

            amountOfCards = Model.Cards.Count - 1;


            Model.Round = 1;
            return View(Model);
        }
        [HttpPost]
        public ActionResult BlackJackIndex(BlackJackViewModel Model)
        {
            String action = Request["action"];
            if (action == "draw")
            {
                Model.Round++;

                Random rnd = new Random();

                //draw a card for the house
                int amountOfCards = Model.Cards.Count - 1;
                int randomNumber = rnd.Next(0, amountOfCards);
                String card = Model.Cards[randomNumber].ToString();
                Model.HouseCount = Model.FindValue(card);
                Model.Cards.RemoveAt(randomNumber);

                //draw a card for the player
                amountOfCards = Model.Cards.Count - 1;
                randomNumber = rnd.Next(0, amountOfCards);
                card = Model.Cards[randomNumber].ToString();
                Model.PlayerCount = Model.FindValue(card);
                Model.Cards.RemoveAt(randomNumber);

                if (Model.PlayerCount > 21)
                {
                    Model.DidPlayerWin = false;
                } else if (Model.HouseCount > 21)
                {
                    Model.DidPlayerWin = true;
                }

            }
            else if (action == "stand")
            {
                Model.Round++;
                Model.DidPlayerStand = true;

                Random rnd = new Random();

                //draw a card for the house
                int amountOfCards = Model.Cards.Count - 1;
                int randomNumber = rnd.Next(0, amountOfCards);
                String card = Model.Cards[randomNumber].ToString();
                Model.HouseCount = Model.FindValue(card);
                Model.Cards.RemoveAt(randomNumber);

                if (Model.HouseCount > Model.PlayerCount)
                {
                    Model.DidPlayerWin = false;
                } else
                {
                    Model.DidPlayerWin = true;
                }

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
            return View(Model);
        }
    }
}