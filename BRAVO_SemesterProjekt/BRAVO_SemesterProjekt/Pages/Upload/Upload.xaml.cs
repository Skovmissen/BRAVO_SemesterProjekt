using Microsoft.Win32;
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
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class Upload : Page
    {
        TempData temp = new TempData();
        public Upload()
        {
            InitializeComponent();
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            XMLUpload.Uploadxml(temp);
        }

        private void Choose_File_Click(object sender, RoutedEventArgs e)
        {
            FileUrl();
          
            
        }
        public void FileUrl()
        {
          

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                temp.Url = openFileDialog.FileName;
                label.Content = openFileDialog.FileName;
            }

            
        }
    }
}
