using GameElement;
using System;
namespace bataille_navale.Views
{
    class views
    {
        public static void ShowGrid(joueur joueur)
        {
            Console.WriteLine("|A|B|C|D|E|F|G|H|I|J|");

            for (int i = 0; i < grille.horizontal; i++)
            {
                int nbr = (i + 1);
                string line =  "" + nbr;

                for (int j = 0; j < grille.vertical; j++)
                {
                    switch (joueur.grille.tab[i, j].etat)
                    {
                        case etat.eau:
                        case etat.bateau:
                            line = line + "| |";
                            break;
                        case etat.boum:
                            string nom = joueur.grille.tab[i, j].bateau.nom.ToString();
                            nom = nom.Substring(0, 1);

                            line = line + "|" + nom + "|";
                            break;
                        case etat.plouf:
                            line = line + "|O|";
                            break;
                    }
                }
                Console.WriteLine(line);
            }
        }

        public static void ShowGridPerso(joueur joueur)
        {
            Console.WriteLine("|  |A|B|C|D|E|F|G|H|I|J|");
            

            for (int i = 0; i < grille.horizontal; i++)
            {
                string line = "|";
                int nbr = (i + 1);
                if (nbr < 10)
                {
                    line = line + nbr + " ";
                }
                else
                {
                    line = line + nbr;
                }
                

                for (int j = 0; j < grille.vertical; j++)
                {
                    switch (joueur.grille.tab[i, j].etat)
                    {
                        case etat.eau:
                            line = line + "|E";
                            break;
                        case etat.bateau:
                            line = line + "|B";
                            break;
                        case etat.boum:
                        case etat.plouf:
                            line = line + "|O";
                            break;
                        default:
                            line = line + "|W";
                            break;
                    }
                }
                line = line + "|";
                Console.WriteLine(line);
            }
        }
    }
}
