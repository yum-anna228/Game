using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game
{
    public class PlayerInGameConfiguration : IEntityTypeConfiguration<PlayerInGame>
    {
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