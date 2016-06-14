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
            

        }

        private void bAddSession_Click(object sender, RoutedEventArgs e)
        {


            Switcher.mainWin.Content = Switcher.Session;
        }

        private void bEmployer_Click(object sender, RoutedEventArgs e)
        {
            
            Switcher.mainWin.Content = Switcher.Employer;
        }

        private void bAddFormation_Click(object sender, RoutedEventArgs e)
        {
            
            Switcher.mainWin.Content = Switcher.Formation;
        }

        private void bParametre_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.Parametre;
        }
    }
}
