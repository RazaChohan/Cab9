using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Prototype_1
{
    public partial class manreg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=(localdb)\v11.0;Integrated Security=true;AttachDbFileName=D:\FYP\CODE\FYP-PROTOTYPE-1\FYP-PROTOTYPE-1\APP_DATA\STATS.MDF;";
            conn.Open();

            //OleDbConnection conn = new OleDbConnection();
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.4.0;Data Source=D:\FYP\Code\FYP-Prototype-1\FYP-Prototype-1\chart.mdb";
            //conn.Open();
            ////string Name = textBox1.Text;
            //OleDbCommand cmmd = new OleDbCommand("INSERT INTO ORDERS (C_Name, C_Phone, To, From, Request_Time) Values("+TextBox6.Text+","+TextBox7.Text+","+TextBox8.Text+","+TextBox9.Text+","+TextBox10.Text+")", conn);
            //    try
            //    {
            //        cmmd.ExecuteNonQuery();
            //        //MessageBox.Show("DATA ADDED");
            //        conn.Close();
            //    }
            //    catch (OleDbException expe)
            //    {
            //        //MessageBox.Show(expe.Message);
            //        conn.Close();
            //    }
        
        }
    }
}