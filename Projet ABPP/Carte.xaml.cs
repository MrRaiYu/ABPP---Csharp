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
using System.Windows.Shapes;

namespace Projet_ABPP
{
    /// <summary>
    /// Logique d'interaction pour Carte.xaml
    /// </summary>
    public partial class Carte : Window
    {
        public Carte()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Bat1(object sender, MouseButtonEventArgs e)
        {
            BatPrincipale map = new BatPrincipale();
            map.Show();
        }

        /*private void Bat2(object sender, MouseButtonEventArgs e)
        {
            Laboratoire map = new Laboratoire();
            map.Show();
        }

        private void Bat3(object sender, MouseButtonEventArgs e)
        {
            Parking map = new Parking();
            map.Show();
        }

        private void Bat4(object sender, MouseButtonEventArgs e)
        {
            Archives map = new Archives();
            map.Show();
        }*/


    }
}