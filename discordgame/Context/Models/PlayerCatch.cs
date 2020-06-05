using System.ComponentModel.DataAnnotations;

namespace DiscordMonsters.Context.Models
{
    public class PlayerCatch
    {
        [Key]
        public int PlayerCatchId { get; set; }
        public int PlayerId { get; set; }
        public int MonsterId { get; set; }
        public int Level { get; set; }
    }
}
