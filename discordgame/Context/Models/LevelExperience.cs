using System.ComponentModel.DataAnnotations;

namespace DiscordMonsters.Context.Models
{
    public class LevelExperience
    {
        [Key]
        public int LevelExperienceId { get; set; }
        public int Level { get; set; }
        public int ExperienceRequired { get; set; }
    }
}
