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
            // on signale l'état de la cellule à "eau" pour dire qu'elle est vide 
            this.etat = etat.eau;

        }
        // créetion d'une methode pour ajouter des bateaux 
        public void ajoutBateau(bateau bateau)
        {
            // on ajoute un bateau 
            this.bateau = bateau;
            // on prévient que la case est utilisée en mettant l'étt à "bateau "
            this.etat = etat.bateau;
        }
        //methode pour le lancement des attaques
        public int attaque()
        {
            // on fait un switch sur l'état des cellules
            switch (this.etat)
            {
                //si il n'y a rien sur l'eau
                case etat.eau:
                    this.etat = etat.plouf;
                    return 3;
                //si il y a un bateau 
                case etat.bateau:
                    // on passe l'état à "boum" pour dire que le bateau a ete touché
                    this.etat = etat.boum;
                    //si le bateau coule
                    if (this.bateau.toucher())
                    {
                        // alors on renvoi "1"
                        return 1;
                    }
                    //sinon c'est qu'il doit encore être toucher avant de couler
                    else
                    {
                        // alors on renvoie "2" 
                        return 2;
                    }
                //si la case à déjà été jouée
                case etat.plouf:
                case etat.boum:
                    // alors on renvoie "4" 
                    return 4;
                default:
                    return 5;
            }
        }
    }
}
