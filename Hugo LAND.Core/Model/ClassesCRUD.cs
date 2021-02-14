using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public class ClassesCRUD
    {
        public static void CréerClasse(string nom, string description, int str, int dex, int ints, int vit, Monde monde, ICollection<Hero> hero)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var nouvelleClasse = new Classe()
                {
                    NomClasse = nom,
                    Description = description,
                    StatBaseStr = str,
                    StatBaseDex = dex,
                    StatBaseInt = ints,
                    StatBaseVitalite = vit,
                    Monde = monde,
                    Heros = hero
                };
                context.Classes.Add(nouvelleClasse);

                context.SaveChanges();
            }
        }

        public static void SupprimeClasse(int id)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.Classes.Where(c => c.Id == id);

                context.Classes.Remove((Classe)result);

                context.SaveChanges();
            }
        }

        public static void ModifClasse(int id,string nom, string description, int str, int dex, int ints, int vit, Monde monde, ICollection<Hero> hero)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.Classes.Where(c => c.Id == id);

                context.Classes.Find(result).NomClasse = nom;
                context.Classes.Find(result).Description = description;
                context.Classes.Find(result).StatBaseStr = str;
                context.Classes.Find(result).StatBaseDex = dex;
                context.Classes.Find(result).StatBaseInt = ints;
                context.Classes.Find(result).StatBaseVitalite = vit;
                context.Classes.Find(result).Monde = monde;
                context.Classes.Find(result).Heros = hero;

                context.SaveChanges();



            }
        }

        public List<Classe> RetournerClassesMonde(Monde monde)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                //var result = context.Mondes.Where(c => c.m == id).First().Classes;
                var result = context.Classes.Where(c => c.Monde == monde);


                return result.ToList();
            }
        }
        public Classe RetourneClasseHero(ICollection<Hero> hero)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.Classes.Where(c => c.Heros == hero);

                return (Classe)result;

            }
        }






    }
}
