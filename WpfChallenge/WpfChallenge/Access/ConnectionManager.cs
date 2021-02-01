using MySql.Data.MySqlClient;
using System;

namespace WpfChallenge.Access
{
    public class ConnectionManager
    {
        public ConnectionManager()
        {}

        public MySqlConnection setConnection()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            MySqlConnection connection = new MySqlConnection("Server=localhost;DataBase=ilia_challenge;Uid=root;Pwd=xxx");

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                throw new Exception("Erro interno do sistema");
            }

            return connection;
        }

        public void closeConnection(MySqlConnection connection)
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro interno do sistema");
            }
        }
    }
}
