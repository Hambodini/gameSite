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
        public  List<String> Cards { get; set; }

    }
}