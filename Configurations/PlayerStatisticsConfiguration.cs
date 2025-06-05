using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Game
{
    /// <summary>
    /// Конфигурация сущности PlayerStatistics
    /// </summary>
    public class PlayerStatisticsConfiguration : IEntityTypeConfiguration<PlayerStatistics>
    {
        /// <summary>
        /// Настройка сущности PlayerStatistics
        /// Устанавливает первичный ключ и связь один-к-одному с сущностью User
        /// </summary>
        public void Configure(EntityTypeBuilder<PlayerStatistics> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.HasOne(ps => ps.User)
                .WithOne(u => u.Statistics)
                .HasForeignKey<PlayerStatistics>(ps => ps.UserId);
        }
    }
}