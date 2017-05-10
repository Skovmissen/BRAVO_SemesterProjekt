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
    /// </summary>
    public partial class CreateCombo : Page
    {
       
        ComboProducts combo = new ComboProducts();
        Products product = new Products();
        
        public CreateCombo()
        {
            InitializeComponent();
            DataContext = combo;
            ShowAllCombiproducts();
            Fillcombo();
        }

        private void btn_CreateCombo(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                DB.InsertCombo(combo);
                DB.CloseDb();
                MessageBox.Show("Kombiprodukt er oprettet");
                ShowAllCombiproducts();
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
        private void ShowAllCombiproducts()
        {
            DB.OpenDb();             
            dg_showcombiproducts.ItemsSource = DB.ShowComboDB().DefaultView;
            DB.CloseDb();
        }

        private void dg_showcombiproducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in dg_showcombiproducts.SelectedItems)
            {
                combo.Id = Convert.ToInt32(row.Row.ItemArray[0]);
            }
            ShowProductsInCombi();
        }
        private void ShowProductsInCombi()
        {
            DB.OpenDb();
            DataTable comboProducts = DB.GetComboProduts(combo);
            dg_showproduts.ItemsSource = DB.GetProductsInCombo(comboProducts).DefaultView;
            DB.CloseDb();            
        }
        private void Fillcombo()
        {
            DataTable products = DB.ShowProducts();
            for (int i = 0; i < products.Rows.Count; i++)
            {
                cmb_products.Items.Add(products.Rows[i]["ProductName"]);
            }
        }

        private void btn_addproductInCombi(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                DB.InsertProductInCombi(combo, product);
                ShowProductsInCombi();
                DB.CloseDb();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmb_products_DropDownClosed(object sender, EventArgs e)
        {            
            combo.ChosenItem = cmb_products.Text;
            DB.OpenDb();
            product.Id = Convert.ToInt32(DB.SelectProductId(combo));
            DB.CloseDb();
        }
        
    }
}
