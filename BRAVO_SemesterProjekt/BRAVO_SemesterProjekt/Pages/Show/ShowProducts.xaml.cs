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
    /// Af Claus
    /// Interaction logic for ShowProducts.xaml
    /// </summary>
    public partial class ShowProducts : Page
    {
        Products product = new Products();
        public ShowProducts()
        {
            InitializeComponent();
            DataContext = product;

        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            datagrid_ShowProducts.ItemsSource = DB.SearchProduct(temp).DefaultView;
        }
    }
}
