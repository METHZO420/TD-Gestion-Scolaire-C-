using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDIGestionScolaire
{
    internal class Etudiant
    {
        public int Id {  get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public int IdClasse { get; set; }

       public Classe Classe { get; set; }


    }
}
