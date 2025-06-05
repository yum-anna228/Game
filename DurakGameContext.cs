using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Game
{
    /// <summary>
    /// Контекст базы данных приложения
    /// Содержит DbSet для всех сущностей и настраивает модель через конфигурации
    /// </summary>
    public class GameDbContext : DbContext
    {
        /// <summary>
        ///  Инициализирует новый экземпляр
        /// </summary>
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Набор пользователей в базе данных
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Набор игровых сессий
        /// </summary>
        public DbSet<GameSession> GameSessions { get; set; }

        /// <summary>
        /// Набор записей о участии игроков в играх
        /// </summary>
        public DbSet<PlayerInGame> PlayerInGames { get; set; }

        /// <summary>
        /// Набор карт в игре
        /// </summary>
        public DbSet<Card> Cards { get; set; }

        /// <summary>
        /// Набор ходов (раундов) в рамках сессии игры
        /// </summary>
        public DbSet<Turn> Turns { get; set; }

        /// <summary>
        /// Набор статистики по игрокам
        /// </summary>
        public DbSet<PlayerStatistics> PlayerStatistics { get; set; }


        /// <summary>
        /// Настройка модели базы данных: применение конфигураций сущностей
        /// </summary>
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