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
using System.Data;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Interaction logic for CreateCombo.xaml
    /// </summary>
    public partial class CreateCombo : Page
    {
        TempData temp = new TempData();
        public CreateCombo()
        {
            InitializeComponent();
            DataContext = temp;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                DB.InsertCombo(temp);
                DB.CloseDb();
            }
            catch (Exception)
            {

                throw;
            }
            MessageBox.Show("Kombiprodukt er oprettet");
            
        }
    }
}
