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

        public bool Atualizar(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var sql = $@"UPDATE dbo.Cliente
                                SET 
                                     Nome = @Nome
                                    ,Email = @Email
                                    ,Telefone = @Telefone
                                    ,CEP = @CEP
                                    ,UF = @UF
                                    ,Cidade = @Cidade
                                    ,Bairro = @Bairro
                                    ,Logradouro = @Logradouro
                                    ,Numero = @Numero
                                    ,Complemento = @Complemento
                                    ,DataEdicao = @DataEdicao
                                WHERE Id=@Id ";
                    var teste =connection.Execute(sql, cliente);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Excluir(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var sql = $@"DELETE FROM dbo.Cliente WHERE Id=@Id";
                    connection.Execute(sql, new { id });
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Cliente Get(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var sql = $@"SELECT  Id
                                        ,Nome
                                        ,Email
                                        ,Telefone
                                        ,CEP
                                        ,UF
                                        ,Cidade
                                        ,Bairro
                                        ,Logradouro
                                        ,Numero
                                        ,Complemento
                                        ,DataCadastro
                                        ,DataEdicao
                                    FROM dbo.Cliente
                                    WHERE Id=@Id";

                    return connection.Query<Cliente>(sql, new { id }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro em ClienteRepository - Get(): {ex.Message}", ex);
                }
            }
        }

        public IEnumerable<Cliente> Listar()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var sql = $@"SELECT  Id
                                        ,Nome
                                        ,Email
                                        ,Telefone
                                        ,CEP
                                        ,UF
                                        ,Cidade
                                        ,Bairro
                                        ,Logradouro
                                        ,Numero
                                        ,Complemento
                                        ,DataCadastro
                                        ,DataEdicao
                                    FROM dbo.Cliente";

                    return connection.Query<Cliente>(sql);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro em ClienteRepository - Listar(): {ex.Message}", ex);
                }
            }
        }
    }
}
