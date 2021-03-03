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
            for(int i=0; i<tableau.Length; i++)
            {
                tableau[i] = true;
            }
            return tableau;
        }

        static void AfficherTasAlumettes(bool[] tasAlumettes)
        {
            for(int i=0;i<tasAlumettes.Length; i++)
            {
                Console.Write("  " + (i+1)+" ");
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

        static bool PositionValide(bool[] tableau, int index)
        {
            bool position = false;
            if (tableau != null && tableau.Length != 0)
            {
                if(index>=0 && index < tableau.Length)
                {
                    position = true;
                }
            }
            return position;
        }
        static bool RetirerUneAllumette(bool[] tasAllumettes, int index)
        {
            bool possible;
            if (tasAllumettes != null && tasAllumettes.Length != 0)
            {
                if(PositionValide(tasAllumettes, index))
                {
                    tasAllumettes[index] = false;
                    possible = true;
                }
                else { possible = false;
                }
            }
            else
            {
                possible = false;
            }
            return possible;
        }

        static int NombreAllumettesRestantes(bool[] tasAllumettes)
        {
            int allumettesRestant=0;
            if (tasAllumettes != null && tasAllumettes.Length != 0)
            {
                foreach(bool allumette in tasAllumettes)
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
            
            while (valeur<=0&&valeur>max)
            {
                valeur = int.Parse(Console.ReadLine());
            }
            return valeur;
        }
        static int DemanderIndexARetirer(bool[] tasAllumerttes)
        {
            int valeur = int.Parse(Console.ReadLine());

            while (valeur <= 0 && valeur > tasAllumerttes.Length)
            {
                valeur = int.Parse(Console.ReadLine());
            }
            return valeur-1;

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
            if(tasAllumettes==null || tasAllumettes.Length==0 || NombreAllumettesRestantes(tasAllumettes)==0)
            {
                perdu = true;
            }
            else { perdu = false; }
            return perdu;
        }
        static bool FinPartie(bool[] tasAllumettes)
        {
            bool FinPartie;
            if (tasAllumettes != null && tasAllumettes.Length != 0 &&(PartieGagnee(tasAllumettes) || PartiePerdue(tasAllumettes)))
            {
                FinPartie = true;
            }
            else { FinPartie = false; }
            return FinPartie;

        }

        static void Main(string[] args)
        {

            //On initialise les allumettes
            bool[] allumettes = CreerTasAllumettes(8);



            //********* Début du jeu *********

            int noJoueur = 0;//Numéro du joueur

            while (!FinPartie(allumettes))
            {
                AfficherTasAlumettes(allumettes);

                //Etape 1 ****** Qui joue
                noJoueur = (noJoueur % 2) + 1;
                Console.WriteLine(" C'est à " + noJoueur);

                //Etape 2 ****** Le nombre d'allumettes à tirer
                Console.WriteLine("Il reste " + NombreAllumettesRestantes(allumettes) + " d'allumettes");

                //Etape3 ******* Allumettes à retirer
                Console.Write("Nombre d'allumettes à retirer : ");
                int nombreARetirer = DemanderNombreAllumettesARetirer(3);

                for(int i=0; i<nombreARetirer; i++)
                {
                    Console.Write("A quelle position : ");
                    int index = DemanderIndexARetirer(allumettes);
                    if (PositionValide(allumettes, index))
                    {
                        RetirerUneAllumette(allumettes, index);
                    }
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
            else { 
                Console.WriteLine(" à perdu!"); 
            }



        }
    }
}
