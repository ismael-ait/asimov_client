using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace asimov
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client;

        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/");
        }

        private async void connexBtn_Click(object sender, EventArgs e)
        {
            string id = loginTextBox.Text;
            string password = passwordTextBox.Text;

            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("id", id),
                    new KeyValuePair<string, string>("password", password)
                });

                var response = await client.PostAsync("api/login", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var utilisateur = JsonConvert.DeserializeObject<Utilisateur>(responseBody);

                    if (utilisateur.id_role == 3) 
                    {
                        Form3 form3 = new Form3(utilisateur);
                        form3.Show();

                    } else

                    {
                        Form2 form2 = new Form2(utilisateur);
                        form2.Show();  
                        this.Hide();


                    }
                    this.Hide(); // Masquez le formulaire actuel si nécessaire
                }
                else
                {
                    MessageBox.Show("Identifiants incorrects.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion : " + ex.Message);
            }
        }

    }
}
