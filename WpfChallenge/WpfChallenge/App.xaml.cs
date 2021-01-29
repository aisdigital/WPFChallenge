using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFChallenge.Aplicacao.GestaoDeClientes;
using WPFChallenge.Dominio;
using WPFChallenge.EF;

namespace WpfChallenge
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
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<Contexto>();
            services.AddSingleton<IServicoDeGestaoDeClientes, ServicoDeGestaoDeClientes>();
            services.AddSingleton<IServicoDePersistencia, ServicoExternoDePersistenciaViaEntityFramework>();
            services.AddSingleton<MainWindow>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
