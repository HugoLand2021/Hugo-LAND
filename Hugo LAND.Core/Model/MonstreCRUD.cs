using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{

    //        public int Id { get; set; }
    //public string Nom { get; set; }
    //public int Niveau { get; set; }
    //public int x { get; set; }
    //public int y { get; set; }
    //public int StatPV { get; set; }
    //public float StatDmgMin { get; set; }
    //public float StatDmgMax { get; set; }
    //public Nullable<int> ImageId { get; set; }

    //public virtual Monde Monde { get; set; }
    public class MonstreCRUD
    {
        public static void CreerMonstre()
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                context.Monstres.Add( new Monstre()
                {

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
        public static void ModifierMonstre(int ID, int ImageId, Monde monde, int niveau, string nom,  float statDmgMax, float statDmgMin, int statPv, int x, int y)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var monstre = context.Monstres.Where(m => m.Id == ID).Single();
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
