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
    }
}
