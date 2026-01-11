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

        #region Planos
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
        public DataTable SelecionarUmPlano(int idPlano)
        {
            DataTable dt = new DataTable();

            try
            {
                //Abre a conexão
                OpenConnection();

                string sql = "SELECT * FROM planos WHERE ID = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("id", idPlano);

                    // Converter o que retorna do banco pra DataTable com um adapter
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                    da.Fill(dt);
                }

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
        public int SelecionarIdPlano(int Plano)
        {
            int id = -1;
            try
            {
                OpenConnection();

                // Select com os filtros
                string sql = "SELECT ID FROM planos WHERE MINUTOS_PLANO = @minutos_plano";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection))
                {
                    cmd.Parameters.AddWithValue("minutos_plano", Plano);

                    object resultado = cmd.ExecuteScalar();

                    // Verifica se o resultado é válido
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        id = Convert.ToInt32(resultado);
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
            return id;
        }
        #endregion

        #region Cidades
        public DataTable SelecionarCidades()
        {
            DataTable dt = new DataTable();

            try
            {
                // Abre a conexão
                OpenConnection();

                // Select concatenando o DDD no nome para ficar mais fácil de visualizar as informações no dropdown
                // Além do nome, precisei concatenar o id único no DDD pois itens com values iguais causam um problema,
                // pois ao selecionar qualquer item na lista como um DDD x, ele sempre vai "escolher" o primeiro item o esse DDD x na lista
                string sql = "SELECT NOME_LOCAL || ' (DDD ' || NUM_DDD_LOCAL || ')' AS NOME, NUM_DDD_LOCAL || '|' || ID AS COD FROM locais ORDER BY NUM_DDD_LOCAL";

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
        #endregion

        #region Tarifas
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
        #endregion
    }
}