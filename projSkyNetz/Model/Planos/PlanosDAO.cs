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

        public DataTable SelecionarPlanos()
        {
            DataTable dt = new DataTable();

            try
            {
                //Abre a conexão
                OpenConnection();

                string sql = "SELECT * FROM planos ORDER BY MINUTOS_PLANO";

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

        public DataTable SelecionarCidades()
        {
            DataTable dt = new DataTable();

            try
            {
                // Abre a conexão
                OpenConnection();

                // Select concatenando o DDD no nome para ficar mais fácil de visualizar as informações no dropdown
                string sql = "SELECT NOME_LOCAL || ' (DDD ' || NUM_DDD_LOCAL || ')' AS NOME, NUM_DDD_LOCAL AS COD FROM locais ORDER BY NUM_DDD_LOCAL";

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

        public DataTable SelecionarTarifas()
        {
            DataTable dt = new DataTable();

            try
            {
                //Abre a conexão
                OpenConnection();

                string sql = "SELECT DDD_ORIGEM, DDD_DESTINO, PRECO_TARIFA FROM tarifa ORDER BY DDD_ORIGEM";

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

        public float BuscarTarifaPorDDD(int dddOrigem, int dddDestino)
        {
            float preco = -1;
            try
            {
                OpenConnection();

                // Select com os filtros
                string sql = "SELECT PRECO_TARIFA FROM tarifas WHERE DDD_ORIGEM = @origem AND DDD_DESTINO = @destino";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("origem", dddOrigem);
                    cmd.Parameters.AddWithValue("destino", dddDestino);

                    object resultado = cmd.ExecuteScalar(); 

                    // Verifica se o resultado é válido
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        preco = Convert.ToSingle(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return preco;
        }
    }
}