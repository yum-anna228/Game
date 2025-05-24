using System;

namespace Game
{
    public class Turn
    {
        public Guid Id { get; set; }
        public Guid GameSessionId { get; set; }
        public Guid AttackerPlayerInGameId { get; set; }
        public Guid DefenderPlayerInGameId { get; set; }
        public DateTime Timestamp { get; set; }

        // Навигационные свойства
        public virtual GameSession GameSession { get; set; }
        public virtual PlayerInGame AttackerPlayerInGame { get; set; }
        public virtual PlayerInGame DefenderPlayerInGame { get; set; }
        public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();
    }
}