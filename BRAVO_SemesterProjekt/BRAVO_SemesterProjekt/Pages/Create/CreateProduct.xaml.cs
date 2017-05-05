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
    /// Interaction logic for CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Page
    {
        TempData temp = new TempData();
        public CreateProduct()
        {
            InitializeComponent();
            DataContext = temp;
            DB.OpenDb();
            Fillcombo();
            DB.CloseDb();
        }     
        private void Fillcombo()
        {
            DataTable actor = DB.ShowActorDB();
            for (int i = 0; i < actor.Rows.Count; i++)
            {
                cmb_actor.Items.Add(actor.Rows[i]["ActorName"]);
            }
            DataTable category = DB.ShowCategory();
            for (int i = 0; i < category.Rows.Count; i++)
            {
                cmb_category.Items.Add(category.Rows[i]["CategoryName"]);
            }
        }

        private void cmb_category_DropDownClosed(object sender, EventArgs e)
        {
            temp.Category = cmb_category.Text;
        }
        private void cmb_actor_DropDownClosed(object sender, EventArgs e)
        {
            temp.Name = cmb_actor.Text;
        }
    }
}
