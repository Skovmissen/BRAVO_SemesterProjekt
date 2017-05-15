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
    /// Interaction logic for EditProducts.xaml
    /// </summary>
    public partial class EditProducts : Page
    {
        public EditProducts()
        {
            InitializeComponent();
        }

        private void dataGrid_Edit_Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in dataGrid_Edit_Product.SelectedItems)
            {
                product.Name = row.Row.ItemArray[0].ToString();
                product.City = row.Row.ItemArray[1].ToString();
                product.Zipcode = row.Row.ItemArray[2].ToString();
                product.Region = row.Row.ItemArray[3].ToString();
                product.Street = row.Row.ItemArray[4].ToString();
                product.Latitude = Convert.ToDouble(row.Row.ItemArray[5].ToString());
                product.Longtitude = Convert.ToDouble(row.Row.ItemArray[6].ToString());
                product.Url = row.Row.ItemArray[7].ToString();
                product.Description = row.Row.ItemArray[8].ToString();
                
                product.Activate = Convert.ToBoolean(row.Row.ItemArray[9].ToString());
            }
        }
    }
}
