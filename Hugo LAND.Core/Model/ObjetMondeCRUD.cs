using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public static class ObjetMondeCRUD
    {
        public static void CreeObjetMonde(int newX, int newY, string newDescription, int newTypeObjet, int idMonde)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                Monde monde = context.Mondes.Find(idMonde);
                context.ObjetMondes.Add(new ObjetMonde
                {
                    x = newX,
                    y = newY,
                    Description = newDescription,
                    TypeObjet = newTypeObjet,
                    Monde = monde
                });
                context.SaveChanges();
            }
        }

        public static void SupprimeObjetMonde(int id) 
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                context.ObjetMondes.Remove(context.ObjetMondes.Find(id));
                context.SaveChanges();
            }

        }
        public static void ChangeDescriptionObjetMonde(int id, string newDescription)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                ObjetMonde objetMonde = context.ObjetMondes.Find(id);
                objetMonde.Description = newDescription; 
                context.SaveChanges();
            }
        }
    }
}
