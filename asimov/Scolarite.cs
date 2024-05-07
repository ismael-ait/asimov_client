using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asimov
{
    public class Scolarite
    {
        public string nom { get; set; } // Ajout de la propriété nom pour l'utilisateur
        public string libelle_classe { get; set; } // Ajout de la propriété libelle_classe

        public int id_classe { get; set; }
        public int numero_semestre { get; set; }
        public decimal moyenne_semestre { get; set; }
        public string annee_scolaire { get; set; }
        public int id_utilisateur { get; set; }
        public bool estvalide { get; set; }
        public int id_scolarite { get; set; }

    }

}
