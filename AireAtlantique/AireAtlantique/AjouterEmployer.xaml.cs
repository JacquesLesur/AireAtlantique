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
        public AjouterEmployer()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.mainPage;
        }

        private void bAjouter_Click(object sender, RoutedEventArgs e)
        {
            LiaisonBDD.AjouterEmployer(tbNom.Text, tbPrenom.Text);
        }
    }
}
