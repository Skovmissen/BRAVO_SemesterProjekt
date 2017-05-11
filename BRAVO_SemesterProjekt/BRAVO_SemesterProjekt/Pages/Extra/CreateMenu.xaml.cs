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

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Interaction logic for CreateMenu.xaml
    /// </summary>
    public partial class CreateMenu : Page
    {
        public CreateMenu()
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
            CreateActors actor = new CreateActors();
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
            CreateCluster cluster = new CreateCluster();
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
            CreateProduct product = new CreateProduct();
            this.NavigationService.Navigate(product);
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
            CreateCombo combo = new CreateCombo();
            this.NavigationService.Navigate(combo);
        }
    }
}
