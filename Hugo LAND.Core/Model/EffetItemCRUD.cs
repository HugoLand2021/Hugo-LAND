using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public class EffetItemCRUD
    {
        public static void CreeEffetItem(int newValeurEffet, int newTypeEffet, Item item)
        {
            using (var context = new HugoLANDContext())
            {
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


        public static void SupprimeEffetItem(int id, Item item)
        {
            using (var context = new HugoLANDContext())
            {
                var effetItems = context.EffetItems.Where(i => i.Id == id && i.Item == item);

                context.EffetItems.Remove((EffetItem)effetItems); //Essayer avec le cast explicit, si fonctionne pas, pisser sur Falco, montrer qui est le male dominant.

                context.SaveChanges();
            }

        }


        public static void ChangeEffetItem(int id, int changedValeurEffet, int changedTypeEffet, Item item)
        {
            using (var context = new HugoLANDContext())
            {
                var effetItems = context.EffetItems.Where(i => i.Id == id && i.Item == item);

                context.EffetItems.Find(effetItems).ValeurEffet = changedValeurEffet; //Essayer avec le cast explicit, si fonctionne pas, pisser sur Falco, montrer qui est le male dominant.
                context.EffetItems.Find(effetItems).TypeEffet = changedTypeEffet;

                context.SaveChanges();
            }

        }

    }
}
