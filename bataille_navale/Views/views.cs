using GameElement;
using System;
namespace bataille_navale.Views
{
    class views
    {
        public static void ShowGrid(joueur joueur1, joueur joueur2)
        {
            Console.WriteLine("{0}                                {1}", joueur1.Pseudo, joueur2.Pseudo);
            Console.WriteLine("|  |A|B|C|D|E|F|G|H|I|J|          |  |A|B|C|D|E|F|G|H|I|J|");

            for (int i = 0; i < grille.horizontal; i++)
            {
                string line1 = "|";
                string line2 = "|";
                int nbr = (i + 1);
                if (nbr < 10)
                {
                    line1 = line1 + nbr + " ";
                    line2 = line2 + nbr + " ";
                }
                else
                {
                    line1 = line1 + nbr;
                    line2 = line2 + nbr;
                }

                for (int j = 0; j < grille.vertical; j++)
                {
                    string ajout1 = WriteBoatState(joueur1, i, j);
                    string ajout2 = WriteBoatState(joueur2, i , j);

                    line1 = line1 + ajout1;
                    line2 = line2 + ajout2;
                }
                line1 = line1 + "|          " + line2 + "|";
                Console.WriteLine(line1);
            }
        }

        public static void ShowGridPerso(joueur joueur)
        {
            Console.WriteLine("|  |A|B|C|D|E|F|G|H|I|J|");


            for (int i = 0; i < grille.horizontal; i++)
            {
                string line1 = "|";
                int nbr = (i + 1);
                if (nbr < 10)
                {
                    line1 = line1 + nbr + " ";
                }
                else
                {
                    line1 = line1 + nbr;
                }


                for (int j = 0; j < grille.vertical; j++)
                {
                    switch (joueur.grille.tab[i, j].etat)
                    {
                        case etat.eau:
                            line1 = line1 + "| ";
                            break;
                        case etat.bateau:
                            line1 = line1 + "|B";
                            break;
                        case etat.boum:
                        case etat.plouf:
                            line1 = line1 + "| ";
                            break;
                        default:
                            line1 = line1 + "| ";
                            break;
                    }
                }
                line1 = line1 + "|";
                Console.WriteLine(line1);
            }
        }

        public static string WriteBoatState(joueur joueur, int i, int j)
        {
            switch (joueur.grille.tab[i, j].etat)
            {
                case etat.eau:
                    //return "| ";
                case etat.bateau:
                    return "| ";
                case etat.boum:
                    if (joueur.grille.tab[i, j].bateau.coulé)
                    {
                        string nom = joueur.grille.tab[i, j].bateau.nom.ToString();
                        nom = nom.Substring(0, 1);
                        return "|" + nom;
                    }
                    else
                    {
                        return "|x";
                    }

                case etat.plouf:
                    return "|O";
                default:
                    return "|?";
            }
        }
    }
}
