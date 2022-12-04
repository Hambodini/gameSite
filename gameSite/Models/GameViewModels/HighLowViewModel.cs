using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gameSite.Models
{
    public class HighLowViewModel
    {
        public HighLowViewModel()
        {
            Cards = new List<String> { "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "sj", "sq", "sk", "sa", "h2", "h3", "h4", "h5", "h6", "h7", "h8", "h9", "h10", "hj", "hq", "hk", "ha", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10", "cj", "cq", "ck", "ca", "d2", "d3", "d4", "d5", "d6", "d7", "d8", "d9", "d10", "dj", "dq", "dk", "da" };
            DidPlayerWin = false;
            DidPlayerStand = false;
            GameEnd = false;
            HouseCount = 0;
            PlayerCount = 0;
            PlayerCardDrawn = "Hidden";
            PlayerChoice = "";
        }
        public int PlayerBet { get; set; }
        public int PlayerCount { get; set; }
        public int HouseCount { get; set; }
        public string PlayerChoice { get; set; }
        public string Outcome { get; set; }
        public List<String> Cards { get; set; }
        public string HouseCardDrawn { get; set; }
        public string PlayerCardDrawn { get; set; }
        public bool DidPlayerWin { get; set; }
        public bool DidPlayerStand { get; set; }
        public bool GameEnd { get; set; }

        public int FindValue(String card)
        {
            int value = 0;
            int spadeVal = 10;
            int heartsVal = 20;
            int clubsVal = 30;
            int diamondsVal = 40;
            switch (card)
            {
                case "s2":
                    value = 2;
                    value += spadeVal;
                    break;
                case "s3":
                    value = 3;
                    value += spadeVal;
                    break;
                case "s4":
                    value = 4;
                    value += spadeVal;
                    break;
                case "s5":
                    value = 5;
                    value += spadeVal;
                    break;
                case "s6":
                    value = 6;
                    value += spadeVal;
                    break;
                case "s7":
                    value = 7;
                    value += spadeVal;
                    break;
                case "s8":
                    value = 8;
                    value += spadeVal;
                    break;
                case "s9":
                    value = 9;
                    value += spadeVal;
                    break;
                case "s10":
                    value = 10;
                    value += spadeVal;
                    break;
                case "sj":
                    value = 10;
                    value += spadeVal;
                    break;
                case "sq":
                    value = 10;
                    value += spadeVal;
                    break;
                case "sk":
                    value = 10;
                    value += spadeVal;
                    break;
                case "sa":
                    value = 1;
                    value += spadeVal;
                    break;



                case "h2":
                    value = 2;
                    value += heartsVal;
                    break;
                case "h3":
                    value = 3;
                    value += heartsVal;
                    break;
                case "h4":
                    value = 4;
                    value += heartsVal;
                    break;
                case "h5":
                    value = 5;
                    value += heartsVal;
                    break;
                case "h6":
                    value = 6;
                    value += heartsVal;
                    break;
                case "h7":
                    value = 7;
                    value += heartsVal;
                    break;
                case "h8":
                    value = 8;
                    value += heartsVal;
                    break;
                case "h9":
                    value = 9;
                    value += heartsVal;
                    break;
                case "h10":
                    value = 10;
                    value += heartsVal;
                    break;
                case "hj":
                    value = 10;
                    value += heartsVal;
                    break;
                case "hk":
                    value = 10;
                    value += heartsVal;
                    break;
                case "hq":
                    value = 10;
                    value += heartsVal;
                    break;
                case "ha":
                    value = 1;
                    value += heartsVal;
                    break;



                case "c2":
                    value = 2;
                    value += clubsVal;
                    break;
                case "c3":
                    value = 3;
                    value += clubsVal;
                    break;
                case "c4":
                    value = 4;
                    value += clubsVal;
                    break;
                case "c5":
                    value = 5;
                    value += clubsVal;
                    break;
                case "c6":
                    value = 6;
                    value += clubsVal;
                    break;
                case "c7":
                    value = 7;
                    value += clubsVal;
                    break;
                case "c8":
                    value = 8;
                    value += clubsVal;
                    break;
                case "c9":
                    value = 9;
                    value += clubsVal;
                    break;
                case "c10":
                    value = 10;
                    value += clubsVal;
                    break;
                case "cj":
                    value = 10;
                    value += clubsVal;
                    break;
                case "ck":
                    value = 10;
                    value += clubsVal;
                    break;
                case "cq":
                    value = 10;
                    value += clubsVal;
                    break;
                case "ca":
                    value = 1;
                    value += clubsVal;
                    break;



                case "d2":
                    value = 2;
                    value += diamondsVal;
                    break;
                case "d3":
                    value = 3;
                    value += diamondsVal;
                    break;
                case "d4":
                    value = 4;
                    value += diamondsVal;
                    break;
                case "d5":
                    value = 5;
                    value += diamondsVal;
                    break;
                case "d6":
                    value = 6;
                    value += diamondsVal;
                    break;
                case "d7":
                    value = 7;
                    value += diamondsVal;
                    break;
                case "d8":
                    value = 8;
                    value += diamondsVal;
                    break;
                case "d9":
                    value = 9;
                    value += diamondsVal;
                    break;
                case "d10":
                    value = 10;
                    value += diamondsVal;
                    break;
                case "dj":
                    value = 10;
                    value += diamondsVal;
                    break;
                case "dq":
                    value = 10;
                    value += diamondsVal;
                    break;
                case "dk":
                    value = 10;
                    value += diamondsVal;
                    break;
                case "da":
                    value = 1;
                    value += diamondsVal;
                    break;
            }
            return value;
        }

        public void ChooseHigh()
        {
            PlayerChoice = "high";
        }

        public void ChooseLow()
        {
            PlayerChoice = "low";
        }

        public void WinCheck()
        {
            if (PlayerChoice == "high")
            {
                if (PlayerCount > HouseCount)
                {
                    DidPlayerWin = false;
                    GameEnd = true;
                }
                else
                {
                    DidPlayerWin = true;
                    GameEnd = true;
                }
            }
            else
            {
                if (HouseCount > PlayerCount)
                {
                    DidPlayerWin = false;
                    GameEnd = true;
                }
                else
                {
                    DidPlayerWin = true;
                    GameEnd = true;
                }
            }
        }

        public void GetHouseDraw()
        {
            Random rnd = new Random();
            int amountOfCards;
            int randomNumber;

            //draw a card for the house
            amountOfCards = Cards.Count - 1;
            randomNumber = rnd.Next(0, amountOfCards);
            var houseCard = Cards[randomNumber].ToString();
            Cards.RemoveAt(randomNumber);

            var houseCardValue = FindValue(houseCard);
            HouseCount += houseCardValue;
            HouseCardDrawn = houseCard;

        }

        public void GetPlayerDraw()
        {
            Random rnd = new Random();
            int amountOfCards;
            int randomNumber;

            //draw a card for the house
            amountOfCards = Cards.Count - 1;
            randomNumber = rnd.Next(0, amountOfCards);
            var playerCard = Cards[randomNumber].ToString();
            Cards.RemoveAt(randomNumber);

            var playerCardValue = FindValue(playerCard);
            PlayerCount += playerCardValue;
            PlayerCardDrawn = playerCard;

            WinCheck();
        }
    }
}