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

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Interaction logic for ShowClusters.xaml
    /// </summary>
    public partial class ShowClusters : Page
    {
        TempData temp = new TempData();
        public ShowClusters()
        {
            DataContext = temp;
            InitializeComponent();
            DB.OpenDb();
            dataGrid_cluster.ItemsSource = DB.ShowCluster().DefaultView;
            DB.CloseDb();
        }

        private void btn_search_cluster_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            dataGrid_cluster.ItemsSource = DB.SearchCluster(temp).DefaultView;
            DB.CloseDb();
        }
    }
}
