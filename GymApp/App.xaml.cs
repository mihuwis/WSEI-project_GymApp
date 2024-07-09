using System.Configuration;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using GymApp.Context;
using System;

namespace GymApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
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
            services.AddSingleton<BootstrapDB>();
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
