using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireAtlantique
{
    class LiaisonBDD
    {
        public static void AjouterEmployer(string nom, string prenom,int numeroTelephone, DateTime dateNaissance, Metier metier)
        {
            using (var db = new DBtestContext())
            {
                db.Employes.Add(new Employe()
                {
                    Nom = nom,
                    Prenom = prenom,
                    numeroTelephone = numeroTelephone,
                    dateNaissance = dateNaissance,
                    //il est important de ne pas metre l'obje directement car sinon cela en fait une copi 
                    //et on se retrouve avec de doublons
                    Metier = (from metierItem in db.Metier
                              where metierItem.IDMetier == metier.IDMetier
                              select metierItem).First()

                });

                db.SaveChanges();


            }

        }
        public static void modifierEmployer(int idEmploye, string nom, string prenom,int numTelephone, DateTime dateNaissance, Metier metierSelectionne)
        {
            using (var db = new DBtestContext())
            {
                Metier nouveauMetier = (from metierItem in db.Metier
                                        where metierItem.IDMetier == metierSelectionne.IDMetier
                                        select metierItem).First();
                Employe employerModifier = db.Employes.Find(idEmploye);
                employerModifier.Nom = nom;
                employerModifier.Prenom = prenom;
                employerModifier.Metier = nouveauMetier;
                employerModifier.dateNaissance = dateNaissance;
                employerModifier.numeroTelephone = numTelephone;
                db.SaveChanges();


            }

        }
        public static void AjouterFormation(string nom, string Description, int validitee,List<Metier> metersSelectionnes)
        {
            using (var db = new DBtestContext())
            {
                List<Metier> listMetier = new List<Metier>();
                foreach (var metierSelectionne in metersSelectionnes)
                {
                    Metier metier = (from metierItem in db.Metier
                                  where metierItem.IDMetier == metierSelectionne.IDMetier
                                  select metierItem).First();
                    listMetier.Add(metier);
                }
                db.Formations.Add(new Formation()
                {
                    Nom = nom,
                    Description = Description,
                    Validité = validitee,
                    listMetier = listMetier
                        
                    });

                    db.SaveChanges();
                }

            
        }


        internal static void AjouterSession(string nomSession,int nombreMaxEmploye, DateTime dateSession, Formation formationSelectionne)
        {
            using (var db = new DBtestContext())
            {
                db.Sessions.Add(new Session()
                {
                    Nom = nomSession,
                    NombreMaxEmploye = nombreMaxEmploye,
                    DateSession = dateSession,
                    Formation = (from formationitem in db.Formations
                                 where formationitem.IDFormation == formationSelectionne.IDFormation
                                 select formationitem).First()

            });

                db.SaveChanges();


            }
        }
        internal static void AjouterMetier(string nomMetier)
        {
            using (var db = new DBtestContext())
            {
                db.Metier.Add(new Metier()
                {
                    Nom = nomMetier
                });

                db.SaveChanges();


            }
        }
        internal static void AjouterEmployeSession(Session sessionSelectionne, List<Employe> listEmploye)
        {

            foreach (Employe employeAAjouter in listEmploye)
            {
                using (var db = new DBtestContext())
                {

                    var sessionLie = (from laSession in db.Sessions
                                      where laSession.IDSession == sessionSelectionne.IDSession
                                      select laSession).First();

                    Employe employeSelectionne = (from employeItem in db.Employes
                                                  where employeItem.IDEmploye == employeAAjouter.IDEmploye
                                                  select employeItem).First();

                    sessionLie.listeEmploye = new List<Employe>();
                    sessionLie.listeEmploye.Add(employeSelectionne);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex) //affiche l'erreur
                    {
                        var sb = new StringBuilder();
                        foreach (var failure in ex.EntityValidationErrors)
                        {
                            sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                            foreach (var error in failure.ValidationErrors)
                            {
                                sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                                sb.AppendLine();
                            }
                        }
                        throw new DbEntityValidationException(
                            "Entity Validation Failed - errors follow:\n" +
                            sb.ToString(), ex
                        );
                    }

                }
            }
        }
        public static void SupprimerEmployer(Employe employeSupprimer)
        {
            using (var db = new DBtestContext())
            {
                Employe employe = (from employeItem in db.Employes
                                  where employeItem.IDEmploye == employeSupprimer.IDEmploye
                                   select employeItem).First();
                db.Employes.Remove(employe);

                db.SaveChanges();


            }

        }
        public static void SupprimerEmployerSession(Employe employeSelectionne, Session sessionSelectionne)
        {
            using (var db = new DBtestContext())
            {


                Employe employe = (from employeItem in db.Employes
                                   where employeItem.IDEmploye == employeSelectionne.IDEmploye
                                   select employeItem).First();
                var listEmployes = (from sessionItem in db.Sessions
                                    where sessionItem.IDSession == sessionSelectionne.IDSession
                                    select sessionItem.listeEmploye).First().ToList();

                List<Employe> listEmployeTemp = listEmployes;

                //sessionRecherche.listeEmploye.Remove(employe);
                listEmployeTemp.Remove(employe);

                listEmployes = listEmployeTemp;
                //for (int i = listEmployes.Count()-1; i >= 0; i--)
                //{
                //    if (listEmployes[i].Nom == nom && listEmployes[i].Prenom == prenom)
                //    {
                //        listEmployes.Remove(listEmployes[i]);
                //    }
                //}

                db.SaveChanges();


            }

        }
        public static void SupprimerSession(string nom)
        {
            using (var db = new DBtestContext())
            {
                Session session = (from sessionItem in db.Sessions
                                   where sessionItem.Nom == nom
                                   select sessionItem).First();
                db.Sessions.Remove(session);

                db.SaveChanges();


            }

        }
        public static void SupprimerFormation(Formation formationSelectionne)
        {
            using (var db = new DBtestContext())
            {
                Formation formation = (from formationItem in db.Formations
                                   where formationItem.IDFormation == formationSelectionne.IDFormation
                                       select formationItem).First();
                db.Formations.Remove(formation);

                db.SaveChanges();


            }

        }

        public static Formation RecupererFormationSession(Session session)
        {
            using (var db = new DBtestContext())
            {

                
                Formation formationSession = (from SessionItem in db.Sessions
                                    where SessionItem.Nom == session.Nom
                                    select SessionItem.Formation).First();


               
                return formationSession;

            }
        }
        public static List<Employe> RecupererEmployeSession(string nomSession)
        {
            using (var db = new DBtestContext())
            {

                List<Employe> listEmploye = new List<Employe>();
                var listEmployes = (from sessionItem in db.Sessions
                                             where sessionItem.Nom == nomSession
                                             select sessionItem.listeEmploye);


                foreach (var item in listEmployes.First())
                {
                   
                    listEmploye.Add(item);
                }
                return listEmploye;

            }
        }
        public static List<Employe> RecupererEmployeCorespondantSession(string nomSession)
        {
            using (var db = new DBtestContext())
            {

                List<Employe> listEmploye = new List<Employe>();
                var listEmployes = RecupererEmploye();
                var metierFormation = (from sessionItem in db.Sessions
                                       where sessionItem.Nom == nomSession
                                       select sessionItem.Formation.listMetier).First();
                //on renvoi seulement le employé qui ont un emploi compatible avec la session
                foreach (var employe in listEmployes)
                {
                    Metier metierEmploye = RecupererMetierEmploye(employe);
                    foreach (var metier in metierFormation)
                    {

                        if (metier.Nom == metierEmploye.Nom)
                        {
                            listEmploye.Add(employe);
                        }
                    }

                }

                return listEmploye;

            }
        }
        public static List<Session> RecupererSessionEmploye(Employe employe)
        {
            using (var db = new DBtestContext())
            {
              
                List<Session> listSession = new List<Session>();
                var listEmployes = (from employeItem in db.Employes
                                    where employeItem.IDEmploye == employe.IDEmploye
                                    select employeItem.listeSession).First();


                foreach (var item in listEmployes)
                    listSession.Add(item);

                return listSession;

            }
        }
        public static List<Formation> RecupererFormations()
        {
            using (var db = new DBtestContext())
            {


                List<Formation> formation = (from Formation in db.Formations
                                             select Formation).ToList(); 
                return formation;

            }
        }
        public static List<Session> RecupererSessionFormation(Formation formationSelectionne)
        {
            using (var db = new DBtestContext())
            {


                List<Session> listSession = (from sessionItem in db.Sessions
                                             where sessionItem.Formation.IDFormation == formationSelectionne.IDFormation
                                             select sessionItem).ToList();
                return listSession;

            }
        }
        public static List<Metier> RecupererMetierFormation(Formation formationSelectionne)
        {
            using (var db = new DBtestContext())
            {


                var listMetier = (from formationItem in db.Formations
                                  where formationItem.IDFormation == formationSelectionne.IDFormation
                                  select formationItem.listMetier).First();
                List<Metier> listMetierFormation = new List<Metier>();
                foreach (var metier in listMetier)
                {
                    listMetierFormation.Add(metier);
                }
                return listMetierFormation;

            }
        }
        public static List<Session> RecupererSession()
        {
            using (var db = new DBtestContext())
            {


                List<Session> Session = (from item in db.Sessions
                                             select item).ToList();
                return Session;

            }
        }
        public static List<Employe> RecupererEmploye()
        {
            using (var db = new DBtestContext())
            {


                List<Employe> employe = (from Employe in db.Employes
                                             select Employe).ToList(); ;
                return employe;

            }
        }
        public static Employe RecupererEmployeId(int idEmploye)
        {
            
            using (var db = new DBtestContext())
            {
                Employe employeVoulu = (from EmployeItem in db.Employes
                                       where EmployeItem.IDEmploye == idEmploye
                                       select EmployeItem).First();
               
                return employeVoulu;

            }
        }
        public static Employe RecupererEmployeUnique(string[] nomPrenomEmploye)
        {
            string nom = nomPrenomEmploye[0];
            string prenom = nomPrenomEmploye[1];
            using (var db = new DBtestContext())
            {
                Employe employeCherche = (from employeItem in db.Employes
                                       where employeItem.Nom == nom
                                       where employeItem.Prenom == prenom
                                       select employeItem).First();

                return employeCherche;

            }
        }
        public static List<Metier> RecupererMetier()
        {
            using (var db = new DBtestContext())
            {


                List<Metier> listMetier = (from Metier in db.Metier
                                         select Metier).ToList(); 
                return listMetier;

            }
        }
        public static Metier RecupererMetierEmploye(Employe employe)
        {
            using (var db = new DBtestContext())
            {


                Metier metierEmploye = (from metierItem in db.Metier
                                    join e in db.Employes
                                        on metierItem equals e.Metier
                                        where e.IDEmploye == employe.IDEmploye
                                    select metierItem).First();


                return metierEmploye;

            }
        }
    }
}
