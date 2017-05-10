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
    /// Lavet af Nikolaj
    /// </summary>
    public partial class EditCluster : Page
    {
        Clusters cluster = new Clusters();
        public EditCluster()
        {
            InitializeComponent();
            DataContext = cluster;
            DB.OpenDb();
            edit_Cluster.ItemsSource = DB.SearchCluster(cluster).DefaultView;
            DB.CloseDb();
        }

        private void edit_Cluster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in edit_Cluster.SelectedItems)
            {
                cluster.OldName = row.Row.ItemArray[0].ToString();
                cluster.Name = row.Row.ItemArray[0].ToString();
                cluster.Activate = Convert.ToBoolean(row.Row.ItemArray[1].ToString());
               
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            DB.UpdateCluster(cluster);
            edit_Cluster.ItemsSource = DB.SearchCluster(cluster).DefaultView;
            DB.CloseDb();
            MessageBox.Show("Redigering fuldført");
           
        }

        private void btn_Edit_Search_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            edit_Cluster.ItemsSource = DB.SearchCluster(cluster).DefaultView;
            DB.CloseDb();
        }
    }
}
