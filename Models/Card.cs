namespace Game
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Suit { get; set; }
        public string Rank { get; set; }
        public bool IsTrump { get; set; }
        public Guid PlayerInGameId { get; set; }
        public Guid GameSessionId { get; set; }
        public Guid? TurnId { get; set; }

        // Навигационные свойства
        public virtual PlayerInGame PlayerInGame { get; set; }
        public virtual GameSession GameSession { get; set; }
        public virtual Turn Turn { get; set; }
    }
}