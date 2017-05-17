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
    /// Lavet af Anders
    /// </summary>
    public partial class EditProducts : Page
    {
        Products product = new Products();
        ComboProducts combo = new ComboProducts();
        TempData temp = new TempData();
        public EditProducts()
        {
            InitializeComponent();
            DataContext = product;
            DB.OpenDb();
            Fillcombo();
            dataGrid_Edit_Product.ItemsSource = DB.ShowProducts().DefaultView;
            DB.CloseDb();
        }

        private void button_Edit_Product_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            DB.UpdateProduct(product);
            dataGrid_Edit_Product.ItemsSource = DB.ShowProducts().DefaultView;            
            if (product.Activate == false)  //Lavet ad Lasse
            {
               DiableCluster();
            }
            DB.CloseDb();
            MessageBox.Show("Redigering fuldført");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            dataGrid_Edit_Product.ItemsSource = DB.SearchProduct(product).DefaultView;
            DB.CloseDb();
        }
        private void Fillcombo() //Denne metode finder produktnavne og fylder dem i comboboxe
        {
            DataTable category = DB.ShowCategory();
            for (int i = 0; i < category.Rows.Count; i++)
            {
                cmb_category.Items.Add(category.Rows[i]["CategoryName"]);
            }
        }
        private void cmb_category_DropDownClosed(object sender, EventArgs e)
        {
            product.Category = cmb_category.Text;
        }

        private void dataGrid_Edit_Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in dataGrid_Edit_Product.SelectedItems) //fylder datagrid med opdaterede datas
            {
                product.Id = Convert.ToInt32(row.Row.ItemArray[0].ToString());
                product.ProductName = row.Row.ItemArray[1].ToString();
                product.City = row.Row.ItemArray[2].ToString();
                product.Zipcode = row.Row.ItemArray[3].ToString();
                product.Region = row.Row.ItemArray[4].ToString();
                product.Street = row.Row.ItemArray[5].ToString();
                product.Latitude = Convert.ToDouble(row.Row.ItemArray[6].ToString());
                product.Longtitude = Convert.ToDouble(row.Row.ItemArray[7].ToString());
                product.Url = row.Row.ItemArray[8].ToString();
                product.Description = row.Row.ItemArray[9].ToString();
                product.Price = Convert.ToDouble(row.Row.ItemArray[10].ToString());
                product.Activate = Convert.ToBoolean(row.Row.ItemArray[11].ToString());
                
                product.Category = row.Row.ItemArray[13].ToString();
                product.ActorName = row.Row.ItemArray[14].ToString();
            }
        }
        private void DiableCluster()    //Lavet af Lasse
        {
            DataTable ComboIdTable = DB.GetComboViewId(product);

            foreach (DataRow row in ComboIdTable.Rows)
            {
                combo.Id = Convert.ToInt32(row.ItemArray[0]);
                DB.DeactiveCombos(combo);
            }
            int counter = ComboIdTable.Rows.Count;
            MessageBox.Show(counter + " Produkt kombinationer er blevet deaktiveret");
        }
        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            EditMenu menu = new EditMenu();
            NavigationService.Navigate(menu);
        }
    }
}
