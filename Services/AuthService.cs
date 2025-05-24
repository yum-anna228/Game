using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepo, IPasswordHasher passwordHasher)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            if (await _userRepo.GetByUsernameAsync(username) != null) return false;

            var hashedPassword = _passwordHasher.HashPassword(password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = hashedPassword
            };

            await _userRepo.AddAsync(user);
            return true;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _userRepo.GetByUsernameAsync(username); 
            if (user == null || !_passwordHasher.VerifyPassword(user.PasswordHash, password)) return null;

            return user;
        }
    }
}
