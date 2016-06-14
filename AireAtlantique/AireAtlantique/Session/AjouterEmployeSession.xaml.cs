using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AireAtlantique
{
    /// <summary>
    /// Logique d'interaction pour AjouterEmployeSession.xaml
    /// </summary>
    public partial class AjouterEmployeSession : Page
    {
        List<Session> listSession;
        public AjouterEmployeSession()
        {
            InitializeComponent();
            afficherSessionCb();
            actualiserEmploye();
        }
        private void afficherSessionCb()
        {
            listSession = LiaisonBDD.RecupererSession();
            cbSession.ItemsSource = listSession;
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.mainPage;
        }
        private void actualiserEmploye()
        {
            List<Employe> listEmploye = LiaisonBDD.RecupererEmploye();
            lbEmploye.ItemsSource = listEmploye;
        }

        private void bAjouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //on récupère les itemps sélectionnés dans un liste
                
                List<Employe> listemploye = new List<Employe>();
                //on en récupère la chaine de caractère
                foreach (Employe employe in lbEmploye.SelectedItems)
                {
                    listemploye.Add(employe);
                }



                Session sessionSelectionnne = cbSession.SelectedItem as Session;
                LiaisonBDD.AjouterEmployeSession(sessionSelectionnne, listemploye);
                lAttention.Content = "";
            }
            catch
            {
                lAttention.Content = "Action Impossible !";
            }
        }

        private void SelectionNewSession(object sender, SelectionChangedEventArgs e)
        {
            if (cbSession.SelectedItem != null)
            {
                //lbEmployeSession.Items.Clear();
                //lbEmploye.Items.Clear();
                Session sessionSelectionne = cbSession.SelectedItem as Session;
                List<Employe> listEmploye = LiaisonBDD.RecupererEmployeSession(sessionSelectionne.Nom);
                lbEmployeSession.ItemsSource = listEmploye;
                List<Employe> listEmployeCorespondantSession = LiaisonBDD.RecupererEmployeCorespondantSession(sessionSelectionne.Nom);
                lbEmploye.ItemsSource = listEmployeCorespondantSession;
            }
        }

        private void bActualiserSessionClick(object sender, RoutedEventArgs e)
        {
            
            afficherSessionCb();
        }
        private void bPrecedent_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.Session;


        }

        private void clicEmployeSession(object sender, SelectionChangedEventArgs e)
        {
            Employe employeSelectionne = lbEmployeSession.SelectedItem as Employe;
            lNom.Content = employeSelectionne.Nom;
            lPrenom.Content = employeSelectionne.Prenom;
            lNumTelephone.Content = employeSelectionne.numeroTelephone;
            lMetier.Content = LiaisonBDD.RecupererMetierEmploye(employeSelectionne).Nom;
            dpDateNaissance.SelectedDate = employeSelectionne.dateNaissance;
        }
    }
}
