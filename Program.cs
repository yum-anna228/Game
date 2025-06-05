using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog.Config;
using NLog.Targets;
using NLog;
using Castle.Windsor;
using Component = Castle.MicroKernel.Registration.Component;
using System.Globalization;

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
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Инициализация Windsor контейнера
            var container = new WindsorContainer();

            // Регистрация DbContext
            container.Register(
                Component.For<GameDbContext>()
                    .UsingFactoryMethod(kernel =>
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<GameDbContext>();
                        optionsBuilder.UseNpgsql(connectionString);
                        return new GameDbContext(optionsBuilder.Options);
                    })
                    .LifestyleTransient()
            );

            // Регистрация репозиториев
            container.Register(
                Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifestyleTransient(),
                Component.For<IGameSessionRepository>().ImplementedBy<GameSessionRepository>().LifestyleTransient(),
                Component.For<ICardRepository>().ImplementedBy<CardRepository>().LifestyleTransient()
            );

            // Регистрация сервисов
            container.Register(
                Component.For<IAuthService>().ImplementedBy<AuthService>().LifestyleTransient(),
                Component.For<IPasswordHasher>().ImplementedBy<PasswordHasher>().LifestyleTransient(),
                Component.For<DeckService>().LifestyleTransient()
            );

            if (args.Length >= 4 && args[0] == "--session" && args[2] == "--player")
            {
                if (Guid.TryParse(args[1], out var sessionId) && Guid.TryParse(args[3], out var playerInGameId))
                {
                    try
                    {
                        // Получаем зависимости из контейнера
                        var db = container.Resolve<GameDbContext>();

                        // Создаём форму напрямую
                        var gameTableForm = new GameTableFormFor2Players(db); 
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
                var authService = container.Resolve<IAuthService>();
                var db = container.Resolve<GameDbContext>();

                Application.Run(new GameForm(authService, db));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске главного меню: {ex.Message}");
            }

            // Установка культуры до запуска приложения
            var cultureName = Properties.Settings.Default.Language ?? "ru-RU";
            var culture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

        }
    }
}