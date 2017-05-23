using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Lavet af Lasse
    /// 
    /// Denne klasse kan oprette klynger og tilføje aktører til klyngerne
    /// </summary>
    public partial class CreateCluster : Page
    {
        Clusters cluster = new Clusters();

        public CreateCluster()
        {

            InitializeComponent();
            DataContext = cluster;

            try
            {
                DB.OpenDb();
                FillcomboActor();
                FillcomboCluster();
                DB.CloseDb();
            }
            catch (SqlException)
            {

                MessageBox.Show("Der er ingen forbindelse til databasen");
            }
            catch
            {
                MessageBox.Show("Ukendt fejl");
            }



        }
        private void FillcomboActor()   //Denne metoder fylder comboboxen med alle aktører i databasen
        {
            DataTable actor = DB.ShowActor();
            for (int i = 0; i < actor.Rows.Count; i++)
            {
                cmb_actor.Items.Add(actor.Rows[i]["ActorName"]);    //For hver række der er i datatablet actor, under kolonnen ActorName, smider den aktørnavnet i comboboxen
            }
        }
        private void FillcomboCluster()   //Denne metoder fylder comboboxen med alle aktører i databasen
        {
            DataTable cluster = DB.ShowCluster();
            for (int i = 0; i < cluster.Rows.Count; i++)
            {
                cmb_cluster.Items.Add(cluster.Rows[i]["ClusterName"]);    //For hver række der er i datatablet actor, under kolonnen ActorName, smider den aktørnavnet i comboboxen
            }
        }

        private void DataGridShowSpecificCluster()      //Fylder et datagrid med aktører under den valgte klynge
        {
            dg_ShowspecificCluster.ItemsSource = DB.GetClusterActors(cluster).DefaultView;
        }
        private void btn_saveClusterName(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            DataTable checkDoubleCluster = DB.CheckForDoubleCluster(cluster);
            DB.CloseDb();
            if (checkDoubleCluster.Rows.Count > 0)
            {
                MessageBox.Show("Klynge navnet er i forvejen oprettet");
            }
            else
            {


                try
                {

                    if (!(cluster.Name == null || cluster.Name == "" || cluster.Description == null || cluster.Description == ""))
                    {
                        DB.OpenDb();
                        DB.InsertCluster(cluster);
                        cmb_cluster.Items.Clear();
                        FillcomboCluster();
                        DB.CloseDb();
                        MessageBox.Show("Klynge er oprettet");
                        txt_description.Clear();
                        txt_navn.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Et felt er ikke udfyldt korrekt");
                    }

                }
                catch (SqlException)
                {

                    MessageBox.Show("Ingen forbindelse til Databasen");
                }
                catch (Exception)
                {

                    MessageBox.Show("Ukendt fejl");
                }
            }

        }
        private void btn_addActorToCluster(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(cluster.Name == null || cluster.ActorName == null))
                {
                    DB.OpenDb();
                    DB.InsertActorInCluster(cluster);
                    DataGridShowSpecificCluster();
                    DB.CloseDb();
                }
                else
                {
                    MessageBox.Show("Et felt er ikke udfyldt korrekt");
                }

            }
            catch (SqlException)
            {
                MessageBox.Show("Ingen forbindelse til Databasen");
            }
            catch (Exception)
            {

                MessageBox.Show("Ukendt fejl");
            }

        }
        private void cmb_actor_DropDownClosed(object sender, EventArgs e)
        {
            cluster.ActorName = cmb_actor.Text;
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            CreateMenu menu = new CreateMenu();
            NavigationService.Navigate(menu);
        }

        private void cmb_cluster_DropDownClosed(object sender, EventArgs e)
        {
            cluster.Name = cmb_cluster.Text;
            DB.OpenDb();
            DataGridShowSpecificCluster();
            DB.CloseDb();
            label1.Content = cmb_cluster.Text;
            txt_navn.Clear();
        }
    }
}
