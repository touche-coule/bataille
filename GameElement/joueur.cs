namespace GameElement
{
    public class joueur
    {
        public string Pseudo { get; set; }
        public grille grille { get; set; }

        public joueur(string pseudo)
        {
            this.Pseudo = pseudo;
            this.grille = new grille();
        }
    }
}
