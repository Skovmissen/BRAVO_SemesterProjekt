using System;
using System.Windows;
using System.Windows.Controls;
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

            try
            {
                DB.OpenDb();
                FillcomboWithActors();
                FillcomboWithCombiProducts();
                DB.CloseDb();
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


        private void ShowProductsInCombi()  //Denne metode finder alle de produktid'er der er tilhørende det valgte komboId, hvorefter den henter produktnavnene ud og læser dem ind i datagridet.
        {
            DataTable comboProducts = DB.GetProductIdFromCombo(combo);
            dg_showproduts.ItemsSource = DB.GetProductsInComboView(comboProducts).DefaultView;
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
                if (!(combo.NewComBoName == null || actor.Name == null || temp.ChosenItem == null))
                {
                    DB.OpenDb();
                    DB.InsertProductInCombi(combo, product);
                    ShowProductsInCombi();
                    DB.CloseDb();
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

                throw;
            }
        }

        private void btn_CreateCombo(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            DataTable CheckDouble = DB.CheckForDoubleCombo(combo);
            DB.CloseDb();
            if (CheckDouble.Rows.Count > 0)
            {
                MessageBox.Show("Kombinations produktet eksistere allerede i databasen");
            }
            else
            {
                try
                {

                    if (!(combo.Name == null || combo.Name == "" || combo.Price == 0 || combo.Description == null || combo.Description == "" || combo.StartTime == null || combo.EndTime == null || combo.EndTime < combo.StartTime || combo.StartTime < DateTime.Now.Date))
                    {
                    DB.OpenDb();
                    DB.InsertCombo(combo);
                    cmb_combiproducts.Items.Clear();
                    FillcomboWithCombiProducts();
                    Clearboxes();
                    DB.CloseDb();
                    MessageBox.Show("Kombiprodukt er oprettet");
                }
                else
                {
                    MessageBox.Show("Et felt er ikke udfyldt korrekt");
                }
             

                }
                catch (SqlException)
                {

                    MessageBox.Show("Ingen forbindelses til DB");
                }
                catch (Exception)
                {

                    throw;
                }
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
            ShowProductsInCombi();
            DB.CloseDb();

        }
        private void Clearboxes()
        {
            combo.Name = null;
            combo.Description = null;
            combo.Price = 0;
            combo.StartTime = null;
            combo.EndTime = null;
        }


    }
}
