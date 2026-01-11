using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projSkyNetz.Model
{
    [Table("locais", Schema = "public")]
    public class LocaisModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome_local")]
        public string NomeLocal { get; set; }

        [Column("num_ddd_local")]
        public int numDddLocal { get; set; }

        public LocaisModel() { }
        
    }
}