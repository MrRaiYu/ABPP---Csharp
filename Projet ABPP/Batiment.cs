using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ABPP
{
    public class Batiment
    {
        public string Nom { get; set; }
        public string Emplacement { get; set; }
        public string Description { get; set; }

        // Constructeur par défaut
        public Batiment()
        {
            Nom = "";
            Emplacement = "";
            Description = "";
        }

        // Constructeur avec paramètres
        public Batiment(string nom, string emplacement, string description)
        {
            Nom = nom;
            Emplacement = emplacement;
            Description = description;
        }
    }
}
