using Microsoft.EntityFrameworkCore;

namespace Game
{
    public class UserRepository : IUserRepository
    {
        private readonly GameDbContext _db;

        public UserRepository(GameDbContext db) => _db = db;

        /// <summary>
        /// реализация поиска пользователя по имени
        /// </summary>
        public async Task<User?> GetByUsernameAsync(string username)
            => await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

        /// <summary>
        /// Реализация получения пользователя с его статистикой
        /// </summary>
        public async Task<User?> GetWithStatisticsAsync(Guid userId)
            => await _db.Users.Include(u => u.Statistics).FirstOrDefaultAsync(u => u.Id == userId);

        /// <summary>
        /// добавляет пользователя в бд
        /// </summary>
        public async Task AddAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }
    }
}
