using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows;
using GymApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GymApp
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        private static Mutex mutex = null;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<GymAppContext>(options =>
                options.UseSqlite("Data Source=gymapp.db")); // Configure SQLite
            services.AddSingleton<MainWindow>();
            services.AddTransient<LogBookPage>();
            services.AddTransient<TrainingPage>();
            services.AddTransient<StatisticsPage>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "GymApp";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                // The application is already running
                Application.Current.Shutdown();
                return;
            }

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (mutex != null)
            {
                mutex.ReleaseMutex();
                mutex = null;
            }

            base.OnExit(e);
        }

        public ServiceProvider ServiceProvider => serviceProvider;
    }
}
