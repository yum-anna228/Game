using Microsoft.EntityFrameworkCore;

namespace Game
{
    public class GameSessionRepository : IGameSessionRepository
    {
        private readonly GameDbContext _db;

        public GameSessionRepository(GameDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// загружает сессию с игроками
        /// </summary>
        public async Task<GameSession?> GetByIdWithPlayersAsync(Guid id)
        {
            return await _db.GameSessions
                .Include(gs => gs.PlayerInGames)
                .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(gs => gs.Id == id);
        }

        /// <summary>
        /// возвращает незавершенные сессии
        /// </summary>
        public async Task<List<GameSession>> GetActiveSessionsAsync()
        {
            return await _db.GameSessions
                .Where(gs => !gs.IsFinished)
                .ToListAsync();
        }

        /// <summary>
        /// добавляет новую сессию
        /// </summary>
        public async Task AddAsync(GameSession session)
        {
            await _db.GameSessions.AddAsync(session);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// обновляет существующую сессию
        /// </summary>
        public async Task UpdateAsync(GameSession session)
        {
            _db.GameSessions.Update(session);
            await _db.SaveChangesAsync();
        }
    }
}