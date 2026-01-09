using Npgsql;
using System;
using System.Data;

namespace projSkyNetz.Model
{
    // Herda de DbConnection
    public class PlanosDAO : DbConnection
    {
        public void teste()
        {
            try
            {
                OpenConnection(); 

                string sql = "SELECT * FROM planos;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable Selecionar_planos()
        {
            DataTable dt = new DataTable();

            try
            {
                //Abre a conexão
                OpenConnection();

                string sql = "SELECT * FROM planos ORDER BY NOME_PLANO";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection);

                // Converter o que retorna do banco pra DataTable com um adapter
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Independente do que acontecer, fecha a conexão
                CloseConnection();
            }
        }

        public DataTable Selecionar_cidades()
        {
            DataTable dt = new DataTable();

            try
            {
                //Abre a conexão
                OpenConnection();

                string sql = "SELECT NOME_LOCAL AS NOME, NUM_DDD_LOCAL AS COD FROM locais ORDER BY NUM_DDD_LOCAL";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection);

                // Converter o que retorna do banco pra DataTable com um adapter
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Independente do que acontecer, fecha a conexão
                CloseConnection();
            }
        }
    }
}