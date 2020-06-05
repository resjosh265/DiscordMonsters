using DiscordMonsters.Context;
using DiscordMonsters.Context.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordMonsters.Repository
{
    public class MonsterRepository
    {
        private MonsterContext _monsterContext;

        public MonsterRepository()
        {
            if (_monsterContext != null) return;

            _monsterContext = new MonsterContext(Settings.GetConnectionString("Database"));
        }

        public async Task<Monster> GetRandomMonster()
        {
            var monsterList = await _monsterContext.Monster.ToListAsync();
            return monsterList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }

        public async Task<Player> GetPlayer(string discordId)
        {
            return await _monsterContext.Player.FirstOrDefaultAsync(x => x.DiscordId == discordId);
        }

        public async Task<Player> CreatePlayer(string discordId)
        {
            var player = new Player
            {
                DiscordId = discordId,
                Level = 1
            };

            _monsterContext.Add(player);
            await _monsterContext.SaveChangesAsync();

            return player;
        }

        public async Task IncreasePlayerExperience(Player player, int experience)
        {
            player.Experience += experience;

            var levelRequirements = await _monsterContext.LevelExperience.AsAsyncEnumerable().Where(x => x.ExperienceRequired > player.Experience).FirstOrDefaultAsync();

            if(levelRequirements != null) player.Level = levelRequirements.Level - 1;

            await _monsterContext.SaveChangesAsync();
        }

        public async Task AddPlayerCatch(Player player, Monster monster)
        {
            var playerCatch = new PlayerCatch
            {
                PlayerId = player.PlayerId,
                MonsterId = monster.MonsterId,
                Level = monster.Level
            };

            _monsterContext.PlayerCatch.Add(playerCatch);
            await _monsterContext.SaveChangesAsync();
        }
    }
}
