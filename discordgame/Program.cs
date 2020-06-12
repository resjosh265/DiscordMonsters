using Discord.WebSocket;
using Discord;
using System;
using System.Threading.Tasks;
using System.Text;

namespace DiscordMonsters
{
    class Program
    {
        private DiscordSocketClient _client;
        private string _token;
        private Game _game;
        private const int _tickRate = 60000; //milliseconds

        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _game = new Game();
            _token = Settings.GetDiscordUserToken();
            _client = new DiscordSocketClient();

            await _client.LoginAsync(TokenType.Bot, _token);

            await ListenerAsync();
        }

        private async Task ListenerAsync()
        {
            Console.WriteLine("Started game server, listening...");

            await _client.StartAsync();

            _client.MessageReceived += ProcessMessage;

            while (_client.Status.ToString() == "Online")
            {
                if (_client.ConnectionState.ToString() == "Connecting" || _client.ConnectionState.ToString() == "Disconnected") continue;

                await _game.MonsterAppears(_client);
                await Task.Delay(_tickRate);
            }
        }

        private async Task ProcessMessage(SocketMessage message)
        {
            switch (message.Content.ToLower())
            {
                case "!catch":
                    await _game.CatchMonster(message);
                    break;
                case "!active":
                    await _game.GetActiveMonster(message);
                    break;
                case "!profile":
                    await _game.GetProfileString(message);
                    break;
                case "!list":
                    await _game.GetMonsterList(message);
                    break;
                case "!list:public":
                    await _game.GetMonsterList(message);
                    break;
                case "!help":
                    var response = await BuildHelpString();
                    await message.Author.SendMessageAsync(response);
                    break;
                case "!web":
                    if (!Settings.WebInterfaceEnabled()) break;
                    var senderId = message.Author.ToString();
                    senderId = senderId.Replace("#", "%23");
                    await message.Channel.SendMessageAsync($"{Settings.GetWebInterfaceUrl()}?discordId={senderId}");
                    break;
                case "!admin:clear_messages":
                    await _game.ClearMessages(message);
                    break;
                case "!admin:monster_timer":
                    await _game.GetMonsterAppearTimer(message);
                    break;
                case "!admin:help":
                    var adminResponse = await BuildAdminHelpString(message);
                    await message.Author.SendMessageAsync(adminResponse);
                    break;
            }

            if (message.Content.ToLower().Contains("!admin:say"))
            {
                await _game.SayMessage(message, _client);
            }
        }

        private async Task<string> BuildHelpString()
        {
            var sb = new StringBuilder();

            sb.Append("```" +
                "!active - Get the active monster in play\n" +
                "!catch - Attempt to catch the active monster\n" +
                "!list - Display your Discord monsters in a DM\n" +
                "!list:public - Display your Discord monsters in game chat\n" +
                "!profile - Display the player profile in a DM\n" +
                "!web - Display your public profile web interface\n" +
                "!help - Display this menu" +
                "```");

            return sb.ToString();
        }

        private async Task<string> BuildAdminHelpString(SocketMessage message)
        {
            var IsAdmin = _game.CheckIfAdmin(message);

            var sb = new StringBuilder();

            sb.Append("```" +
                "!admin:clear_messages - Clears all messages\n" +
                "!admin:monster_timer - Get the time in minutes until the next monster spawns\n" +
                "!admin:say - Say something from the bot\n" +
                "!admin:help - Display this menu" +
                "```");

            return sb.ToString();
        }
    }
}
