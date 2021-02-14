using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public class CompteJoueurs //
    {
        public static void CreerJoueur(string nomJoueur, string courriel, string prenom, string nom, int typeUtilisateur, string mdp, Guid salt, Hero hero)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                context.CreerCompteJoueur(nomJoueur, courriel, prenom, nom, typeUtilisateur, mdp, null);//A revoir le null.


                context.SaveChanges();

            }
        }

        public static void SupprimerJoueur(int id)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.CompteJoueurs.Where(c => c.Id == id);

                context.CompteJoueurs.Remove((CompteJoueur)result);

                context.SaveChanges();

            }
        }

        public static void ModifCompteJoueur(int id, string nomJoueur, string courriel, string prenom, string nom, int typeUtilisateur, string mdp, ICollection<Hero> hero)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.CompteJoueurs.Where(c => c.Id == id).Single();
                

                context.CompteJoueurs.Find(result).NomJoueur = nomJoueur;
                context.CompteJoueurs.Find(result).Courriel = courriel;
                context.CompteJoueurs.Find(result).Prenom = prenom;
                context.CompteJoueurs.Find(result).Nom = nom;
                context.CompteJoueurs.Find(result).TypeUtilisateur = typeUtilisateur;
                context.CompteJoueurs.Find(result).MotDePasseHash = Encoding.ASCII.GetBytes(mdp);
                context.CompteJoueurs.Find(result).Heros = hero;
                

                context.SaveChanges();
            }
        }

        public bool ValideJoueur(string nom, string mdp)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.CompteJoueurs.Where(c => c.NomJoueur == nom && c.MotDePasseHash == Encoding.ASCII.GetBytes(mdp));

                if (result != null)
                {
                    int connect = 0;
                    connect = context.Connexion(context.CompteJoueurs.Find().NomJoueur, context.CompteJoueurs.Find().MotDePasseHash.ToString(), null);

                    if (connect == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
