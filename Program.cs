using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows.Forms;

namespace Game
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            // Убедитесь, что appsettings.json найден
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Регистрация контекста БД
            services.AddDbContext<GameDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Регистрация репозиториев
            services.AddScoped<IUserRepository, UserRepository>();

            // Регистрация сервисов
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthService, AuthService>();

            // Регистрация форм
            services.AddTransient<LoginForm>();
            services.AddTransient<RegistrForm>();
            services.AddTransient<GameForm>();
            services.AddTransient<SelectModeForm>();
            services.AddTransient<GameTableFormFor2Players>();
            services.AddTransient<GameTableFormFor3Players>();
            services.AddTransient<StatisticsForm>();


            var serviceProvider = services.BuildServiceProvider();

            if (args.Length >= 4 && args[0] == "--session" && args[2] == "--player")
            {
                if (Guid.TryParse(args[1], out var sessionId) && Guid.TryParse(args[3], out var playerInGameId))
                {
                    try
                    {
                        var dbContext = serviceProvider.GetRequiredService<GameDbContext>();
                        var gameTableForm = new GameTableFormFor2Players(sessionId, playerInGameId, dbContext);
                        Application.Run(gameTableForm);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при запуске формы игры: {ex.Message}");
                    }
                }
            }

            // По умолчанию запускаем главное меню
            try
            {
                var mainMenu = serviceProvider.GetRequiredService<GameForm>();
                Application.Run(mainMenu);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске главного меню: {ex.Message}");
            }


        }
    }
}