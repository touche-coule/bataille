namespace GameElement
{
    public class grille
    {
        //on initialise une grille avec 10 lignes et 10 colonnes
        const int horizontal = 10;
        const int vertical = 10;
        //la grilles contient des cellules qui ont une ordonnée et une abcisse
        public cellule[,] tab = new cellule[horizontal, vertical];
        // on crée la grille avec le nombre de colonnes et de ligens 

        public grille()
        {
            for (int i = 0; i < horizontal; i++)
            {
                for (int j = 0; j < vertical; j++)
                {
                    tab[i, j] = new cellule(i, j);
                }
            }
        }

        // on ajoute un bateau selon une cellule de départ et une direction 
        public bool ajoutBateau(bateau bateau, cellule cellule, direction direction)
        {
            int taille = bateau.taille;
            int vertical = cellule.vertical;
            int horizontal = cellule.horizontal;
            // on vérifie le placement d'un bateau en position verticale vers le bas 

            switch (direction)
            {
                case direction.bas:
                    //on vérifie si il y a asser de place pour le placement du bateau 
                    // la taille du bateau + la valeur de la cellule de départ ne peut dépasser la longueur totale de la colonne
                    if (vertical + taille <= 10)
                    {
                        // on initialise une variable bool à true 
                        bool ok = true;
                        // on fait une boucle pour la taille du bateau  
                        for (int i = 0; i < taille; i++)
                        {
                            if (tab[horizontal, i].etat != etat.eau)
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
                                tab[horizontal, i].ajoutBateau(bateau);

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
                    if (vertical - taille >= 0)
                    {
                        bool ok = true;
                        for (int i = 0; i < taille; i--)
                        {
                            if (tab[horizontal, i].etat != etat.eau)
                            {
                                ok = false;
                            }
                        }

                        if (ok)
                        {
                            for (int i = 0; i < taille; i--)
                            {
                                tab[horizontal, i].ajoutBateau(bateau);

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
                    if (horizontal - taille >= 0)
                    {
                        bool ok = true;
                        for (int i = 0; i < taille; i--)
                        {
                            if (tab[horizontal, i].etat != etat.eau)
                            {
                                ok = false;
                            }
                        }

                        if (ok)
                        {
                            for (int i = 0; i < taille; i--)
                            {
                                tab[i, horizontal].ajoutBateau(bateau);

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
                    if (horizontal - taille <= 0)
                    {
                        bool ok = true;
                        for (int i = 0; i < taille; i++)
                        {
                            if (tab[horizontal, i].etat != etat.eau)
                            {
                                ok = false;
                            }
                        }

                        if (ok)
                        {
                            for (int i = 0; i < taille; i++)
                            {
                                tab[i, horizontal].ajoutBateau(bateau);

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
//string str = ((DocumentTypes)value).ToString();