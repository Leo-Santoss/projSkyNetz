using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projSkyNetz.DataDAO.Tabelas
{
    public class DbLocais
    {
        public class CidadeComboItem
        {
            // Vai ficar no padrão: "São Paulo (DDD 011)"
            public string ItemNome { get; set; }

            // Vai ficar no padrão: "011|01"
            public string ItemValor { get; set; }
        }

        public List<CidadeComboItem> SelecionarCidades()
        {
            // Retorna uma lista das cidades
            using (var ctx = new SkyNetzContext())
            {
                var listaBruta = ctx.Locais
                                    .OrderBy(l => l.numDddLocal)
                                    .ToList();

                List<CidadeComboItem> listaFormatada = listaBruta.Select(item => new CidadeComboItem
                {
                    // Concatenando o DDD no nome para ficar mais fácil de visualizar as informações no dropdown
                    // Além do nome, precisei concatenar o id único no DDD pois itens com values iguais causam um problema,
                    // pois ao selecionar qualquer item na lista como um DDD x, ele sempre vai "escolher" o primeiro item o esse DDD x na lista
                    ItemNome = $"{item.NomeLocal} (DDD {item.numDddLocal})",
                    ItemValor = $"{item.numDddLocal}|{item.Id}"

                }).ToList();

                return listaFormatada;
            }
        }
    }
}