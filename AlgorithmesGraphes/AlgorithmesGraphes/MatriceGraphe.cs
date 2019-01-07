using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace AlgorithmesGraphes
{
    class MatriceGraphe
    {
        int taille;
        int[,] plateau;


        public int[,] getPlateau { get => plateau; }
        public int Taille_Matrice { get => plateau.GetLength(0); }

        /// <summary>
        /// Constructeur de la classe "Grille". Cette grille est utiliser comme matrice d'un graphe.
        /// ATTENTION !!! La grille du graphe (placée dans le fichier debug) DOIT ETRE "!" CARREE "!".
        /// </summary>
        public MatriceGraphe()
        {
            var t = Task.Delay(2500);

            try
            {
                string[] lecture = File.ReadAllLines("graphe.tx
                taille++;
            }
            return taille;
        }

        /// <summary>
        /// Fonction qui extrait les valeurs du tableau de chaines de caratères.
        /// </summary>
        /// <param name="lecture">Chaine de caractères représentant la matrice du graphe</param>
        private void Remplir_Plateau(string[] lecture)
        {sdfqsdfsqdfqsdf
            for (int i = 0; i < taille; i++)
            {
                int j = 0;
                string valeur = "";
                for (int k = 0; k < lecture[i].Length; k++)
                {
                    if (lecture[i][k] == ',' || lecture[i][k] == '\n')
                    {
                        plateau[i, j] = int.Parse(valeur);
                        j++;
                        valeur = "";
                    }
                    else
                    {
                        valeur += lecture[i][k];
                    }
                }
                plateau[i, j] = int.Parse(valeur);
            }
        }

        public override string ToString()
        {
            string mot = "";

            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    if (plateau[i, j] < 10)
                    {
                        mot += "    " + plateau[i, j];
                    }
                    if (plateau[i, j] < 100 && plateau[i, j] > 9)
                    {
                        mot += "   " + plateau[i, j];
                    }
                    if (plateau[i, j] < 1000 && plateau[i, j] > 99)
                    {
                        mot += "  " + plateau[i, j];
                    }
                }
                mot += "\n";
            }
            return mot;
        }

        /// <summary>
        /// Fonction qui retourne la ligne de la matrice du graphe correspondant au sommet donnée.
        /// </summary>
        /// <param name="Sommet">Sommet dont nous souhaitons connaître les connections sortantes.</param>
        /// <returns>Tableau à une dimension contenant les pondération des connections sortantes.</returns>
        public int[] getCheminsPossible(int Sommet)
        {
            int[] ligne = new int[taille];

            for (int j = 0; j < taille; j++)
            {
                ligne[j] = plateau[Sommet, j];
            }
            return ligne;
        }
    }
}
