using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game
{
    /// <summary>
    /// Конфигурация сущности Turn
    /// </summary>
    public class TurnConfiguration : IEntityTypeConfiguration<Turn>
    {
        /// <summary>
        /// Настройка сущности Turn
        /// Устанавливает первичный ключ и связи:
        /// - Связь с GameSession через GameSessionId
        /// - Связь с атакующим игроком (PlayerInGame) через AttackerPlayerInGameId
        /// - Связь с защищающимся игроком (PlayerInGame) через DefenderPlayerInGameId
        /// Указывает, что удаление игрока или сессии не должно каскадно удалять ходы.
        /// </summary>
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