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
             
            Console.WriteLine(CompteJoueursCRUD.CreerJoueur("Random-Pal", "Arnaudzetaime@gaymail.com", "Arnaud", "Labrecque", 4, "SucksTObeU"));
            CompteJoueursCRUD.SupprimerJoueur(2);
            CompteJoueursCRUD.ModifCompteJoueur(3, "JetManger", "AntonynyneCoolDextraze@gmail.com", "Anthony", "Dextrazio", 1, "GirlHunterzz64");
            CompteJoueursCRUD.ValideJoueur("Random-Pal", "SucksTObeU");

            */

            /* Range de test pour les Items
             
            ItemCRUD.CreerItem("Potion de Vigueur", "Augmente le debit d'eau", 23, 10, null, 3);

            */

            /* Range de test pour les ItemsEffets
             
            */


            /* Range de test pour les Heros
                         HeroCRUD.CreeHero(1,0,1,1,1,1,1,50,"Peteux",false,2,5,1);
                        HeroCRUD.ModifHero(2,4,5000,10,13,123,20,10,500,"senteux ultime",false,2,5,4);
                    HeroCRUD.SupprimeHero(2);
                        var poop = HeroCRUD.RetourneHerosCompte(5);
            foreach (Hero pooper in poop)
            {
                Console.WriteLine($"ID : {pooper.Id}");
                Console.WriteLine($"Nom hero : {pooper.NomHero}");
            };
            
                        HeroCRUD.DeplaceHero(1,2,2);


            */


            /* Range de test pour les Classes
                ClassesCRUD.CreerClasse("Chevalier", "force brute est son troisieme nom", 5, 2, 0, 8, 3);
                ClassesCRUD.CreerClasse("Magicien Démoniaque", "force démoniaque est son quatrieme nom", 2, 5, 8, 1, 3);
                ClassesCRUD.Modif("trou de pete", "sens fort", 23, 53, 82, 14, 3);
                ClassesCRUD.SupprimeClasse(4);
                        var poop = ClassesCRUD.RetournerClassesMonde(3);          
            Console.WriteLine(ClassesCRUD.RetourneClasseHero(1).NomClasse); 
            foreach (Classe pooper in poop)
            {
                Console.WriteLine($"ID : {pooper.Id}");
                Console.WriteLine($"Description : {pooper.Description}");
            };
            */

            EffetItemCRUD.SupprimeEffetItem(1);
        }
    }
}
