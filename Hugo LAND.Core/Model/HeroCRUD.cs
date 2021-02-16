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
            using (HugoLANDContext context = new HugoLANDContext())
            {
                Monde monde = context.Mondes.Find(idMonde);
                Classe classe = context.Classes.Find(idClasse);
                CompteJoueur compteJoueur = context.CompteJoueurs.Find(idCompteJoueur);
                context.Heros.Add(new Hero
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
                    Classe = classe,
                    CompteJoueur = compteJoueur,
                    Monde = monde
                });
                context.SaveChanges();
            }
        }

        public static void SupprimeHero(int id)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                context.Heros.Remove(context.Heros.Find(id));
                context.SaveChanges();
            }
        }

        public static void ModifHero(int id, int newNiveau, long newExperience, int newStatStr, int newStatDex,
            int newStatInt, int newStatVitalite, string newNomHero)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                Hero hero = context.Heros.Find(id);
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

        public static ICollection<ObjetMonde> RetourneObjetMondes(int mondeId, int heroX, int heroY, int rayon)
        {
            if (rayon > 200 || rayon <= 0)
            {
                throw new Exception("DimensionRayonPasBonne");
            }

            using (HugoLANDContext context = new HugoLANDContext())
            {
                return context.Mondes.Find(mondeId)
                    .ObjetMondes.Where(obj => Math.Abs(obj.x - heroX) < rayon &&
                                              Math.Abs(obj.y - heroY) < rayon)
                    .ToList();
            }
        }

        public static ICollection<Hero> RetourneHerosCompte(int idCompteJoueur)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                return context.CompteJoueurs.Find(idCompteJoueur).Heros;
            }
        }

        public static void DeplaceHero(int idHero, int newX, int newY)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                Hero hero = context.Heros.Find(idHero);
                hero.x = newX;
                hero.y = newY;
                context.SaveChanges();
            }
        }
    }
}
