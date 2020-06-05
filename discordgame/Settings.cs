using Microsoft.Extensions.Configuration;
using System.IO;

namespace DiscordMonsters
{
    public static class Settings
    {
        public static IConfigurationRoot configuration;
        public static void GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
        }

        public static string GetConnectionString(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            return configuration.GetSection("ConnectionStrings").GetValue<string>(key);
        }

        public static string GetDiscordUserToken()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            return configuration.GetValue<string>("Discord:UserToken");
        }

        public static ulong GetDiscordChannelId()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            return configuration.GetValue<ulong>("Discord:ChannelId");
        }

        public static int GetMonsterActiveMaxTime()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            return configuration.GetValue<int>("MonsterActiveTime");
        }

        public static int GetMinMonsterAppearTime()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            return configuration.GetValue<int>("MinMonsterAppearTime");
        }

        public static int GetMaxMonsterAppearTime()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            return configuration.GetValue<int>("MinMonsterAppearTime") * configuration.GetValue<int>("MonsterAppearModifer");
        }

        public static string GetCatchImageUrl()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            return configuration.GetValue<string>("CatchImageUrl");
        }

        public static bool GetSuccessChanceEnabled()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            return configuration.GetValue<bool>("EnableSuccessChance");
        }

        public static string GetDatabaseSchemaName()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            return configuration.GetValue<string>("Database:Schema");
        }
    }
}
