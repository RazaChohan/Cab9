<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cabloc.aspx.cs" Inherits="FYP_Prototype_1.cabloc" CodeFile="~/cabloc.aspx.cs"%>

<%@ Register Assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGauges" TagPrefix="dx" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Linear" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Circular" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.State" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Digital" tagprefix="dx" %>

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

    

</head>
<body>
    <script type="text/javascript">
        var markers;
        var Positions;
        var CabDataTable;
        var InformationWindows = [];
        var info = new google.maps.InfoWindow({ content: '' });
        var map;

        function initialize() {

            var mapProp = {
                center: new google.maps.LatLng(33.718151, 73.060547),
                zoom: 12,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById("googleMap")
                , mapProp);

            markers = new Array();
            Positions = new Array();

        }

        function ClearAllMarkers() {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
        }

        function CreateMarkers() {

            markers = new Array();
            Positions = new Array();
            var TokenizedDetails = CabDataTable.split("_");     //All details related to one cab
            //var IndividualDetails;      //For individual details of each cab


            for (var i = 0; i < (TokenizedDetails.length - 1) ; i++) {
                // Extracting information related to each cab by splitting on the basis of comma
                var IndividualDetails = TokenizedDetails[i].split(",");

                //Defining position for the new marker to be added
                Positions[i] = new google.maps.LatLng(IndividualDetails[2], IndividualDetails[3]);

                //Adding the new marker to the map
                markers[i] = new google.maps.Marker({
                    position: Positions[i], title: "Cab " + i,
                    icon: 'images/taxi-icon_vectorized.png'
                });

                markers[i].setMap(map);

                //Associating the information window with the new marker
                var InfoContent = "Driver: " + IndividualDetails[1].toString() + ", Status: " + IndividualDetails[0].toString();
                google.maps.event.addListener(markers[i], 'click', (function (marker, InfoContent) {
                    return function () {
                        info.setContent(InfoContent);
                        info.open(map, marker);
                    }
                })(markers[i], InfoContent));
            }

        }

        function UpdateLocationsFromDB() {
            CabDataTable = '<%= Session["CurrentCabLocations"] %>';
        }

        function ChangeMarkerPositions() {

            InformationWindows = new Array();
            Positions = new Array();
            var TokenizedDetails = CabDataTable.split("_");     //All details related to one cab
            //var IndividualDetails;      //For individual details of each cab


            for (var i = 0; i < (TokenizedDetails.length - 1) ; i++) {
                // Extracting information related to each cab by splitting on the basis of comma
                var IndividualDetails = TokenizedDetails[i].split(",");

                //Updating new position for the cab marker 
                Positions[i] = new google.maps.LatLng(IndividualDetails[2], IndividualDetails[3]);

                //Setting the new position of cab on dashboard
                markers[i].setPosition(Positions[i]);

                var InfoContent = "Driver: " + IndividualDetails[1].toString() + ", Status: " + IndividualDetails[0].toString();
                google.maps.event.addListener(markers[i], 'click', (function (marker, InfoContent) {
                    return function () {
                        info.setContent(InfoContent);
                        info.open(map, marker);
                    }
                })(markers[i], InfoContent));
            }

        }

        google.maps.event.addDomListener(window, 'load', initialize);
        google.maps.event.addDomListener(window, 'load', UpdateLocationsFromDB);
        google.maps.event.addDomListener(window, 'load', CreateMarkers);
        setInterval(UpdateLocationsFromDB, 1000);
        setInterval(ChangeMarkerPositions, 1000);

    </script>

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
                        <dx:ASPxButton ID="DashboardButton" runat="server" Text="Dashboard" Width="180" Height="50" Theme="BlackGlass" OnClick="DashboardButton_Click1"></dx:ASPxButton></td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="DriversButton" runat="server" Text="Drivers" Width="180" Height="50" Theme="BlackGlass" OnClick="DriversButton_Click1"></dx:ASPxButton></td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="CabsButton" runat="server" Text="Cabs" Width="180" Height="50" Theme="BlackGlass" OnClick="CabsButton_Click1"></dx:ASPxButton></td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="BookingRequestsButton" runat="server" Text="Booking Requests" Width="180" Height="50" Theme="BlackGlass" OnClick="BookingRequestsButton_Click1"></dx:ASPxButton></td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="LogoutButton" runat="server" Text="Logout" Width="180" Height="50" Theme="BlackGlass" OnClick="LogoutButton_Click1"></dx:ASPxButton></td>
                </table>
                 
            </center>
            
        </div>
        <br />
        <div id="Div1">
            <center>
                <cc1:GMap ID="GMap1" runat=server></cc1:GMap>
            </center>
        </div>
    <center>
        <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" ForeColor="White" Text="Total Revenue"></asp:Label>
        <br />
        <dx:ASPxGaugeControl ID="ASPxGaugeControl1" Height="250px" Width="250px" runat="server" BackColor="Transparent" Value="00,000">
            <Gauges>
                <dx:DigitalGauge AppearanceOff-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#C8C8C8&quot;/&gt;" AppearanceOn-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:Black&quot;/&gt;" Bounds="0, 0, 250, 250" DigitCount="5" Name="Gauge0" Padding="20, 20, 20, 20" Text="00,000">
                    <backgroundlayers>
                        <dx:DigitalBackgroundLayerComponent AcceptOrder="-1000" BottomRight="259.8125, 99.9625" Name="digitalBackgroundLayerComponent13" ShapeType="Style11" TopLeft="20, 0" ZOrder="1000" />
                    </backgroundlayers>
                </dx:DigitalGauge>
            </Gauges>
<LayoutPadding All="0" Left="0" Top="0" Right="0" Bottom="0"></LayoutPadding>
        </dx:ASPxGaugeControl>
        <br />
        <br />
        <table>
            <tr><td>
                <center><asp:Label ID="Label2" runat="server" Font-Size="X-Large" ForeColor="White" Text="Best Sources"></asp:Label></center>
                </td><td>
                    <center><asp:Label ID="Label3" runat="server" Font-Size="X-Large" ForeColor="White" Text="Best Destinations"></asp:Label></center>
                </td></tr>
            <tr><td><asp:Chart ID="Chart1" runat=server DataSourceID="SqlDataSource1" Height="335px" Width="492px"><Series><asp:Series Name="Series1" ChartType="Pie" CustomProperties="PieLabelStyle=Disabled" Legend="Legend1" XValueMember="Booking_Source" YValueMembers="Column1"></asp:Series></Series><ChartAreas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></ChartAreas>
                <Legends>
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True" SelectCommand="SELECT [Booking_Source], Count([Booking_Source]) FROM [Booking] Group By Booking_Source"></asp:SqlDataSource>
                </td><td><asp:Chart ID="Chart2" runat=server DataSourceID="SqlDataSource2" Height="337px" Width="467px"><Series><asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Pie" CustomProperties="PieLabelStyle=Disabled" Legend="Legend1" XValueMember="Booking_Destination" YValueMembers="Column1"></asp:Series></Series><ChartAreas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1">
                        </asp:Legend>
                    </Legends>
                    </asp:Chart>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True" SelectCommand="SELECT [Booking_Destination], COUNT([Booking_Destination]) FROM [Booking] GROUP BY Booking_Destination"></asp:SqlDataSource>
                </td></tr>
        </table>
    </center>
    </form>
    </body>
</html>
