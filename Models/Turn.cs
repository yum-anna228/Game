using System;

namespace Game
{
    /// <summary>
    /// представляет игровой ход
    /// </summary>
    public class Turn
    {
        /// <summary>
        /// Уникальный идентификатор хода
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор игровой сессии, к которой относится данный ход
        /// </summary>
        public Guid GameSessionId { get; set; }

        /// <summary>
        /// Идентификатор игрока, совершающего ход (атакующего)
        /// </summary>
        public Guid AttackerPlayerInGameId { get; set; }

        /// <summary>
        /// Идентификатор игрока, защищающегося в этом ходе
        /// </summary>
        public Guid DefenderPlayerInGameId { get; set; }

        /// <summary>
        /// Время совершения хода (в формате UTC)
        /// </summary>
        public DateTime Timestamp { get; set; }

        // Навигационные свойства
        /// <summary>
        /// Ссылка на объект, представляющий игровую сессию, к которой относится этот ход
        /// </summary>
        public virtual GameSession GameSession { get; set; }

        /// <summary>
        /// Ссылка на объект, представляющий атакующего игрока в этом ходе
        /// </summary>
        public virtual PlayerInGame AttackerPlayerInGame { get; set; }

        /// <summary>
        ///  Ссылка на объект, представляющий обороняющегося игрока в этом ходе
        /// </summary>
        public virtual PlayerInGame DefenderPlayerInGame { get; set; }

        /// <summary>
        ///  Коллекция объектов, представляющих карты, использованные в этом ходе
        /// </summary>
        public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();
    }
}