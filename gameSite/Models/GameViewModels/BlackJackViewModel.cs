using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gameSite.Models
{
    public class BlackJackViewModel
    {
        public int Round { get; set; }
        public int PlayerBet { get; set; }
        public int PlayerCount { get; set; }
        public int HouseCount { get; set; }
        public List<String> Cards { get; set; }
        public string HouseCardDrawn { get; set; }
        public string PlayerCardDrawn { get; set; }
        public bool DidPlayerWin { get; set; }
        public bool DidPlayerDoubleDown { get; set; }
        public bool GameEnd { get; set; }
        public bool WasDraw { get; set; }
        public int FindValue(String card)
        {
            int value = 0;
            switch (card)
            {
                case "s2":
                    value = 2;
                    break;
                case "s3":
                    value = 3;
                    break;
                case "s4":
                    value = 4;
                    break;
                case "s5":
                    value = 5;
                    break;
                case "s6":
                    value = 6;
                    break;
                case "s7":
                    value = 7;
                    break;
                case "s8":
                    value = 8;
                    break;
                case "s9":
                    value = 9;
                    break;
                case "s10":
                    value = 10;
                    break;
                case "sj":
                    value = 10;
                    break;
                case "sq":
                    value = 10;
                    break;
                case "sk":
                    value = 10;
                    break;
                case "sa":
                    value = 1;
                    break;



                case "h2":
                    value = 2;
                    break;
                case "h3":
                    value = 3;
                    break;
                case "h4":
                    value = 4;
                    break;
                case "h5":
                    value = 5;
                    break;
                case "h6":
                    value = 6;
                    break;
                case "h7":
                    value = 7;
                    break;
                case "h8":
                    value = 8;
                    break;
                case "h9":
                    value = 9;
                    break;
                case "h10":
                    value = 10;
                    break;
                case "hj":
                    value = 10;
                    break;
                case "hk":
                    value = 10;
                    break;
                case "hq":
                    value = 10;
                    break;
                case "ha":
                    value = 1;
                    break;



                case "c2":
                    value = 2;
                    break;
                case "c3":
                    value = 3;
                    break;
                case "c4":
                    value = 4;
                    break;
                case "c5":
                    value = 5;
                    break;
                case "c6":
                    value = 6;
                    break;
                case "c7":
                    value = 7;
                    break;
                case "c8":
                    value = 8;
                    break;
                case "c9":
                    value = 9;
                    break;
                case "c10":
                    value = 10;
                    break;
                case "cj":
                    value = 10;
                    break;
                case "ck":
                    value = 10;
                    break;
                case "cq":
                    value = 10;
                    break;
                case "ca":
                    value = 1;
                    break;



                case "d2":
                    value = 2;
                    break;
                case "d3":
                    value = 3;
                    break;
                case "d4":
                    value = 4;
                    break;
                case "d5":
                    value = 5;
                    break;
                case "d6":
                    value = 6;
                    break;
                case "d7":
                    value = 7;
                    break;
                case "d8":
                    value = 8;
                    break;
                case "d9":
                    value = 9;
                    break;
                case "d10":
                    value = 10;
                    break;
                case "dj":
                    value = 10;
                    break;
                case "dq":
                    value = 10;
                    break;
                case "dk":
                    value = 10;
                    break;
                case "da":
                    value = 1;
                    break;
            }
            return value;
        }

        public void Draw()
        {

            Random rnd = new Random();
            int amountOfCards;
            int randomNumber;
            if (HouseCount < 17)
            {
                //draw a card for the house
                amountOfCards = Cards.Count - 1;
                randomNumber = rnd.Next(0, amountOfCards);
                var houseCard = Cards[randomNumber].ToString();
                Cards.RemoveAt(randomNumber);

                //add value to house set card drawn
                var houseCardValue = FindValue(houseCard);
                HouseCount += houseCardValue;
                HouseCardDrawn = houseCard;
                //Model.HouseCount = updatedHouseCount;
            }
            else
            {
                HouseCardDrawn = "nothing";
            }

            //draw a card for the player
            amountOfCards = Cards.Count - 1;
            randomNumber = rnd.Next(0, amountOfCards);
            var playerCard = Cards[randomNumber].ToString();
            Cards.RemoveAt(randomNumber);

            //add value to player and set card drawn
            var playerCardValue = FindValue(playerCard);
            PlayerCount += playerCardValue;
            PlayerCardDrawn = playerCard;

            WinCheck();

            Round++;
        }
        public void WinCheck()
        {
            if (PlayerCount <= 21)
            {
                if (HouseCount > 21)
                {
                    DidPlayerWin = true;
                    GameEnd = true;
                }
                if (PlayerCount == 21)
                {
                    DidPlayerWin = true;
                    GameEnd = true;
                }
            }
            else if (HouseCount <= 21)
            {
                if (PlayerCount > 21)
                {
                    DidPlayerWin = false;
                    GameEnd = true;
                }
                if (HouseCount == 21)
                {
                    DidPlayerWin = false;
                    GameEnd = true;
                }
            }
            else if (HouseCount > 21)
            {
                if (PlayerCount > 21)
                {
                    WasDraw = true;
                    GameEnd = true;
                }
            }
            else if (HouseCount == 21 && PlayerCount == 21)
            {
                WasDraw = true;
                GameEnd = true;
            }
        }

    }
}