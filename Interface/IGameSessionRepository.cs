namespace Game
{
    public interface IGameSessionRepository
    {
        Task<GameSession?> GetByIdWithPlayersAsync(Guid id);
        Task<List<GameSession>> GetActiveSessionsAsync();
        Task AddAsync(GameSession session);
        Task UpdateAsync(GameSession session);
    }
}
