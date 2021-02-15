using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public static class ItemCRUD
    {


        public static void CreerItem(string nom, string description, int x, int y, Nullable<int> imageId, int mondeId)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var monde = context.Mondes.Find(mondeId);// On passe un ID, On recherche le hero basé sur l'Id, on pogne le hero et c'est lui qu'on passe

                context.Items.Add(new Item()
                {
                    Nom = nom,
                    Description = description,
                    x = x,
                    y = y,
                    ImageId = imageId,
                    Hero = null,
                    Monde = monde
                });


                context.SaveChanges();
            }
        }

        public static void SupprimerItem(int id, int idHero)
        {

            using (HugoLANDContext context = new HugoLANDContext())
            {
                Hero hero = context.Heros.Find(idHero);
                Item item = context.Items.Find(id);
                item.x = null;
                item.y = null;
                item.Hero = hero;
                hero.InventaireHeroes.Add(new InventaireHero()
                {
                    Hero = hero,
                    Item = item
                });
                hero.Items.Add(item);
                context.SaveChanges();
            }
        }

        public static void ModifierItem(int idHero)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                //Hero hero = context.Heros.Where(h => h.Id == id).FirstOrDefault();
                //Item item = context.Items.Where(m => m.Id == id).FirstOrDefault();
                context.SaveChanges();
            }
        }
    }
}
