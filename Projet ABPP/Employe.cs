using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_ABPP
{
    public class Employe
    {
        public string Nom { get; set; }
        public string Habilitation { get; set; }
        public string Photo { get; set; }

        // Constructeur par défaut
        public Employe()
        {
            Nom = "";
            Habilitation = "";
            Photo = "";
        }

        // Constructeur avec paramètres
        public Employe(string nom, string habilitation, string photo)
        {
            Nom = nom;
            Habilitation = habilitation;
            Photo = photo;
        }
    }
}
