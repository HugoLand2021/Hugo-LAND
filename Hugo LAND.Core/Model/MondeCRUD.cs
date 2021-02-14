using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public static class MondeCRUD
    {

        //Méthode pour les Mondes
        public static void CreerMonde(string description, int limX, int limY)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var nouveauMonde = new Monde()
                {
                    Description = description,
                    LimiteX = limX,
                    LimiteY = limY
                };
                context.Mondes.Add(nouveauMonde);
                context.SaveChanges();
            }
        }
        public static void SupprimeMonde(int id)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.Mondes.Where(c => c.Id == id).First();

                context.Mondes.Remove(result);


                context.SaveChanges();
            }
        }
        public static void ModifDimensions(int id, int limX, int limY)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.Mondes.Where(c => c.Id == id).First();

                result.LimiteX = limX;
                result.LimiteY = limY;

                context.SaveChanges();
            }

        }

        public static void ModifDescription(int id, string description)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.Mondes.Where(c => c.Id == id).First();

                result.Description = description;
                context.SaveChanges();
            }

        }
        public static List<Monde> ListeMonde()
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                return context.Mondes.ToList();
            }
        }

    }
}
