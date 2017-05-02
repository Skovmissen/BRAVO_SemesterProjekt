using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BRAVO_SemesterProjekt
{

    static class DB
    {
        static private SqlConnection connection = null;
        public static void OpenDb()
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectToDb"].ConnectionString);
                connection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Der er ingen forbindelse til databasen");
            }
        }
        public static void CloseDb()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InserActor(TempData temp)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Actor (ActorName, Email, Tlf Activate) VALUES (@ActorName, @Email, @Tlf @Activate)", connection);
            command.Parameters.Add(CreateParam("@ActorName", temp.Name, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Email", temp.Email, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Tlf", temp.Tlf, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Activate", 1, SqlDbType.Bit));
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertCluster(TempData temp)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Cluster (ClusterName, Activate) VALUES (@ClusterName, @Activate)", connection);
            command.Parameters.Add(CreateParam("@ClusterName", temp.Name, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Activate", 1, SqlDbType.Bit));
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertCombo(TempData temp)
        {
            SqlCommand command = new SqlCommand("INSERT INTO CombiProduct (CombiProductName, StartTime, EndTime, Activate) VALUES (@CombiProductName, @StartTime, @EndTime, @Activate)", connection);
            command.Parameters.Add(CreateParam("@CombiProductName", temp.Name, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@StartTime", temp.StartTime, SqlDbType.Date));
            command.Parameters.Add(CreateParam("@EndTime", temp.EndTime, SqlDbType.Date));
            command.Parameters.Add(CreateParam("@Activate", 1, SqlDbType.Bit));
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertProduct(TempData temp)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Product (City, ZipCode, Region, Street, Latitude, Longtitude, URL, Describtion, Activate) VALUES (@City, @ZipCode, @Region, @Street, @Latitude, @Longtitude, @URL, @Describtion, @Activate)", connection);
            command.Parameters.Add(CreateParam("@City", temp.City, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@ZipCode", temp.Zipcode, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Region", temp.Region, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Street", temp.Street, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Latitude", temp.Latitude, SqlDbType.Float));
            command.Parameters.Add(CreateParam("@Longtitude", temp.Longtitude, SqlDbType.Float));
            command.Parameters.Add(CreateParam("@URL", temp.Url, SqlDbType.NVarChar));            
            command.Parameters.Add(CreateParam("@Describtion", temp.Describtion, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Activate", 1, SqlDbType.Int));
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void UpdateActor(TempData temp)
        {
            SqlCommand command = new SqlCommand("UPDATE Actor SET ActorName = @ActorName , Email = @Email, Tlf = @Tlf WHERE ActorId = @ActorId", connection);
            command.Parameters.AddWithValue("@ActorName", temp.Name);
            command.Parameters.AddWithValue("@Email", temp.City);
            command.Parameters.AddWithValue("@Tlf", temp.City);
            command.Parameters.AddWithValue("@ActorId", temp.Id);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void UpdateCluster(TempData temp)
        {
            SqlCommand command = new SqlCommand("UPDATE Cluster SET ClusterName = @OldClusterName WHERE ClusterName = @NewClusterName", connection);
            command.Parameters.AddWithValue("@OldClusterName", temp.Name);
            command.Parameters.AddWithValue("@NewClusterName", temp.Describtion);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void UpdateCombo(TempData temp)
        {
            SqlCommand command = new SqlCommand("UPDATE CombiProduct SET CombiProductName = @CombiProductName, StartTime = @StartTime, EndTime = @EndTime WHERE CombiId = @CombiId", connection);
            command.Parameters.AddWithValue("@CombiProductName", temp.Name);
            command.Parameters.AddWithValue("@StartTime", temp.StartTime);
            command.Parameters.AddWithValue("@EndTime", temp.EndTime);
            command.Parameters.AddWithValue("@CombiId", temp.Id);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void UpdateProduct(TempData temp)
        {
            SqlCommand command = new SqlCommand("UPDATE Product SET City = @City, ZipCode = @ZipCode, Region = @Region, Street = @Street, Latitude = @Latitude, Longtitude = @Longtitude, URL = @URL, Describtion = @Describtion WHERE ProductId = @ProductId", connection);
            command.Parameters.AddWithValue("@City", temp.City);
            command.Parameters.AddWithValue("@ZipCode", temp.City);
            command.Parameters.AddWithValue("@Region", temp.City);
            command.Parameters.AddWithValue("@Street", temp.City);
            command.Parameters.AddWithValue("@Latitude", temp.City);
            command.Parameters.AddWithValue("@Longtitude", temp.City);
            command.Parameters.AddWithValue("@URL", temp.City);           
            command.Parameters.AddWithValue("@Describtion", temp.City);
            command.Parameters.AddWithValue("@ProductId", temp.Id);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private static SqlParameter CreateParam(string name, object value, SqlDbType type)  //Parameter omdanner en value læsbart til databasen
        {
            SqlParameter param = new SqlParameter(name, type);
            param.Value = value;
            return param;
        }
    }
}
