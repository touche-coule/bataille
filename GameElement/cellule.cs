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
                case etat.eau:
                    this.etat = etat.plouf;
                    return 3;
                    // et du bateau 
                case etat.bateau:
                    // l'état est a "boum" pour dire que le bateau a ete touché
                    this.etat = etat.boum;
                    if (this.bateau.toucher())
                    {
                        // si le bateau est touche alors on renvoi "1"
                        return 1;
                    }
                    else
                    {
                        
                        return 2;
                    }
                   
                case etat.plouf:
                   
                case etat.boum:
                    return 4;
                default:
                    return 5;
            }
        }
    }
}
