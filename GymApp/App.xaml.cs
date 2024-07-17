using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows;
using GymApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            // Caly czas uzywa bazy w bin ??!!! jak to zmienic ? 
            string dbPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\gymapp.db");
            MessageBox.Show($"Sciezka {dbPath}");

            services.AddDbContext<GymAppContext>(options =>
                options.UseSqlite($"Data Source={dbPath}")); // Configure SQLite

            services.AddSingleton<MainWindow>(); // Rejestracja MainWindow jako singleton
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
            if (mainWindow == null)
            {
                MessageBox.Show("MainWindow is not registered in the service provider.");
                Application.Current.Shutdown();
                return;
            }

            MessageBox.Show("MainWindow successfully retrieved from service provider.");
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
