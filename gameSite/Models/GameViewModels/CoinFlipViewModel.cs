using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gameSite.Models
{
    public class CoinFlipViewModel
    {
        public int PlayerBet { get; set; }
        public string PlayerChoice { get; set; }
        public string CoinOutcome { get; set; }
        public  List<String> Possibles { get; set; }
        public bool DidPlayerWin { get; set; }
        public bool GameEnd { get; set; }

    }
}