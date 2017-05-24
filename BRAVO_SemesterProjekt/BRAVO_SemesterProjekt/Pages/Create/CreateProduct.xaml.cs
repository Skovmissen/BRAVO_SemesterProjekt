using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Lavet af Lasse
    /// 
    /// Den klasse bruges til at oprette produkter
    /// </summary>
    public partial class CreateProduct : Page
    {
        Products product = new Products();
        public CreateProduct()
        {
            InitializeComponent();
            DataContext = product;
            DB.OpenDb();
            Fillcombos();
            DB.CloseDb();
        }     
        private void Fillcombos() //Denne metode finder aktør- og produktnavne og fylder dem i comboboxe
        {
            DataTable actor = DB.ShowActor();
            for (int i = 0; i < actor.Rows.Count; i++)
            {
                cmb_actor.Items.Add(actor.Rows[i]["ActorName"]);
            }
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
        private void cmb_actor_DropDownClosed(object sender, EventArgs e)
        {
            product.ActorName = cmb_actor.Text;
        }      

        private void btn_opretprodukt(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(product.ProductName == null || product.ProductName == "" || product.Street == null || product.Street == "" || product.City == null || product.City == "" || product.Zipcode == null || product.Zipcode == "" || product.Region == null || product.Region == "" || product.Longtitude == 0 || product.Latitude == 0 || product.Url == null || product.Url == "" || product.Price == 0 || product.Description == null || product.Description == "" || product.ActorName == null || product.Category == null))
                {
                DB.OpenDb();
                DB.InsertProduct(product);
                DB.CloseDb();
                MessageBox.Show("Produktet er oprettet");
                ClearBoxes();
                }
                else
                {
                    MessageBox.Show("Et felt er ikke udfyldt korrekt");

                }               
            }
            catch (SqlException)
            {
                
                MessageBox.Show("Der er ingen forbindelse til databasen");
            }
            catch (Exception)
            {

                MessageBox.Show("Ukendt fejl");
            }
            
        }
        private void ClearBoxes()
        {
            product.City = null;
            product.Description = null;
            product.Latitude = 0;
            product.Longtitude = 0;
            product.Region = null;
            product.Street = null;
            product.Url = null;
            product.Zipcode = null;
            cmb_category.SelectedItem = null;
            cmb_actor.SelectedItem = null;
            product.Price = 0;
            product.ProductName = null;
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            CreateMenu menu = new CreateMenu();
            NavigationService.Navigate(menu);
        }
    }
}
