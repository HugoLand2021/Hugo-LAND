using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public static class HeroCRUD
    {
        public static void CreeHero(int newNiveau, long newExperience, int newX, int newY, int newStatStr, int newStatDex,
            int newStatInt, int newStatVitalite, string newNomHero, bool newConnection, Classe newClasse, CompteJoueur compteJoueur,
              Monde monde)
        {
            using (var context = new HugoLANDContext())
            {
                var newHero = new Hero // Dans le constructeur d'hero il fait deja un call de this.inventaire etc. Je prend le monde en paramêtre aussi ?
                {
                    Niveau = newNiveau,
                    Experience = newExperience,
                    x = newX,
                    y = newY,
                    StatStr = newStatStr,
                    StatDex = newStatDex,
                    StatInt = newStatInt,
                    StatVitalite = newStatVitalite,
                    NomHero = newNomHero,
                    EstConnecte = newConnection,
                    Classe = newClasse,
                    CompteJoueur = compteJoueur,
                    Monde = monde
                };

                context.Heros.Add(newHero);
                context.SaveChanges();
            }
        }

        public static void SupprimeHero(int id)
        {
            using (var context = new HugoLANDContext())
            {
                var hero = context.Heros.Where(o => o.Id == id);

                context.ObjetMondes.Remove((ObjetMonde)hero); //Essayer avec le cast explicit, si fonctionne pas, pisser sur Falco, montrer qui est le male dominant.

                context.SaveChanges();
            }
        }

        public static void ChangeHero(int id, int newNiveau, long newExperience, int newX, int newY, int newStatStr, int newStatDex,
            int newStatInt, int newStatVitalite, string newNomHero, bool newConnection, Classe newClasse, CompteJoueur compteJoueur,
             ICollection<InventaireHero> newInventaireHeroes, Monde monde, ICollection<Item> newItems)
        {
            using (var context = new HugoLANDContext())
            {
                var hero = context.Heros.Where(o => o.Id == id).First();

                hero.Niveau = newNiveau;
                hero.Experience = newExperience;
                hero.x = newX;
                hero.y = newY;
                hero.StatStr = newStatStr;
                hero.StatDex = newStatDex;
                hero.StatInt = newStatInt;
                hero.StatVitalite = newStatVitalite;
                hero.NomHero = newNomHero;
                hero.EstConnecte = newConnection;
                hero.Classe = newClasse;
                hero.CompteJoueur = compteJoueur;
                hero.InventaireHeroes = newInventaireHeroes;
                hero.Items = newItems;
                hero.Monde = monde;
                // Voir avec les boys si on modifie tous ?????!???!??!?
                context.SaveChanges();
            }
        }

        public static ICollection<ObjetMonde> ObjetsMondesVues(Hero hero)
        {
            using (var context = new HugoLANDContext())
            {
                var heroView = context.Mondes.Where(o => o.Id == hero.Monde.Id);

                return context.Mondes.Find(heroView).ObjetMondes;
            }
        } // Revoir si je dois faire du for dans du for pour sortir chaque coordonnés

        public static ICollection<Hero> RetourneHerosCompte(CompteJoueur compteJoueur)
        {
            return compteJoueur.Heros;
        }

        public static void DeplaceHero(Hero hero, int newX, int newY)
        {
            using (var context = new HugoLANDContext())
            {
                var heroToMove = hero;

                heroToMove.x = newX;
                heroToMove.y = newY;
                context.SaveChanges();
            }
        }
    }
}
