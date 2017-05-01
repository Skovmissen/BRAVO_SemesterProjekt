using System;
using System.Collections.Generic;
using System.Configuration;
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

        }
    }
}
