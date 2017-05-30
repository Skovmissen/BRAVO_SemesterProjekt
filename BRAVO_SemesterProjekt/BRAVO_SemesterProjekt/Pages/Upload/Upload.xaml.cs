using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

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
