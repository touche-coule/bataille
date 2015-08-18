using System;
using GameElement;
namespace bataille_navale
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Comment s'appel le joureur N°1?");
            string nom1 = Console.ReadLine();
            Console.WriteLine("Comment s'appel le joureur N°2?");
            string nom2 = Console.ReadLine();

            joueur joueur1 = new joueur(nom1);
            joueur joueur2 = new joueur(nom2);

            Console.WriteLine("Mise en place des bateaux de {0}", joueur1.Pseudo);
            Console.WriteLine("A partir d'où voulez-vous placer votre porte avions? ");
            string position = Console.ReadLine();
            Console.WriteLine("Vers quel coté? [gauche/droite/haut/bas] ");
            string direction = Console.ReadLine();
        }
    }
}
