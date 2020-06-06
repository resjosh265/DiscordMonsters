using DiscordMonsters.Context;
using DiscordMonsters.Context.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var monsterList = await _monsterContext.Monster.AsAsyncEnumerable().ToListAsync();
            return monsterList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }

        public async Task<Player> GetPlayer(string discordId)
        {
            return await _monsterContext.Player.AsAsyncEnumerable().FirstOrDefaultAsync(x => x.DiscordId == discordId);
        }

        public async Task<Player> CreatePlayer(string discordId)
        {
            var player = new Player
            {
                DiscordId = discordId,
                Level = 1,
                IsAdmin = false
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

        public async Task<List<PlayerMonster>> GetList(Player player){
            var playerCatches = await _monsterContext.PlayerCatch.AsAsyncEnumerable().Where(x => x.PlayerId == player.PlayerId).ToListAsync();
            var playerMonsters = new List<PlayerMonster>();
            
            foreach(var playerCatch in playerCatches){
                PlayerMonster pm = new PlayerMonster();
                pm.playerCatch = playerCatch;
                pm.monster = await _monsterContext.Monster.AsAsyncEnumerable().FirstOrDefaultAsync(x => x.MonsterId == playerCatch.MonsterId);

                playerMonsters.Add(pm);
            }

            return playerMonsters.OrderBy(x => x.monster.Name).ThenBy(x => x.playerCatch.Level).ToList();
        }
    }
}
