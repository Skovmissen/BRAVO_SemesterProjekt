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
        
        
        
        public ShowActors()
        {
            
            InitializeComponent();
            DB.OpenDb();
            h.ItemsSource = DB.ShowActorDB().DefaultView;
            DB.CloseDb();
            
        }
        
        
    }
}
