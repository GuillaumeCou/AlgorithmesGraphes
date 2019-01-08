using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmesGraphes
{
            shortest_paths = new int[matgra.Taille_Matrice, matgra.Taille_Matrice];

            choiles sommets "libres".
                Calculer_Distance();

                // Pour finir, nous choisissons le sommets qui a la plus petite valeur à parcourir.
                Choisir_Sauvegarder_Minimum();
            }

            /* Pour finir, nous remomtons tous les calculs de l'algorithme de Dijkstra.
             * Cela nous permet d'obtenir tous les chemins depuis le sommet de départ vers tous les autres sommets. */
            Trouver_Chemins_Plus_Courts();
        }

        /// <summary>
        /// Fonction qui met en forme les résultats de l'algorithme de Dijkstra.
        /// </summary>
        /// <returns></returns>
        public string ToString_Shortest_Paths()
        {
            string mot = "";

            for (int i = 0; i < shortest_paths.GetLength(0); i++)
            {
                mot += sommets[i] + " : \t";
                if (i != depart && provenance[i] == -1)
                {
                    mot += 0;
                }
                else
                {
                    mot += choix_distances.ElementAt(choix_points.FindIndex(x => x == i)) + "\t";

                    for (int j = 0; j < shortest_paths.GetLength(1); j++)
                    {
                        if (shortest_paths[i, shortest_paths.GetLength(1) - 1 - j] != -1)
                        {
                            if (shortest_paths[i, shortest_paths.GetLength(1) - 1 - j] == depart)
                            {
                                mot += sommets[shortest_paths[i, shortest_paths.GetLength(1) - 1 - j]];
                            }
                            else
                            {
                                mot += "--" + sommets[shortest_paths[i, shortest_paths.GetLength(1) - 1 - j]];
                            }
                        }
                    }
                }
                if (i == depart)
                {
                    mot += sommets[i] + "\n";
                }
                else
                {
                    mot += "--" + sommets[i] + "\n";
                }
            }
            return mot;
        }

        /// <summary>
        /// Fonction qui calcule les distances entre le sommet sélectionné et les autres sommets libres.
        /// </summary>
        private void Calculer_Distance()
        {
            // Nous obtenons les connections sortantes du derniers sommet selectionné.
            int[] distances_prochains_sommets = matgra.getCheminsPossible(choix_points.Last());

            // Et nous récuperons sa distance avec le point de départ.
            int distance_actuelle = choix_distances.Last();

            for (int j = 0; j < tableau.GetLength(1); j++)
            {
                // Nous prennons les valeurs (distances) entre le sommet sélectionné et tous les autres.
                int dps = distances_prochains_sommets[j];

                /* - Il est nécessaire que la distance soit différente à 0 pour ne pas tourner en rond avec la point de départ.
                 * - Il est nécessaire que le sommet soit libre et non déjà sélectionné précedement.
                 * - Si la valeur de l'étape précedente pour le même sommet est égale à -1 ou supérieure à la somme de la distance du sommet sélectionné
                 *      et de la distance vers ce nouveau sommet, on remplace par cette dernière somme dans les deux cas.
                 */
                if (dps != 0 && !(choix_points.Exists(x => x == j)) && (tableau[tableau.GetLength(0) - 2, j] > dps + distance_actuelle || tableau[tableau.GetLength(0) - 2, j] == -1))
                {
                    // On indique les distance dans "tableau" et le sommet sélectionné dans "provenance" pour suivre le chemin.
                    tableau[tableau.GetLength(0) - 1, j] = dps + distance_actuelle;
                    provenance[j] = choix_points.Last();
                }
                // Dans le cas où les conditions ne sont pas validées, on copie simplement la valeur de la ligne supérieure pour le même sommet.
                else
                {
                    tableau[tableau.GetLength(0) - 1, j] = tableau[tableau.GetLength(0) - 2, j];
                    provenance[j] = provenance[j];
                }
            }
        }

        /// <summary>
        /// Fonction qui permet de déterminer le sommet à sélectionner
        /// </summary>
        private void Choisir_Sauvegarder_Minimum()
        {
            // On recherche le sommet le plus proche. Donc avec la distance la plus petite à l'étape actuelle.
            int sommet_min = -1;
            int min = 10000000;
            for (int j = 0; j < tableau.GetLength(1); j++)
            {
                /* - Pour concidérer un sommet il doit être libre et donc non inscrit dans la liste
                 * - Il est nécessaire que nous ayons déjà calculé une distance en direction du sommet analyser pour le comparer.
                 *      Si sa distance est égale à -1, c'est qu'il n'a pas encore été vu.*/
                if (!(choix_points.Exists(x => x == j)) && tableau[tableau.GetLength(0) - 1, j] != -1)
                {
                    if (tableau[tableau.GetLength(0) - 1, j] < min)
                    {
                        min = tableau[tableau.GetLength(0) - 1, j];
                        sommet_min = j;
                    }
                }
            }
            // Si aucun sommet n'est sélectionné, c'est qu'il ne nous est plus possible de nous déplacer et donc
            // que le tableau de Dijkstra est rempli.
            if (sommet_min == -1 || choix_points.Exists(x => x == sommet_min))
            {
                est_rempli = true;
            }
            else
            {
                // Sinon, nous enregistrons le sommet sélectionné et sa distance au sommet de départ.
                choix_points.Add(sommet_min);
                choix_distances.Add(min);
            }
        }

        /// <summary>
        /// Fonction qui vérifie s'il y a encore des sommets non visités dans notre tableau.
        /// </summary>
        /// <returns></returns>
        private bool Negatif_Dans_La_Ligne()
        {
            bool test = false;

            for (int j = 0; j < tableau.GetLength(1); j++)
            {
                if (tableau[tableau.GetLength(0) - 1, j] < 0)
                {
                    test = true;
                }
            }

            return test;
        }

        /// <summary>
        /// Fonction qui ajouter une ligne à une matrice.
        /// </summary>
        /// <param name="tab"></param>
        /// <returns>Même tableau qu'en paramètre avec une ligne supplémentaire remplie de -1.</returns>
        private int[,] Ajouter_Ligne(int[,] tab)
        {
            int dim1 = tab.GetLength(0) + 1;
            int dim2 = tab.GetLength(1);

            int[,] new_tab = new int[dim1, dim2];

            for (int i = 0; i < dim1 - 1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    new_tab[i, j] = tab[i, j];
                }
            }

            for (int j = 0; j < new_tab.GetLength(1); j++)
            {
                new_tab[new_tab.GetLength(0) - 1, j] = -1;
            }

            for (int j = 0; j < choix_points.Count; j++)
            {
                new_tab[new_tab.GetLength(0) - 1, choix_points.ElementAt(j)] = choix_distances.ElementAt(j);
            }

            return new_tab;
        }

        /// <summary>
        /// Fonction qui remonte l'algorithme de Dijkstra et donne le chemin de chaque sommet depuis le sommet de départ.
        /// </summary>
        private void Trouver_Chemins_Plus_Courts()
        {
            /* Nous avons sauvegarder tous nous sommets visités les un après les autres dans "provenance".
             * Il nous suffit de sélectionner un indice de "provenance" (qui correspond au sommet du même indice)
             * et de prendre la valeur donner (qui correspond au sommet précédent).
             * On récupère cet indice et on réittere jusqu'à arrivé au point de départ.
             * Puis on recommence pour tous les autres points. */
            for (int i = 0; i < shortest_paths.GetLength(0); i++)
            {
                int index = i;
                for (int j = 0; j < shortest_paths.GetLength(1); j++)
                {
                    if (index != -1)
                    {
                        shortest_paths[i, j] = provenance[index];
                        index = provenance[index];
                    }
                }
            }
        }

        // Fonction de mise en forme
        private int Max_Taille_Digit_Matrice(int[,] mat)
        {
            int max = 0;

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] > max)
                    {
                        max = mat[i, j];
                    }
                }
            }
            int max_digit = 0;
            while (max > 1)
            {
                max_digit++;
                max = max / 10;
            }

            return max_digit;
        }

        // Fonction de mise en forme
        private int Max_Taille_Digit_Tableau(int[] tab)
        {
            int max = 0;

            for (int j = 0; j < tab.Length; j++)
            {
                if (tab[j] > max)
                {
                    max = tab[j];
                }
            }

            int max_digit = 0;
            while (max > 1)
            {
                max_digit++;
                max = max / 10;
            }

            return max_digit;
        }


    }

}
