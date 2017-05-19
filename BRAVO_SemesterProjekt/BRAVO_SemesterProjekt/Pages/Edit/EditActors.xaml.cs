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
    /// Lavet af Nikolaj
    /// </summary>
    public partial class EditActors : Page
    {
        Actors actor = new Actors();
        TempData temp = new TempData();
        public EditActors()
        {
            InitializeComponent();
            //DataContext = actor;
            txt_Edit_Search.DataContext = temp;
            txt_Edit_ActorEmail.DataContext = actor;
            txt_Edit_ActorTlf.DataContext = actor;
            txt_Edit_ActorName.DataContext = actor;
            checkBox.DataContext = actor;
            try
            {
                DB.OpenDb();
                edit_Actor.ItemsSource = DB.ShowAllActor().DefaultView;
                DB.CloseDb();
            }
            catch (SqlException)
            {

                MessageBox.Show("Ingen forbindelses til databasen");
            }
            catch (Exception)
            {
                MessageBox.Show("Ukendt fejl");
            }
         
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(actor.OldName == null || actor.OldName == "" || actor.Name == null || actor.Name == "" || actor.Email == null || actor.Email == "" || actor.Tlf == null || actor.Tlf == ""))
                {
                    DB.OpenDb();
                    DB.UpdateActor(actor);
                    edit_Actor.ItemsSource = DB.ShowAllActor().DefaultView;
                    DB.CloseDb();
                    actor.OldName = null;
                    actor.Name = null;
                    actor.Email = null;
                    actor.Tlf = null;
                    actor.Activate = false;
                    MessageBox.Show("Redigering fuldført");
                }
                else
                {
                    MessageBox.Show("Et felt er ikke udfyldt korrekt");
                }
            }
            catch (SqlException)
            {

                MessageBox.Show("Ingen forbindelse til databasen");
            }
            catch (Exception)
            {

                MessageBox.Show("ukendt fejl");
            }


        }

        private void btn_Edit_Search_Click(object sender, RoutedEventArgs e)
        {
            
            DB.OpenDb();
            edit_Actor.ItemsSource = DB.SearchActor(temp).DefaultView;
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

        private void edit_Actor_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "")
            {

            }
        }
    }
}
