using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gameSite.Models
{
    public class PlayerItem
    {

        public PlayerItem(int Itemid, string ItemName, string Userid, string Useremail, int Quantity)
        {
            this.Itemid = Itemid;
            this.ItemName = ItemName;
            this.Userid = Userid;
            this.Useremail = Useremail;
            this.Quantity = Quantity;
        }

        public PlayerItem()
        {

        }

        public PlayerItem(string Userid, int Itemid, string ItemName, int Quantity, string Useremail)
        {
            this.Userid = Userid;
            this.Itemid = Itemid;
            this.ItemName = ItemName;
            this.Quantity = Quantity;
            this.Useremail = Useremail;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Userid { get; set; }
        [Required]
        public int Itemid { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Useremail { get; set; }
    }
}