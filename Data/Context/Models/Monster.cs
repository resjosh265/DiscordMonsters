using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context.Models
{
    public class Monster
    {
        [Key]
        public int MonsterId { get; set; }
        public string Name { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public int BaseExperienceAward { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public int Level { get; set; }

        public void GenerateLevel()
        {
            if(MaxLevel < MinLevel)
            {
                MinLevel = 1;
                MaxLevel = 100;
            }

            var rnd = new Random();
            Level = rnd.Next(MinLevel, MaxLevel);
        }
    }
}
