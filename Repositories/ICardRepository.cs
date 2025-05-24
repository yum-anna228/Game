namespace Game
{
    public interface ICardRepository
    {
        Task<List<Card>> GetTrumpCardsAsync(Guid sessionId);
    }
}
