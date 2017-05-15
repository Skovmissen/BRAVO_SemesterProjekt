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
    /// Lavet af Lasse
    /// 
    /// Den klasse bruges til at oprette produkter
    /// </summary>
    public partial class CreateProduct : Page
    {
        Actors actor = new Actors();
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
            actor.Name = cmb_actor.Text;
        }      

        private void btn_opretprodukt(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                DB.InsertProduct(product, actor);
                DB.CloseDb();
                MessageBox.Show("Produktet er oprettet");
                ClearBoxes();

            }
            catch (SqlException)
            {

                MessageBox.Show("Et felt er ikke udfyldt korrekt");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private void ClearBoxes()
        {
            product.City = null;
            product.Description = null;
            product.Email = null;
            product.Latitude = 0;
            product.Longtitude = 0;
            product.Name = null;
            product.Region = null;
            product.Street = null;
            product.Tlf = null;
            product.Url = null;
            product.Zipcode = null;
            cmb_category.SelectedItem = null;
        }
    }
}
