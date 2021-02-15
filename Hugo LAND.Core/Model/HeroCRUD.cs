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
            int newStatInt, int newStatVitalite, string newNomHero, bool newConnection, int idClasse, int idCompteJoueur,
              int idMonde)
        {
            using (var context = new HugoLANDContext())
            {
                var monde = context.Mondes.Where(m => m.Id == idMonde).First();
                var newClasse = context.Classes.Where(c => c.Id == idClasse).First();
                var compteJoueur = context.CompteJoueurs.Where(co => co.Id == idCompteJoueur).First();

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
                var hero = context.Heros.Where(o => o.Id == id).First();

                context.Heros.Remove(hero);

                context.SaveChanges();
            }
        }

        public static void ModifHero(int id, int newNiveau, long newExperience, int newX, int newY, int newStatStr, int newStatDex,
            int newStatInt, int newStatVitalite, string newNomHero, bool newConnection, int idClasse, int idCompteJoueur, int idMonde)
        {
            using (var context = new HugoLANDContext())
            {
                Hero hero = context.Heros.Find(o => o.Id == id).First();

                hero.Niveau = newNiveau;
                hero.Experience = newExperience;
                hero.StatStr = newStatStr;
                hero.StatDex = newStatDex;
                hero.StatInt = newStatInt;
                hero.StatVitalite = newStatVitalite;
                hero.NomHero = newNomHero;

                context.SaveChanges();
            }
        }

        public static void ModifierHero(int id, string prenom, string nom)
        {
            using (var context = new HugoLANDContext())
            {

                context.Heros.Attach(hero);
                context.Entry<Hero>(hero).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static ICollection<ObjetMonde> GetObjetMondes(int heroId, int mondeId, int heroX, int heroY, int radius)
        {
            if (radius > 200)
            {
                throw new RuntimeException();
            }

            using (var context = new HugoLANDContext())
            {
                return context.Mondes.Find(mondeId)
                    .ObjetMondes.Where(obj => Math.Abs(obj.x - heroX) < radius &&
                                              Math.Abs(obj.y - heroY) < radius)
                    .ToList();
            }
        }



        //public static ICollection<ObjetMonde> ObjetsMondesVues(Hero hero)
        //{
        //    using (var context = new HugoLANDContext())
        //    {
        //        var heroView = context.Mondes.Where(o => o.Id == her.Monde.Id);

        //        return heroView.ObjetMondes;
        //    }
        //} // Revoir si je dois faire du for dans du for pour sortir chaque coordonnés

        public static ICollection<Hero> RetourneHerosCompte(int idCompteJoueur)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.CompteJoueurs.Where(c => c.Id == idCompteJoueur).First().Heros;
                return result;
            }
        }

        public static void DeplaceHero(int idHero, int newX, int newY)
        {
            using (var context = new HugoLANDContext())
            {
                var hero = context.Heros.Where(h => h.Id == idHero).First();

                hero.x = newX;
                hero.y = newY;
                context.SaveChanges();
            }
        }
    }
}
