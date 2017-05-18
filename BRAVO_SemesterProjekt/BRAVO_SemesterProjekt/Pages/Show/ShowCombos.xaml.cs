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
using System.Data;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Interaction logic for ShowCombos.xaml
    /// </summary>
    public partial class ShowCombos : Page
    {

        Products product = new Products();
        ComboProducts combo = new ComboProducts();
        TempData temp = new TempData();
        public ShowCombos()
        {
            
            InitializeComponent();
            txt_Search_Combo.DataContext = temp;
            DB.OpenDb();
            GridShowCombo.ItemsSource = DB.ShowCombo().DefaultView;
            DB.CloseDb();
        }

        private void btn_Search_Combo_Click(object sender, RoutedEventArgs e)
        {
            DB.OpenDb();
            GridShowCombo.ItemsSource = DB.SearchCombo(temp).DefaultView;
            DB.CloseDb();
        }

        private void GridShowCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in GridShowCombo.SelectedItems)
            {
                combo.Id = Convert.ToInt32(row.Row.ItemArray[0].ToString());
            }
          
            DB.OpenDb();

            DataTable comboProducts = DB.GetComboProduts(combo);
            dataGridCombo.ItemsSource = DB.GetProductsInCombo(comboProducts).DefaultView;
            DB.CloseDb();
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu menu = new ShowMenu();
            NavigationService.Navigate(menu);
        }
    }
}
