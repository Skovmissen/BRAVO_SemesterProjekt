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

        private void dataGrid_Edit_Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in dataGrid_Edit_Product.SelectedItems)
            {
                product.Name = row.Row.ItemArray[1].ToString();
                product.City = row.Row.ItemArray[2].ToString();
                product.Zipcode = row.Row.ItemArray[3].ToString();
                product.Region = row.Row.ItemArray[4].ToString();
                product.Street = row.Row.ItemArray[5].ToString();
                product.Latitude = Convert.ToDouble(row.Row.ItemArray[6].ToString());
                product.Longtitude = Convert.ToDouble(row.Row.ItemArray[7].ToString());
                product.Url = row.Row.ItemArray[8].ToString();
                product.Description = row.Row.ItemArray[9].ToString();

                product.Activate = Convert.ToBoolean(row.Row.ItemArray[10].ToString());
            }
        }
    }
}
