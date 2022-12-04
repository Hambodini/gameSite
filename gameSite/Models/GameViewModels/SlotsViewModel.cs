using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gameSite.Models
{
    public class SlotsViewModel
    {
        public SlotsViewModel()
        {
            Cards = new List<String> { "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "sj", "sq", "sk", "sa", "h2", "h3", "h4", "h5", "h6", "h7", "h8", "h9", "h10", "hj", "hq", "hk", "ha", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10", "cj", "cq", "ck", "ca", "d2", "d3", "d4", "d5", "d6", "d7", "d8", "d9", "d10", "dj", "dq", "dk", "da" };
            DidPlayerWin = false;
            DidPlayerStand = false;
            DidPlayerDoubleDown = false;
            GameEnd = false;
            HouseCount = 0;
            PlayerCount = 0;
            Round = 1;
        }

        public int Round { get; set; }
        public int PlayerBet { get; set; }
        public int PlayerCount { get; set; }
        public int HouseCount { get; set; }
        public List<String> Cards { get; set; }
        public string HouseCardDrawn { get; set; }
        public string PlayerCardDrawn { get; set; }
        public bool DidPlayerWin { get; set; }
        public bool DidPlayerStand { get; set; }
        public bool DidPlayerDoubleDown { get; set; }
        public bool GameEnd { get; set; }
        public bool WasDraw { get; set; }

        internal void Spin()
        {
            throw new NotImplementedException();
        }
    }
}