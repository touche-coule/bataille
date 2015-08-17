namespace GameElement
{
    // on crée une classe cellule  
    public class cellule
    {
        //on place les differents attributs afin de pouvoir y faire appel 
        public int horizontal { get; set; }
        public int vertical { get; set; }
        public bateau bateau { get; set; }
        public etat etat { get; set; }

        public cellule(int horizontal, int vertical)
        {
            // on initialise les variables de la classe
            // une cellule est definie par son ordonnée et son abcisse 
            this.horizontal = horizontal;
            this.vertical = vertical;
            // on initialise les cellules à false pour dire qu'elles sont inutilisées
            this.etat = etat.eau;
            // on assigne un false a la cellule pour dire qu'elle n'est pas touchée
        }
        // créetion d'une methode pour ajouter des bateaux 
        public void ajoutBateau(bateau bateau)
        {
            // on ajoute un bateau 
            this.bateau = bateau;
            // on prévient que la case est utilisée en mettant assignement à true
            this.etat = etat.bateau;
        }
        //methode pour le lancement des attaques
        public int attaque()
        {

            switch (this.etat)
            {
                case etat.eau:
                    this.etat = etat.plouf;
                    return 3;
                case etat.bateau:
                    this.etat = etat.boum;
                    if (this.bateau.toucher())
                    {
                        // si le bateau est touche alors on renvoi "1"
                        return 1;
                    }
                    else
                    {
                        // si la cellule est assignée à un bateau alors on retourne "2"
                        return 2;
                    }
                case etat.plouf:
                case etat.boum:
                    return 4;
            }
        }
    }
}
