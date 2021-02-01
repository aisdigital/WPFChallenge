using MySql.Data.MySqlClient;
using System;
using System.Data;
using WpfChallenge.Models;
using WpfChallenge.Repository;
using Xunit;

namespace XUnitTest
{

    public class ClientesUnitTest
    {
        static IClienteRepository _clienteRepository;
        public static string connectionString = "Server=localhost;DataBase=ilia_challenge;Uid=root;Pwd=V@gn3r811973";

        static ClientesUnitTest()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
        }

        public ClientesUnitTest()
        {
            _clienteRepository = new ClienteRepository();
        }

        [Fact]
        public void GetClientes_Return_OkResult()
        {
            //Arrange
            _clienteRepository = new ClienteRepository();
            
            //Act
            var data = _clienteRepository.Get();

            //Assert
            Assert.IsType<DataTable>(data);
        }

        [Fact]
        public void PostCliente_Add_ValidData_Return()
        {
            //Arrange
            _clienteRepository = new ClienteRepository();

            var cliente = new Cliente()
            { Name = "TesteXunit12", Email = "TesteXunit12@gmail.com", Address = "Endereço12 Teste", Phone = "2121212121" };

            //Act
            var data = _clienteRepository.Post(cliente);

            //Assert
            Assert.IsType<DataTable>(data);
        }

        [Fact]
        public void Put_Cliente_Return_CreatedResult()
        {
            //Arrange
            _clienteRepository = new ClienteRepository();

            //Act
            var data = _clienteRepository.Get(9);
            DataRow[] rows = data.Select();
            Cliente cliente = new Cliente();
            cliente.IdCliente = Convert.ToInt32(rows[0].ItemArray[0].ToString());
            cliente.Name = "TesteXunitTest";
            cliente.Email = "TesteXunit@hotmail.com";
            cliente.Phone = "1111111111";
            cliente.Address = "TesteXunit Address";
            var updateData = _clienteRepository.Put(cliente);


            //Assert
            Assert.IsType<DataTable>(updateData);
        }

        [Fact]
        public void Delete_Cliente_Return_OkResult()
        {
            //Arrange
            _clienteRepository = new ClienteRepository();

            //Act
            var data = _clienteRepository.Delete(12);

            //Assert
            Assert.IsType<bool>(data);
        }
    }
}
