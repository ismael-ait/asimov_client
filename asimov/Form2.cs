using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asimov
{
    public partial class Form2 : Form
    {
        private Utilisateur utilisateur;

        public Form2(Utilisateur utilisateur)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Afficher le message de bienvenue avec les données de l'utilisateur
            string message = $"Bienvenue, {utilisateur.prenom} {utilisateur.nom}";
            labelBienvenue.Text = message;
        }


    }
}