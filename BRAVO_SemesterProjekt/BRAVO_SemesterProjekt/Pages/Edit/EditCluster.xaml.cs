using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Lavet af Nikolaj
    /// </summary>
    public partial class EditCluster : Page
    {
        Clusters cluster = new Clusters();
        TempData temp = new TempData();
        public EditCluster()
        {
            InitializeComponent();
            txt_Edit_Search.DataContext = temp;
            DataContext = cluster;
            try
            {
                DB.OpenDb();
                edit_Cluster.ItemsSource = DB.SearchCluster(temp).DefaultView;
                DB.CloseDb();
            }
            catch (SqlException)
            {

                MessageBox.Show("Ingen forbindelse til databsen");
            }
            catch(Exception)
            {
                MessageBox.Show("Ukendt fejl");
            }
        }

        private void edit_Cluster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in edit_Cluster.SelectedItems)
            {
                cluster.OldName = row.Row.ItemArray[0].ToString();
                cluster.Name = row.Row.ItemArray[0].ToString();
                cluster.Description = row.Row.ItemArray[1].ToString();
                cluster.Activate = Convert.ToBoolean(row.Row.ItemArray[2].ToString());
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(cluster.OldName == null || cluster.OldName == "" || cluster.Name == null || cluster.Name == "" || cluster.Description == null | cluster.Description == ""))
                {
                    DB.OpenDb();
                    DB.UpdateCluster(cluster);
                    edit_Cluster.ItemsSource = DB.SearchCluster(temp).DefaultView;
                    DB.CloseDb();
                    cluster.OldName = null;
                    cluster.Name = null;
                    cluster.Description = null;
                    cluster.Activate = false;
                    MessageBox.Show("Redigering fuldført");
                }
                else
                {
                    MessageBox.Show("Et felt er ikke udfyldt korrekt");
                }
                
            }
            catch (SqlException)
            {

                MessageBox.Show("ingen forbindelse til databasen");
            }
            catch (Exception)
            {
                MessageBox.Show("Ukendt fejl");
            }
        }

        private void btn_Edit_Search_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            edit_Cluster.ItemsSource = DB.SearchCluster(temp).DefaultView;
            DB.CloseDb();
        }

        private void edit_Cluster_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ClusterName")
            {
                e.Column.Header = "Klyngenavn";
            }
            if (e.PropertyName == "Description")
            {
                e.Column.Header = "Beskrivelse";
            }
            if (e.PropertyName == "Activate")
            {
                e.Column.Header = "Aktiv";
            }
        }
        private void btn_back_click(object sender, RoutedEventArgs e)
        {
            EditMenu menu = new EditMenu();
            NavigationService.Navigate(menu);
        }
    }
}
