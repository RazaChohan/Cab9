using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class EditCabAllocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
        SqlConnection conn = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select Cab_RegNo from Cab where Cab_AssignedDriver='Yes'", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        DropDownList1.Items.Clear();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DropDownList1.Items.Add(dt.Rows[i]["Cab_RegNo"].ToString());
        }
        ///////////////////////////////////////////////////////////////////////////
        SqlConnection conn1 = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
        conn1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("Select Driver_Name from Driver", conn1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        DropDownList2.Items.Clear();
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            DropDownList2.Items.Add(dt1.Rows[i]["Driver_Name"].ToString());
        }

        da1 = new SqlDataAdapter("select Driver.Driver_name, Cab.Cab_RegNo from Driver, Cab where Driver.Cab_ID = Cab.Cab_ID", conn1);
        dt1 = new DataTable();
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
        conn1.Close();
    }
}
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn1 = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
        conn1.Open();
        string test = DropDownList1.SelectedItem.ToString();
        string test1 = DropDownList1.SelectedValue.ToString();
        string test3 = DropDownList2.SelectedItem.ToString();
        string test4 = DropDownList2.SelectedValue.ToString();
        SqlDataAdapter da1 = new SqlDataAdapter("Select Cab_ID from Cab where Cab_RegNo='"+DropDownList1.SelectedValue.ToString()+"'", conn1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        string cabid = dt1.Rows[0]["Cab_ID"].ToString();
        conn1.Close();
        //////////////////////////////////////////////////////////////
        SqlConnection conn2 = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
        conn2.Open();
        SqlCommand cmd = new SqlCommand("Update Driver Set Cab_ID='" + cabid + "' where Driver_Name='" + DropDownList2.SelectedItem.Text + "'");
        cmd.Connection = conn2;
        cmd.ExecuteNonQuery();
        conn2.Close();
        WarningLabel.Visible = true;
        WarningLabel.Text = "Cab Allocation has been updated Successfully!!!";
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
        SqlDataAdapter da1 = new SqlDataAdapter("select Driver.Driver_name, Cab.Cab_RegNo from Driver, Cab where Driver.Cab_ID = Cab.Cab_ID", conn1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();
        conn1.Close();
    }
}