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
    /// Interaction logic for EditProducts.xaml
    /// </summary>
    public partial class EditProducts : Page
    {
        Actors actor = new Actors();
        Products product = new Products();
        public EditProducts()
        {
            InitializeComponent();
            DataContext = product;
            DB.OpenDb();
            dataGrid_Edit_Product.ItemsSource = DB.ShowProducts().DefaultView;
            DB.CloseDb();
        }

        private void button_Edit_Product_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            DB.UpdateProduct(product, actor);
            dataGrid_Edit_Product.ItemsSource = DB.ShowProducts().DefaultView;
            DB.CloseDb();
            MessageBox.Show("Redigering fuldført");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            dataGrid_Edit_Product.ItemsSource = DB.SearchProduct(product).DefaultView;
            DB.CloseDb();
        }
    }
}
