using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MDIGestionScolaire
{
    internal class DBScolaire : DbContext
    {
        public DBScolaire() : base("ecoleConnect")
        {
           
        }
        public DbSet<Classe>Classes { get; set; }
        public DbSet<Etudiant> Etudiants { get;set; }
    }
}
