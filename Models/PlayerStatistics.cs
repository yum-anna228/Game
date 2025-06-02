namespace Game
{
    /// <summary>
    /// представляет статистику игрока
    /// </summary>
    public class PlayerStatistics
    {

        /// <summary>
        ///  Уникальный идентификатор записи статистики
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит данная статистика
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Количество выигранных игр пользователем
        /// </summary>
        public int GamesWon { get; set; }

        /// <summary>
        /// Количество проигранных игр пользователем
        /// </summary>
        public int GamesLost { get; set; }

        /// <summary>
        /// Количество сыгранных пользователем партий вничью
        /// </summary>
        public int GamesDraw { get; set; }

        // Навигационные свойства
        /// <summary>
        ///  Ссылка на объект, которому принадлежит данная статистика
        /// </summary>
        public virtual User User { get; set; }
    }
}