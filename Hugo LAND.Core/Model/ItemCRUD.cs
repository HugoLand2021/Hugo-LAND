using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public static class ItemCRUD
    {

        //public int Id { get; set; }
        //public string Nom { get; set; }
        //public string Description { get; set; }
        //public Nullable<int> x { get; set; }
        //public Nullable<int> y { get; set; }
        //public Nullable<int> ImageId { get; set; }
        //public virtual Hero Hero { get; set; }
        //public virtual Monde Monde { get; set; }


        public static void CreerItem(string nom, string description, Nullable<int> x, Nullable<int> y, Nullable<int> imageId, Monde monde)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
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
                Hero hero = context.Heros.Where(h => h.Id == id).FirstOrDefault();
                Item item = context.Items.Where(m => m.Id == id).FirstOrDefault();
                item.x = null;
                item.y = null;
                item.Hero = hero;
                hero.InventaireHeroes.Add( new InventaireHero() { 
                    Hero = hero,
                    Item = item
                });
                hero.Items.Add(item);
                context.SaveChanges();
            }
        }

        public static void ModifierItem(int idHero) {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                //Hero hero = context.Heros.Where(h => h.Id == id).FirstOrDefault();
                //Item item = context.Items.Where(m => m.Id == id).FirstOrDefault();
                context.SaveChanges();
            }
        }
    }
}
