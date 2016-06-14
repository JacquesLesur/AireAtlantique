using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AireAtlantique
{
    /// <summary>
    /// Logique d'interaction pour SessionPage.xaml
    /// </summary>
    public partial class SessionPage : Page
    {
        public SessionPage()
        {
            InitializeComponent();
            afficherSession();
        }
        private void bAddSession_Click(object sender, RoutedEventArgs e)
        {


            Switcher.mainWin.Content = Switcher.ajouterSession;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.ajouterEmployeSession;
        }
        private void afficherSession()
        {
            List<Session> listSession = LiaisonBDD.RecupererSession();
            lbSession.ItemsSource = listSession;
        }
        private void afficherEmploye(Session sessionSelectionne)
        {
            List<Employe> listEmployeSession = LiaisonBDD.RecupererEmployeSession(sessionSelectionne.Nom);
            lbEmploye.ItemsSource = listEmployeSession;
        }
        private void SelectionItem(object sender, SelectionChangedEventArgs e)
        {

                if (lbSession.SelectedItem != null)
                {
                Session sessionSelectionne = lbSession.SelectedItem as Session;
                            tbNom.Text = sessionSelectionne.Nom;
                tbParticipantMax.Text = sessionSelectionne.NombreMaxEmploye.ToString();
                            tbFormation.Text = LiaisonBDD.RecupererFormationSession(sessionSelectionne).Nom;
                            afficherEmploye(sessionSelectionne);
                       
                }
            
        }

        private void bActualiserSessions_Click(object sender, RoutedEventArgs e)
        {
            afficherSession();
        }

        private void bSupprimerSession_Click(object sender, RoutedEventArgs e)
        {
            LiaisonBDD.SupprimerSession(lbSession.SelectedItem.ToString());
            afficherSession();
        }

        private void bSupprimmerParticipantSession_Click(object sender, RoutedEventArgs e)
        {

            Employe employeSelectionne = lbEmploye.SelectedItem as Employe;
            Session sessionSelectionne = lbSession.SelectedItem as Session;
                LiaisonBDD.SupprimerEmployerSession(employeSelectionne,sessionSelectionne);
            
                afficherEmploye(sessionSelectionne);
            
        }
        private void bPrecedent_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.mainPage;


        }

        private void clicSurEmploye(object sender, SelectionChangedEventArgs e)
        {
            if (lbEmploye.SelectedItem != null)
            {
                Employe employeSelectionne = lbEmploye.SelectedItem as Employe;
                lNom.Content = employeSelectionne.Nom;
                lPrenom.Content = employeSelectionne.Prenom;
                lNumTelephone.Content = employeSelectionne.numeroTelephone;
                dpDateNaissance.SelectedDate = employeSelectionne.dateNaissance;
                lMetier.Content = LiaisonBDD.RecupererMetierEmploye(employeSelectionne).Nom;
            }
        }
    }
}
