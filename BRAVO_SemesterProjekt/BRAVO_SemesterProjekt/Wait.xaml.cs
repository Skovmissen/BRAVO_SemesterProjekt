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
using System.Windows.Shapes;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Interaction logic for Wait.xaml
    /// </summary>
    public partial class Wait : Window
    {
        private bool cancel;

        public bool Cancel
        {
            get { return cancel; }
            set { cancel = value; }
        }


        public Wait(TempData temp)
        {
           
            InitializeComponent();
            DataContext = temp;
        }

        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            
        }
    }
}
