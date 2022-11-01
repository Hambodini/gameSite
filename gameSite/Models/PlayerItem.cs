using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gameSite.Models
{
    public class PlayerItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Inventoryid { get; set; }
        [Required]
        public int Userid { get; set; }
        [Required]
        public int Itemid { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Useremail { get; set; }
    }
}