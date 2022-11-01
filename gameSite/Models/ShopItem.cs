using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gameSite.Models
{
    public class ShopItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Itemid { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Name { get; set; }
    }
}