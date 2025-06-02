namespace Game
{
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// Хэширует указанный пароль с использованием алгоритма BCrypt
        /// </summary>
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Проверяет, соответствует ли предоставленный пароль указанному хэшированному значению
        /// </summary>
        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        }
    }
}
