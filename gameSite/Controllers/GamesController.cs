using gameSite.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gameSite.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public static BlackJackViewModel BJControllerModel { get; set; }
        public static CoinFlipViewModel CFControllerModel { get; set; }
        public static HighLowViewModel HLControllerModel { get; set; }
        public static RockPaperScissorsViewModel RPSControllerModel { get; set; }
        public static SlotsViewModel SControllerModel { get; set; }
        public static WheelOfFortuneViewModel WOFControllerModel { get; set; }
        // GET: Games
        public ActionResult BlackJackIndex()
        {
            BJControllerModel = new BlackJackViewModel();

            return View(BJControllerModel);
        }
        public ActionResult BlackJackDraw()
        {
            BJControllerModel.Draw();

            var Userid = User.Identity.GetUserId();
            var currentCap = db.Caps.Find(Userid);

            if (BJControllerModel.GameEnd == true)
            {
                if (BJControllerModel.DidPlayerWin == true)
                {
                    currentCap.Amount += BJControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if (BJControllerModel.DidPlayerWin == false)
                {
                    currentCap.Amount -= BJControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            
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
            CFControllerModel = new CoinFlipViewModel();

            return View(CFControllerModel);
        }

        public ActionResult CoinFlipHeads()
        {

            CFControllerModel.ChooseHeads();
            return View("CoinFlipIndex", CFControllerModel);
        }

        public ActionResult CoinFlipTails()
        {

            CFControllerModel.ChooseTails();
            return View("CoinFlipIndex", CFControllerModel);
        }

        public ActionResult CoinFlipDraw()
        {
            CFControllerModel.Draw();

            var Userid = User.Identity.GetUserId();
            var currentCap = db.Caps.Find(Userid);

            if (CFControllerModel.GameEnd == true)
            {
                if (CFControllerModel.DidPlayerWin == true)
                {
                    currentCap.Amount += CFControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if (CFControllerModel.DidPlayerWin == false)
                {
                    currentCap.Amount -= CFControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
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
            RPSControllerModel = new RockPaperScissorsViewModel();

            return View(RPSControllerModel);
        }

        public ActionResult RockPaperScissorsRock()
        {

            RPSControllerModel.ChooseRock();
            return View("RockPaperScissorsIndex", RPSControllerModel);
        }

        public ActionResult RockPaperScissorsPaper()
        {

            RPSControllerModel.ChoosePaper();
            return View("RockPaperScissorsIndex", RPSControllerModel);
        }

        public ActionResult RockPaperScissorsScissors()
        {

            RPSControllerModel.ChooseScissors();
            return View("RockPaperScissorsIndex", RPSControllerModel);
        }

        public ActionResult RockPaperScissorsDraw()
        {
            RPSControllerModel.Draw();

            var Userid = User.Identity.GetUserId();
            var currentCap = db.Caps.Find(Userid);

            if (RPSControllerModel.GameEnd == true)
            {
                if (RPSControllerModel.DidPlayerWin == true)
                {
                    currentCap.Amount += RPSControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if (RPSControllerModel.DidPlayerWin == false)
                {
                    currentCap.Amount -= RPSControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

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
            HLControllerModel = new HighLowViewModel();

            HLControllerModel.GetHouseDraw();
            return View(HLControllerModel);
        }
        public ActionResult HighLowHigh()
        {
            HLControllerModel.ChooseHigh();
            return View("HighLowIndex", HLControllerModel);
        }
        public ActionResult HighLowLow()
        {
            HLControllerModel.ChooseLow();
            return View("HighLowIndex", HLControllerModel);
        }
        public ActionResult HighLowPlay()
        {
            HLControllerModel.GetPlayerDraw();

            var Userid = User.Identity.GetUserId();
            var currentCap = db.Caps.Find(Userid);

            if (HLControllerModel.GameEnd == true)
            {
                if (HLControllerModel.DidPlayerWin == true)
                {
                    currentCap.Amount += HLControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if (HLControllerModel.DidPlayerWin == false)
                {
                    currentCap.Amount -= HLControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return View("HighLowIndex", HLControllerModel);
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
            SControllerModel = new SlotsViewModel();

            return View(SControllerModel);
        }
        public ActionResult SlotsSpin()
        {
            SControllerModel.Spin();

            var Userid = User.Identity.GetUserId();
            var currentCap = db.Caps.Find(Userid);

            if (SControllerModel.GameEnd == true)
            {
                if (SControllerModel.DidPlayerWin == true)
                {
                    currentCap.Amount += SControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if (SControllerModel.DidPlayerWin == false)
                {
                    currentCap.Amount -= SControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return View("SlotsIndex", SControllerModel);
        }
        public ActionResult SlotsBet(string Amount)
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
                SControllerModel.PlayerBet = BetAmount;
            }

            return View("SlotsIndex", SControllerModel);

        }
        public ActionResult WheelOfFortuneIndex()
        {
            WOFControllerModel = new WheelOfFortuneViewModel();

            return View(WOFControllerModel);
        }
        public ActionResult WheelOfFortuneSpin()
        {

            WOFControllerModel.Spin();

            var Userid = User.Identity.GetUserId();
            var currentCap = db.Caps.Find(Userid);

            if (WOFControllerModel.GameEnd == true)
            {
                if (WOFControllerModel.DidPlayerWin == true)
                {
                    currentCap.Amount += WOFControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if (WOFControllerModel.DidPlayerWin == false)
                {
                    currentCap.Amount -= WOFControllerModel.PlayerBet;
                    db.Entry(currentCap).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return View("SlotsIndex", WOFControllerModel);
        }
        public ActionResult WheelOfFortuneBet(string Amount)
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
                WOFControllerModel.PlayerBet = BetAmount;
            }

            return View("WheelOfFortuneIndex", WOFControllerModel);

        }
    }
}