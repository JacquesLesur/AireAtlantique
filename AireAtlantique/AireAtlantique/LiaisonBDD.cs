using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireAtlantique
{
    public class LiaisonBDD
    {
        public static void AjouterEmployer(string nom, string prenom)
        {
            using (var db = new DBtestContext())
            {
                db.Employes.Add(new Employe()
                {
                    Nom=nom,
                    Prenom=prenom
                  
                });

                db.SaveChanges();
                

            }
            
        }
       
    }
}
