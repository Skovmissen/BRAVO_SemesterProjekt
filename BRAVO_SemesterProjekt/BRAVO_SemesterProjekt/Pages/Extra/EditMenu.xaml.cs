using System.Windows;
using System.Windows.Controls;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Interaction logic for EditMenu.xaml
    /// </summary>
    public partial class EditMenu : Page
    {
        public EditMenu()
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
            EditActors actor = new EditActors();
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
            EditCluster cluster = new EditCluster();
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
            EditProducts product = new EditProducts();
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
            EditCombo combo = new EditCombo();
            this.NavigationService.Navigate(combo);
        }
    }
}
