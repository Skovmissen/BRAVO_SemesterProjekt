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
    public partial class EditActors : Page
    {
        Actors actor = new Actors();
        public EditActors()
        {
            InitializeComponent();
            DataContext = actor;
            DB.OpenDb();
            edit_Actor.ItemsSource = DB.ShowActor().DefaultView;
            DB.CloseDb();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            DB.UpdateActor(actor);
            edit_Actor.ItemsSource = DB.ShowActor().DefaultView;
            DB.CloseDb();
            MessageBox.Show("Redigering fuldført");
        }

        private void btn_Edit_Search_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            edit_Actor.ItemsSource = DB.SearchActor(actor).DefaultView;
            DB.CloseDb();
        }

        private void edit_Actor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in edit_Actor.SelectedItems)
            {
                actor.OldName = row.Row.ItemArray[0].ToString();
                actor.Name = row.Row.ItemArray[0].ToString();
                actor.Email = row.Row.ItemArray[1].ToString();
                actor.Tlf = row.Row.ItemArray[2].ToString();
                actor.Activate = Convert.ToBoolean(row.Row.ItemArray[3].ToString());
                
            }
           
        }
       

        private void button_Click(object sender, RoutedEventArgs e)
        {
            EditMenu menu = new EditMenu();
            NavigationService.Navigate(menu);
        }
    }
}
