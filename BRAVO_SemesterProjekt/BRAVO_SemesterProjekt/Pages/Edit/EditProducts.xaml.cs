using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            try
            {
                if (!(product.ProductName == null || product.ProductName == "" || product.City == null || product.City == "" || product.Zipcode == null || product.Zipcode == "" || product.Street == null || product.Street == "" || product.Latitude == 0  || product.Longtitude == 0 || product.Url == null || product.Url == "" || product.Description == null || product.Description == "" || product.Price == 0 || product.Category == null || product.Category == "" || product.ActorName == null || product.ActorName == "" ))
                {
                    DB.OpenDb();
                    DB.UpdateProduct(product);
                    dataGrid_Edit_Product.ItemsSource = DB.ShowProducts().DefaultView;
                    if (product.Activate == false)  //Lavet ad Lasse
                    {
                        DiableCluster();
                    }
                    DB.CloseDb();
                    product.Id = 0;
                    product.ProductName = null;
                    product.City = null;
                    product.Zipcode = null;
                    product.Region = null;
                    product.Street = null;
                    product.Latitude = 0;
                    product.Longtitude = 0;
                    product.Url = null;
                    product.Description = null;
                    product.Price = 0;
                    product.Category = null;
                    product.ActorName = null;
                    MessageBox.Show("Redigering fuldført");
                }
                else
                {
                    MessageBox.Show("Et felt er ikke udfyldt korrekt");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Ingen forbindelse til Databasen");
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            dataGrid_Edit_Product.ItemsSource = DB.SearchProduct(temp).DefaultView;
            DB.CloseDb();
        }
        private void Fillcombo() //Denne metode finder produktnavne og fylder dem i comboboxe
        {
            DataTable category = DB.ShowCategory();
            for (int i = 0; i < category.Rows.Count; i++)
            {
                cmb_category.Items.Add(category.Rows[i]["CategoryName"]);
            }
            DataTable actorname = DB.ShowActor();
            for (int i = 0; i < actorname.Rows.Count; i++)
            {
                cmb_Actorname.Items.Add(actorname.Rows[i]["ActorName"]);
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
                product.OldName = product.ProductName;
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
        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Describtion")
            {
                e.Column = null;
            }
        }
    }
}
