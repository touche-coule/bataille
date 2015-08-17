namespace GameElement
{
    public class grille
    {
        const int horizontal = 10;
        const int vertical = 10;
        public cellule[,] tab = new cellule[horizontal, vertical];

        public grille()
        {
            for (int i = 0; i < horizontal; i++)
            {
                for (int j = 0; j < vertical; j++)
                {
                    tab[i,j] = new cellule(i,j);
                }
            }
        }

        public bool ajoutBateau(bateau bateau, cellule cellule, direction direction )
        {
            int taille = bateau.taille;
            int vertical = cellule.vertical;
            int horizontal = cellule.horizontal;

            if (direction == direction.bas)
            {
                if (vertical + taille <= 10)
                {
                    bool ok = true;
                    for (int i = 0; i < taille; i++)
                    {
                        if (!tab[horizontal, i].used)
                        {
                            ok = false;
                        }
                    }

                    if (ok)
                    {
                        for (int i = 0; i < taille; i++)
                        {
                            tab[horizontal, i].ajoutBateau(bateau);
                            return true;
                        }
                    }

                }
                else
                {
                    return false;
                }

            }

            //string str = ((DocumentTypes)value).ToString();

        }
    }
}
