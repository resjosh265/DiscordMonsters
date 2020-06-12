using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data
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
