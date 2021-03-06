﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BRAVO_SemesterProjekt
{
    /// <summary>
    /// Lavet af Lasse
    /// 
    /// Denne klasse bruges til at oprette aktører
    /// </summary>
    public partial class CreateActors : Page
    {
        Actors actor = new Actors();
        public CreateActors()
        {
            DataContext = actor;
            InitializeComponent();
        }

        private void btn_gem(object sender, RoutedEventArgs e)
        {
            if (!(actor.Name == null || actor.Name == "" || actor.Email == null || actor.Email == "" ||
                  actor.Tlf == null || actor.Tlf == ""))
            {
                try
                {

                    DB.OpenDb();
                    DataTable CheckDoubleActor = DB.CheckForDoubleActor(actor);
                    if (CheckDoubleActor.Rows.Count > 0)
                    {
                        MessageBox.Show("Aktør navnet findes i forvejen");
                    }
                    else
                    {
                        DB.InsertActor(actor);

                        MessageBox.Show("Aktør er oprettet");
                        ClearBoxes();
                    }
                }
                catch (SqlException)
                {

                    MessageBox.Show("Der er ingen forbindelse til databasen");
                }
                catch (Exception)
                {

                    MessageBox.Show("Ukendt fejl");
                }

                DB.CloseDb();
            }
            else
            {
                MessageBox.Show("Et felt er ikke udfyldt korrekt");
            }
        }
        private void ClearBoxes() // Denne metoder tømmer alle vores textboxes
        {
            actor.Name = null;
            actor.Tlf = null;
            actor.Email = null;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            CreateMenu menu = new CreateMenu();
            NavigationService.Navigate(menu); //Bruger navigation service til at navigere til menu siden
        }
    }
}
