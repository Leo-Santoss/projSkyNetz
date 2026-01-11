using projSkyNetz.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projSkyNetz.DataDAO
{
    public class SkyNetzContext : DbContext
    {
        public SkyNetzContext() : base("name=NeonDb")
        {
        }

        // Tabela Planos
        public DbSet<PlanosModel> Planos { get; set; }

        // Tabela Locais
        public DbSet<LocaisModel> Locais { get; set; }

        // Tabela Tarifas
        public DbSet<TarifasModel> Tarifas { get; set; }

    }
}