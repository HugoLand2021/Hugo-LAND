using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public static class ItemCRUD
    {
        public static void CreerItem(string nom, string description, Nullable<int> x, Nullable<int> y, Nullable<int> imageId, int mondeId)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                Monde monde = context.Mondes.Find(mondeId);
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

        public static void SupprimerItem(int idItem, int idHero)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                Hero hero = context.Heros.Find(idHero);
                Item item = context.Items.Find(idItem);
                item.x = null;
                item.y = null;
                item.Hero = hero;
                hero.Items.Add(item);
                context.SaveChanges();
            }
        }

        public static void ModifierQuantiteItem(int idItem, int idHero, int quantite) //On s'excuse 
        {
            if (quantite < 0)
                throw new Exception("ErreurQuantitéNégative");

            using (HugoLANDContext context = new HugoLANDContext())
            {
                Hero hero = context.Heros.Find(idHero);
                Item item = context.Items.Find(idItem);
                int nombreItems = hero.Items.Where(it => it.Nom == item.Nom && it.Hero.Id == idHero && it.Monde.Id == item.Monde.Id).Count();
                int nombreDiff = Math.Abs(quantite - nombreItems);
                if (nombreDiff > 0)
                {
                    if (nombreItems < quantite) //En ajouter
                    {
                        for (int i = 0; i < nombreDiff; i++)
                        {
                            CreerItem(item.Nom, item.Description, item.x, item.y, item.ImageId, item.Monde.Id);
                            SupprimerItem(context.Items.ToList().LastOrDefault(it => it.Nom == item.Nom).Id,idHero);
                        }
                    }
                    else if (nombreItems > quantite)  // En retirer
                    {
                        for (int i = 0; i < nombreDiff; i++)
                        {
                            Item itemRemove = context.Items.ToList().LastOrDefault(it => it.Nom == item.Nom && it.Hero.Id == idHero && it.Monde.Id == item.Monde.Id);
                            hero.Items.Remove(itemRemove);
                            context.Items.Remove(context.Items.Find(itemRemove.Id));
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
