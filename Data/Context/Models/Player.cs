using System.ComponentModel.DataAnnotations;

namespace Data.Context.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string DiscordId { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public bool IsAdmin { get; set; }
    }
}
