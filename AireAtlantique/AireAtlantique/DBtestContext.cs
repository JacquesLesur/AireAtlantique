using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireAtlantique
{
    /// <summary>
    /// Contexte de liaison à la base de données
    /// </summary>
    class DBtestContext : DbContext
    {
        public DBtestContext()
            : base("AireAtlantique")
        { }

        public virtual DbSet<Employe> Employes { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Formation> Formations { get; set; }

        public virtual DbSet<Metier> Metier { get; set; }

    }
}
