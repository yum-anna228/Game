using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Game
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<PlayerInGame> PlayerInGames { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<PlayerStatistics> PlayerStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GameSessionConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerInGameConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new TurnConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerStatisticsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}