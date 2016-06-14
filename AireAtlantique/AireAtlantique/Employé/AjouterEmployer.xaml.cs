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
    /// Logique d'interaction pour AjouterEmployer.xaml
    /// </summary>
    public partial class AjouterEmployer : Page
    {
        List<Metier> listMetier;
        public AjouterEmployer()
        {
            InitializeComponent();
            actualiserMetier();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            Switcher.mainWin.Content = Switcher.mainPage;
        }
        private void bPrecedent_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.Employer;
            

        }
        private void bAjouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Metier metierEmploye = cbMetier.SelectedItem as Metier;
                
                LiaisonBDD.AjouterEmployer(tbNom.Text, tbPrenom.Text, int.Parse(tbNumTelephone.Text), dateNaissance.SelectedDate.Value, metierEmploye);
                tbNom.Text = "";
                tbPrenom.Text = "";
                tbNumTelephone.Text = "";
                
            }
            catch
            {
                lErreure.Content = "Informations non valides";
            }
        }
        private void actualiserMetier()
        {
            listMetier = LiaisonBDD.RecupererMetier();
            cbMetier.ItemsSource = listMetier;
           
        }

        private void bActualiser_Click(object sender, RoutedEventArgs e)
        {
            
            actualiserMetier();
        }
    }
}
