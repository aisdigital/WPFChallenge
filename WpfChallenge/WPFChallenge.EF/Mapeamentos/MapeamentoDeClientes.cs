using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChallenge.Dominio.Clientes;

namespace WPFChallenge.EF.Mapeamentos
{
    public class MapeamentoDeClientes : EntityTypeConfiguration<Cliente>
    {
        public MapeamentoDeClientes()
        {
            this.ToTable("Clientes");
        }
    }
}
