using System;
using GameElement;
using bataille_navale.Mods;
using bataille_navale.Views;
namespace bataille_navale
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Comment s'appel le joureur N°1?");
            //string nom1 = Console.ReadLine();
            //Console.WriteLine("Comment s'appel le joureur N°2?");
            //string nom2 = Console.ReadLine();

            //joueur joueur1 = new joueur(nom1);
            //joueur joueur2 = new joueur(nom2);

            joueur joueur1 = new joueur("Flink");
            joueur joueur2 = new joueur("Plop");

            Random rnd = new Random();

            tools.PutBoatAuto(joueur1, rnd);
            Console.Clear();
            tools.PutBoatAuto(joueur2, rnd);
            Console.Clear();

            joueur current = joueur1;
            do
            {
                if (current == joueur1)
                {
                    if (joueur1.grille.PorteAvion.coulé && joueur1.grille.SousMarin.coulé && joueur1.grille.Croiseur.coulé && joueur1.grille.ContreTorpilleur.coulé && joueur1.grille.Torpilleur1.coulé && joueur1.grille.Torpilleur2.coulé)
                    {
                        Console.Clear();
                        views.ShowGrid(joueur1, joueur2);
                        Console.WriteLine("{0} a gagné !", joueur2.Pseudo);
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        views.ShowGrid(joueur1, joueur2);
                        Console.WriteLine("\n{0}, à vouz de jouer !", current.Pseudo);
                        Console.WriteLine("-------------------------------------------");
                        //int retour = tools.Coup(joueur2);
                        System.Threading.Thread.Sleep(250);
                        int retour = tools.CoupAuto(joueur2, rnd);
                        current = joueur2;
                        Console.Clear();

                        switch (retour)
                        {
                            case 1:
                                Console.WriteLine("Vous avez coulé un bateau");
                                break;
                            case 2:
                                Console.WriteLine("Vous avez touché un bateau");
                                break;
                            case 3 :
                                Console.WriteLine("Malheureusement c'était un coup dans l'eau :(");
                                break;
                        }
                    }
                }
                else
                {
                    if (joueur2.grille.PorteAvion.coulé && joueur2.grille.SousMarin.coulé && joueur2.grille.Croiseur.coulé && joueur2.grille.ContreTorpilleur.coulé && joueur2.grille.Torpilleur1.coulé && joueur2.grille.Torpilleur2.coulé)
                    {
                        Console.Clear();
                        views.ShowGrid(joueur1, joueur2);
                        Console.WriteLine("{0} a gagné !", joueur1.Pseudo);
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        views.ShowGrid(joueur1, joueur2);
                        Console.WriteLine("\n{0}, à vouz de jouer !", current.Pseudo);
                        Console.WriteLine("-------------------------------------------");
                        System.Threading.Thread.Sleep(250);
                        int retour = tools.CoupAuto(joueur1, rnd);
                        current = joueur1;
                        Console.Clear();

                        switch (retour)
                        {
                            case 1:
                                Console.WriteLine("Vous avez coulé un bateau");
                                break;
                            case 2:
                                Console.WriteLine("Vous avez touché un bateau");
                                break;
                            case 3:
                                Console.WriteLine("Malheureusement c'était un coup dans l'eau :(");
                                break;
                        }
                    }
                }
            } while (true);






        }
    }
}
