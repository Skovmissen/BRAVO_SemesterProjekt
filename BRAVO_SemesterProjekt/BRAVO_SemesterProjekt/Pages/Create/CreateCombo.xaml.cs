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
using System.Data;
using System.Data.SqlClient;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Lavet af Lasse og Nikolaj
    /// 
    /// Denne klasse bruges til at oprette komboprodukter og tilføje produkter til dem
    /// </summary>
    public partial class CreateCombo : Page
    {
       
        ComboProducts combo = new ComboProducts();
        Products product = new Products();
        Actors actor = new Actors();
        TempData temp = new TempData();
        
        public CreateCombo()
        {
            InitializeComponent();
            DataContext = combo;
            DB.OpenDb();
            FillcomboWithActors();
            FillcomboWithCombiProducts();
            DB.CloseDb();
        }
               
       

        
        private void ShowProductsInCombi()  //Denne metode finder alle de produktid'er der er tilhørende det valgte komboId, hvorefter den henter produktnavnene ud og læser dem ind i datagridet.
        {
            DB.OpenDb();
            DataTable comboProducts = DB.GetProductIdFromCombo(combo);            
            dg_showproduts.ItemsSource = DB.GetProductsInComboView(comboProducts).DefaultView;
            DB.CloseDb();            
        }
        private void FillcomboWithActorsProducts()   //Denne metoder fylder comboboxen med alle produkter i databasen
        {
            DataTable products = DB.ShowActorsProducts(actor);
            for (int i = 0; i < products.Rows.Count; i++)
            {
                cmb_products.Items.Add(products.Rows[i]["ProductName"]);
            }
        }
        private void FillcomboWithActors()   //Denne metoder fylder comboboxen med alle produkter i databasen
        {
            DataTable actor = DB.ShowActor();
            for (int i = 0; i < actor.Rows.Count; i++)
            {
                cmb_actor.Items.Add(actor.Rows[i]["ActorName"]);
            }
        }
        private void FillcomboWithCombiProducts()   //Denne metoder fylder comboboxen med alle Kombinationsprodukter i databasen
        {
            DataTable Combiproducts = DB.ShowCombo();
            for (int i = 0; i < Combiproducts.Rows.Count; i++)
            {
                cmb_combiproducts.Items.Add(Combiproducts.Rows[i]["CombiProductName"]);
            }
        }


        private void cmb_products_DropDownClosed(object sender, EventArgs e)    //Den metode finder produktetsId da det er det der skal sættes ind i databasen
        {
            temp.ChosenItem = cmb_products.Text;
            DB.OpenDb();
            product.Id = DB.SelectProductId(temp);
            DB.CloseDb();
        }

        private void btn_addproductInCombi(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                DB.InsertProductInCombi(combo, product);
                
                DB.CloseDb();
                ShowProductsInCombi();
                MessageBox.Show("Produktet er oprettet i den valgte Kombo");
            }
            catch (SqlException)
            {

                MessageBox.Show("Et felt er ikke blevet valgt");
            }
            catch (Exception)
            {

                throw;
            }
        }
      
        private void btn_CreateCombo(object sender, RoutedEventArgs e)
        {
            try
            {
                if (combo.Name != "")
                { 
                    DB.OpenDb();
                DB.InsertCombo(combo);
                cmb_combiproducts.Items.Clear();
                FillcomboWithCombiProducts();                
                DB.CloseDb();
                MessageBox.Show("Kombiprodukt er oprettet");
                }
                else
                {
                    MessageBox.Show("Det valgte Kombinations produktnavn er ikke gyldigt");
                }

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

        private void cmb_actor_DropDownClosed(object sender, EventArgs e)
        {
            actor.Name = cmb_actor.Text;
            cmb_products.Items.Clear();
            FillcomboWithActorsProducts();
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            CreateMenu menu = new CreateMenu();
            NavigationService.Navigate(menu);
        }

        private void comboBox_DropDownClosed(object sender, EventArgs e)
        {
            combo.NewComBoName = cmb_combiproducts.Text;
            lbl_comproductname.Content = cmb_combiproducts.Text;


            DB.OpenDb();
            combo.Id = DB.GetcomboId(combo);                        
            DB.CloseDb();
            ShowProductsInCombi();
        }

       
    }
}
