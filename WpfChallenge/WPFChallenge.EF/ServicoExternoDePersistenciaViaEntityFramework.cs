using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChallenge.Dominio;
using WPFChallenge.Dominio.Clientes;
using WPFChallenge.EF.Repositorios;

namespace WPFChallenge.EF
{
    public class ServicoExternoDePersistenciaViaEntityFramework : IServicoDePersistencia, IDisposable
    {
        private readonly Contexto _contexto;

        public ServicoExternoDePersistenciaViaEntityFramework(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public IRepositorioDeClientes RepositorioDeClientes => new RepositorioDeClientes(this._contexto);

        public void Dispose()
        {
            if (this._contexto != null)
                this._contexto.Dispose();

            GC.SuppressFinalize(this);
        }

        public void Persistir()
        {
            this._contexto.SaveChanges();
        }
    }
}
