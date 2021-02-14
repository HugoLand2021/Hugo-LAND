using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public class MonstreCRUD
    {
        public static void CreerMonstre(string nom, int niveau, int x, int y, int statPv, float statDmgMin, float statDmgMax, Nullable<int> imageId, int idMonde)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var monde = context.Mondes.Where(o => o.Id == idMonde).First();

                context.Monstres.Add(new Monstre()
                {
                    Nom = nom,
                    Niveau = niveau,
                    x = x,
                    y = y,
                    StatPV = statPv,
                    StatDmgMin = statDmgMin,
                    StatDmgMax = statDmgMax,
                    ImageId= imageId,
                    Monde = monde
                });
                context.SaveChanges();
            }
        }
        public static void SupprimerMonstre(int ID)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                context.Monstres.Remove(context.Monstres.Where(m => m.Id.Equals(ID)).Single());
                context.SaveChanges();
            }
        }
        public static void ModifierMonstre(int ID, string nom, int niveau, int x, int y, int statPv,  float statDmgMin, float statDmgMax, Nullable<int> ImageId, int idMonde)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var monstre = context.Monstres.Where(m => m.Id == ID).Single();
                var monde = context.Mondes.Where(o => o.Id == idMonde).First();

                monstre.ImageId = ImageId;
                monstre.Monde = monde;
                monstre.Niveau = niveau;
                monstre.Nom = nom;
                monstre.StatDmgMax = statDmgMax;
                monstre.StatDmgMin = statDmgMin;
                monstre.StatPV = statPv;
                monstre.x = x;
                monstre.y = y;
                context.SaveChanges();
            }
        }
    }
}
