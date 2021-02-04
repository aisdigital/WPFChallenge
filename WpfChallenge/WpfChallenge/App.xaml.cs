using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySchool.Infra.Data.Repositories.Context;
using System.Windows;
using WpfChallenge.Data.IoC;

namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
