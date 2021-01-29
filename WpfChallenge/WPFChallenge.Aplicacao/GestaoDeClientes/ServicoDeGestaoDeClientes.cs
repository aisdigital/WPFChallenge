using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChallenge.Aplicacao.GestaoDeClientes.Modelos;
using WPFChallenge.Dominio;
using WPFChallenge.Dominio.Clientes;

namespace WPFChallenge.Aplicacao.GestaoDeClientes
{
    public class ServicoDeGestaoDeClientes : IServicoDeGestaoDeClientes
    {
        private readonly IServicoDePersistencia _servicoDePersistencia;

        public ServicoDeGestaoDeClientes(IServicoDePersistencia servicoDePersistencia)
        {
            this._servicoDePersistencia = servicoDePersistencia;
        }

        public void Cadastrar(ModeloDeCadastroDeCliente modelo)
        {
            var cliente = new Cliente(modelo.Nome, modelo.Email, modelo.Telefone, modelo.Endereco);

            this._servicoDePersistencia.RepositorioDeClientes.Cadastrar(cliente);

            this._servicoDePersistencia.Persistir();
        }

        public void Editar(ModeloDeEdicaoDeCliente modelo)
        {
            var cliente = this._servicoDePersistencia.RepositorioDeClientes.BuscarPorId(modelo.Id);

            if (cliente == null)
                return;

            cliente.AlterarDados(modelo.Nome, modelo.Endereco, modelo.Telefone, modelo.Endereco);

            this._servicoDePersistencia.Persistir();
        }

        public void Excluir(int clienteId)
        {
            var cliente = this._servicoDePersistencia.RepositorioDeClientes.BuscarPorId(clienteId);

            if (cliente == null)
                return;

            this._servicoDePersistencia.RepositorioDeClientes.Excluir(cliente);

            this._servicoDePersistencia.Persistir();
        }

        public ModeloDeListaDeClientes Listar()
        {
            var clientes = this._servicoDePersistencia.RepositorioDeClientes.Listar();

            return new ModeloDeListaDeClientes(clientes);
        }
    }
}
