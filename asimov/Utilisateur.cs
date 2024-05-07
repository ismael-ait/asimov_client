namespace asimov
{
    public class Utilisateur
    {
        public int id_utilisateur { get; set; }
        public string mdp { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string date_naissance { get; set; }
        public int id_classe { get; set; }
        public int id_role { get; set; }
        public int id_responsable { get; set; }
    }
}
