using bataille_navale.Views;
using GameElement;
using System;
namespace bataille_navale.Mods
{
    class tools
    {
        public static void GetPositionFromConsole(string questionToUser, out int x, out int y)
        {
            int ix;
            int iy;
            while (true)
            {
                try
                {
                    Console.WriteLine(questionToUser);
                    string position = Console.ReadLine();
                    string sx = position.Substring(0, 1);
                    string sy = position.Substring(1, 1);

                    iy = int.Parse(sy);
                    //string str = ((DocumentTypes)value).ToString();
                    ix = (int)Enum.Parse(typeof(vertical), sx, true);
                    //x = (int)vertical.x;
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            x = ix;
            y = iy-1;

        }

        public static direction GetDirectionFromConsole()
        {
            string directionVoulue;
            do
            {
                Console.WriteLine("Vers quel coté? [gauche/droite/haut/bas] ");
                directionVoulue = Console.ReadLine();
            } while (directionVoulue != "gauche" && directionVoulue != "droite" && directionVoulue != "haut" && directionVoulue != "bas");

            switch (directionVoulue)
            {
                case "gauche":
                    return direction.gauche;
                case "droite":
                    return direction.droite;
                case "haut":
                    return direction.haut;
                case "bas":
                    return direction.bas;
                default:
                    return direction.gauche;
            }
        }

        public static void PutBoat(joueur joueur)
        {
            int x;
            int y;

            Console.WriteLine("Mise en place des bateaux de {0}", joueur.Pseudo);
            bool retour = false;

            views.ShowGridPerso(joueur);

            do
            {
                tools.GetPositionFromConsole("A partir d'où voulez-vous placer votre porte avions? (ex : c6)", out x, out y);
                direction direction = tools.GetDirectionFromConsole();
                retour = joueur.grille.ajoutBateau(joueur.grille.PorteAvion, joueur.grille.tab[x, y], direction);
            } while (!retour);

            views.ShowGridPerso(joueur);

            do
            {
                tools.GetPositionFromConsole("A partir d'où voulez-vous placer votre croiseur? (ex : c6)", out x, out y);
                direction direction = tools.GetDirectionFromConsole();
                retour = joueur.grille.ajoutBateau(joueur.grille.Croiseur, joueur.grille.tab[x, y], direction);
            } while (!retour);

            views.ShowGridPerso(joueur);

            do
            {
                tools.GetPositionFromConsole("A partir d'où voulez-vous placer votre contre torpilleur? (ex : c6)", out x, out y);
                direction direction = tools.GetDirectionFromConsole();
                retour = joueur.grille.ajoutBateau(joueur.grille.ContreTorpilleur, joueur.grille.tab[x, y], direction);
            } while (!retour);

            views.ShowGridPerso(joueur);

            do
            {
                tools.GetPositionFromConsole("A partir d'où voulez-vous placer votre sous marin? (ex : c6)", out x, out y);
                direction direction = tools.GetDirectionFromConsole();
                retour = joueur.grille.ajoutBateau(joueur.grille.SousMarin, joueur.grille.tab[x, y], direction);
            } while (!retour);

            views.ShowGridPerso(joueur);

            do
            {
                tools.GetPositionFromConsole("A partir d'où voulez-vous placer votre torpilleur1? (ex : c6)", out x, out y);
                direction direction = tools.GetDirectionFromConsole();
                retour = joueur.grille.ajoutBateau(joueur.grille.Torpilleur1, joueur.grille.tab[x, y], direction);
            } while (!retour);

            views.ShowGridPerso(joueur);

            do
            {
                tools.GetPositionFromConsole("A partir d'où voulez-vous placer votre torpilleur2? (ex : c6)", out x, out y);
                direction direction = tools.GetDirectionFromConsole();
                retour = joueur.grille.ajoutBateau(joueur.grille.Torpilleur2, joueur.grille.tab[x, y], direction);
            } while (!retour);

            views.ShowGridPerso(joueur);
        }

        public static int Coup(joueur joueur)
        {
            int x;
            int y;
            int result;

            do
            {
                tools.GetPositionFromConsole("Où voulez-vous faire feux? (ex : c6)", out x, out y);
                result = joueur.grille.tab[x, y].attaque();
            } while (result == 4 || result == 5);

            return result;

        }

    }
}
