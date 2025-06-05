namespace Game
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetWithStatisticsAsync(Guid userId);
        Task AddAsync(User user);
    }
}
