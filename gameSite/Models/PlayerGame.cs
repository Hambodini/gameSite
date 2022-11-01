using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gameSite.Models
{
    public class PlayerGame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Gameid { get; set; }
        [Required]
        public int Userid { get; set; }
        [Required]
        public string Useremail { get; set; }
    }
}