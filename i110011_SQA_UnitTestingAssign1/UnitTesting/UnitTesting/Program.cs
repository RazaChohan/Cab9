using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class DbOperations
    {
        public DbOperations() { }
        public bool AuthenticateUser(string name, string password)
        {
            string ConnectionString = @"Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;";
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
    public class Fare
    {
        public Fare() { }
        public int CalculateFare(string dist)
        {
            int distance = Convert.ToInt32(dist);
            int tfare = (distance / 25);
            return tfare;
        }
    }
}
