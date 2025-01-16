using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDIGestionScolaire
{
    internal class Classe
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        ICollection<Etudiant> etudiants { get; set; }
    }
}
