using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projSkyNetz.Model
{
    public class PlanosModel
    {
        public PlanosModel()
        {
        }

        public PlanosModel(string pId
                          ,string pNomePlano
                          ,string pMinutosPlano
                          ,string pDetalhesPlano
                          ,string pPrecoPlano)
        {
            Id = pId;
            NomePlano = pNomePlano;
            MinutosPlano = pMinutosPlano;
            DetalhesPlano = pDetalhesPlano;
            PrecoPlano = pPrecoPlano;
        }

        public string Id { get; set; }
        public string NomePlano { get; set; }
        public string MinutosPlano { get; set; }
        public string DetalhesPlano { get; set; }
        public string PrecoPlano { get; set; }
    }
}