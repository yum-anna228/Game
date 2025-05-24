using System;
using System.Collections.Generic;

namespace Game
{
    /// <summary>
    /// класс, который представляет пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// логин
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// пароль
        /// </summary>
        public string PasswordHash { get; set; }

        // Навигационные свойства
        public virtual ICollection<PlayerInGame> PlayerInGames { get; set; } = new HashSet<PlayerInGame>();

        /// <summary>
        /// статистика игрока
        /// </summary>
        public virtual PlayerStatistics Statistics { get; set; }
    }
}