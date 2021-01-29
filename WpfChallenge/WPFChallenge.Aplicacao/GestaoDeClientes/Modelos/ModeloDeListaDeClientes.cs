using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChallenge.Dominio.Clientes;

namespace WPFChallenge.Aplicacao.GestaoDeClientes.Modelos
{
    public class ModeloDeListaDeClientes
    {
        public ModeloDeListaDeClientes()
        {
            this.Lista = new List<ModeloDeClienteDaLista>();
        }

        public ModeloDeListaDeClientes(List<Cliente> clientes) : this()
        {
            if (clientes == null)
                return;

            clientes.ForEach(a => this.Lista.Add(new ModeloDeClienteDaLista(a)));
        }


        public List<ModeloDeClienteDaLista> Lista { get; private set; }
    }
}
