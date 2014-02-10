<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="FYP_Prototype_1.dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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

        html {
            background: url(images/bg.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
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

        p {
            font: 15px/2 Georgia, Serif;
            margin: 0 0 30px 0;
            text-indent: 40px;
        }
    </style>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript">
        var directionDisplay;
        var directionsService = new google.maps.DirectionsService();
        var map;
        var origin = null;
        var destination = null;
        var waypoints = [];
        var markers = [];
        var directionsVisible = false;

        function initialize() {
            directionsDisplay = new google.maps.DirectionsRenderer();
            var e7 = new google.maps.LatLng(33.726338, 73.045006);
            var myOptions = {
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                center: e7
            }
            map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
            directionsDisplay.setMap(map);
            directionsDisplay.setPanel(document.getElementById("directionsPanel"));

            google.maps.event.addListener(map, 'click', function (event) {
                if (origin == null) {
                    origin = event.latLng;
                    addMarker(origin);
                } else if (destination == null) {
                    destination = event.latLng;
                    addMarker(destination);
                } else {
                    if (waypoints.length < 9) {
                        waypoints.push({ location: destination, stopover: true });
                        destination = event.latLng;
                        addMarker(destination);
                    } else {
                        alert("Maximum number of waypoints reached");
                    }
                }
            });
        }

        function addMarker(latlng) {
            markers.push(new google.maps.Marker({
                position: latlng,
                map: map,
                icon: "http://maps.google.com/mapfiles/marker" + String.fromCharCode(markers.length + 65) + ".png"
            }));
        }

        function calcRoute() {
            if (origin == null) {
                alert("Click on the map to add a start point");
                return;
            }

            if (destination == null) {
                alert("Click on the map to add an end point");
                return;
            }

            var mode;
            switch (document.getElementById("mode").value) {
                case "bicycling":
                    mode = google.maps.DirectionsTravelMode.BICYCLING;
                    break;
                case "driving":
                    mode = google.maps.DirectionsTravelMode.DRIVING;
                    break;
                case "walking":
                    mode = google.maps.DirectionsTravelMode.WALKING;
                    break;
            }

            var request = {
                origin: origin,
                destination: destination,
                waypoints: waypoints,
                travelMode: mode,
                optimizeWaypoints: document.getElementById('optimize').checked,
                avoidHighways: document.getElementById('highways').checked,
                avoidTolls: document.getElementById('tolls').checked
            };

            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                }
            });

            clearMarkers();
            directionsVisible = true;
        }

        function updateMode() {
            if (directionsVisible) {
                calcRoute();
            }
        }

        function clearMarkers() {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
        }

        function clearWaypoints() {
            markers = [];
            origin = null;
            destination = null;
            waypoints = [];
            directionsVisible = false;
        }

        function reset() {
            clearMarkers();
            clearWaypoints();
            directionsDisplay.setMap(null);
            directionsDisplay.setPanel(null);
            directionsDisplay = new google.maps.DirectionsRenderer();
            directionsDisplay.setMap(map);
            directionsDisplay.setPanel(document.getElementById("directionsPanel"));
        }
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
            <asp:ImageButton ID="ImageButton1" runat="server" Height="53px" ImageUrl="~/images/buttons/d_button.png" OnClick="ImageButton1_Click" Width="183px"></asp:ImageButton>
        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/buttons/c_button.png" OnClick="ImageButton2_Click" />
&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/buttons/f_button.png" OnClick="ImageButton3_Click" Height="53px" />
&nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/buttons/m_button.png" OnClick="ImageButton4_Click" />
        &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/buttons/r_button.png" OnClick="ImageButton5_Click" />
        &nbsp;</center>
        </div>
        <br />
        <div id="page">
            <div></div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Image ID="Image2" runat="server" Height="398px" ImageUrl="~/images/Google-Maps-Location.png" Width="684px" />
            &nbsp;<br />
            <p id="newsp">
                <%--<marquee direction="up" scrollamount='1'>
				<%
           
                   
           while(reader.Read())
           {
               Response.Write("<span class='newsp'  ><u>" + reader[1] + "</u></span><br>");
               Response.Write("<span class='newsp' style='color:Gray;' > " + reader[2] + "</span><br>");

               Response.Write("<span style='Font-size:8px;' ><i>" + reader[3] + "</i></span><hr>");
           
           }

           reader.Close();
           mydata.Close();
		    		    		    
            %></marquee>--%>
            </p>
            <center>
            &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
&nbsp;</center>
            &nbsp;
        </div>
    </form>
</body>
</html>
