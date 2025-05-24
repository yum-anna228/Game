using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
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