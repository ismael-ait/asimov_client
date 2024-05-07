using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace asimov
{
    public partial class Form3 : Form
    {
        private Utilisateur utilisateur;
        private readonly HttpClient client;
        public Form3(Utilisateur utilisateur)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/");
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            string message = $"Bienvenue, {utilisateur.prenom} {utilisateur.nom}";
            labelNom.Text = message;

            try
            {
                var response = await client.GetAsync("api/liste");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    var listeEleves = JsonConvert.DeserializeObject<List<Utilisateur>>(jsonResponse.eleves.ToString());



                    // Créer une liste de KeyValuePair pour stocker les ID et les noms des élèves
                    var elevesKeyValue = new List<KeyValuePair<int, string>>();

                    foreach (var eleve in listeEleves)
                    {
                        elevesKeyValue.Add(new KeyValuePair<int, string>(eleve.id_utilisateur, $"{eleve.prenom} {eleve.nom}"));
                        // Ajouter le nom de l'élève et son ID à la liste
                    }

                    // Remplir le ComboBox avec les noms des élèves
                    cbListeEleve.DataSource = elevesKeyValue;
                    cbListeEleve.DisplayMember = "Value"; // Afficher le nom de l'élève
                    cbListeEleve.ValueMember = "Key"; // Stocker l'ID de l'élève
                }
                else
                {
                    MessageBox.Show("Impossible de récupérer les données des élèves");
                }
            }
            catch (Exception ex)
            {
            }

        }




        private async void cbListeEleve_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Vérifier si un élève est sélectionné
            if (cbListeEleve.SelectedItem != null)
            {
                // Récupérer l'objet KeyValuePair de l'élève sélectionné
                KeyValuePair<int, string> selectedKeyValuePair = (KeyValuePair<int, string>)cbListeEleve.SelectedItem;

                // Récupérer l'ID de l'élève à partir de l'objet KeyValuePair
                int eleveId = selectedKeyValuePair.Key;

                try
                {
                    // Faire une requête GET à l'URL construite en ajoutant le chemin de l'API au préfixe de l'URL
                    var response = await client.GetAsync($"api/note{eleveId}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Lire le contenu de la réponse
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
                        var scolarite = JsonConvert.DeserializeObject<List<Scolarite>>(jsonResponse.scolarite.ToString());

                        // Créer un DataTable pour stocker les données de la scolarité

                        DataTable dt = new DataTable();

                        dt.Columns.Add("Nom");
                        dt.Columns.Add("Classe");
                        dt.Columns.Add("Semestre");
                        dt.Columns.Add("Moyenne");
                        dt.Columns.Add("Année scolaire");
                        dt.Columns.Add("ID_Scolarité");

                        // Remplir le DataTable avec les données de la listeScolarite
                        foreach (var notes in scolarite)
                        {
                            dt.Rows.Add(notes.nom, notes.libelle_classe, notes.numero_semestre, notes.moyenne_semestre, notes.annee_scolaire, notes.id_scolarite);
                        }

                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Impossible de récupérer les notes de l'élève");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la connexion : " + ex.Message);
                }
            }
        }

     
    }
}

     
    
