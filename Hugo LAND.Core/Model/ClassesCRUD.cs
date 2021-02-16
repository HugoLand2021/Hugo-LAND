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
                Monde monde = context.Mondes.Find(idMonde);
                context.Classes.Add(new Classe()
                {
                    NomClasse = nom,
                    Description = description,
                    StatBaseStr = str,
                    StatBaseDex = dex,
                    StatBaseInt = ints,
                    StatBaseVitalite = vit,
                    Monde = monde
                });
                context.SaveChanges();
            }
        }

        public static void SupprimeClasse(int id)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                context.Classes.Remove(context.Classes.Find(id));
                context.SaveChanges();
            }
        }

        public static void ModifClasse(int id, string nom, string description, int str, int dex, int ints, int vit, int idMonde)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                Classe result = context.Classes.Find(id);
                Monde monde = context.Mondes.Find(idMonde);
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
                return context.Mondes.Find(idMonde).Classes;
            }
        }
        public static Classe RetourneClasseHero(int idHero)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                return context.Heros.Find(idHero).Classe;
            }
        }
    }
}
