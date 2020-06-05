using DiscordMonsters.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordMonsters.Context
{
    public partial class MonsterContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _schemaName;
        public MonsterContext(string connectionString)
        {
            //_connectionString = "server=localhost;port=3306;user=devuser;password=Nothing123;database=esports";
            _connectionString = connectionString;
            _schemaName = Settings.GetDatabaseSchemaName();
        }

        public MonsterContext(DbContextOptions<MonsterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<PlayerInventory> PlayerInventory { get; set; }
        public virtual DbSet<Monster> Monster { get; set; }
        public virtual DbSet<LevelExperience> LevelExperience { get; set; }
        public virtual DbSet<PlayerCatch> PlayerCatch { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("player", _schemaName);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item", _schemaName);
            });

            modelBuilder.Entity<PlayerInventory>(entity =>
            {
                entity.ToTable("player_inventory", _schemaName);
            });

            modelBuilder.Entity<Monster>(entity =>
            {
                entity.ToTable("monster", _schemaName);
            });

            modelBuilder.Entity<LevelExperience>(entity =>
            {
                entity.ToTable("level_experience", _schemaName);
            });

            modelBuilder.Entity<PlayerCatch>(entity =>
            {
                entity.ToTable("player_catch", _schemaName);
            });
        }
    }
}
