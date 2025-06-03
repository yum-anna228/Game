using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Game
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            // ���������, ��� appsettings.json ������
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // ����������� ��������� ��
            services.AddDbContext<GameDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // ����������� ������������
            services.AddScoped<IUserRepository, UserRepository>();

            // ����������� ��������
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthService, AuthService>();

            // ����������� ����
            services.AddTransient<LoginForm>();
            services.AddTransient<RegistrForm>();
            services.AddTransient<GameForm>();
            services.AddTransient<SelectModeForm>();
            services.AddTransient<GameTableFormFor2Players>();
            services.AddTransient<StatisticsForm>();


            var serviceProvider = services.BuildServiceProvider();

            if (args.Length >= 4 && args[0] == "--session" && args[2] == "--player")
            {
                if (Guid.TryParse(args[1], out var sessionId) && Guid.TryParse(args[3], out var playerInGameId))
                {
                    try
                    {
                        // �������� ����� ����� DI � ��� ��� ������� ��� �����������, ������� IServiceProvider
                        var gameTableForm = serviceProvider.GetRequiredService<GameTableFormFor2Players>();
                        gameTableForm.SetPlayerInGame(sessionId, playerInGameId); // ����� SetPlayerInGame ������ ���� ����������
                        Application.Run(gameTableForm);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� ������� ����� ����: {ex.Message}");
                    }
                }
            }

            // �� ��������� ��������� ������� ����
            try
            {
                var mainMenu = serviceProvider.GetRequiredService<GameForm>();
                Application.Run(mainMenu);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ������� �������� ����: {ex.Message}");
            }


        }
    }
}