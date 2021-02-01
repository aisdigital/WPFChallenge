using MySql.Data.MySqlClient;
using System;
using System.Data;
using WpfChallenge.Access;
using WpfChallenge.Models;

namespace WpfChallenge.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        ConnectionManager _connection;
        MySqlCommand cmd = null;

        public ClienteRepository()
        {
            _connection = new ConnectionManager();
        }

        /// <summary>
        /// Obtem todos os  Clientes existentes
        /// </summary>
        /// <returns>Uma tabela de dados(DataTable)</returns>
        public DataTable Get()
        {
            try
            {
                cmd = new MySqlCommand("Select * From clientes", _connection.setConnection());
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                return dt;
            }
            catch (Exception)
            {
                throw new NotFoundException("Erro interno do sistema.");
            }
            finally
            {
                if (cmd != null) _connection.closeConnection(cmd.Connection);
            }
        }

        /// <summary>
        /// Obtem um Cliente pelo seu Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Uma tabela de dados(DataTable)</returns>
        public DataTable Get(int Id)
        {
            try
            {
                cmd = new MySqlCommand("Select * From clientes Where IdCliente = " + Id, _connection.setConnection());
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                return dt;
            }
            catch (Exception)
            {
                throw new NotFoundException("Erro interno do sistema.");
            }
            finally
            {
                if (cmd != null) _connection.closeConnection(cmd.Connection);
            }
        }

        /// <summary>
        /// Insere um novo Cliente
        /// </summary>
        /// <remarks>
        /// Exemplo de inserção:
        /// Clinete cliente = new Cliente()
        /// { 
        /// Name = "TesteXunit12", 
        /// Email = "TesteXunit12@gmail.com", 
        /// Address = "Endereço12 Teste", 
        /// Phone = "2121212121" };
        /// </remarks>
        /// <param name="cliente">Objeto Cliente</param>
        /// <returns>tabela de dados(DataTable) com os dados inseridos</returns>
        public DataTable Post(Cliente cliente)
        {
            try
            {
                Int32 newID = 0;
                string isQuery = string.Empty;
                cmd = new MySqlCommand(isQuery, _connection.setConnection());

                isQuery = "Insert Into clientes(Name, Email, Phone, Address) ";
            
                isQuery += "Values(@varName"; 
                cmd.Parameters.AddWithValue("@varName", cliente.Name);
            
                isQuery += ", @varEmail";
                cmd.Parameters.AddWithValue("@varEmail", cliente.Email);
            
                isQuery += ", @varPhone";
                cmd.Parameters.AddWithValue("@varPhone", cliente.Phone);

                isQuery += ", @varAddress";
                cmd.Parameters.AddWithValue("@varAddress", cliente.Address);

                isQuery += ")";

                cmd.CommandText = isQuery;
                cmd.ExecuteNonQuery();

                string queryReturn = "Select @@Identity";
                cmd.CommandText = queryReturn;
                newID = Convert.ToInt32(cmd.ExecuteScalar());

                return Get(newID);
            }
            catch (Exception)
            {
                throw new NotFoundException("Erro interno do sistema ao tentar Inserir um Cliente.");
            }
            finally
            {
                if (cmd != null) _connection.closeConnection(cmd.Connection);
            }
        }

        /// <summary>
        /// Atualiza um Cliente existente
        /// </summary>
        /// <param name="cliente">Objeto Cliente</param>
        /// <returns>tabela de dados(DataTable) com os dados atualizados</returns>
        public DataTable Put(Cliente cliente)
        {
            try
            {
                string isQuery = "Update clientes Set Name = @varName, Email = @varEmail, Phone = @varPhone, Address =  @varAddress Where IdCliente = " + cliente.IdCliente;

                cmd = new MySqlCommand(isQuery, _connection.setConnection());
                cmd.Parameters.AddWithValue("@varName", cliente.Name);
                cmd.Parameters.AddWithValue("@varEmail", cliente.Email);
                cmd.Parameters.AddWithValue("@varPhone", cliente.Phone);
                cmd.Parameters.AddWithValue("@varAddress", cliente.Address);
                cmd.ExecuteNonQuery();

                return Get(cliente.IdCliente);
            }
            catch (Exception)
            {
                throw new NotFoundException("Erro interno do sistema ao tentar atualizar um Cliente.");
            }
            finally
            {
                if (cmd != null) _connection.closeConnection(cmd.Connection);
            }
        }

        /// <summary>
        /// Deleta um Cliente existente
        /// </summary>
        /// <param name="Id">Id de um cliente existente</param>
        /// <returns>true caso a deleção realizada com sucesso</returns>
        public bool Delete(int Id)
        {
            try
            {
                string isQuery = "Delete From clientes Where IdCliente = " + Id;
                cmd = new MySqlCommand(isQuery, _connection.setConnection());

                return (cmd.ExecuteNonQuery() > 0) ? true : false;

            }
            catch (Exception)
            {
                throw new NotFoundException("Erro interno do sistema.");
            }
            finally
            {
                if (cmd != null) _connection.closeConnection(cmd.Connection);
            }
        }

    }
}
