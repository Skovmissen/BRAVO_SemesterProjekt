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
            SqlCommand command = new SqlCommand("INSERT INTO Actor (ActorName, Activate) VALUES (@ActorName, @Activate)", connection);
            command.Parameters.Add(CreateParam("@ActorName", temp.Name, SqlDbType.NVarChar));
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
            SqlCommand command = new SqlCommand("INSERT INTO Product (City, ZipCode, Region, Street, Latitude, Longtitude, URL, Email, Tlf, Describtion, Activate) VALUES (@City, @ZipCode, @Region, @Street, @Latitude, @Longtitude, @URL, @Email, @Tlf, @Describtion, @Activate)", connection);
            command.Parameters.Add(CreateParam("@City", temp.City, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@ZipCode", temp.Zipcode, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Region", temp.Region, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Street", temp.Street, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Latitude", temp.Latitude, SqlDbType.Float));
            command.Parameters.Add(CreateParam("@Longtitude", temp.Longtitude, SqlDbType.Float));
            command.Parameters.Add(CreateParam("@URL", temp.Url, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Email", temp.Email, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Tlf", temp.Tlf, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Describtion", temp.Describtion, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Activate", temp.Activate, SqlDbType.Int));
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
