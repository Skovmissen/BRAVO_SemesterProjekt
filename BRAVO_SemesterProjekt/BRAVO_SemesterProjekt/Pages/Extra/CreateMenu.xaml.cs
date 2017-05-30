using System.Windows;
using System.Windows.Controls;

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
            btn_Actor.IsEnabled = false; //Her deaktivere vi knappen så den ikke kan bruges
            btn_Actor.Visibility = Visibility.Hidden; //Her skjuler vi knappen
            btn_Cluster.IsEnabled = false;
            btn_Cluster.Visibility = Visibility.Hidden;
            btn_Combo.IsEnabled = false;
            btn_Combo.Visibility = Visibility.Hidden;
            btn_Product.IsEnabled = false;
            btn_Product.Visibility = Visibility.Hidden;
            CreateActors actor = new CreateActors();
            NavigationService.Navigate(actor);
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
            NavigationService.Navigate(cluster);
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
            NavigationService.Navigate(product);
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
            NavigationService.Navigate(combo);
        }
    }
}
