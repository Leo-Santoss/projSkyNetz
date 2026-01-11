using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projSkyNetz.Model
{
    [Table("planos", Schema = "public")]
    public class PlanosModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome_plano")]
        public string NomePlano { get; set; }

        [Column("minutos_plano")]
        public int MinutosPlano { get; set; }

        [Column("detalhes_plano")]
        public string DetalhesPlano { get; set; }

        [Column("preco_plano")]
        public string PrecoPlano { get; set; }

        public PlanosModel() { }
    }
}