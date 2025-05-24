namespace Game
{
    public class PlayerStatistics
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int GamesDraw { get; set; }

        // Навигационные свойства
        public virtual User User { get; set; }
    }
}