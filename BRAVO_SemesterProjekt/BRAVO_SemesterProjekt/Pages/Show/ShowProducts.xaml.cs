using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

        private void datagrid_ShowProducts_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in datagrid_ShowProducts.SelectedItems)
            {
                product.ProductName = row.Row.ItemArray[0].ToString();
                product.Description = row.Row.ItemArray[4].ToString();
                product.Latitude = Convert.ToDouble(row.Row.ItemArray[5].ToString());
                product.Longtitude = Convert.ToDouble(row.Row.ItemArray[6].ToString());

            }
            string temp = product.Latitude.ToString();
            temp = temp.Insert(2, ".");
            product.Latitude =  double.Parse(temp, CultureInfo.InvariantCulture);

            temp = product.Longtitude.ToString();
            temp = temp.Insert(2, ".");
            product.Longtitude = double.Parse(temp, CultureInfo.InvariantCulture);



        }

        private void datagrid_ShowProducts_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Describtion" || e.PropertyName == "Latitude" || e.PropertyName == "Longitude")
            {
                e.Column = null;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Print.WriteToFile(product);
        }

       
    }
}
