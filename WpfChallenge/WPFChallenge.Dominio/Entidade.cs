using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFChallenge.Dominio
{
    public class Entidade
    {
        public Entidade()
        {
            this.DataDoCadastro = DateTime.Now;
        }

        public int Id { get; private set; }
        public DateTime DataDoCadastro { get; private set; }
    }
}
