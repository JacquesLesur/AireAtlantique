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
    /// Logique d'interaction pour AjouterSession2.xaml
    /// </summary>
    public partial class AjouterSession2 : Page
    {
        List<Formation> listFormation;
        public AjouterSession2()
        {
            
            InitializeComponent();
            AfficherFormation();
        }

        private void bHome_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.mainPage;
        }

        private void bNouvelleSession_Click(object sender, RoutedEventArgs e)
        {

            try {
                Formation formationSelectionne = cbFormation.SelectedItem as Formation;
                LiaisonBDD.AjouterSession(tbNomSession.Text,int.Parse(tbNombreMaxEmploye.Text), dateSession.SelectedDate.Value, formationSelectionne);
                lErreur.Content = "";
            }
            catch
            {
                lErreur.Content = "Veuiller renseigner correctement les champs";
            }
            
        }
        private void AfficherFormation()
        {
            listFormation = LiaisonBDD.RecupererFormations();
            cbFormation.ItemsSource = listFormation;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            AfficherFormation();
        }
        private void bPrecedent_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.Session;


        }
    }
}
