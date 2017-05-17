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
        
        public CreateCombo()
        {
            InitializeComponent();
            DataContext = combo;
            ShowAllCombies();
            FillcomboWithActors();
        }
               
        private void ShowAllCombies()
        {
            DB.OpenDb();             
            dg_showcombiproducts.ItemsSource = DB.ShowCombo().DefaultView;
            DB.CloseDb();
        }
        
        private void dg_showcombiproducts_SelectionChanged(object sender, SelectionChangedEventArgs e) // Her finder jeg det ID kombo'en har ved den række der er markeret + navnet på kombo'en.
        {                                                                                               
            foreach (DataRowView row in dg_showcombiproducts.SelectedItems) 
            {
                combo.Id = Convert.ToInt32(row.Row.ItemArray[0]);           //Finder objektet i kolonne 0 i datagridet og convertere det til en int
                combo.Name = row.Row.ItemArray[1].ToString();               //Finder objektet, i kollone 1 i datagridet og convertere det til en string
            }
            ShowProductsInCombi();
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

        private void cmb_products_DropDownClosed(object sender, EventArgs e)    //Den metode finder produktetsId da det er det der skal sættes ind i databasen
        {
            combo.ChosenItem = cmb_products.Text;
            DB.OpenDb();
            product.Id = DB.SelectProductId(combo);
            DB.CloseDb();
        }

        private void btn_addproductInCombi(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                DB.InsertProductInCombi(combo, product);
                ShowProductsInCombi();
                DB.CloseDb();
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
                DB.OpenDb();
                DB.InsertCombo(combo);
                DB.CloseDb();
                MessageBox.Show("Kombiprodukt er oprettet");
                ShowAllCombies();
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
    }
}
