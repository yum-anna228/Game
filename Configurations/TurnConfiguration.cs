using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game
{
    public class TurnConfiguration : IEntityTypeConfiguration<Turn>
    {
        public void Configure(EntityTypeBuilder<Turn> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.GameSession)
                .WithMany(gs => gs.Turns)
                .HasForeignKey(t => t.GameSessionId);

            builder.HasOne(t => t.AttackerPlayerInGame)
                .WithMany()
                .HasForeignKey(t => t.AttackerPlayerInGameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.DefenderPlayerInGame)
                .WithMany()
                .HasForeignKey(t => t.DefenderPlayerInGameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}