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
            using (var context = new HugoLANDContext())
            {
                var item = context.Items.Where(m => m.Id == idItem).First();

                var newEffetItem = new EffetItem
                {
                    ValeurEffet = newValeurEffet,
                    TypeEffet = newTypeEffet,
                    Item = item

                };
                context.EffetItems.Add(newEffetItem);
                context.SaveChanges();
            }
        }


        public static void SupprimeEffetItem(int id)
        {
            using (var context = new HugoLANDContext())
            {
                var effetItems = context.EffetItems.Where(i => i.Id == id).First();

                context.EffetItems.Remove(effetItems);
                context.SaveChanges();
            }

        }


        public static void ModifEffetItem(int id, int changedValeurEffet, int changedTypeEffet)
        {
            using (var context = new HugoLANDContext())
            {
                var effetItems = context.EffetItems.Where(e => e.Id == id).First();

                effetItems.ValeurEffet = changedValeurEffet;
                effetItems.TypeEffet = changedTypeEffet;

                context.SaveChanges();
            }

        }

    }
}
