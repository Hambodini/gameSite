using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gameSite.Models
{
    public class RockPaperScissorsViewModel
    {
        public RockPaperScissorsViewModel()
        {
            Possibles = new List<String> { "Rock", "Paper", "Scissors" };
            DidPlayerWin = false;
            GameEnd = false;
            Outcome = "";
            PlayerChoice = "";
        }

        public int PlayerBet { get; set; }
        public string PlayerChoice { get; set; }
        public string Outcome { get; set; }
        public List<String> Possibles { get; set; }
        public bool DidPlayerWin { get; set; }
        public bool GameEnd { get; set; }

        public void WinCheck()
        {

            if (PlayerChoice == "Rock" && Outcome == "Scissors")
            {
                DidPlayerWin = true;
                GameEnd = true;
            }
            if (PlayerChoice == "Rock" && Outcome == "Paper")
            {
                DidPlayerWin = false;
                GameEnd = true;
            }
            if (PlayerChoice == "Paper" && Outcome == "Scissors")
            {
                DidPlayerWin = false;
                GameEnd = true;
            }
            if (PlayerChoice == "Paper" && Outcome == "Rock")
            {
                DidPlayerWin = true;
                GameEnd = true;
            }
            if (PlayerChoice == "Scissors" && Outcome == "Paper")
            {
                DidPlayerWin = true;
                GameEnd = true;
            }
            if (PlayerChoice == "Scissors" && Outcome == "Rock")
            {
                DidPlayerWin = false;
                GameEnd = true;
            }
        }

        internal void ChooseRock()
        {
            PlayerChoice = "Rock";
            Possibles.Remove("Rock");
        }

        internal void ChoosePaper()
        {
            PlayerChoice = "Paper";
            Possibles.Remove("Paper");
        }

        internal void ChooseScissors()
        {
            PlayerChoice = "Scissors";
            Possibles.Remove("Scissors");
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
            Outcome = outcome;

            //win check
            WinCheck();
        }
    }
}