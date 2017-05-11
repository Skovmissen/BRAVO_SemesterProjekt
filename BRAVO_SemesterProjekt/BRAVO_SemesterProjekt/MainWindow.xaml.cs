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
          
            frame.Content = new Upload();
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

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            btn_Create.IsEnabled = false;
            btn_Create.Visibility = Visibility.Hidden;
            btn_Edit.IsEnabled = false;
            btn_Edit.Visibility = Visibility.Hidden;
            btn_Show.IsEnabled = false;
            btn_Show.Visibility = Visibility.Hidden;
            btn_Upload.IsEnabled = false;
            btn_Upload.Visibility = Visibility.Hidden;

            frame.Content = new CreateMenu();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            btn_Create.IsEnabled = false;
            btn_Create.Visibility = Visibility.Hidden;
            btn_Edit.IsEnabled = false;
            btn_Edit.Visibility = Visibility.Hidden;
            btn_Show.IsEnabled = false;
            btn_Show.Visibility = Visibility.Hidden;
            btn_Upload.IsEnabled = false;
            btn_Upload.Visibility = Visibility.Hidden;

            frame.Content = new EditMenu();
        }

        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            btn_Create.IsEnabled = false;
            btn_Create.Visibility = Visibility.Hidden;
            btn_Edit.IsEnabled = false;
            btn_Edit.Visibility = Visibility.Hidden;
            btn_Show.IsEnabled = false;
            btn_Show.Visibility = Visibility.Hidden;
            btn_Upload.IsEnabled = false;
            btn_Upload.Visibility = Visibility.Hidden;

            frame.Content = new ShowMenu();
        }

        private void btn_Upload_Click(object sender, RoutedEventArgs e)
        {
            btn_Create.IsEnabled = false;
            btn_Create.Visibility = Visibility.Hidden;
            btn_Edit.IsEnabled = false;
            btn_Edit.Visibility = Visibility.Hidden;
            btn_Show.IsEnabled = false;
            btn_Show.Visibility = Visibility.Hidden;
            btn_Upload.IsEnabled = false;
            btn_Upload.Visibility = Visibility.Hidden;

            frame.Content = new Upload();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
