﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Subgurim;
using Subgurim.Controles;
using Subgurim.Controls;
using Subgurim.Maps;
using Subgurim.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Prototype_1
{
    public partial class cabloc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            string id = Request.QueryString["id"];
            double lat = 0, lon = 0;
            //          SELECT Cab.Cab_ID, CabLocations.Latitude, CabLocations.Longitude FROM Cab INNER JOIN CabLocations ON Cab.Cab_ID=CabLocations.Cab_ID WHERE Cab.Cab_RegNo = 'VY-702';
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
            connection.Open();
            SqlCommand sqlCmd = new SqlCommand("SELECT Cab.Cab_ID, CabLocations.Latitude, CabLocations.Longitude FROM Cab INNER JOIN CabLocations ON Cab.Cab_ID=CabLocations.Cab_ID WHERE Cab.Cab_RegNo = '" + id + "'", connection);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lat = Convert.ToDouble(dt.Rows[0]["Latitude"]);
                lon = Convert.ToDouble(dt.Rows[0]["Longitude"]);
            }
            connection.Close();

            GLatLng latlng = new GLatLng(lat, lon);
            GMapType.GTypes mType = GMapType.GTypes.Normal;
            GMap1.setCenter(latlng, 15, mType);
            ///////////////////////////////////////////////
            GMap1.Add(new GControl(GControl.preBuilt.LargeMapControl));

            GMarker m1 = new GMarker(new GLatLng(lat, lon));

            MarkerManager mManager = new MarkerManager();
            mManager.Add(m1, 10);

            List<GMarker> mks = new List<GMarker>();
            List<GInfoWindow> iws = new List<GInfoWindow>();

            Random r = new Random();
            GMarker mkr;
            for (int i = 0; i < 5; i++)
            {
                double ir1 = r.Next(40) / 10.0 - 2.0;
                double ir2 = r.Next(40) / 10.0 - 2.0;

                mkr = new GMarker(m1.point + new GLatLng(lat, lon));
                mks.Add(mkr);

                GMap1.Add(new GListener(mkr.ID, GListener.Event.click, "function(){alert('" + i + "');}"));
            }

            for (int i = 0; i < 5; i++)
            {
                double ir1 = r.Next(40) / 20.0 - 1;
                double ir2 = r.Next(40) / 20.0 - 1;

                mkr = new GMarker(m1.point + new GLatLng(lat, lon));
                GInfoWindow window = new GInfoWindow(mkr, i.ToString());
                iws.Add(window);
            }

            mManager.Add(mks, 5, 6);
            mManager.Add(iws, 7, 8);

            GMap1.markerManager = mManager;

        }

        protected void DashboardButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }

        protected void DriversButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("drivers.aspx");
        }

        protected void CabsButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("cabs.aspx");
        }

        protected void BookingRequestsButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CabBookingRequests.aspx");
        }

        protected void LogoutButton_Click1(object sender, EventArgs e)
        {
            Session["uname"] = null;
            Response.Redirect("Index.aspx");
        }

    }
}