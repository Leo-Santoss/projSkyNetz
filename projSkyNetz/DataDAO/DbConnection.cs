using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Net; // Necessário para configurar o TLS 1.2

namespace projSkyNetz.DataDAO
{
    public class DbConnection
    {
        protected NpgsqlConnection Connection;

        // Abrir conexão
        protected void OpenConnection()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                if (Connection == null)
                {
                    string connString = ConfigurationManager.ConnectionStrings["NeonDb"].ConnectionString;
                    Connection = new NpgsqlConnection(connString);
                }

                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar no banco de dados: " + ex.Message);
            }
        }

        // Fechar conexão
        protected void CloseConnection()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}