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
                DB.OpenDb();                    //Denne indeholder en catch med messagebox, det skal den ikke gøre, der skal try catch om alle db.open i stedet for. ellers kommer der dobbelt messageboxe
                FillcomboActor();
                FillcomboCluster();
                //DataGridShowAllCluster();
                DB.CloseDb(); 
            }
            catch (Exception)
            {
               
                
                //MessageBox.Show("Der er ingen forbindelse til databasen");
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
            DataTable ShowSpecificClusterTable = DB.GetClusterActors(cluster);
            dg_ShowspecificCluster.ItemsSource = ShowSpecificClusterTable.DefaultView;
        }
        private void btn_saveClusterName(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cluster.Name != "") //Lavet for at forhindre en et tomt klynge navn bliver oprettet, i tilfælde af der bliver skrevet noget tekst, det bliver slettet, og man trykker opret.
                {
                    DB.OpenDb();
                    DB.InsertCluster(cluster);
                    //DataGridShowAllCluster();
                    cmb_cluster.Items.Clear();
                    FillcomboCluster();
                    DB.CloseDb();
                    MessageBox.Show("Klynge er oprettet");
                }
                else
                {
                    MessageBox.Show("Det valgte klynge navn er ikke gyldigt");
                }

            }
            catch (SqlException)
            {

                MessageBox.Show("Et felt er ikke udfyldt korrekt eller klyngen eksisterer i forvejen");
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void btn_addActorToCluster(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                DB.InsertActorInCluster(cluster);
                DataGridShowSpecificCluster();
                DB.CloseDb();
            }
            catch (Exception)
            {

                throw;
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
