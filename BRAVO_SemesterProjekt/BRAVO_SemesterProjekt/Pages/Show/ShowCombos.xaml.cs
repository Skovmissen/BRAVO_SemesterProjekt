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

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Interaction logic for ShowCombos.xaml
    /// </summary>
    public partial class ShowCombos : Page
    {
       
        Products product = new Products();
        ComboProducts Combo = new ComboProducts();
        public ShowCombos()
        {
            DataContext = Combo;
            InitializeComponent();
            DB.OpenDb();
            GridShowCombo.ItemsSource = DB.ShowComboDB().DefaultView;
            DB.CloseDb();
        }

        private void btn_Search_Combo_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            GridShowCombo.ItemsSource = DB.SearchCombo(Combo).DefaultView;
            DB.CloseDb();
        }

        private void GridShowCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in GridShowCombo.SelectedItems)
            {
                Combo.Name = row.Row.ItemArray[0].ToString();
            }
            DB.OpenDb();
            dataGridCombo.ItemsSource = DB.GetComboProduts(Combo).DefaultView;
            DB.CloseDb();
        }
    }
}
