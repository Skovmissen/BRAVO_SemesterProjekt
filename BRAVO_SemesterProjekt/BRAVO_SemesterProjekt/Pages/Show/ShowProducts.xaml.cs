using System;
using System.Collections.Generic;
using System.Data;
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
        
        //TempData temp = new TempData();
        Products product = new Products();
        public ShowProducts()
        {
            InitializeComponent();
            DataContext = product;
            DB.OpenDb();
            datagrid_ShowProducts.ItemsSource = DB.ShowProductsOverview().DefaultView;
            DB.CloseDb();
        }

        /// <summary>
        /// klik på knap søger produkt tabel for det indtastede
        /// </summary>
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            datagrid_ShowProducts.ItemsSource = DB.SearchProductOverview(product).DefaultView;
            DB.CloseDb();            
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu menu = new ShowMenu();
            NavigationService.Navigate(menu);
        }

        private void datagrid_ShowProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in datagrid_ShowProducts.SelectedItems)
            {
                product.ProductName = row.Row.ItemArray[1].ToString();

                product.Description = row.Row.ItemArray[9].ToString();
            }
        }

        private void datagrid_ShowProducts_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
          
        }
    }
}
