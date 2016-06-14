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
    /// Logique d'interaction pour AjouterFormation.xaml
    /// </summary>
    public partial class AjouterFormation : Page
    {
        public AjouterFormation()
        {
            InitializeComponent();
            for (int i = 1; i <= 20; i++)
            {
                cbValiditee.Items.Add(i);
            }
        }

        private void bHome_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.mainPage;
        }

        private void ajouterFormation(object sender, RoutedEventArgs e)
        {
            var listMetierSelectionne = lbMetiers.SelectedItems;
            List<Metier> metiersSelectonnes = new List<Metier>();
            foreach (Metier metier in lbMetiers.SelectedItems)
                metiersSelectonnes.Add(metier); 
            LiaisonBDD.AjouterFormation(tbNomFormation.Text, tbDescriptionFormation.Text, int.Parse(cbValiditee.Text),metiersSelectonnes);
        }


        private void actualiserMetier()
        {
            
            List<Metier> listMetier = LiaisonBDD.RecupererMetier();
            lbMetiers.ItemsSource = listMetier;
        }

        private void bActualiserMetier_Click(object sender, RoutedEventArgs e)
        {
            actualiserMetier();
        }
        private void bPrecedent_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.Formation;


        }


    }
}
