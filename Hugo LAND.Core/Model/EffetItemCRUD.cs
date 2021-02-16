using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public static class EffetItemCRUD
    {
        public static void CreeEffetItem(int newValeurEffet, int newTypeEffet, int idItem)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                Item item = context.Items.Find(idItem);
                context.EffetItems.Add(new EffetItem
                {
                    ValeurEffet = newValeurEffet,
                    TypeEffet = newTypeEffet,
                    Item = item
                });
                context.SaveChanges();
            }
        }

        public static void SupprimeEffetItem(int id)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                context.EffetItems.Remove(context.EffetItems.Find(id));
                context.SaveChanges();
            }
        }

        public static void ModifEffetItem(int id, int changedValeurEffet, int changedTypeEffet)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                EffetItem effetItems = context.EffetItems.Find(id);
                effetItems.ValeurEffet = changedValeurEffet;
                effetItems.TypeEffet = changedTypeEffet;
                context.SaveChanges();
            }

        }

    }
}
