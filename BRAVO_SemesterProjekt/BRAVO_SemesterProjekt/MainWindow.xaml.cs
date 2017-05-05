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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        

        private void NewActor_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new CreateActors();
        }

        private void ShowActors_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ShowActors();
        }

        private void NewProduct_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new CreateProduct();
        }

        private void ShowProduct_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ShowProducts();
        }

        private void NewCluster_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new CreateCluster();
        }

        private void NewKombi_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new CreateCombo();
        }

        private void ShowCombos_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ShowCombos();
        }

        private void ShowClusters_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ShowClusters();
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            
            dummy4.Reader();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            frame.Content = new DeactivateActivate();
        }

        private void EditActor_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new EditActors();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new EditProducts();
        }

        private void EditCombo_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new EditCombo();
        }

        private void EditCluster_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new EditCluster();
        }
    }
}
