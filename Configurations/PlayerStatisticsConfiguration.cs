using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Game
{
    public class PlayerStatisticsConfiguration : IEntityTypeConfiguration<PlayerStatistics>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistics> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.HasOne(ps => ps.User)
                .WithOne(u => u.Statistics)
                .HasForeignKey<PlayerStatistics>(ps => ps.UserId);
        }
    }
}