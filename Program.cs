//TD4 d'algorithmique
//Nathan Choukroun
//Esilv A1S2
//TDN2

using System;

namespace I2TD4JeuAllumettes
{
    class Program
    {
        static bool[] CreerTasAllumettes(int taille)
        {
            bool[] tableau = new bool[taille];
            for (int i = 0; i < tableau.Length; i++)
            {
                tableau[i] = true;
            }
            return tableau;
        }

        static void AfficherTasAlumettes(bool[] tasAlumettes)
        {
            
            for (int i = 0; i < tasAlumettes.Length; i++)
            {
                if (i < 10){
                    Console.Write("  " + (i + 1) + " ");
                }
                else{
                    Console.Write(" " + (i + 1) + " ");
                }

            }
             

            Console.WriteLine("");
            for (int i = 0; i < tasAlumettes.Length; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine("");
            for (int i = 0; i < tasAlumettes.Length; i++)
            {
                Console.Write("| ");
                if (tasAlumettes[i])
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine("");
            for (int i = 0; i < tasAlumettes.Length; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine();
        }
        static int valeurValide(int min, int max)
        {
            int valeur;

            do
            {
                valeur = int.Parse(Console.ReadLine());
            } while (valeur > max && valeur < min);

            return valeur;
        }
        static bool PositionValide(bool[] tableau, int index)
        {
            bool position = false;
            if (tableau != null && tableau.Length != 0)
            {
                if (index >= 0 && index < tableau.Length && tableau[index]==true)
                {
                    position = true;
                }
            }
            return position;
        }
        static bool RetirerUneAllumette(bool[] tasAllumettes, int index)
        {
            bool possible = false;
            if (tasAllumettes != null && tasAllumettes.Length != 0)
            {
                if (PositionValide(tasAllumettes, index))
                {
                    tasAllumettes[index] = false;
                    possible = true;
                }
            }
            return possible;
        }

        static int NombreAllumettesRestantes(bool[] tasAllumettes)
        {
            int allumettesRestant = 0;
            if (tasAllumettes != null && tasAllumettes.Length != 0)
            {
                foreach (bool allumette in tasAllumettes)
                {
                    if (allumette)
                    {
                        allumettesRestant++;
                    }
                }
            }
            return allumettesRestant;
        }

        static int DemanderNombreAllumettesARetirer(int max)
        {

            int valeur = int.Parse(Console.ReadLine());

            while (valeur <= 0 || valeur > max)
            {
                Console.Write("Mauvaise entrée, recommencez : ");
                valeur = int.Parse(Console.ReadLine());
            }
            return valeur;
        }
        static int DemanderIndexARetirer(bool[] tasAllumettes)
        {
            int valeur = int.Parse(Console.ReadLine());

            while (valeur <= 0 || valeur > tasAllumettes.Length)
            {
                Console.Write("Mauvaise entrée, recommencez : ");
                valeur = int.Parse(Console.ReadLine());
            }
            //return -1 pour repasser l'index selon les positions dans le tableau
            return valeur - 1;
        }
        static bool PartieGagnee(bool[] tasAllumettes)
        {
            bool gagnee;
            if (tasAllumettes != null && tasAllumettes.Length != 0 && NombreAllumettesRestantes(tasAllumettes) == 1)
            {
                gagnee = true;
            }
            else
            {
                gagnee = false;
            }
            return gagnee;
        }
        static bool PartiePerdue(bool[] tasAllumettes)
        {
            bool perdu;
            if (tasAllumettes == null || tasAllumettes.Length == 0 || NombreAllumettesRestantes(tasAllumettes) == 0)
            {
                perdu = true;
            }
            else { perdu = false; }
            return perdu;
        }
        static bool FinPartie(bool[] tasAllumettes)
        {
            bool FinPartie;
            if (tasAllumettes != null && tasAllumettes.Length != 0 && (PartieGagnee(tasAllumettes) || PartiePerdue(tasAllumettes)))
            {
                FinPartie = true;
            }
            else { FinPartie = false; }
            return FinPartie;

        }

        static void Main(string[] args)
        {
            Console.Write("Nombre d'allumettes : ");
            int nombreAllumettes = valeurValide(3,99);
            
            //On initialise les allumettes
            bool[] allumettes = CreerTasAllumettes(nombreAllumettes);

            //Maximum d'allumette a retirer
            Console.Write("Maximum d'allumettes par tour : ");
            int maximumParTour = valeurValide(1,10);



            //********* Début du jeu *********

            int noJoueur = 0;//Numéro du joueur

            while (!FinPartie(allumettes))
            {
                AfficherTasAlumettes(allumettes);

                //Etape 1 ****** Qui joue
                noJoueur = (noJoueur % 2) + 1;
                Console.WriteLine("C'est au joueur " + noJoueur);

                //Etape 2 ****** Le nombre d'allumettes à tirer
                Console.WriteLine("Il reste " + NombreAllumettesRestantes(allumettes) + " d'allumettes");

                //Etape3 ******* Allumettes à retirer
                Console.Write("Nombre d'allumettes à retirer : ");
                int nombreARetirer = DemanderNombreAllumettesARetirer(maximumParTour);

                int indexARetirer;
                for (int i = 0; i < nombreARetirer; i++)
                {
                    Console.Write("A quelle position : ");
                    /*
                    do
                    {
                        indexARetirer = DemanderIndexARetirer(allumettes);
                        RetirerUneAllumette(allumettes, indexARetirer);

                    } while (!PositionValide(allumettes, indexARetirer));
                    */
                    indexARetirer = DemanderIndexARetirer(allumettes);
                    
                    while (!PositionValide(allumettes, indexARetirer))
                    {
                        Console.Write("Mauvaise entrée, recommencez : ");
                        indexARetirer = DemanderIndexARetirer(allumettes);
                    }
                    RetirerUneAllumette(allumettes, indexARetirer);
                }





                PartieGagnee(allumettes);
                PartiePerdue(allumettes);
                FinPartie(allumettes);



            }

            //Billan ******

            Console.Write("Le joureur " + noJoueur);
            if (PartieGagnee(allumettes))
            {
                Console.WriteLine(" à gagnée!");
            }
            else
            {
                Console.WriteLine(" à perdu!");
            }


            Console.ReadKey();
        }
    }
}