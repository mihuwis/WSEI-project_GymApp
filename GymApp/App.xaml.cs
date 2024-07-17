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
        private static Mutex mutex = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// Configures services and builds the service provider.
        /// </summary>
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Configures the services required by the application.
        /// </summary>
        /// <param name="services">The service collection to add services to.</param>
        public void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<BootstrapDB>(); // Ensure BootstrapDB is singleton
            services.AddSingleton<MainWindow>();
            services.AddTransient<LogBookPage>();
            services.AddTransient<TrainingPage>();
            services.AddTransient<StatisticsPage>();
        }

        /// <summary>
        /// Handles the startup event of the application.
        /// Ensures that only one instance of the application is running.
        /// </summary>
        /// <param name="e">The startup event data.</param>
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

        /// <summary>
        /// Handles the exit event of the application.
        /// Releases the mutex when the application exits.
        /// </summary>
        /// <param name="e">The exit event data.</param>
        protected override void OnExit(ExitEventArgs e)
        {
            if (mutex != null)
            {
                mutex.ReleaseMutex();
                mutex = null;
            }

            base.OnExit(e);
        }

        /// <summary>
        /// Gets the service provider for the application.
        /// </summary>
        public ServiceProvider ServiceProvider => serviceProvider;
    }
}
