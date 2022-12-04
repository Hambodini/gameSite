using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gameSite.Models
{
    public class CoinFlipViewModel
    {
        public CoinFlipViewModel()
        {
            Possibles = new List<String> { "Tails", "Heads" };
            DidPlayerWin = false;
            GameEnd = false;
            CoinOutcome = "";
                PlayerChoice = "";
            }
        public int PlayerBet { get; set; }
        public string PlayerChoice { get; set; }
        public string CoinOutcome { get; set; }
        public  List<String> Possibles { get; set; }
        public bool DidPlayerWin { get; set; }
        public bool GameEnd { get; set; }

        internal void ChooseHeads()
        {
            PlayerChoice = "Heads";
        }

        internal void ChooseTails()
        {
            PlayerChoice = "Tails";
        }

        internal void Draw()
        {
            Random rnd = new Random();
            int amountOfPossibles;
            int randomNumber;

            //draw out of possibles
            amountOfPossibles = Possibles.Count - 1;
            randomNumber = rnd.Next(0, amountOfPossibles);
            var outcome = Possibles[randomNumber].ToString();
            Possibles.RemoveAt(randomNumber);

            //show outcome
            CoinOutcome = outcome;

            //win check
            if (PlayerChoice == CoinOutcome)
            {
                DidPlayerWin = true;
                GameEnd = true;
            }
            else
            {
                DidPlayerWin = false;
                GameEnd = true;
            }
        }
    }
}