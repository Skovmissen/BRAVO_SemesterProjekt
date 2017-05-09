using System;
using System.Collections.Generic;
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
    /// Interaction logic for CreateActors.xaml
    /// </summary>
    public partial class CreateActors : Page
    {
        TempData temp = new TempData();
        public CreateActors()
        {
            DataContext = temp;
            InitializeComponent();
            
            
        }

        private void btn_gem(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                DB.InsertActor(temp);
                DB.CloseDb();
                MessageBox.Show("Aktør er oprettet");
            }
            catch (SqlException)
            {

                MessageBox.Show("Et felt er ikke udfyldt korrekt");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
