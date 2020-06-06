﻿using Discord.WebSocket;
using DiscordMonsters.Context;
using DiscordMonsters.Context.Models;
using DiscordMonsters.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace DiscordMonsters
{
    public class Game
    {
        private MonsterRepository _monsterRepository;
        private ulong _channelId;

        public Monster ActiveMonster;

        private int ActiveMonsterTimer;
        private int MonsterAppearTimer;

        public Game()
        {
            if (_monsterRepository == null) _monsterRepository = new MonsterRepository();

            _channelId = Settings.GetDiscordChannelId();
        }

        public async Task MonsterAppears(DiscordSocketClient client)
        {
            if (ActiveMonster != null)
            {
                var monsterInactivated = await MonsterInactivate(client);

                if (!monsterInactivated) return;
            }

          if (MonsterAppearTimer > 0)
            {
                MonsterAppearTimer -= 1;
                return;
            }

            var channel = client.GetChannel(Settings.GetDiscordChannelId()) as SocketTextChannel;

            if (channel == null) return;

            var minAppearTime = Settings.GetMinMonsterAppearTime();
            var maxAppearTime = Settings.GetMaxMonsterAppearTime();
            var rnd = new Random();

            ActiveMonster = await _monsterRepository.GetRandomMonster();
            ActiveMonster.GenerateLevel();
            MonsterAppearTimer = rnd.Next(minAppearTime, maxAppearTime);
            ActiveMonsterTimer = Settings.GetMonsterActiveMaxTime();

            await channel.SendMessageAsync($"{ActiveMonster.ImageUrl}\n A wild lvl{ActiveMonster.Level} {ActiveMonster.Name} appears!");

            Console.WriteLine($"Spawned new monster {ActiveMonster.Name}");
        }

        public async Task CatchMonster(SocketMessage message)
        {
            if(ActiveMonster == null)
            {
                await message.Channel.SendMessageAsync($"No active monster to catch. Try later.");
                return;
            }

            var player = await _monsterRepository.GetPlayer(message.Author.ToString());

            if (player == null) player = await _monsterRepository.CreatePlayer(message.Author.ToString());

            var catchSuccess = GetCatchSuccess(player);

            if (catchSuccess)
            {
                var catchImageUrl = Settings.GetCatchImageUrl();

                await message.Channel.SendMessageAsync($"{catchImageUrl} \n {player.DiscordId} caught the {ActiveMonster.Name}!");
                await _monsterRepository.IncreasePlayerExperience(player, ActiveMonster.BaseExperienceAward * ActiveMonster.Level);
                await _monsterRepository.AddPlayerCatch(player, ActiveMonster);
                Console.WriteLine($"New monster will spawn in {MonsterAppearTimer} minutes");
                ActiveMonster = null;
            }
            else
            {
                await message.Channel.SendMessageAsync($"{player.DiscordId} failed to catch the {ActiveMonster.Name}! GET RECKT!");
            }
        }

        public async Task GetActiveMonster(SocketMessage message)
        {
            if (ActiveMonster == null)
            {
                await message.Channel.SendMessageAsync($"No active monster to catch. Try later.");
                return;
            }

            await message.Channel.SendMessageAsync($"Active monster is {ActiveMonster.Name}!");
        }

        public async Task GetProfileString(SocketMessage message) {
            var player = await _monsterRepository.GetPlayer(message.Author.ToString());
            if (player == null) player = await _monsterRepository.CreatePlayer(message.Author.ToString());

            var sb = new StringBuilder();
            sb.Append("```" +
                      "User - " + player.DiscordId + "\n" +
                      "Level - " + player.Level + "\n" +
                      "Exp - " + player.Experience + "\n" +
                      "```");  

            await message.Author.SendMessageAsync(sb.ToString());          
        }

        public async Task GetMonsterList(SocketMessage message)
        {
            var player = await _monsterRepository.GetPlayer(message.Author.ToString());
            if (player == null) player = await _monsterRepository.CreatePlayer(message.Author.ToString());

            var list = await _monsterRepository.GetList(player);
            if (!list.Any())
            {
                await message.Channel.SendMessageAsync($"{message.Author.ToString()} does not currently have any Discord monsters");
                return;
            }
            
            var discordMonsterList = $"List of Monsters for {message.Author.ToString()}\n";
            foreach(var item in list){
                discordMonsterList += $"{item.monster.Name} (Level: {item.playerCatch.Level})\n";
            }

            if (message.Content.ToLower().Contains(":public"))
                await message.Channel.SendMessageAsync(discordMonsterList);
            else
                await message.Author.SendMessageAsync(discordMonsterList);
        }

        private bool GetCatchSuccess(Player player)
        {
            if (!Settings.GetSuccessChanceEnabled()) return true;

            float successChance = ((float)player.Level / ActiveMonster.Level);
            var rnd = new Random();

            return rnd.NextDouble() < successChance;
        }

        private async Task<bool> MonsterInactivate(DiscordSocketClient client)
        {
            if(ActiveMonsterTimer > 0)
            {
                ActiveMonsterTimer -= 1;
                return false;
            }

            var channel = client.GetChannel(Settings.GetDiscordChannelId()) as SocketTextChannel;

            await channel.SendMessageAsync($"{ActiveMonster.Name} has ran away!");

            Console.WriteLine($"Despawned monster {ActiveMonster.Name} due to inactivity");

            ActiveMonster = null;

            return true;
        }

        public async Task GetMonsterAppearTimer(SocketMessage message)
        {
            var player = await _monsterRepository.GetPlayer(message.Author.ToString());
            if (player == null) player = await _monsterRepository.CreatePlayer(message.Author.ToString());

            if (player.IsAdmin)
                await message.Channel.SendMessageAsync($"The next Discord monster will appear in {MonsterAppearTimer} minutes.");
        }

        public async Task ClearMessages(SocketMessage message)
        {
            var player = await _monsterRepository.GetPlayer(message.Author.ToString());
            if (player == null) player = await _monsterRepository.CreatePlayer(message.Author.ToString());

            if (player.IsAdmin)
            {
                var messages = await message.Channel.GetMessagesAsync(1000).FlattenAsync();
                await ((ITextChannel)message.Channel).DeleteMessagesAsync(messages);
                const int delay = 3000;
                await Task.Delay(delay);
                await message.DeleteAsync();
                await message.Channel.SendMessageAsync($"Admin {message.Author.ToString()} has cleared the chat.");
            }
        }

        public async Task<bool> CheckIfAdmin(SocketMessage message)
        {
            var player = await _monsterRepository.GetPlayer(message.Author.ToString());
            if (player == null) player = await _monsterRepository.CreatePlayer(message.Author.ToString());
            
            return player.IsAdmin;
        }
    }
}
