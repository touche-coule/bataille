namespace GameElement
{
    public class grille
    {
        //on initialise une grille avec 10 lignes et 10 colonnes
        public const int horizontal = 10;


        public const int vertical = 10;



        private bateau porteAvion = new bateau(type.porte_avion, 5);

        public bateau PorteAvion
        {
            get { return porteAvion; }
            set { porteAvion = value; }
        }
        private bateau croiseur = new bateau(type.croiseur, 4);

        public bateau Croiseur
        {
            get { return croiseur; }
            set { croiseur = value; }
        }
        private bateau contreTorpilleur = new bateau(type.contre_torpilleur, 3);

        public bateau ContreTorpilleur
        {
            get { return contreTorpilleur; }
            set { contreTorpilleur = value; }
        }
        private bateau sousMarin = new bateau(type.sous_marin, 3);

        public bateau SousMarin
        {
            get { return sousMarin; }
            set { sousMarin = value; }
        }
        private bateau torpilleur1 = new bateau(type.torpilleur, 2);

        public bateau Torpilleur1
        {
            get { return torpilleur1; }
            set { torpilleur1 = value; }
        }
        private bateau torpilleur2 = new bateau(type.torpilleur, 2);

        public bateau Torpilleur2
        {
            get { return torpilleur2; }
            set { torpilleur2 = value; }
        }
        //la grilles contient des cellules qui ont une ordonnée et une abcisse
        public cellule[,] tab = new cellule[horizontal, vertical];
        // on crée la grille avec le nombre de colonnes et de ligens 

        public grille()
        {
            for (int y = 0; y < horizontal; y++)
            {
                for (int x = 0; x < vertical; x++)
                {
                    tab[y, x] = new cellule(y, x);
                }
            }
        }

        // on ajoute un bateau selon une cellule de départ et une direction 
        public bool ajoutBateau(bateau bateau, cellule cellule, direction direction)
        {
            int taille = bateau.taille;
            int x = cellule.x;
            int y = cellule.y;
            // on vérifie le placement d'un bateau en position verticale vers le bas 

            switch (direction)
            {
                case direction.bas:
                    //on vérifie si il y a asser de place pour le placement du bateau 
                    // la taille du bateau + la valeur de la cellule de départ ne peut dépasser la longueur totale de la colonne
                    if (y + taille <= 10)
                    {
                        // on initialise une variable bool à true 
                        bool ok = true;
                        // on fait une boucle pour la taille du bateau  
                        for (int i = 0; i < taille; i++)
                        {
                            if (tab[y+i, x].etat != etat.eau)
                            {
                                ok = false;
                            }
                        }

                        if (ok)
                        {
                            // on fait une boucle pour la taille du bateau
                            for (int i = 0; i < taille; i++)
                            {
                                // on place le bateau 
                                tab[y+i, x].ajoutBateau(bateau);

                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                case direction.haut:
                    //la taille de vérification doit être inversée du fait qu'on remonte vers la cellule 0 
                    if (y - taille >= 0)
                    {
                        bool ok = true;
                        for (int i = 0; i < taille; i++)
                        {
                            if (tab[y-i,x].etat != etat.eau)
                            {
                                ok = false;
                            }
                        }

                        if (ok)
                        {
                            for (int i = 0; i < taille; i++)
                            {
                                tab[y-i, x].ajoutBateau(bateau);

                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                case direction.gauche:
                    if (x - taille >= 0)
                    {
                        bool ok = true;
                        for (int i = 0; i < taille; i++)
                        {
                            if (tab[y, x-i].etat != etat.eau)
                            {
                                ok = false;
                            }
                        }

                        if (ok)
                        {
                            for (int i = 0; i < taille; i++)
                            {
                                tab[y, x-i].ajoutBateau(bateau);

                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                case direction.droite:
                    if (x + taille <= 10)
                    {
                        bool ok = true;
                        for (int i = 0; i < taille; i++)
                        {
                            if (tab[y, x+i].etat != etat.eau)
                            {
                                ok = false;
                            }
                        }

                        if (ok)
                        {
                            for (int i = 0; i < taille; i++)
                            {
                                tab[y, x+i].ajoutBateau(bateau);

                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }
    }
}
