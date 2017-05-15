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
    /// 
    /// deaktivering produkt??
    /// start,slu,aktiver
    /// 
    /// </summary>
    public partial class EditCombo : Page
    {
        ComboProducts comboProduct = new ComboProducts();
        public EditCombo()
        {
            InitializeComponent();
            DataContext = comboProduct;
            DB.OpenDb();
            dataGrid_edit_Combo.ItemsSource = DB.ShowCombo().DefaultView;
            DB.CloseDb();
        }

        private void dataGrid_edit_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in dataGrid_edit_Combo.SelectedItems)
            {
                comboProduct.Name = row.Row.ItemArray[1].ToString();
                comboProduct.StartTime = Convert.ToDateTime(row.Row.ItemArray[2]);
                comboProduct.EndTime = Convert.ToDateTime(row.Row.ItemArray[3]);
                comboProduct.Activate = Convert.ToBoolean(row.Row.ItemArray[4]);
              //  comboProduct.Description = row.Row.ItemArray[5].ToString();

            }

        }

        private void button_search_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            dataGrid_edit_Combo.ItemsSource = DB.SearchCombo(comboProduct).DefaultView;
            DB.CloseDb();
        }
    }
}
