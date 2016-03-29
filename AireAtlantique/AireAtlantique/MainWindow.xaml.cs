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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Switcher.ajouterFormation = new AjouterFormation();
            Switcher.mainPage = new MainPage();
            Switcher.ajouterSession = new AjouterSession2();
            Switcher.ajouterEmployer = new AjouterEmployer();
            Switcher.mainWin = this;
            this.Content = Switcher.mainPage;
        }



        

        
    }
}
