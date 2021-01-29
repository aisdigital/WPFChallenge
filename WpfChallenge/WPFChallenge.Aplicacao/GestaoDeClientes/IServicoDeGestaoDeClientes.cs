using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChallenge.Aplicacao.GestaoDeClientes.Modelos;

namespace WPFChallenge.Aplicacao.GestaoDeClientes
{
    public interface IServicoDeGestaoDeClientes
    {
        void Cadastrar(ModeloDeCadastroDeCliente modelo);

        void Editar(ModeloDeEdicaoDeCliente modelo);

        void Excluir(int clienteId);

        ModeloDeListaDeClientes Listar();
    }
}
