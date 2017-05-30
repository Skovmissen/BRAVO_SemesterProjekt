using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Lavet af Nikolaj
    /// 
    /// 
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

        private void FileUrl() //Denne metode bruges til at åbne klassen OpenFileDialog, som bruger windows inbygget stifinder.
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (.xml)|*.xml"; // Gør at vi kun kan vælge XML filer i vores file dialog
            if (openFileDialog.ShowDialog() == true)
            {
                temp.Path = openFileDialog.FileName;
            }
        }
    }
}
