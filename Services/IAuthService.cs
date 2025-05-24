namespace Game
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(string username, string password);
        Task<User?> LoginAsync(string username, string password);
    }
}
