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
                case "!help":
                    var response = await BuildHelpString();
                    await message.Author.SendMessageAsync(response);
                    break;
            }
        }

        private async Task<string> BuildHelpString()
        {
            var sb = new StringBuilder();

            sb.Append("```" +
                "!active - Get the active monster in play\n" +
                "!catch - Attempt to catch the active monster\n" +
                "!list - Display your Discord monsters\n" +
                "!profile - Display the player profile in a DM\n" +
                "!help - Display this menu" +
                "```");

            return sb.ToString();
        }
    }
}
