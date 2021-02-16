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
                hero.InventaireHeroes.Add(new InventaireHero()
                {
                    Hero = hero,
                    Item = item
                });
                context.SaveChanges();
            }
        }

        public static void ModifierItem(int idItem,int idHero, int quantite)
        {
            if (quantite < 0)
                throw new Exception("ErreurQuantitéNégative");

            using (HugoLANDContext context = new HugoLANDContext())
            {
                Hero hero = context.Heros.Find(idHero);
                Item item = context.Items.Find(idItem);
                int nombreItems = hero.InventaireHeroes.Where(i => i.Item.Id == idItem).Count();

                if (nombreItems > quantite) //En retirer
                {
                    for (int i = 0; i < Math.Abs(quantite - nombreItems); i++)
                    {
                        hero.InventaireHeroes.Add(new InventaireHero()
                        {
                            Item = item,
                            Hero = hero
                        });
                    }
                }
                else if (nombreItems < quantite)  // En ajouter
                {
                    for (int i = 0; i < Math.Abs(quantite - nombreItems); i++)
                    {
                        hero.InventaireHeroes.Remove()
                    }

                }
                context.SaveChanges();
            }
        }
    }
}
