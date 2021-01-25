
using System.Threading;
using System.Windows;
using WpfChallenge;
using WpfChallenge.Domain.Interfaces.Repository;
using WpfChallenge.Domain.Interfaces.Services;
using WpfChallenge.Domain.Models;
using WpfChallenge.Domain.Services;
using WpfChallenge.Repository.Data;
using WpfChallenge.Repository.Repositorys;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WpfChallenge.Test
{
    public class ClienteTest
    {
        [Fact]
        public void Salvar_Cliente()
        {

            Cliente cliente = new Cliente
            {
                Nome = "Nome Teste",
                Email = "email@teste.com",
                Telefone = "(61) 87654-3210",
                Endereco = "Endereco Teste"
            };

            Context t = new Context();
            IClienteRepository clienteRepository = new ClienteRepository(t);
            IClienteServices icliente = new ClienteServices(clienteRepository);
            var result = icliente.Save(cliente);

            //Assert
            Assert.IsFalse(result.Success, "Error.");

        }
    }
}
