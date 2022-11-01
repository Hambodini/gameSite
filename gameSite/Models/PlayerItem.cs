using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gameSite.Models
{
    public class PlayerItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Inventoryid { get; set; }
        public int Userid { get; set; }
        public int Itemid { get; set; }
        public int Quantity { get; set; }
        public string Useremail { get; set; }
    }
}