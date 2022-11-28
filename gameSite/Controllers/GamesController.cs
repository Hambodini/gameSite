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
        public static CoinFlipViewModel CFControllerModel { get; set; }
        public static HighLowViewModel HLControllerModel { get; set; }
        public static RockPaperScissorsViewModel RPSControllerModel { get; set; }
        public static SlotsViewModel SControllerModel { get; set; }
        public static WheelOfFortuneViewModel WOFControllerModel { get; set; }
        // GET: Games
        public ActionResult BlackJackIndex()
        {
            BJControllerModel = new BlackJackViewModel
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

            return View(BJControllerModel);
        }
        public ActionResult BlackJackDraw()
        {
            BJControllerModel.Draw();
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
        public ActionResult CoinFlipIndex()
        {
            CoinFlipViewModel Model = new CoinFlipViewModel
            {
                Possibles = new List<String> { "Tails", "Heads" },
                DidPlayerWin = false,
                GameEnd = false,
                CoinOutcome = "",
                PlayerChoice = "",
            };

            CFControllerModel = Model;
            return View(CFControllerModel);
        }

        public ActionResult CoinFlipHeads()
        {

            CFControllerModel.PlayerChoice = "Heads";
            return View("CoinFlipIndex", CFControllerModel);
        }

        public ActionResult CoinFlipTails()
        {

            CFControllerModel.PlayerChoice = "Tails";
            return View("CoinFlipIndex", CFControllerModel);
        }

        public ActionResult CoinFlipDraw()
        {
            Random rnd = new Random();
            int amountOfPossibles;
            int randomNumber;

            //draw out of possibles
            amountOfPossibles = CFControllerModel.Possibles.Count - 1;
            randomNumber = rnd.Next(0, amountOfPossibles);
            var outcome = CFControllerModel.Possibles[randomNumber].ToString();
            CFControllerModel.Possibles.RemoveAt(randomNumber);

            //show outcome
            CFControllerModel.CoinOutcome = outcome;

            //win check
            if (CFControllerModel.PlayerChoice == CFControllerModel.CoinOutcome)
            {
                CFControllerModel.DidPlayerWin = true;
                CFControllerModel.GameEnd = true;
            }
            else
            {
                CFControllerModel.DidPlayerWin = false;
                CFControllerModel.GameEnd = true;
            }

            return View("CoinFlipIndex", CFControllerModel);

        }

        public ActionResult CoinFlipBet(string Amount)
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
                CFControllerModel.PlayerBet = BetAmount;
            }

            return View("CoinFlipIndex", CFControllerModel);

        }
        public ActionResult RockPaperScissorsIndex()
        {
            RockPaperScissorsViewModel Model = new RockPaperScissorsViewModel
            {
                Possibles = new List<String> { "Rock", "Paper", "Scissors" },
                DidPlayerWin = false,
                GameEnd = false,
                Outcome = "",
                PlayerChoice = "",
            };

            RPSControllerModel = Model;
            return View(RPSControllerModel);
        }

        public ActionResult RockPaperScissorsRock()
        {

            RPSControllerModel.PlayerChoice = "Rock";
            RPSControllerModel.Possibles.Remove("Rock");
            return View("RockPaperScissorsIndex", RPSControllerModel);
        }

        public ActionResult RockPaperScissorsPaper()
        {

            RPSControllerModel.PlayerChoice = "Paper";
            RPSControllerModel.Possibles.Remove("Paper");
            return View("RockPaperScissorsIndex", RPSControllerModel);
        }

        public ActionResult RockPaperScissorsScissors()
        {

            RPSControllerModel.PlayerChoice = "Scissors";
            RPSControllerModel.Possibles.Remove("Scissors");
            return View("RockPaperScissorsIndex", RPSControllerModel);
        }

        public ActionResult RockPaperScissorsDraw()
        {
            Random rnd = new Random();
            int amountOfPossibles;
            int randomNumber;

            //draw out of possibles
                amountOfPossibles = RPSControllerModel.Possibles.Count - 1;
            randomNumber = rnd.Next(0, amountOfPossibles);
            var outcome = RPSControllerModel.Possibles[randomNumber].ToString();
            RPSControllerModel.Possibles.RemoveAt(randomNumber);

            //show outcome
            RPSControllerModel.Outcome = outcome;

            //win check
            RPSControllerModel.WinCheck();

            return View("RockPaperScissorsIndex", RPSControllerModel);

        }

        public ActionResult RockPaperScissorsBet(string Amount)
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
                RPSControllerModel.PlayerBet = BetAmount;
            }

            return View("RockPaperScissorsIndex", RPSControllerModel);

        }
        public ActionResult HighLowIndex()
        {
            HLControllerModel = new HighLowViewModel
            {
                Cards = new List<String> { "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "sj", "sq", "sk", "sa", "h2", "h3", "h4", "h5", "h6", "h7", "h8", "h9", "h10", "hj", "hq", "hk", "ha", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10", "cj", "cq", "ck", "ca", "d2", "d3", "d4", "d5", "d6", "d7", "d8", "d9", "d10", "dj", "dq", "dk", "da" },
                DidPlayerWin = false,
                DidPlayerStand = false,
                GameEnd = false,
                HouseCount = 0,
                PlayerCount = 0,
                PlayerCardDrawn = "Hidden",
                PlayerChoice = ""
            };
            HLControllerModel.GetHouseDraw();
            return View(HLControllerModel);
        }
        public ActionResult HighLowHigh()
        {
            HLControllerModel.ChooseHigh();
            return View(HLControllerModel);
        }
        public ActionResult HighLowLow()
        {
            HLControllerModel.ChooseLow();
            return View(HLControllerModel);
        }
        public ActionResult HighLowBet(string Amount)
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
                HLControllerModel.PlayerBet = BetAmount;
            }

            return View("HighLowIndex", HLControllerModel);

        }
        public ActionResult SlotsIndex()
        {
            SlotsViewModel Model = new SlotsViewModel
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

            SControllerModel = Model;
            return View(SControllerModel);
        }
        public ActionResult WheelOfFortuneIndex()
        {
            WheelOfFortuneViewModel Model = new WheelOfFortuneViewModel
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

            WOFControllerModel = Model;
            return View(WOFControllerModel);
        }
    }
}