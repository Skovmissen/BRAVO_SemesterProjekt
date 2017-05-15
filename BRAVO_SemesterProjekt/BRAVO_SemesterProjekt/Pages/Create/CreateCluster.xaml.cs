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
        Actors actor = new Actors();
        public CreateCluster()
        {

            InitializeComponent();
            DataContext = cluster;
            
            try
            {
                DB.OpenDb();                    //Denne indeholder en catch med messagebox, det skal den ikke gøre, der skal try catch om alle db.open i stedet for. ellers kommer der dobbelt messageboxe
                FillcomboActor();
                DataGridShowAllCluster();
                DB.CloseDb();
            }
            catch (Exception)
            {

                MessageBox.Show("Der er ingen forbindelse til databasen");
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
        private void DataGridShowAllCluster()
        {
            DataTable ShowCluster = DB.ShowCluster();
            dg_showcluster.ItemsSource = ShowCluster.DefaultView;
        }

        private void dg_showcluster_SelectionChanged(object sender, SelectionChangedEventArgs e)    //Denne metode finder klynges aktører, ved hjælp af det man markerer i datagridet 
        {
            foreach (DataRowView view in dg_showcluster.SelectedItems)
            {
                cluster.Name = view.Row.ItemArray[0].ToString(); //Her finden jeg det objekt der ligger i kolonne 0 i datagridet på den markerede linje og gemmer det i propertien Cluster.Name som en string

            }
            DataGridShowSpecificCluster();

        }
        private void DataGridShowSpecificCluster()
        {
            DataTable ShowSpecificCluster = DB.GetClusterActors(cluster);
            dg_ShowspecificCluster.ItemsSource = ShowSpecificCluster.DefaultView;
        }
        private void btn_saveClusterName(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cluster.Name != "") //Lavet for at forhindre en et tomt klynge navn bliver oprettet, i tilfælde af der bliver skrevet noget tekst, det bliver slettet, og man trykker opret.
                {
                    DB.OpenDb();
                    DB.InsertCluster(cluster);
                    DataGridShowAllCluster();
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

                MessageBox.Show("Valgte klynge navn er ikke gyldigt");
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
                DB.InsertActorInCluster(actor, cluster);
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
            actor.OldName = cmb_actor.Text;
        }
    }
}
