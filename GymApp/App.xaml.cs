using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using GymApp.Context;
using System;

namespace GymApp
{

    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<BootstrapDB>(); // Ensure BootstrapDB is singleton
            services.AddSingleton<MainWindow>();
            services.AddTransient<LogBookPage>();
            services.AddTransient<TrainingPage>();
            services.AddTransient<StatisticsPage>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        public ServiceProvider ServiceProvider => serviceProvider;
    }

}
