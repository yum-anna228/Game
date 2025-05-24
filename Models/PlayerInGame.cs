using System;

namespace Game
{
    public class PlayerInGame
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GameSessionId { get; set; }
        public int Position { get; set; }
        public bool IsAttacker { get; set; }
        public bool IsDefender { get; set; }

        // Навигационные свойства
        public virtual User User { get; set; }
        public virtual GameSession GameSession { get; set; }
    }
}