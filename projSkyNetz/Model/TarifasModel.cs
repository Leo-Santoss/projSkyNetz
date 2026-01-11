using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projSkyNetz.Model
{
    [Table("tarifas", Schema = "public")]
    public class TarifasModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ddd_origem")]
        public int DddOrigem { get; set; }

        [Column("ddd_destino")]
        public int DddDestino { get; set; }

        [Column("preco_tarifa")]
        public decimal PrecoTarifa { get; set; }

        public TarifasModel() { }
        
    }
}