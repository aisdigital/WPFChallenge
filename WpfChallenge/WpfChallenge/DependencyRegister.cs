using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Domain.Interfaces.Services;
using WpfChallenge.Domain.Interfaces.Repository;
using WpfChallenge.Domain.Services;
using WpfChallenge.Repository.Repositorys;

namespace WpfChallenge
{
    public static class DependencyRegister
    {
        public static void Register(IKernel container)
        {
            container.Bind<IClienteRepository>().To<ClienteRepository>().InTransientScope();
            container.Bind<IClienteServices>().To<ClienteServices>().InTransientScope();
        }

    }
}
