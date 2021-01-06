using Infrastructure.Repositories;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Handlers;
using Ninject;

namespace Shared
{
    public static class DependencyRegister
    {
        public static void Register(IKernel container)
        {
            container.Bind<IClienteRepository>().To<ClienteRepository>().InTransientScope();
            container.Bind<ClienteHandler>().To<ClienteHandler>().InTransientScope();
        }
    }
}
