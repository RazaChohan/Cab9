<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cdetails.aspx.cs" Inherits="FYP_Prototype_1.cdetails" CodeFile="~/cdetails.aspx.cs"%>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cab 9</title>
    <link type="text/css" rel="stylesheet" href="css/stylesheet.css" />
    <style>
		* { margin: 0; padding: 0; }
		
		/*html { 
			background: url(images/bg.jpg) no-repeat center center fixed; 
			-webkit-background-size: cover;
			-moz-background-size: cover;
			-o-background-size: cover;
			background-size: cover;
		}*/
		
		#page-wrap { width: 400px; margin: 50px auto; padding: 20px; background: white; -moz-box-shadow: 0 0 20px black; -webkit-box-shadow: 0 0 20px black; box-shadow: 0 0 20px black; }
		p { font: 15px/2 Georgia, Serif; margin: 0 0 30px 0; text-indent: 40px; }
	    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/banner2.png"></asp:Image>
            </center>
        </div>
        <br />
        <div id="page">
            <center>
                <table>
                    <td>
                        <dx:ASPxButton ID="DashboardButton" runat="server" Text="Dashboard" Width="180" Height="50" Theme="BlackGlass" OnClick="DashboardButton_Click1"></dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="DriversButton" runat="server" Text="Drivers" Width="180" Height="50" Theme="BlackGlass" OnClick="DriversButton_Click1"></dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="CabsButton" runat="server" Text="Cabs" Width="180" Height="50" Theme="BlackGlass" OnClick="CabsButton_Click1"></dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="BookingRequestsButton" runat="server" Text="Booking Requests" Width="180" Height="50" Theme="BlackGlass" OnClick="BookingRequestsButton_Click1"></dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="LogoutButton" runat="server" Text="Logout" Width="180" Height="50" Theme="BlackGlass" OnClick="LogoutButton_Click1"></dx:ASPxButton>
                    </td>
                </table>
                 
            </center>
            
        </div>
        <br />
    <div id="page">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Cab Details" ForeColor="White" Font-Size="XX-Large"></asp:Label>
            <br />
            <a href="cabs.aspx" style="text-decoration:none; font-size:large; color: #FFFFFF;">View All Cabs</a>
        </center>
    </div>
        <div id="page">
            <center>
                <asp:Button ID="EditCabDetailsButtons" runat="server" Text="Edit Cab Details" Width="125px" OnClick="EditCabDetailsButtons_Click"></asp:Button>
                &nbsp&nbsp&nbsp&nbsp
                <asp:Button ID="DeleteCabButton" runat="server" Text="Delete Cab" Width="125px" OnClick="DeleteCabButton_Click"></asp:Button>
                <br />
                <asp:Label ID="DeleteWarningLabel" runat="server" Text="Label" ForeColor="White" Visible="false"></asp:Label>
                <br />
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Registration No.:" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="RegNumberLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Chassis No.:" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="ChassisNumLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Make:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                             <asp:Label ID="MakeLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Model:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="ModelLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Status:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="StatusLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Color:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="ColorLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Assigned Driver:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="AssignedDriverLabel" runat="server" Text="Label" ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                </table>
                
               
            </center>
        </div>
    </form>
</body>
</html>