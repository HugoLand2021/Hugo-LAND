using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public static class ObjetMondeCRUD
    {
        /// <summary>
        /// Auteur : Arnaud Labrecque
        /// Descritption : Créer un nouveau ObjetMonde pour un Monde spécifique.
        /// Date : 2021-02-10
        /// </summary>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <param name="newDescription"></param>
        /// <param name="newTypeObjet"></param>
        /// <param name="monde"></param>
        public static void CreeObjetMonde(int newX, int newY, string newDescription, int newTypeObjet, int idMonde)
        {
            using (var context = new HugoLANDContext())
            {
                var monde = context.Mondes.Where(m => m.Id == idMonde).First();

                var newObjetMonde = new ObjetMonde
                {
                    x = newX,
                    y = newY,
                    Description = newDescription,
                    TypeObjet = newTypeObjet,
                    Monde = monde
                };

                context.ObjetMondes.Add(newObjetMonde);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Auteur : Arnaud Labrecque
        /// Descritption : Supprimer un ObjetMonde pour un Monde spécifique.
        /// Date : 2021-02-10
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monde"></param>
        public static void SupprimeObjetMonde(int id) 
        {
            using (var context = new HugoLANDContext())
            {
                var objetMonde = context.ObjetMondes.Where(o => o.Id == id).First();

                context.ObjetMondes.Remove(objetMonde); //Essayer avec le cast explicit, si fonctionne pas, pisser sur Falco, montrer qui est le male dominant.

                context.SaveChanges();
            }

        }

        /// <summary>
        /// Auteur : Arnaud Labrecque
        /// Descritption : Modifier la description d’un ObjetMonde pour un Monde spécique.
        /// Date : 2021-02-10
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monde"></param>
        /// <param name="newDescription"></param>
        public static void ChangeDescriptionObjetMonde(int id, /*int idMonde, */string newDescription)
        {
            using (var context = new HugoLANDContext())
            {
                //var monde = context.Mondes.Where(o => o.Id == idMonde).First();

                var objetMonde = context.ObjetMondes.Where(o => o.Id == id/* && o.Monde == monde*/).First();

                objetMonde.Description = newDescription; //Essayer avec le cast explicit, si fonctionne pas, pisser sur Falco, montrer qui est le male dominant.

                context.SaveChanges();
            }

        }

    }
}
