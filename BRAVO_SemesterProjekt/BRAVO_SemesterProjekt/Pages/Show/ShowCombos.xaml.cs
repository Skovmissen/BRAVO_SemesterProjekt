﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;

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
            lbl_end.DataContext = combo;
            lbl_start.DataContext = combo;
            lbl_name.DataContext = combo;
            txt_description.DataContext = combo;
            lbl_price.DataContext = combo;
            dp_end.DataContext = combo;
            dp_start.DataContext = combo;

            txt_Search_Combo.DataContext = temp;
            combo.SearchStartTime = DateTime.Now;
            combo.SearchEndTime = DateTime.Now;

            try
            {
                DB.OpenDb();
                GridShowCombo.ItemsSource = DB.ShowCombo().DefaultView;
                DB.CloseDb();
            }
            catch (SqlException)
            {

                MessageBox.Show("Ingen forbindelse til databasen");
            }
            catch (Exception)
            {

                MessageBox.Show("Ukendt fejl");
            }
        }

        private void btn_Search_Combo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.OpenDb();
                GridShowCombo.ItemsSource = DB.SearchCombo(temp, combo).DefaultView;
                DB.CloseDb();
            }
            catch (SqlException)
            {

                MessageBox.Show("Ingen forbindelse til databasen");
            }
            catch (Exception)
            {

                MessageBox.Show("Ukendt fejl");
            }

        }

        private void GridShowCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRowView row in GridShowCombo.SelectedItems)
            {
                combo.Id = Convert.ToInt32(row.Row.ItemArray[0].ToString());
                combo.StartTime = Convert.ToDateTime(row.Row.ItemArray[3].ToString());
                combo.EndTime = Convert.ToDateTime(row.Row.ItemArray[4].ToString());
                combo.Description = row.Row.ItemArray[2].ToString();
                combo.Name = row.Row.ItemArray[1].ToString();
                combo.Price = Convert.ToDouble(row.Row.ItemArray[5].ToString());
            }
            try
            {
                DB.OpenDb();

                DataTable comboProducts = DB.GetComboProduts(combo);
                dataGridCombo.ItemsSource = DB.GetProductsInCombo(comboProducts).DefaultView;
                DB.CloseDb();
            }
            catch (SqlException)
            {

                MessageBox.Show("Ingen forbindelse til databasen");
            }
            catch (Exception)
            {

                MessageBox.Show("Ukendt fejl");
            }

        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu menu = new ShowMenu();
            NavigationService.Navigate(menu);
        }

        private void GridShowCombo_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "CombiId" || e.PropertyName == "Description" || e.PropertyName == "Price" || e.PropertyName == "Activate")
            {
                e.Column = null;
            }
        }
    }
}
