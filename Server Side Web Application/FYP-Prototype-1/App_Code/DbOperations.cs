using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FYP_Prototype_1
{
    public class DbOperations
    {
        public bool AuthenticateUser(string name, string password)
        {
            string ConnectionString = @"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            SqlDataAdapter ad = new SqlDataAdapter();
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from Admin where Admin_Name= '" + name + "' And Admin_Password= '" + password + "'", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}