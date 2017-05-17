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
    /// Af Claus
    /// Interaction logic for EditCombo.xaml
    /// </summary>
    public partial class EditCombo : Page
    {
        ComboProducts combo = new ComboProducts(); //objekt af typen comboproducts
        TempData temp = new TempData();
        public EditCombo() //kontruktør binder datacontext til object og indlæser combo tabel i gridview
        {
            InitializeComponent();
            DataContext = combo;
            DB.OpenDb();
            dataGrid_edit_Combo.ItemsSource = DB.ShowCombo().DefaultView;
            DB.CloseDb();
        }

        private void dataGrid_edit_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e) //kolonner i gridview bindes til obj properties, så de kan persisteres til db 
        {
            foreach (DataRowView row in dataGrid_edit_Combo.SelectedItems)
            {
                combo.Id = Convert.ToInt32(row.Row.ItemArray[0]);
                combo.Name = row.Row.ItemArray[1].ToString();
                combo.Description = row.Row.ItemArray[2].ToString();
                combo.StartTime = Convert.ToDateTime(row.Row.ItemArray[3]);
                combo.EndTime = Convert.ToDateTime(row.Row.ItemArray[4]);
                combo.Price = Convert.ToDouble(row.Row.ItemArray[5]);               
                combo.Activate = Convert.ToBoolean(row.Row.ItemArray[6]);

            }

        }

        private void button_search_Click(object sender, RoutedEventArgs e) // søg efter kombo produkt
        {
            DB.OpenDb();
            dataGrid_edit_Combo.ItemsSource = DB.SearchCombo(temp).DefaultView;
            DB.CloseDb();
        }

        private void button_update_Click(object sender, RoutedEventArgs e) // instansen combo sendes til updatecombo metden, der opdaterer tabbellen, viewet opdateres.
        {

            DB.OpenDb();
            DB.UpdateCombo(combo);
            dataGrid_edit_Combo.ItemsSource = DB.ShowCombo().DefaultView;
            DB.CloseDb();
            combo.Id = 0;
            combo.Name = null;
            combo.Description = null;
            combo.StartTime = null;
            combo.EndTime = null;
            combo.Price = 0;
            
            MessageBox.Show("Redigering fuldført");
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            EditMenu menu = new EditMenu();
            NavigationService.Navigate(menu);
        }
    }
}
