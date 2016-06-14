﻿using System;
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
    /// Logique d'interaction pour Parametre.xaml
    /// </summary>
    public partial class Parametre : Page
    {
        public Parametre()
        {
            InitializeComponent();
        }

        private void bMenu_Click(object sender, RoutedEventArgs e)
        {
            Switcher.mainWin.Content = Switcher.mainPage;
        }

        private void bAjouterMetier_Click(object sender, RoutedEventArgs e)
        {
            LiaisonBDD.AjouterMetier(tbAjouterMetier.Text);
            tbAjouterMetier.Text = "";
        }
    }
}
