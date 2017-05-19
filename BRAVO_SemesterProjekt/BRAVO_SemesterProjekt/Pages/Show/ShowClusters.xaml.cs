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
    /// Af Claus
    /// Interaction logic for ShowClusters.xaml
    /// 
    /// Vi laver 3 DB kald her. Showcluster viser alle klynger. SearchCluster søger klynge tabellen. GetClusterActor viser aktører der er medlem af den valgte klynge
    /// </summary>
    public partial class ShowClusters : Page
    {

        Clusters cluster = new Clusters();
        //Actors actor = new Actors();
        TempData temp = new TempData();

        public ShowClusters() //vis klynge metoden køres og sendes til datagriddet
        {

            InitializeComponent();
            DataContext = temp;
            txt_description.DataContext = cluster;
            DB.OpenDb();
            dataGrid_cluster.ItemsSource = DB.ShowCluster().DefaultView;
            DB.CloseDb();
        }

        private void btn_search_cluster_Click(object sender, RoutedEventArgs e)//søge metoden køres og og sendes til datagriddet
        {
            try
            {
                DB.OpenDb();
                dataGrid_cluster.ItemsSource = DB.SearchCluster(temp).DefaultView;
                DB.CloseDb();
            }
            catch (SqlException)
            {
                MessageBox.Show("Ingen forbindelse til databasen");
            }
            catch (Exception)
            {

                MessageBox.Show("Ukendt Fejl");
            }


        }

        private void dataGrid_cluster_SelectionChanged(object sender, SelectionChangedEventArgs e)//ved valg af række i datagrid vises resultat i clusterdata griddet.
        {

            foreach (DataRowView row in dataGrid_cluster.SelectedItems)
            {
                cluster.Name = row.Row.ItemArray[0].ToString();
                cluster.Description = row.Row.ItemArray[1].ToString();
            }
            DB.OpenDb();
            ClusterData.ItemsSource = DB.GetClusterActors(cluster).DefaultView;
            DB.CloseDb();


        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu menu = new ShowMenu();
            NavigationService.Navigate(menu);
        }

        private void dataGrid_cluster_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Description" || e.PropertyName == "Activate")
            {
                e.Column = null;
            }
            if (e.PropertyName == "ClusterName")
            {
                e.Column.Header = "Klynge";
            }
        }
    }
}
