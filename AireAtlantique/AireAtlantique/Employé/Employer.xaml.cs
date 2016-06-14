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
    /// Logique d'interaction pour Employer.xaml
    /// </summary>
    public partial class Employer : Page
    {
        public Employer()
        {
            InitializeComponent();
            actualiserEmploye();
            List<Metier> listMetier = LiaisonBDD.RecupererMetier();
            cbListMetier.ItemsSource = listMetier;
            
        }
        private void bAddPersonne_Click(object sender, RoutedEventArgs e)
        {

            Switcher.mainWin.Content = Switcher.ajouterEmployer;
        }
        private void actualiserEmploye()
        {
            //lbEmploye.Items.Clear();
            List<Employe> listEmploye = LiaisonBDD.RecupererEmploye();
            lbEmploye.ItemsSource = listEmploye;
            //foreach(var employe in listEmploye)
            //{
            //    lbEmploye.Items.Add(employe.IDEmploye + " " + employe.Nom + " " + employe.Prenom);

            //}
        }

        private void clicEmploye(object sender, SelectionChangedEventArgs e)
        {
            //on récupère le nom et prénom de l'employé
            //int idEmployeClique = int.Parse(lbEmploye.SelectedItem.ToString().Split(' ').First());
            //List<Employe> listEmploye = LiaisonBDD.RecupererEmploye();
            if (lbEmploye.SelectedItem != null)
            {
                Employe employeClique = lbEmploye.SelectedItem as Employe;

                Metier metierEmploye = LiaisonBDD.RecupererMetierEmploye(employeClique);

                tbNom.Text = employeClique.Nom;
                tbPrenom.Text = employeClique.Prenom;
                tbNumTelphone.Text = employeClique.numeroTelephone.ToString();
                dpDateNaissance.SelectedDate = employeClique.dateNaissance;
                tbMetier.Text = metierEmploye.Nom;



                List<Session> listSession = LiaisonBDD.RecupererSessionEmploye(employeClique);
                lbSessionEmploye.ItemsSource = listSession;
            }


        }

        private void bActualiserListEmploye_Click(object sender, RoutedEventArgs e)
        {
            
            actualiserEmploye();

        }

        private void bSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Employe employeSupprimer = lbEmploye.SelectedItem as Employe;
            LiaisonBDD.SupprimerEmployer(employeSupprimer);
            actualiserEmploye();
        }

        private void bPrecedent_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.mainPage;
           

        }

        private void bModification_Click(object sender, RoutedEventArgs e)
        {
            if (lbEmploye.SelectedItem !=null)
            {
                gridEnable.IsEnabled = true;
                tbMetier.Visibility = Visibility.Hidden;
                bModification.IsEnabled = false;
                bValiderModification.Visibility = Visibility.Visible;
                cbListMetier.Visibility = Visibility.Visible;
            }
        }

        private void bValider_Click(object sender, RoutedEventArgs e)
        {
            try {
                List<Employe> listEmploye = LiaisonBDD.RecupererEmploye();

                Employe employeSelectionne = lbEmploye.SelectedItem as Employe;
                Metier metierSelectionne = cbListMetier.SelectedItem as Metier;
                LiaisonBDD.modifierEmployer(employeSelectionne.IDEmploye, tbNom.Text, tbPrenom.Text, int.Parse(tbNumTelphone.Text), dpDateNaissance.SelectedDate.Value, metierSelectionne);
                if (lbEmploye.SelectedItem != null)//on les remet en hidden
                {
                    gridEnable.IsEnabled = false;
                    tbMetier.Visibility = Visibility.Visible;
                    bModification.IsEnabled = true;
                    bValiderModification.Visibility = Visibility.Hidden;
                    cbListMetier.Visibility = Visibility.Hidden;
                }
                lErreur.Content = "";
            }
            catch
            {
                lErreur.Content = "Erreur dans la saisie";
            }
        }
    }
}
