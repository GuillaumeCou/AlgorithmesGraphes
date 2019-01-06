using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmesGraphes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] SOMMET1 = {
        " 1", " 2"," 3", " 4"," 5",
        "S1", "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "S11", "S12", "S13", "S14",
        " 6", " 7", " 8", " 9", "10", "11", "12", "13", "14"
        };
            string[] SOMMET = {
        "  1", "  2","  3", "  4","  5",
        " S1", " S2", " S3", " S4", " S5", " S6", " S7", " S8", " S9", "S10", "S11", "S12", "S13", "S14",
        "  6", "  7", "  8", "  9", " 10", " 11", " 12", " 13", " 14",
        " F6", " F7", " F8", " F9", "F10", "F11", "F12", "F13", "F14"
        };


            /* Je créer une nouvelle matrice de graphe (provencance en ligne et direction en colonne).
             * Le fichier où se trouve la matrice est un fichier ".txt" sous le nom "graphe" (cf. constructeur).*/

            MatriceGraphe grl = new MatriceGraphe();

            /* Puis j'initialise une instance de l'outil défini par l'algorithme souhaité.
             * J'indique la matrice ("grl") et le point de départ (valeur de base 1).*/

            DijkstraTool djk1 = new DijkstraTool  (grl, 5, SOMMET);

            /* Enfin je lui demande d'effectuer les étapes de l'algorithme.*/
            djk1.Compute();

            /* Pour finir, je lui demande de me donner le résultat mis en forme.*/
            string mot = djk1.ToString_Shortest_Paths();

            Console.Write(mot);

            Console.ReadKey();
        }
    }
}

