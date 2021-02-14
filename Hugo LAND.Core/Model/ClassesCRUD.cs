using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public static class ClassesCRUD
    {
        public static void CreerClasse(string nom, string description, int str, int dex, int ints, int vit, int idMonde)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var monde = context.Mondes.Where(m => m.Id == idMonde).First();

                var nouvelleClasse = new Classe()
                {
                    NomClasse = nom,
                    Description = description,
                    StatBaseStr = str,
                    StatBaseDex = dex,
                    StatBaseInt = ints,
                    StatBaseVitalite = vit,
                    Monde = monde
                };
                context.Classes.Add(nouvelleClasse);

                context.SaveChanges();
            }
        }

        public static void SupprimeClasse(int id)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.Classes.Where(c => c.Id == id).First();

                context.Classes.Remove(result);

                context.SaveChanges();
            }
        }

        public static void ModifClasse(int id,string nom, string description, int str, int dex, int ints, int vit, int idMonde)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.Classes.Where(c => c.Id == id).First();
                var monde = context.Mondes.Where(m => m.Id == idMonde).First();

                result.NomClasse = nom;
                result.Description = description;
                result.StatBaseStr = str;
                result.StatBaseDex = dex;
                result.StatBaseInt = ints;
                result.StatBaseVitalite = vit;
                result.Monde = monde;

                context.SaveChanges();
            }
        }

        public static ICollection<Classe> RetournerClassesMonde(int idMonde)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.Mondes.Where(c => c.Id == idMonde).First().Classes;
                return result;
            }
        }
        public static Classe RetourneClasseHero(int idHero)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.Heros.Where(c => c.Id == idHero).First().Classe;

                return result;
            }
        }






    }
}
