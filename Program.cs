using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Config;
using NLog.Targets;
using NLog;

namespace Game
{
    internal static class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget("logfile")
            {
                FileName = "log.txt",
                Layout = "${longdate} | ${level:uppercase=true} | ${logger} | ${message}"
            };

            config.AddTarget(fileTarget);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, fileTarget);
            LogManager.Configuration = config;

            logger.Info("Игра запущена");
            


            var services = new ServiceCollection();
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
            services.AddTransient<StatisticsForm>();
            services.AddTransient<RuleForm>();


            var serviceProvider = services.BuildServiceProvider();

            if (args.Length >= 4 && args[0] == "--session" && args[2] == "--player")
            {
                if (Guid.TryParse(args[1], out var sessionId) && Guid.TryParse(args[3], out var playerInGameId))
                {
                    try
                    {
                        var gameTableForm = serviceProvider.GetRequiredService<GameTableFormFor2Players>();
                        gameTableForm.SetPlayerInGame(sessionId, playerInGameId); 
                        Application.Run(gameTableForm);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при запуске формы игры: {ex.Message}");
                    }
                }
            }

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