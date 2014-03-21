<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cabs.aspx.cs" Inherits="FYP_Prototype_1.cabs" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

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
        <br />
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
        <%--<div id="page">
        <center>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="53px" ImageUrl="~/images/buttons/d_button.png" OnClick="ImageButton1_Click" Width="183px"></asp:ImageButton>
        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/buttons/dshb.png" OnClick="ImageButton2_Click" Height="52px" Width="197px" />
&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/buttons/f_button.png" OnClick="ImageButton3_Click" Height="53px" />
&nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/buttons/lg.png" OnClick="ImageButton4_Click" />
        &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/buttons/r_button.png" OnClick="ImageButton5_Click" />
        &nbsp;</center>
    </div>--%>
        <br />
    <div id="page">
        
        <center>
            <asp:Label ID="Label1" runat="server" Text="Cabs" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br />
            <a href="cabreg.aspx" style="text-decoration:none; font-size:large; color: #FFFFFF;">Add New Cab</a>
        </center>
    </div>
        <div id="page">
            <center>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" HorizontalAlign="Justify" OnRowDataBound="GridView1_RowDataBound1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Width="500px">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:HyperLinkField />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>

            </center>
            
        </div>
    </form>
</body>
</html>