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
    /// Interaction logic for CreateCluster.xaml
    /// </summary>
    public partial class CreateCluster : Page
    {
        Clusters cluster = new Clusters();
        Actors actor = new Actors();
        public CreateCluster()
        {
            
            InitializeComponent();
            DataContext = cluster;
            DB.OpenDb();
            Fillcombo();
            DataGridShowCluster();
            DB.CloseDb();
        }

        private void btn_gem(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                DB.InsertCluster(cluster);
                DataGridShowCluster();
                DB.CloseDb();

            }
            catch (SqlException)
            {

                MessageBox.Show("Et felt er ikke udfyldt korrekt");
            }
            catch (Exception)
            {

                throw;
            }
            MessageBox.Show("Klynge er oprettet");
        }
        private void Fillcombo()
        {
            DataTable actor = DB.ShowActorDB();
            for (int i = 0; i < actor.Rows.Count; i++)
            {
                cmb_actor.Items.Add(actor.Rows[i]["ActorName"]);
            }           
        }
        private void DataGridShowCluster()
        {
            DataTable ShowCluster = DB.ShowCluster();
            dg_showcluster.ItemsSource = ShowCluster.DefaultView;
        }

        private void cmb_actor_DropDownClosed(object sender, EventArgs e)
        {
            actor.OldName = cmb_actor.Text;
        }

        private void dg_showcluster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in dg_showcluster.SelectedItems)
            {                
                cluster.Name = row.Row.ItemArray[0].ToString();
            }
            DataGridShowSpecificCluster();
        }
        private void DataGridShowSpecificCluster()
        {
            DataTable ShowSpecificCluster = DB.GetClusterActors(cluster);
            dg_ShowspecificCluster.ItemsSource = ShowSpecificCluster.DefaultView;          
        }
        private void AddActorToCluster()
        {
            DB.OpenDb();
        }

    }
}
