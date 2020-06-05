using System.ComponentModel.DataAnnotations;

namespace DiscordMonsters.Context.Models
{
    public class PlayerMonster
    {
        public PlayerCatch playerCatch { get; set; }
        public Monster monster { get; set; }
    }
}
