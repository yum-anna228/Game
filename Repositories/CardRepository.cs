using Microsoft.EntityFrameworkCore;

namespace Game
{
    public class CardRepository : ICardRepository
    {
        private readonly GameDbContext _db;

        public CardRepository(GameDbContext db) => _db = db;

        /// <summary>
        /// Реализация поиска козырных карт
        /// </summary>
        public async Task<List<Card>> GetTrumpCardsAsync(Guid sessionId)
            => await _db.Cards.Where(c => c.GameSessionId == sessionId && c.IsTrump).ToListAsync();
    }
}
