using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game
{
    /// <summary>
    /// Конфигурация сущности GameSession
    /// </summary>
    public class GameSessionConfiguration : IEntityTypeConfiguration<GameSession>
    {
        /// <summary>
        /// Настройка сущности GameSession
        /// Устанавливает первичный ключ и свойства:
        /// - Id (первичный ключ)
        /// - TrumpSuit — масть козыря, максимальная длина 20 символов
        /// </summary>
        public void Configure(EntityTypeBuilder<GameSession> builder)
        {
            builder.HasKey(gs => gs.Id);

            builder.Property(gs => gs.TrumpSuit)
                .HasMaxLength(20);
        }
    }
}