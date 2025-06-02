using System;

namespace Game
{
    /// <summary>
    /// Представляет участника игры в контексте конкретной игровой сессии
    /// </summary>
    public class PlayerInGame
    {
        /// <summary>
        /// Уникальный идентификатор участника в рамках текущей игровой сессии
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя, участвующего в игре
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор игровой сессии, к которой относится данный игрок
        /// </summary>
        public Guid GameSessionId { get; set; }

        /// <summary>
        /// Позиция игрока за столом
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Указывает, является ли игрок атакующим
        /// </summary>
        public bool IsAttacker { get; set; }

        /// <summary>
        /// Указывает, является ли игрок обороняющимся
        /// </summary>
        public bool IsDefender { get; set; }

        // Навигационные свойства
        /// <summary>
        ///  Ссылка на объект, представляющий пользователя, участвующего в игре
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Ссылка на объект, представляющий игровую сессию, к которой относится этот игрок
        /// </summary>
        public virtual GameSession GameSession { get; set; }
    }
}