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

            logger.Info("���� ��������");
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // ������������� Windsor ����������
            var container = new WindsorContainer();

            // ����������� DbContext
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

            // ����������� ������������
            container.Register(
                Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifestyleTransient(),
                Component.For<IGameSessionRepository>().ImplementedBy<GameSessionRepository>().LifestyleTransient(),
                Component.For<ICardRepository>().ImplementedBy<CardRepository>().LifestyleTransient()
            );

            // ����������� ��������
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
                        // �������� ����������� �� ����������
                        var db = container.Resolve<GameDbContext>();

                        // ������ ����� ��������
                        var gameTableForm = new GameTableFormFor2Players(db); 
                        gameTableForm.SetPlayerInGame(sessionId, playerInGameId);

                        Application.Run(gameTableForm);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� ������� ����� ����: {ex.Message}");
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
                MessageBox.Show($"������ ��� ������� �������� ����: {ex.Message}");
            }

            // ��������� �������� �� ������� ����������
            var cultureName = Properties.Settings.Default.Language ?? "ru-RU";
            var culture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

        }
    }
}