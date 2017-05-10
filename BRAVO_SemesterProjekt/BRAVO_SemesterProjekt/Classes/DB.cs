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

        public static void InsertActor(Actors actor)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Actor (ActorName, Email, Tlf, Activate) VALUES (@ActorName, @Email, @Tlf, @Activate)", connection);
            command.Parameters.Add(CreateParam("@ActorName", actor.Name, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Email", actor.Email, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Tlf", actor.Tlf, SqlDbType.NVarChar));
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
        public static void InsertActorInCluster(Actors actor, Clusters cluster)
        {
            SqlCommand command = new SqlCommand("INSERT INTO ActorCluster (FK_ClusterName, FK_ActorName) VALUES (@ClusterName, @ActorName)", connection);
            command.Parameters.Add(CreateParam("@ActorName", actor.OldName, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@ClusterName", cluster.Name, SqlDbType.NVarChar));
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertCluster(Clusters cluster)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Cluster (ClusterName, Activate) VALUES (@ClusterName, @Activate)", connection);
            command.Parameters.Add(CreateParam("@ClusterName", cluster.Name, SqlDbType.NVarChar));
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
        public static void InsertCategory(Products product)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Category (CategoryName) VALUES (@CategoryName)", connection);
            command.Parameters.Add(CreateParam("@CategoryName", product.Category, SqlDbType.NVarChar));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertCombo(ComboProducts combo)
        {
            SqlCommand command = new SqlCommand("INSERT INTO CombiProduct (CombiProductName, StartTime, EndTime, Activate) VALUES (@CombiProductName, @StartTime, @EndTime, @Activate)", connection);
            command.Parameters.Add(CreateParam("@CombiProductName", combo.Name, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@StartTime", combo.StartTime, SqlDbType.Date));
            command.Parameters.Add(CreateParam("@EndTime", combo.EndTime, SqlDbType.Date));
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
        public static void InsertXMLProduct( Products product, Actors actor)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Product (City, ZipCode, Region, Street, Latitude, Longtitude, URL, Describtion, Activate, FK_ActorName, FK_CategoryName, ProductName, XML_Id) VALUES (@City, @ZipCode, @Region, @Street, @Latitude, @Longtitude, @URL, @Describtion, @Activate, @ActorName, @CategoryName, @ProductName, @XmlId)", connection);
            command.Parameters.Add(CreateParam("@City", product.City, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@ZipCode", product.Zipcode, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Region", product.Region, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Street", product.Street, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Latitude", product.Latitude, SqlDbType.Float));
            command.Parameters.Add(CreateParam("@Longtitude", product.Longtitude, SqlDbType.Float));
            command.Parameters.Add(CreateParam("@URL", product.Url, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Describtion", product.Description, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Activate", 1, SqlDbType.Int));
            command.Parameters.Add(CreateParam("@ActorName", actor.Name, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@CategoryName", product.Category, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@ProductName", product.Name, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@XmlId", product.XmlId, SqlDbType.Int));

            try
            {

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertProduct(Products product, Actors actor)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Product (City, ZipCode, Region, Street, Latitude, Longtitude, URL, Describtion, Activate, FK_ActorName, FK_CategoryName, ProductName) VALUES (@City, @ZipCode, @Region, @Street, @Latitude, @Longtitude, @URL, @Describtion, @Activate, @ActorName, @CategoryName, @ProductName)", connection);
            command.Parameters.Add(CreateParam("@City", product.City, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@ZipCode", product.Zipcode, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Region", product.Region, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Street", product.Street, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Latitude", product.Latitude, SqlDbType.Float));
            command.Parameters.Add(CreateParam("@Longtitude", product.Longtitude, SqlDbType.Float));
            command.Parameters.Add(CreateParam("@URL", product.Url, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Describtion", product.Description, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Activate", 1, SqlDbType.Int));
            command.Parameters.Add(CreateParam("@ActorName", actor.Name, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@CategoryName", product.Category, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@ProductName", product.Name, SqlDbType.NVarChar));
            

            try
            {

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateActor(Actors actor)
        {
            SqlCommand command = new SqlCommand("UPDATE Actor SET ActorName = @ActorName , Email = @Email, Tlf = @Tlf, Activate = @Activate WHERE ActorName = @OldActorName", connection);
            command.Parameters.AddWithValue("@ActorName", actor.Name);
            command.Parameters.AddWithValue("@OldActorName", actor.OldName);
            command.Parameters.AddWithValue("@Email", actor.Email);
            command.Parameters.AddWithValue("@Tlf", actor.Tlf);
            command.Parameters.AddWithValue("@Activate", actor.Activate);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateCluster(Clusters cluster)
        {
            SqlCommand command = new SqlCommand("UPDATE Cluster SET ClusterName = @NewClusterName, Activate = @Activate WHERE ClusterName = @OldClusterName", connection);
            command.Parameters.AddWithValue("@OldClusterName", cluster.OldName);
            command.Parameters.AddWithValue("@NewClusterName", cluster.Name);
            command.Parameters.AddWithValue("@Activate", cluster.Activate);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateCombo(ComboProducts combo)
        {
            SqlCommand command = new SqlCommand("UPDATE CombiProduct SET CombiProductName = @CombiProductName, StartTime = @StartTime, EndTime = @EndTime WHERE CombiId = @CombiId", connection);
            command.Parameters.AddWithValue("@CombiProductName", combo.Name);
            command.Parameters.AddWithValue("@StartTime", combo.StartTime);
            command.Parameters.AddWithValue("@EndTime", combo.EndTime);
            command.Parameters.AddWithValue("@CombiId", combo.Id);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateProduct(Products product, Actors actor)
        {
            SqlCommand command = new SqlCommand("UPDATE Product SET ProductName = @ProductName, FK_CategoryName = @CategoryName, FK_ActorName = @ActorName, Activate = @Activate, City = @City, ZipCode = @ZipCode, Region = @Region, Street = @Street, Latitude = @Latitude, Longtitude = @Longtitude, URL = @URL, Describtion = @Describtion WHERE Xml_Id = @XmlId", connection);
            command.Parameters.Add(CreateParam("@City", product.City, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@ZipCode", product.Zipcode, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Region", product.Region, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Street", product.Street, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Latitude", product.Latitude, SqlDbType.Float));
            command.Parameters.Add(CreateParam("@Longtitude", product.Longtitude, SqlDbType.Float));
            command.Parameters.Add(CreateParam("@URL", product.Url, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Describtion", product.Description, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@Activate", 1, SqlDbType.Int));
            command.Parameters.Add(CreateParam("@ActorName", actor.Name, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@CategoryName", product.Category, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@ProductName", product.Name, SqlDbType.NVarChar));
            command.Parameters.Add(CreateParam("@XmlId", product.XmlId, SqlDbType.Int));
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static int SelectActorId(Actors actor)
        {
            SqlCommand command = new SqlCommand("SELECT ActorId FROM Actor WHERE ActorName = @ActorName", connection);
            command.Parameters.AddWithValue("@ActorName", actor.Name);
            try
            {
                int id = command.ExecuteNonQuery();
                return id;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable CheckForDoubleCategory(Products product)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter command = new SqlDataAdapter("SELECT CategoryName FROM Category WHERE CategoryName = @CategoryName", connection);
            command.SelectCommand.Parameters.AddWithValue("@CategoryName", product.Category);
            try
            {
                command.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable CheckForDoubleActor(Actors actor)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter command = new SqlDataAdapter("SELECT ActorName FROM Actor WHERE ActorName = @ActorName", connection);
            command.SelectCommand.Parameters.AddWithValue("@ActorName", actor.Name);
            try
            {
                command.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable CheckForDoubleProduct(Products product)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter command = new SqlDataAdapter("SELECT ProductName FROM Product WHERE Xml_Id = @xmlId", connection);
            command.SelectCommand.Parameters.AddWithValue("@xmlId", product.XmlId);
            try
            {
                command.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable ShowCluster()
        {
            DataTable ds = new DataTable();
            try
            {
                SqlDataAdapter reader = new SqlDataAdapter("SELECT * FROM Cluster WHERE Activate = 1", connection);
                reader.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataTable ShowCategory()
        {
            DataTable ds = new DataTable();
            try
            {
                SqlDataAdapter reader = new SqlDataAdapter("SELECT * FROM Category", connection);
                reader.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public static DataTable SearchCluster(Clusters cluster)
        {
            DataTable ds = new DataTable();
            try
            {
                SqlDataAdapter reader = new SqlDataAdapter("SELECT * FROM Cluster WHERE ClusterName LIKE @search", connection);
                reader.SelectCommand.Parameters.AddWithValue("@search", "%" + cluster.Name + "%");
                reader.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public static DataTable GetClusterActors(Clusters cluster)
        {
            DataTable ds = new DataTable();
            try
            {
                SqlDataAdapter reader = new SqlDataAdapter("SELECT FK_ActorName FROM ActorCluster WHERE FK_ClusterName LIKE @ClusterName", connection);
                reader.SelectCommand.Parameters.AddWithValue("@ClusterName", "%" + cluster.Name + "%");
                reader.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        private static SqlParameter CreateParam(string name, object value, SqlDbType type)  //Parameter omdanner en value læsbart til databasen
        {
            SqlParameter param = new SqlParameter(name, type);
            param.Value = value;
            return param;
        }
        public static DataTable ShowActorDB()
        {
            SqlDataAdapter ShowActor = new SqlDataAdapter("SELECT * FROM Actor", connection);
            DataTable dt = new DataTable();
            ShowActor.Fill(dt);
            return dt;
        }
        public static DataTable SearchActor(TempData temp)
        {
            DataTable SearchActorDt = new DataTable();
            try
            {
                SqlDataAdapter SearchActor = new SqlDataAdapter("SELECT * FROM ACTOR WHERE ACTORNAME LIKE @search", connection);
                SearchActor.SelectCommand.Parameters.AddWithValue("@search", "%" + temp.Search + "%");
                SearchActor.Fill(SearchActorDt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SearchActorDt;
        }
        public static DataTable ShowComboDB()
        {
            SqlDataAdapter ShowCombiProduct = new SqlDataAdapter("SELECT * FROM CombiProduct", connection);
            DataTable dt = new DataTable();
            ShowCombiProduct.Fill(dt);
            return dt;
        }
        public static DataTable SearchCombo(TempData temp)
        {
            DataTable SearchComboDt = new DataTable();
            try
            {
                SqlDataAdapter reader = new SqlDataAdapter("SELECT * FROM COMBIPRODUCT WHERE COMBIPRODUCTNAME LIKE @search", connection);
                reader.SelectCommand.Parameters.AddWithValue("@search", "%" + temp.Search + "%");
                reader.Fill(SearchComboDt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SearchComboDt;
        }

    }
}
