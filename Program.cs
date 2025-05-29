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
        static void Main()
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


            var serviceProvider = services.BuildServiceProvider();
            var gameForm = serviceProvider.GetRequiredService<GameForm>();
            Application.Run(gameForm);
        }
    }
}