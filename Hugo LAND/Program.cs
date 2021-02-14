using Hugo_LAND.Core;
using Hugo_LAND.Core.Model;
using System;
using System.Data.Entity.Core.Objects;

namespace Hugo_LAND
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Range de test pour le MondeCRUD
             
            MondeCRUD.CreerMonde("Globule",100,100);
            MondeCRUD.SupprimeMonde(5);
            MondeCRUD.ModifDescription(2, "Huile dolive");
            MondeCRUD.ModifDimensions(2, 150, 150);
            var poop = MondeCRUD.ListeMonde();
            foreach(Monde pooper in poop)
            {
                Console.WriteLine($"ID : {pooper.Id}");
                Console.WriteLine($"Description : {pooper.Description}");
            };

            */

            /*  Range de test pour les ObjetMondes
             
            ObjetMondeCRUD.CreeObjetMonde(20, 21, "Sauce", 3, 2);
            ObjetMondeCRUD.CreeObjetMonde(21, 21, "Sauce", 3, 2);
            ObjetMondeCRUD.CreeObjetMonde(22, 21, "Sauce", 3, 2);
            ObjetMondeCRUD.CreeObjetMonde(22, 22, "Sauce", 3, 2);
            ObjetMondeCRUD.SupprimeObjetMonde(2);
            ObjetMondeCRUD.ChangeDescriptionObjetMonde(4, "Sauce rosée");

            */

            /* Range de test pour les Monstres
             
            MonstreCRUD.CreerMonstre("Cancer", 3, 13, 25, 30, 4, 12, null, 3);
            MonstreCRUD.ModifierMonstre(1, "Bolero", 4, 13, 25, 35, 5, 14, null, 2);

            */

            /* Range de test pour les CompteJoueurs
             
            CompteJoueursCRUD.CreerJoueur("Random-Pal", "Arnaudzetaime@gaymail.com", "Arnaud", "Labrecque", 4, "SucksTObeU");
            CompteJoueursCRUD.SupprimerJoueur(2);
            CompteJoueursCRUD.ModifCompteJoueur(3, "JetManger", "AntonynyneCoolDextraze@gmail.com", "Anthony", "Dextrazio", 1, "GirlHunterzz64");
            CompteJoueursCRUD.ValideJoueur("Random-Pal", "SucksTObeU");

            */



        }
    }
}
