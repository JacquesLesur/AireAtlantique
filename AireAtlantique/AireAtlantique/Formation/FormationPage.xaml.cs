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
    /// Logique d'interaction pour Formation.xaml
    /// </summary>
    public partial class FormationPage : Page
    {
        public FormationPage()
        {
            InitializeComponent();
            actualiserFormation();
        }
        private void bAddFormation_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.ajouterFormation;
        }

        private void bActualiser_Click(object sender, RoutedEventArgs e)
        {
            actualiserFormation();
        }
        private void actualiserFormation()
        {
           
            List<Formation> listFormation = LiaisonBDD.RecupererFormations();
            lbFormation.ItemsSource = listFormation;
        }

        private void selectionFormation(object sender, SelectionChangedEventArgs e)
        {
            Formation formationSelectionne = lbFormation.SelectedItem as Formation;
            List<Formation> listFormation = LiaisonBDD.RecupererFormations();
            //on récupère la list de session associé à la formation
            List<Session> listSessionFormation = LiaisonBDD.RecupererSessionFormation(formationSelectionne);
            lbSessionFormation.ItemsSource = listSessionFormation;
            tbNom.Text = formationSelectionne.Nom;
            tbDescription.Text = formationSelectionne.Description;
                    

            //on récupère la list de metier de la formation
            List<Metier> listMetierFormation = LiaisonBDD.RecupererMetierFormation(formationSelectionne);
            lbMetier.ItemsSource = listMetierFormation;

        }

        private void bSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Formation formationSelectionne = lbFormation.SelectedItem as Formation;
            LiaisonBDD.SupprimerFormation(formationSelectionne);

        }

        private void bPrecedent_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.mainPage;


        }


    }
}
