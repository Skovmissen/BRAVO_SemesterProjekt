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

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Interaction logic for ShowMenu.xaml
    /// </summary>
    public partial class ShowMenu : Page
    {
        public ShowMenu()
        {
            InitializeComponent();
        }

        private void btn_Actor_Click(object sender, RoutedEventArgs e)
        {
            btn_Actor.IsEnabled = false;
            btn_Actor.Visibility = Visibility.Hidden;
            btn_Cluster.IsEnabled = false;
            btn_Cluster.Visibility = Visibility.Hidden;
            btn_Combo.IsEnabled = false;
            btn_Combo.Visibility = Visibility.Hidden;
            btn_Product.IsEnabled = false;
            btn_Product.Visibility = Visibility.Hidden;
            ShowActors actor = new ShowActors();
            this.NavigationService.Navigate(actor);
        }

        private void btn_Cluster_Click(object sender, RoutedEventArgs e)
        {
            btn_Actor.IsEnabled = false;
            btn_Actor.Visibility = Visibility.Hidden;
            btn_Cluster.IsEnabled = false;
            btn_Cluster.Visibility = Visibility.Hidden;
            btn_Combo.IsEnabled = false;
            btn_Combo.Visibility = Visibility.Hidden;
            btn_Product.IsEnabled = false;
            btn_Product.Visibility = Visibility.Hidden;
            ShowClusters cluster = new ShowClusters();
            this.NavigationService.Navigate(cluster);
        }

        private void btn_Product_Click(object sender, RoutedEventArgs e)
        {
            btn_Actor.IsEnabled = false;
            btn_Actor.Visibility = Visibility.Hidden;
            btn_Cluster.IsEnabled = false;
            btn_Cluster.Visibility = Visibility.Hidden;
            btn_Combo.IsEnabled = false;
            btn_Combo.Visibility = Visibility.Hidden;
            btn_Product.IsEnabled = false;
            btn_Product.Visibility = Visibility.Hidden;
            ShowProducts products = new ShowProducts();
            this.NavigationService.Navigate(products);
        }

        private void btn_Combo_Click(object sender, RoutedEventArgs e)
        {
            btn_Actor.IsEnabled = false;
            btn_Actor.Visibility = Visibility.Hidden;
            btn_Cluster.IsEnabled = false;
            btn_Cluster.Visibility = Visibility.Hidden;
            btn_Combo.IsEnabled = false;
            btn_Combo.Visibility = Visibility.Hidden;
            btn_Product.IsEnabled = false;
            btn_Product.Visibility = Visibility.Hidden;
            ShowCombos combo = new ShowCombos();
            this.NavigationService.Navigate(combo);
        }
    }
}