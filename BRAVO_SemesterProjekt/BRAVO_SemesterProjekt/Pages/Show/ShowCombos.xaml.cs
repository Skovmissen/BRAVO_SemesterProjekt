﻿using System;
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
    /// Interaction logic for ShowCombos.xaml
    /// </summary>
    public partial class ShowCombos : Page
    {
        TempData Temp = new TempData();
        public ShowCombos()
        {
            DataContext = Temp;
            InitializeComponent();
            DB.OpenDb();
            GridShowCombo.ItemsSource = DB.ShowActorDB().DefaultView;
            DB.CloseDb();
        }

        private void btn_Search_Combo_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            GridShowCombo.ItemsSource = DB.SearchCombo(Temp).DefaultView;
            DB.CloseDb();
        }
    }
}
