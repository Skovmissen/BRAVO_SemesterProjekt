using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            datagrid_ShowProducts.ItemsSource = DB.ShowProductsOverview().DefaultView;//i konstruktøren kaldes i DB en produktoversigt, der sendes til datagrid
            DB.CloseDb();
            product.SearchCatname = "";
            product.SearchCity = "";
            product.SearchProduct = "";
            product.SearchZipcode = "";

           
        }

        /// <summary>
        /// klik på knap søger produkt tabel for det indtastede
        /// </summary>
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
      
            try
            {
                
                if (!(product.SearchCatname == null && product.SearchCity == null && product.SearchZipcode == null && product.SearchProduct == null))
                {
                    datagrid_ShowProducts.UnselectAllCells();
                    DB.OpenDb();
                    datagrid_ShowProducts.ItemsSource = DB.SearchProductOverview(product).DefaultView;//metoden kalder de søgte koonner i DB og sender dem til datagriddet
                    DB.CloseDb();
                }
                else
                {
                    MessageBox.Show("Udfyld venligst en af de 4 søgefelter");
                }
              
            }
            catch (SqlException ex)
            {

                throw ex;
                
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu menu = new ShowMenu();
            NavigationService.Navigate(menu);
        }

        private void datagrid_ShowProducts_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in datagrid_ShowProducts.SelectedItems) //for hvert række i datagriddet bliver indholdet af kolonner lagt i properties, som vi kan databinde til.
            {
                product.ProductName = row.Row.ItemArray[0].ToString();
                product.Category = row.Row.ItemArray[1].ToString();
                product.Description = row.Row.ItemArray[2].ToString();
                product.Price = Convert.ToDouble(row.Row.ItemArray[3].ToString());
                product.Street = row.Row.ItemArray[4].ToString();
                product.City = row.Row.ItemArray[5].ToString();
                product.Zipcode = row.Row.ItemArray[6].ToString();
                product.Url = row.Row.ItemArray[7].ToString();
                product.Latitude = Convert.ToDouble(row.Row.ItemArray[8].ToString());
                product.Longtitude = Convert.ToDouble(row.Row.ItemArray[9].ToString());
                product.Region = row.Row.ItemArray[10].ToString();

                product.OldName = "Kommune";

            }
        }       
        private void datagrid_ShowProducts_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {// i datagrid hvor oversigt vises frasorteres de kolonner der ikke er relevante for oversigten
            if (e.PropertyName == "Describtion" || e.PropertyName == "Region" || e.PropertyName == "URL" || e.PropertyName == "Street" || e.PropertyName == "Price" || e.PropertyName == "Latitude" || e.PropertyName == "Longtitude")
            {
                e.Column = null;
            }
            //kolonnenavne redigeres her så de giver mening for bruger - navnene fra tabellen udskiftes med en string værdi.
            if (e.PropertyName == "ProductName")
            {
                e.Column.Header = "Produkt";
            }
            if (e.PropertyName == "FK_CategoryName")
            {
                e.Column.Header = "Kategori";
            }
            if (e.PropertyName == "City")
            {
                e.Column.Header = "By";
            }
            if (e.PropertyName == "ZipCode")
            {
                e.Column.Header = "Post.Nr.";
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Print.WriteToFile(product);
        }

        
    }
}
