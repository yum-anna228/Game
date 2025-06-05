using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game
{
    /// <summary>
    /// Конфигурация сущности User 
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Настройка сущности User.
        /// Устанавливает первичный ключ и настраивает обязательные поля:
        /// - Id (первичный ключ)
        /// - Username — логин пользователя, максимум 50 символов
        /// - PasswordHash — хэш пароля пользователя, максимум 255 символов
        /// </summary>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}