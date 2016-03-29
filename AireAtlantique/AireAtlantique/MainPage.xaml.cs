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
    /// Logique d'interaction pour MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            bAddFormation.Click += new System.Windows.RoutedEventHandler(this.Formation);
        }
        public void Formation(object sender, RoutedEventArgs e)
        {
            // Switcher.home.Hide();
            // Switcher.ajouterFormation.Show();
            Switcher.mainWin.Content = Switcher.ajouterFormation;
        }
        private void bAddSession_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.home.Hide();

            Switcher.mainWin.Content = Switcher.ajouterSession;
        }

        private void bAddPersonne_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.ajouterEmployer;
        }
    }
}
