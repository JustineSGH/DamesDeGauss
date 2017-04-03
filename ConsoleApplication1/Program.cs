using System;

namespace NReines
{
    public class Position
    {
        /*Définition des variables*/
        public static int NombreReines = 8;
        public static int NombreSolution;//création d'un compteur pour compter le nombre de solution
        public Position peutPlacer;
        public static Position reinePrecedente;
        public int ligne, rangee;

        public Position(int Ligne, int Rangee, Position PeutPlacer)
        {
            ligne = Ligne;
            rangee = Rangee;
            peutPlacer = PeutPlacer;
        }
        /*Fonction de vérification*/
        public void PlacerReine()
        {
            for (int r = 0; r < NombreReines; r++)//on check la rangée sur la prochaine ligne
            {
                reinePrecedente = this;
                while (reinePrecedente.rangee >= 0 && r != reinePrecedente.rangee//ligne verticale
                       && r - reinePrecedente.rangee != ligne + 1 - reinePrecedente.ligne //digonale gauche
                       && reinePrecedente.rangee - r != ligne + 1 - reinePrecedente.ligne)//diagonale droite
                {
                    reinePrecedente = reinePrecedente.peutPlacer;//on va répéter cette opération pour toutes les autres lignes
                }
                if(reinePrecedente.ligne == 0)
                {
                    new Position(ligne + 1, r, this).PlacerReine();//On place une reine
                } 
            }
            if (ligne == NombreReines)//si la derniere ligne (=nbr de reines) est atteinte: solution
            {
                AfficheSolution(this);// on affiche la solution
                return;
            }
        }
        /*Fonction qui affiche toutes les solutions pour n dames*/
        private static void AfficheSolution(Position Numero)
        {
            NombreSolution++;
            while (Numero.rangee >= 0)
            {
                Console.Write(((char)('a' + Numero.rangee)).ToString());
                Numero = Numero.peutPlacer;
            }
           Console.WriteLine();
        }
        /* La Classe principale*/
        public class Program
        {
            static void Main(string[] args)
            {  
                new Position(0, int.MinValue, null).PlacerReine();//Appel de ma fonction placer reines
                Console.WriteLine("Solutions: " + Position.NombreSolution.ToString());
                Console.ReadLine();
            }
        }
    }
}
