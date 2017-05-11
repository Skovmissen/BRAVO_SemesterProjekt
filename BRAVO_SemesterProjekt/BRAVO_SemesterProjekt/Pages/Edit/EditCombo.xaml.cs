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

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Af Claus
    /// Interaction logic for EditCombo.xaml
    /// 
    /// deaktivering produkt??
    /// start,slu,aktiver
    /// 
    /// </summary>
    public partial class EditCombo : Page
    {
        public EditCombo()
        {
            InitializeComponent();
            DB.OpenDb();
            //dataGrid_ShowCombo.ItemsSource = DB.ShowComboDB().DefaultView;
            DB.CloseDb();
        }
    }
}
