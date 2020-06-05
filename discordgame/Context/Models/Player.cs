using System.ComponentModel.DataAnnotations;

namespace DiscordMonsters.Context.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string DiscordId { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
    }
}
