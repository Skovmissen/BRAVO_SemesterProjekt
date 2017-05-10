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
    /// Interaction logic for CreateCombo.xaml
    /// </summary>
    public partial class CreateCombo : Page
    {
       
        ComboProducts combo = new ComboProducts();
        
        public CreateCombo()
        {
            InitializeComponent();
            DataContext = combo;
            ShowAllCombiproducts();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                DB.InsertCombo(combo);
                DB.CloseDb();
            }
            catch (SqlException)
            {

                MessageBox.Show("Et felt er ikke udfyldt korrekt");
            }
            catch (Exception)
            {

                throw;
            }
            MessageBox.Show("Kombiprodukt er oprettet");
            
        }
        private void ShowAllCombiproducts()
        {
            DB.OpenDb();
            DataTable allCombiProducts = DB.ShowComboDB();
            dg_showcombiproducts.ItemsSource = allCombiProducts.DefaultView;
            DB.CloseDb();
        }

        private void dg_showcombiproducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in dg_showcombiproducts.SelectedItems)
            {
                combo.Search = row.Row.ItemArray[0].ToString();
            }
            ProductsInCombi();
        }
        private void ProductsInCombi()
        {
            DB.OpenDb();
            DataTable allProductsInCombi = DB.SearchCombo(combo);
            dg_showproduts.ItemsSource = allProductsInCombi.DefaultView;
            DB.CloseDb();
            
        }
    }
}
