namespace Game
{
    /// <summary>
    /// игровая сессия
    /// </summary>
    public class GameSession
    {
        /// <summary>
        /// уникальный идентификатор игровой сессии
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///  Дата и время начала игровой сессии (в формате UTC)
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// дата и время окончания игровой сессии (в формате UTC)
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Указывает, завершена ли игровая сессия
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// Масть, которая является козырной в данной игровой сессии
        /// </summary>
        public string TrumpSuit { get; set; }

        // Навигационные свойства
        /// <summary>
        /// Коллекция объектов, представляющих игроков, участвующих в этой сессии
        /// </summary>
        public virtual ICollection<PlayerInGame> PlayerInGames { get; set; } = new HashSet<PlayerInGame>();

        /// <summary>
        /// Коллекция объектов, представляющих карты, связанные с этой игровой сессией
        /// </summary>
        public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();

        /// <summary>
        /// Коллекция объектов, представляющих ходы, сделанные в рамках этой игровой сессии
        /// </summary>
        public virtual ICollection<Turn> Turns { get; set; } = new HashSet<Turn>();
    }
}