using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game
{
    /// <summary>
    /// Конфигурация сущности PlayerInGame
    /// </summary>
    public class PlayerInGameConfiguration : IEntityTypeConfiguration<PlayerInGame>
    {
        /// <summary>
        /// Настройка сущности PlayerInGame
        /// Устанавливает первичный ключ и связи:
        /// - Связь с User через UserId (один ко многим)
        /// - Связь с GameSession через GameSessionId (один ко многим
        public void Configure(EntityTypeBuilder<PlayerInGame> builder)
        {
            builder.HasKey(pig => pig.Id);

            builder.HasOne(pig => pig.User)
                .WithMany(u => u.PlayerInGames)
                .HasForeignKey(pig => pig.UserId);

            builder.HasOne(pig => pig.GameSession)
                .WithMany(gs => gs.PlayerInGames)
                .HasForeignKey(pig => pig.GameSessionId);
        }
    }
}