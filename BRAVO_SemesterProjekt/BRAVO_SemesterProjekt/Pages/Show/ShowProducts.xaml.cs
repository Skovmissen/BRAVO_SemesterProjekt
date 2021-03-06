﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Af Claus
    /// 
    /// Denne klasse styre vores oversigt af produkter
    /// </summary>
    public partial class ShowProducts : Page
    {

        Products product = new Products();

        private bool valgt = false;
        public ShowProducts()
        {
            InitializeComponent();
            DataContext = product;
           
            try
            {
                DB.OpenDb();
            datagrid_ShowProducts.ItemsSource = DB.ShowProductsOverview().DefaultView;//i konstruktøren kaldes i DB en produktoversigt, der sendes til datagrid
            DB.CloseDb();
            SetSearchPropertiesToNull();
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

        private void SetSearchPropertiesToNull() //Sætter vores search properties til ingenting
        {
            product.SearchCatname = "";
            product.SearchCity = "";
            product.SearchProduct = "";
            product.SearchZipcode = "";
        }

        /// <summary>
        /// klik på knap søger i produkttabel for det bruger har indtastet
        /// </summary>
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(product.SearchCatname == null && product.SearchCity == null && product.SearchZipcode == null && product.SearchProduct == null))
                {
                    datagrid_ShowProducts.UnselectAllCells();
                    DB.OpenDb();
                    datagrid_ShowProducts.ItemsSource = DB.SearchProductOverview(product).DefaultView;//metoden kalder de søgte kolonner i DB og sender dem til datagriddet
                    DB.CloseDb();

                }
                else
                {
                    MessageBox.Show("Udfyld venligst en af de 4 søgefelter");
                }
              
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

        private void datagrid_ShowProducts_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            valgt = true;
            foreach (DataRowView row in datagrid_ShowProducts.SelectedItems) //for hvert række i datagriddet bliver indholdet af kolonner lagt i properties, som vi kan databinde til.
            {
                FillProperties(row);
            }
        }

        private void FillProperties(DataRowView row)
        {
            product.ProductName = row.Row.ItemArray[0].ToString();
            product.Category = row.Row.ItemArray[1].ToString();
            product.Description = row.Row.ItemArray[2].ToString();
            product.Price = Convert.ToDouble(row.Row.ItemArray[3].ToString());
            product.Street = row.Row.ItemArray[4].ToString();
            product.City = row.Row.ItemArray[5].ToString();
            product.Zipcode = row.Row.ItemArray[6].ToString();
            product.Url = row.Row.ItemArray[7].ToString();
            product.Latitude = Convert.ToDouble(row.Row.ItemArray[8].ToString());
            product.Longtitude = Convert.ToDouble(row.Row.ItemArray[9].ToString());
            product.Region = row.Row.ItemArray[10].ToString();
            product.OldName = "Kommune";
        }

        private void datagrid_ShowProducts_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {// i datagrid hvor oversigt vises frasorteres de kolonner der ikke er relevante for oversigten
            if (e.PropertyName == "Describtion" || e.PropertyName == "Region" || e.PropertyName == "URL" || e.PropertyName == "Street" || e.PropertyName == "Price" || e.PropertyName == "Latitude" || e.PropertyName == "Longtitude")
            {
                e.Column = null;
            }
            //kolonnenavne redigeres her så de giver mening for bruger - navnene fra tabellen udskiftes med en string værdi.
            if (e.PropertyName == "ProductName")
            {
                e.Column.Header = "Produkt";
            }
            if (e.PropertyName == "FK_CategoryName")
            {
                e.Column.Header = "Kategori";
            }
            if (e.PropertyName == "City")
            {
                e.Column.Header = "By";
            }
            if (e.PropertyName == "ZipCode")
            {
                e.Column.Header = "Post.Nr.";
            }
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            if (valgt)
            {
                Print.WriteToFile(product);
            }
            else
            {
                MessageBox.Show("Vælg et produkt før du printer");
            }
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu menu = new ShowMenu();
            NavigationService.Navigate(menu);
        }

    }
}
