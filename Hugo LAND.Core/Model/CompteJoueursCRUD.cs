using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_LAND.Core.Model
{
    public static class CompteJoueursCRUD //
    {
        public static void CreerJoueur(string nomJoueur, string courriel, string prenom, string nom, int typeUtilisateur, string mdp)
        {
            ObjectParameter message = new ObjectParameter("message", typeof(string));

            using (HugoLANDContext context = new HugoLANDContext())
            {
                context.CreerCompteJoueur(nomJoueur, courriel, prenom, nom, typeUtilisateur, mdp, message);

                Console.WriteLine(message.Value);
                context.SaveChanges();

            }
        }

        public static void SupprimerJoueur(int id)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                var result = context.CompteJoueurs.Find(id);

                context.CompteJoueurs.Remove(result);

                context.SaveChanges();

            }
        }

        public static void ModifCompteJoueur(int id, string nomJoueur, string courriel, string prenom, string nom, int typeUtilisateur, string mdp)
        {
            using (HugoLANDContext context = new HugoLANDContext())
            {
                CompteJoueur result = context.CompteJoueurs.Find(id);
                result.NomJoueur = nomJoueur;
                result.Courriel = courriel;
                result.Prenom = prenom;
                result.Nom = nom;
                result.TypeUtilisateur = typeUtilisateur;
                result.MotDePasseHash = Encoding.ASCII.GetBytes(mdp); // Procédure stocké pour gérer le changement de mot de passe.
                context.SaveChanges();
            }
        }

        public static bool ValideJoueur(string nom, string mdp)
        {
            ObjectParameter message = new ObjectParameter("message", typeof(string));

            using (HugoLANDContext context = new HugoLANDContext())
            {

                    int connect = 0;
                    connect = context.Connexion(nom, mdp, message);

                    if (connect == 1)
                    {
                        Console.WriteLine(message.Value);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(message.Value);
                        return false;
                    }

            }
        }
    }
}
