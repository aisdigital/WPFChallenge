using Infrastructure.Repositories;
using Domain.Repositories;
using Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
//using Unity;
using Domain.Handlers;
using Ninject;

namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();

            container.Bind<IClienteRepository>().To<ClienteRepository>().InTransientScope();
            container.Bind<ClienteHandler>().To<ClienteHandler>().InTransientScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MainWindow>();
            Current.MainWindow.Title = "DI with Ninject";
        }
    }
}
