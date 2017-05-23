using System.Windows;

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
        public void WaitStart()
        {
            this.Show();
        }
        public void WaitEnd()
        {
            this.Close();
        }
    }
}
