using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game
{
    /// <summary>
    /// Конфигурация сущности Card
    /// </summary>
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        /// <summary>
        /// Настройка сущности Card
        /// Устанавливает ключи, свойства и связи с другими сущностями:
        /// - Primary Key: Id
        /// - Связь с PlayerInGame через PlayerInGameId
        /// - Связь с GameSession через GameSessionId
        /// - Связь с Turn через TurnId
        /// </summary>
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Suit)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.Rank)
                .IsRequired()
                .HasMaxLength(5);

            builder.HasOne(c => c.PlayerInGame)
                .WithMany()
                .HasForeignKey(c => c.PlayerInGameId);

            builder.HasOne(c => c.GameSession)
                .WithMany(gs => gs.Cards)
                .HasForeignKey(c => c.GameSessionId);

            builder.HasOne(c => c.Turn)
                .WithMany(t => t.Cards)
                .HasForeignKey(c => c.TurnId)
                .IsRequired(false);
        }
    }
}