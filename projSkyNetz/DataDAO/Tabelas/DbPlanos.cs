using Npgsql;
using projSkyNetz.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace projSkyNetz.DataDAO
{
    public class DbPlanos
    {
        public List<PlanosModel> SelecionarPlanos()
        {
            // Retorna uma lista de todos os planos ordenado pelos minutos
            using (var ctx = new SkyNetzContext())
            {
                return ctx.Planos
                          .OrderBy(p => p.MinutosPlano)
                          .ToList();
            }
        }
        public PlanosModel SelecionarUmPlano(int idPlano)
        {
            // Passa o ID como o filtro para retornar o plano escolhido
            using (var ctx = new SkyNetzContext())
            {
                int idStr = Convert.ToInt32(idPlano);
                return ctx.Planos.FirstOrDefault(p => p.Id == idStr);
            }
        }
        public int SelecionarIdPlano(int minutos)
        {
            // Recebe a quantidade de minutos e retorna o ID do plano
            using (var ctx = new SkyNetzContext())
            {
                int minutosStr = minutos;

                var planoEncontrado = ctx.Planos.FirstOrDefault(p => p.MinutosPlano == minutosStr);

                if (planoEncontrado != null)
                {
                    return planoEncontrado.Id;
                }

                // Retorna -1 se nao achar nada
                return -1;
            }
        }
    }
}