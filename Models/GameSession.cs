using System;
using System.Collections.Generic;

namespace Game
{
    /// <summary>
    /// игровая сессия
    /// </summary>
    public class GameSession
    {
        /// <summary>
        /// уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsFinished { get; set; }
        public string TrumpSuit { get; set; }

        // Навигационные свойства
        public virtual ICollection<PlayerInGame> PlayerInGames { get; set; } = new HashSet<PlayerInGame>();
        public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();
        public virtual ICollection<Turn> Turns { get; set; } = new HashSet<Turn>();
    }
}