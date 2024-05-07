using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asimov
{
    internal class ListeEleve
    {
        private List<Utilisateur> listeEleve = new List<Utilisateur>();

        public List<Utilisateur> Utilisateurs
        {
            get { return listeEleve; }
        }


    }
}