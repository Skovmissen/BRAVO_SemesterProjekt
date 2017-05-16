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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Interaction logic for ShowActors.xaml
    /// </summary>
    public partial class ShowActors : Page
    {
        Actors actor = new Actors();
        Clusters cluster = new Clusters();
        Products product = new Products();
        public ShowActors()
        {
            DataContext = actor;
            InitializeComponent();
            DB.OpenDb();
            GridShowActor.ItemsSource = DB.ShowActor().DefaultView;
            DB.CloseDb();     
        }

        private void Btn_Search_Actor_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            GridShowActor.ItemsSource = DB.SearchActor(actor).DefaultView;
            DB.CloseDb();
        }

        private void GridShowActor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            foreach (DataRowView row in GridShowActor.SelectedItems)
            {
                cluster.Name = row.Row.ItemArray[0].ToString();
                product.ProductName = row.Row.ItemArray[0].ToString();
            }
            DB.OpenDb();
            ShowCluster.ItemsSource = DB.GetActorCluster(cluster).DefaultView;
            ShowProduct.ItemsSource = DB.GetActorProducts(product).DefaultView;
            DB.CloseDb();
        }
    }
}
