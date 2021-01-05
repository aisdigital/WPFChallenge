using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string connectionString = "Data Source=prd-01.database.windows.net;Database=IlliaDigital;Persist Security Info=True;User Id=walisson;Password=VGY&8uhb;";


        public void Cadastrar(Cliente cliente)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var sql = $@"INSERT INTO dbo.Cliente
                                (Id,Nome,Email,Telefone,CEP,UF,Cidade,Bairro,Logradouro,Numero,Complemento,DataCadastro)
                                VALUES
                                (@Id,@Nome,@Email,@Telefone,@CEP,@UF,@Cidade,@Bairro,@Logradouro,@Numero,@Complemento,GETDATE())";
                    
                    var result = connection.Execute(sql, cliente);

                    //return true;
                }
                catch (Exception ex)
                {
                   // return false;
                }
            }
        }
    }
}
