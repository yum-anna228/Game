namespace Game
{
    /// <summary>
    /// представляет игральную карту
    /// </summary>
    public class Card
    {
        /// <summary>
        /// уникальный идентификатор карты
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// масть карты
        /// </summary>
        public string Suit { get; set; }

        /// <summary>
        /// достоинство карты
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// указывает, является ли карта козырной
        /// </summary>
        public bool IsTrump { get; set; }

        /// <summary>
        /// идентификатор игрока, которому принадлежит карта
        /// </summary>
        public Guid PlayerInGameId { get; set; }

        /// <summary>
        /// Идентификатор игровой сессии, к которой относится карта
        /// </summary>
        public Guid GameSessionId { get; set; }

        /// <summary>
        /// идентификатор хода, в котором была использована эта карта
        /// </summary>
        public Guid? TurnId { get; set; }

        // Навигационные свойства

        /// <summary>
        /// Ссылка на объект, представляющий игрока, которому принадлежит эта карта
        /// </summary>
        public virtual PlayerInGame PlayerInGame { get; set; }

        /// <summary>
        /// Ссылка на объект, представляющий игровую сессию, к которой относится эта карта
        /// </summary>
        public virtual GameSession GameSession { get; set; }

        /// <summary>
        /// Ссылка на объект, представляющий ход, в котором была использована эта карта
        /// </summary>
        public virtual Turn Turn { get; set; }
    }
}