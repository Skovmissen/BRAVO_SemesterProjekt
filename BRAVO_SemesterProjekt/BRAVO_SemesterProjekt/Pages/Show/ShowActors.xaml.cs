using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Af Anders
    /// 
    /// Denne klasse styre vores oversigt af aktøre
    /// </summary>
    public partial class ShowActors : Page
    {
        Clusters cluster = new Clusters();
        Products product = new Products();
        TempData temp = new TempData();

        public ShowActors()
        {
            InitializeComponent();
            txt_search_actor.DataContext = temp;

            try
            {
                DB.OpenDb();
                GridShowActor.ItemsSource = DB.ShowActor().DefaultView;
                DB.CloseDb();
            }
            catch (SqlException)
            {

                MessageBox.Show("Ingen forbindelse til databasen");
            }
            catch (Exception)
            {

                MessageBox.Show("Ukendt fejl");
            }
        }

        private void Btn_Search_Actor_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DB.OpenDb();
                GridShowActor.ItemsSource = DB.SearchActor(temp).DefaultView;
                DB.CloseDb();
            }
            catch (SqlException)
            {

                MessageBox.Show("Ingen forbindelse til databasen");
            }
            catch (Exception)
            {

                MessageBox.Show("Ukendt fejl");
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            var menu = new ShowMenu();
            NavigationService.Navigate(menu);
        }

        private void GridShowActor_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in GridShowActor.SelectedItems)
            {
                cluster.Name = row.Row.ItemArray[0].ToString();
                product.ProductName = row.Row.ItemArray[0].ToString();
            }

            try
            {
                DB.OpenDb();
                ActorDataProducts.ItemsSource = DB.GetActorProducts(product).DefaultView;
                ActorDataCluster.ItemsSource = DB.GetActorCluster(cluster).DefaultView;
                DB.CloseDb();
            }
            catch (SqlException)
            {

                MessageBox.Show("Ingen forbindelse til databasen");
            }
            catch (Exception)
            {

                MessageBox.Show("Ukendt fejl");
            }
        }

        private void GridShowActor_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Activate")
                e.Column = null;
            if (e.PropertyName == "ActorName")
                e.Column.Header = "Aktør";
        }
    }
}