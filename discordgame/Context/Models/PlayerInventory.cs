using System.ComponentModel.DataAnnotations;

namespace DiscordMonsters.Context.Models
{
    public class PlayerInventory
    {
        [Key]
        public int PlayerInventoryId { get; set; }
        public int PlayerId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
    }
}
