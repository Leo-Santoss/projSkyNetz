using projSkyNetz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projSkyNetz.DataDAO.Tabelas
{
    public class DbTarifas
    {
        public List<TarifasModel> SelecionarTarifas()
        {
            // Retorna uma lista de todos as tarifas ordenadas pelo ddd de origem
            using (var ctx = new SkyNetzContext())
            {
                return ctx.Tarifas
                          .OrderBy(p => p.DddOrigem)
                          .ToList();
            }
        }
        public float BuscarTarifaPorDDD(int dddOrigem, int dddDestino)
        {
            // Passa o ddd de origem e o de destino como filtros para retornar a tarifa
            using (var ctx = new SkyNetzContext())
            {
                var tarifaEncontrada = ctx.Tarifas.FirstOrDefault(p => p.DddOrigem == dddOrigem && p.DddDestino == dddDestino);

                if (tarifaEncontrada != null)
                {
                    return Convert.ToSingle(tarifaEncontrada.PrecoTarifa);
                }
            }
            // Retorna -1 se nao achar nada
            return -1;            
        }
    }
}