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
    /// Lavet af Nikolaj
    /// </summary>
    public partial class Upload : Page
    {
        TempData temp = new TempData();
        Actors actor = new Actors();
        Products product = new Products();

        
        public Upload()
        {
            InitializeComponent();
            DataContext = temp;
        
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            Wait wait = new Wait(temp);
            XMLUpload.Uploadxml(temp, wait, actor, product);
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
                temp.Path = openFileDialog.FileName;
                
            }

            
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            CreateMenu menu = new CreateMenu();
            NavigationService.Navigate(menu);
        }
    }
}
