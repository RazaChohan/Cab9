<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="FYP_Prototype_1.AdminDashboard" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cab 9</title>
    <link type="text/css" rel="stylesheet" href="css/stylesheet.css" />
    <style>
        * {
            margin: 0;
            padding: 0;
        }
        

        #page-wrap {
            width: 400px;
            margin: 50px auto;
            padding: 20px;
            background: white;
            -moz-box-shadow: 0 0 20px black;
            -webkit-box-shadow: 0 0 20px black;
            box-shadow: 0 0 20px black;
        }

        #googleMap {
            height: 100%;
        }

        p {
            font: 15px/2 Georgia, Serif;
            margin: 0 0 30px 0;
            text-indent: 40px;
        }
        .auto-style1 {
            height: 52px;
        }
    </style>

    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCTeDk76jhKEU93aWiH8qhKZiZs0jnlFfY&sensor=false">
    </script>

    <script>
        var markers;
        var Positions;
        var Latitude1 = 33.686771;
        var Longitude1 = 73.038096;
        var Latitude2 = 33.708051;
        var Longitude2 = 73.063159;
        var Latitude3 = 33.728826;
        var Longitude3 = 73.057151;
        var Latitude4 = 33.691199;
        var Longitude4 = 73.004622;
        var map;

        function initialize() {           
            
            var mapProp = {
                center: new google.maps.LatLng(33.718151, 73.060547),
                zoom: 12,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById("googleMap")
                , mapProp);

            var infowindow = new google.maps.InfoWindow({ content: "Driver: Driver1, Status: Engaged" });
            var infowindow2 = new google.maps.InfoWindow({ content: "Driver: Driver2, Status: Engaged" });
            var infowindow3 = new google.maps.InfoWindow({ content: "Driver: Driver3, Status: free" });
            var infowindow4 = new google.maps.InfoWindow({ content: "Driver: Driver4, Status: Engaged" });

            markers = new Array();
            Positions = new Array();

            Positions[0] = new google.maps.LatLng(Latitude1, Longitude1);
            Positions[1] = new google.maps.LatLng(Latitude2, Longitude2);
            Positions[2] = new google.maps.LatLng(Latitude3, Longitude3);
            Positions[3] = new google.maps.LatLng(Latitude4, Longitude4);

            for (i = 0; i < 4; i++) {
                markers[i] = new google.maps.Marker({
                    position: Positions[i], title: "Marker " + i,
                    icon: 'images/taxi-128.png'
                });
                markers[i].setMap(map);

            }
            google.maps.event.addListener(markers[0], 'click', function () {
                infowindow.open(map, markers[0]);
            });
            google.maps.event.addListener(markers[1], 'click', function () {
                infowindow2.open(map, markers[1]);
            });
            google.maps.event.addListener(markers[2], 'click', function () {
                infowindow3.open(map, markers[2]);
            });
            google.maps.event.addListener(markers[3], 'click', function () {
                infowindow4.open(map, markers[3]);
            });
        }

        function ClearAllMarkers() {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
        }

        function CreateMarkers() {
            Latitude1 = Latitude1 - 0.00001;
            Longitude1 = Longitude1 - 0.00001;
            Latitude2 = Latitude2 + 0.000001;
            Longitude2 = Longitude2 + 0.000001;
            Latitude3 = Latitude3 + 0.0000001;
            //Longitude3 = Longitude3 + 0.0000001;
            Latitude4 = Latitude4 + 0.000001;
            Longitude4 = Longitude4 + 0.000001;


            var infowindow = new google.maps.InfoWindow({ content: "Driver: Driver1, Status: Engaged" });

            markers = new Array();
            Positions = new Array();

            Positions[0] = new google.maps.LatLng(Latitude1, Longitude1);
            Positions[1] = new google.maps.LatLng(Latitude2, Longitude2);
            Positions[2] = new google.maps.LatLng(Latitude3, Longitude3);
            Positions[3] = new google.maps.LatLng(Latitude4, Longitude4);

            for (i = 0; i < 4; i++) {
                markers[i] = new google.maps.Marker({
                    position: Positions[i], title: "Marker " + i,
                    icon: 'images/taxi-128.png'
                });
                markers[i].setMap(map);

            }
            google.maps.event.addListener(markers[0], 'click', function () {
                infowindow.open(map, markers[0]);
            });
            google.maps.event.addListener(markers[1], 'click', function () {
                infowindow.open(map, markers[1]);
            });
            google.maps.event.addListener(markers[2], 'click', function () {
                infowindow.open(map, markers[2]);
            });
            google.maps.event.addListener(markers[3], 'click', function () {
                infowindow.open(map, markers[3]);
            });
        }

        function ChangeMarkerPositions() {
            Latitude1 = Latitude1 + 0.001;
            Longitude1 = Longitude1 + 0.001;
            Latitude2 = Latitude2 + 0.001;
            Longitude2 = Longitude2 + 0.001;
            Latitude3 = Latitude3 + 0.001;
            Longitude3 = Longitude3 + 0.001;
            Latitude4 = Latitude4 + 0.001;
            Longitude4 = Longitude4 + 0.001;

            Positions[0] = new google.maps.LatLng(Latitude1, Longitude1);
            Positions[1] = new google.maps.LatLng(Latitude2, Longitude2);
            Positions[2] = new google.maps.LatLng(Latitude3, Longitude3);
            Positions[3] = new google.maps.LatLng(Latitude4, Longitude4);

            for (i = 0; i < 4; i++) {
                markers[i].setPosition(Positions[i]);
            }
            //map.setCenter(Positions[0]);

        }

        google.maps.event.addDomListener(window, 'load', initialize);
        //setInterval(ClearAllMarkers, 2000);
        setInterval(ChangeMarkerPositions, 1000);

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div>
            <center>
                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/banner2.png" />
            </center>
        </div>
        <br />
        <div id="page">
            <center>
                <table>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="DriversButton" runat="server" Text="Drivers" Theme="BlackGlass" Width="180" Height="50px" OnClick="DriversButton_Click"></dx:ASPxButton>
                    </td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="CabsButton" runat="server" Text="Cabs" Theme="BlackGlass" Width="180" Height="50px" OnClick="CabsButton_Click"></dx:ASPxButton>
                    </td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="BookingRequestsButton" runat="server" Text="Booking Requests" Theme="BlackGlass" Width="180" Height="50px" OnClick="BookingRequestsButton_Click"></dx:ASPxButton>
                    </td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="LogoutButton" runat="server" Text="Logout" Theme="BlackGlass" Width="180" Height="50px" OnClick="LogoutButton_Click"></dx:ASPxButton>
                    </td>
                </table>
                 
            </center>
            
        </div>
        <%--<div id="page">
            <center>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="53px" ImageUrl="~/images/buttons/d_button.png" OnClick="ImageButton1_Click" Width="183px"></asp:ImageButton>
                &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/buttons/c_button.png" OnClick="ImageButton2_Click" />
                &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/buttons/f_button.png" OnClick="ImageButton3_Click" Height="53px" />
                &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/buttons/m_button.png" OnClick="ImageButton4_Click" />
                &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/buttons/r_button.png" OnClick="ImageButton5_Click" />
                &nbsp;<asp:Button ID="Button1" runat="server" Text="Booking Requests" OnClick="Button1_Click1"></asp:Button>
                &nbsp;</center>
        </div>--%>
        <br />
        <div id="page"><center><div id="googleMap" style="width: 700px; height: 500px;"></div></center></div>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
