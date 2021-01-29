using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChallenge.Dominio.Clientes;

namespace WPFChallenge.Tests
{
    [TestClass]
    public class ClientesTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarSeNomeEObrigatorio()
        {
            var cliente = new Cliente("", "natanaelsantosbr@gmail.com","(61)3070-1038", "SHIS 712");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarSeEmailEObrigatorio()
        {
            var cliente = new Cliente("Natanael", "", "(61)3070-1038", "SHIS 712");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarSeTelefoneEObrigatorio()
        {
            var cliente = new Cliente("Natanael", "natanaelsantosbr@gmail.com", "", "SHIS 712");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestarSeEnderecoEObrigatorio()
        {
            var cliente = new Cliente("Natanael", "natanaelsantosbr@gmail.com", "(61)3070-1038", "");
        }

        [TestMethod]
        public void TestarAlteracaoDeDados()
        {
            var cliente = new Cliente("Natanael", "natanaelsantosbr@gmail.com", "(61)3070-1038", "QN 120 Conjunto B ");

            cliente.AlterarDados(cliente.Nome, cliente.Email, "(61)98114-5923", cliente.Endereco);
        }

    }
}
