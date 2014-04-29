<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/AdminDashboard.aspx.cs" Inherits="FYP_Prototype_1.AdminDashboard" CodeFile="~/AdminDashboard.aspx.cs"%>

<%@ Register Assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGauges" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Linear" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Circular" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.State" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Digital" tagprefix="dx" %>
<%@ Register assembly="DevExpress.XtraGauges.v13.1.Core, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraGauges.Base" TagPrefix="dx" %>


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
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    
Cab 9</title>
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
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    

</head>
<body>
    <script type="text/javascript">
        var markers;
        var Positions;
        var CabDataTable;
        var InformationWindows = [];
        var info = new google.maps.InfoWindow({ content: '' });
        var map;
        var count = 1;
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
                    icon: 'images/BookeCab.png'
                });

                markers[i].setMap(map);

                //Associating the information window with the new marker
                var InfoContent = "Driver: " + IndividualDetails[1].toString() + "<br/>Status: " + IndividualDetails[0].toString() + "<br/>Registration Number: " + IndividualDetails[4].toString() + "<br/>Location: " + IndividualDetails[2].toString() + "," + IndividualDetails[3].toString();
                google.maps.event.addListener(markers[i], 'click', (function (marker, InfoContent) {
                    return function () {
                        info.setContent(InfoContent);
                        info.open(map, marker);
                    }
                })(markers[i], InfoContent));
            }

        }

        var webMethod_result;
        function WebMethod_OnError(result, response) {
            //debugger
            //Dummy function for page method ajax call
            //alert("ERROR: "+result.d);
        }
        function WebMethod_OnSuccess(result, response) {
            //Dummy function for page method ajax call
            webMethod_result = result.d;
        }

        function CallWebMethod(MethodName, ObjParams, isAsync, OnSuccessHandler, OnErrorHandler) {
            try {
                //Set the callback methods for success and error
                if (OnSuccessHandler == undefined || typeof (OnSuccessHandler) == "undefined") {
                    OnSuccessHandler = WebMethod_OnSuccess
                }

                if (OnErrorHandler == undefined || typeof (OnErrorHandler) == "undefined") {
                    OnErrorHandler = WebMethod_OnError
                }

                //Serialize the webmethod function parameters
                var serializedParams = "";
                //using Json2.js; 
                //you can download the file from the location mentioned in the references
                serializedParams = JSON.stringify(ObjParams);


                //Make the ajax calls
                return $.ajax(
                    {
                        type: "POST",
                        url: "GetUpdatedSession.asmx/GetUpdatedLocation",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: OnSuccessHandler,
                        error: OnErrorHandler
                    });
            }
            catch (e) {
                //suppress error
                //alert(e);
            }

            return;
        }

        function GetSessionValue(SessionName, OnSuccessHandler, OnErrorHandler) {
            //set web method parameters; should be same as parameter name else the web 
            //method wont be called 
            var methodParams = new Object();
            methodParams.Name = SessionName;

            CallWebMethod("GetUpdatedLocation", methodParams, false, OnSuccessHandler, OnErrorHandler);

            //get the response 
            return webMethod_result;
        }

        function UpdateLocationsFromDB() {

            if (count == 1 || webMethod_result == "undefined") {
                CabDataTable = '<%= Session["CurrentCabLocations"] %>';
                //alert(CabDataTable);
        }
        else {
            GetSessionValue("CurrentCabLocations")
            CabDataTable = webMethod_result;
                //alert("Result of web service function: " + webMethod_result);
        }
        count = count + 1;


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
            var NewPosition = new google.maps.LatLng(IndividualDetails[2], IndividualDetails[3]);

            markers[i].setPosition(NewPosition);

            if (IndividualDetails[0].toString() == "Booked") {
                markers[i].setIcon('images/BookedCab.png');
            }
            if (IndividualDetails[0].toString() == "Available") {
                markers[i].setIcon('images/AvailableCab.png');
            }
            if (IndividualDetails[0].toString() == "Unavailable") {
                markers[i].setIcon('images/UnavailableCab.png');
            }

            var InfoContent = "Driver: " + IndividualDetails[1].toString() + "<br/>Status: " + IndividualDetails[0].toString() + "<br/>Registration Number: " + IndividualDetails[4].toString() + "<br/>Location: " + IndividualDetails[2].toString() + "," + IndividualDetails[3].toString();;
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
                        <dx:ASPxButton ID="DriversButton" runat="server" Text="Drivers" Theme="BlackGlass" Width="180" Height="50px" OnClick="DriversButton_Click"></dx:ASPxButton>
                    </td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="CabsButton" runat="server" Text="Cabs" Theme="BlackGlass" Width="180" Height="50px" OnClick="CabsButton_Click"></dx:ASPxButton>
                    </td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="BookingRequestsButton" runat="server" Text="Booking Requests" Theme="BlackGlass" Width="180" Height="50px" OnClick="BookingRequestsButton_Click"></dx:ASPxButton>
                    </td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="PendingRegReqButton" runat="server" Text="Registration Requests" Theme="BlackGlass" Width="180" Height="50px" OnClick="PendingRegReqButton_Click"></dx:ASPxButton>
                    </td>
                    <td class="auto-style1">
                        <dx:ASPxButton ID="LogoutButton" runat="server" Text="Logout" Theme="BlackGlass" Width="180" Height="50px" OnClick="LogoutButton_Click"></dx:ASPxButton>
                    </td>
                </table>
                 
            </center>
            
        </div>
        <br />
        <div id="page"><center><div id="googleMap" style="width: 700px; height: 500px;"></div></center></div>
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="Page not updated yet" ForeColor="White" Visible="False"></asp:Label>

                
            </ContentTemplate>
            
        </asp:UpdatePanel>
        <asp:Label ID="HiddenLabel" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />
        <asp:Panel ID="Panel1" runat="server">
        
            <center>
                <table>
                    <tr>
                        <td><center><asp:Label runat="server" Font-Size="XX-Large" Text="Total Cabs" ForeColor="White"></asp:Label></center></td><td><center><asp:Label runat="server" Font-Size="XX-Large" Text="Catered Orders" ForeColor="White"></asp:Label></center></td><td><center><asp:Label runat="server" Font-Size="XX-Large" Text="Total Drivers" ForeColor="White"></asp:Label></center></td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxGaugeControl ID="ASPxGaugeControl1" runat="server" BackColor="Transparent" Height="250px" Value="00,000" Width="250px">
                                <Gauges>
                                    <dx:DigitalGauge AppearanceOff-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#C8C8C8&quot;/&gt;" AppearanceOn-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:Black&quot;/&gt;" Bounds="0, 0, 250, 250" DigitCount="5" Name="Gauge0" Padding="20, 20, 20, 20" Text="00,000">
                                        <backgroundlayers>
                                            <dx:DigitalBackgroundLayerComponent AcceptOrder="-1000" BottomRight="259.8125, 99.9625" Name="digitalBackgroundLayerComponent13" ShapeType="Style11" TopLeft="20, 0" ZOrder="1000" />
                                        </backgroundlayers>
                                    </dx:DigitalGauge>
                                </Gauges>
                                <LayoutPadding All="0" Bottom="0" Left="0" Right="0" Top="0" />
                            </dx:ASPxGaugeControl>
                        </td><td><center>
                            <dx:ASPxGaugeControl ID="ASPxGaugeControl2" runat="server" BackColor="Transparent" Height="250px" Value="00,000" Width="250px">
                                <Gauges>
                                    <dx:DigitalGauge AppearanceOff-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#C8C8C8&quot;/&gt;" AppearanceOn-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:Black&quot;/&gt;" Bounds="0, 0, 250, 250" DigitCount="5" Name="Gauge0" Padding="20, 20, 20, 20" Text="00,000">
                                        <backgroundlayers>
                                            <dx:DigitalBackgroundLayerComponent AcceptOrder="-1000" BottomRight="259.8125, 99.9625" Name="digitalBackgroundLayerComponent13" ShapeType="Style11" TopLeft="20, 0" ZOrder="1000" />
                                        </backgroundlayers>
                                    </dx:DigitalGauge>
                                </Gauges>
                                <LayoutPadding All="0" Bottom="0" Left="0" Right="0" Top="0" />
                            </dx:ASPxGaugeControl>
                            </center></td><td><center>
                            <dx:ASPxGaugeControl ID="ASPxGaugeControl3" runat="server" BackColor="Transparent" Height="250px" Value="00,000" Width="250px">
                                <Gauges>
                                    <dx:DigitalGauge AppearanceOff-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#C8C8C8&quot;/&gt;" AppearanceOn-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:Black&quot;/&gt;" Bounds="0, 0, 250, 250" DigitCount="5" Name="Gauge0" Padding="20, 20, 20, 20" Text="00,000">
                                        <backgroundlayers>
                                            <dx:DigitalBackgroundLayerComponent AcceptOrder="-1000" BottomRight="259.8125, 99.9625" Name="digitalBackgroundLayerComponent13" ShapeType="Style11" TopLeft="20, 0" ZOrder="1000" />
                                        </backgroundlayers>
                                    </dx:DigitalGauge>
                                </Gauges>
                                <LayoutPadding All="0" Bottom="0" Left="0" Right="0" Top="0" />
                            </dx:ASPxGaugeControl>
                            </center></td>
                    </tr>
                </table>
                <center>
                    <table>
                        <tr>
                            <td><center><asp:Label ID="Label5" runat="server" Font-Size="XX-Large" Text="Best Drivers" ForeColor="White"></asp:Label>&nbsp;</center></td><td><center>
                            <asp:Label ID="Label6" runat="server" Font-Size="XX-Large" Text="Best locations" ForeColor="White"></asp:Label>
                                &nbsp;</center></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Chart ID="Chart1" runat="server" Width="467px" DataSourceID="SqlDataSource4">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="Driver_Name" YValueMembers="Driver_Rating">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Cab9ConnectionString %>" SelectCommand="SELECT [Driver_Name], [Driver_Rating] FROM [Driver] ORDER BY [Driver_Rating] DESC"></asp:SqlDataSource>
                            </td><td>
                                <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource1" Width="357px">
                                    <Series>
                                        <asp:Series ChartType="Pie" Legend="Legend1" Name="Series1" CustomProperties="PieLabelStyle=Disabled" XValueMember="Booking_Source" YValueMembers="Column1">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                    <Legends>
                                        <asp:Legend Name="Legend1">
                                        </asp:Legend>
                                    </Legends>
                                </asp:Chart>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Cab9ConnectionString %>" SelectCommand="Select Booking.Booking_Source,
 count(Booking.Booking_Source)
  from Booking group by Booking_Source"></asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="Label7" runat="server" Font-Size="XX-Large" Text="Generated Revenue" ForeColor="White"></asp:Label>
                    &nbsp;<br />
                    <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource2" Width="821px">
                        <Series>
                            <asp:Series ChartType="Spline" Name="Series1" XValueMember="DATE" YValueMembers="Booking_Fare">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Cab9ConnectionString %>" SelectCommand="SELECT LEFT(Booking_DateTime,11) AS DATE, 
       [Booking_Fare] 
  FROM [Cab9].[dbo].[Booking]
ORDER BY [Booking_DateTime]"></asp:SqlDataSource>
                    <br />
                </center>
            </center>
        
        </asp:Panel>
        <br />
    </form>
</body>
</html>
