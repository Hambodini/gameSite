using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace gameSite.Models
{
    public class Cap
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Cap(string UserID, int Amount)
        {
            this.UserID = UserID;
            this.Amount = Amount;
        }
        public Cap()
        {
        }

        [Key]
        public string UserID { get; set; }
        public int Amount { get; set; }

        public int getCurrentUserAmount(string userID)
        {
            Cap currentCap = db.Caps.Find(userID);
            return currentCap.Amount;
        }
    }
}