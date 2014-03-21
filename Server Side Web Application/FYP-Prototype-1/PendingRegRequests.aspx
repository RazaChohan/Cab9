<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingRegRequests.aspx.cs" Inherits="FYP_Prototype_1.PendingRegRequests" %>

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

        /*html {
            background: url(images/bg.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }*/

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
    </style>

   

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
                    <td>
                        <dx:ASPxButton ID="DashboardButton" runat="server" Text="Dashboard" Width="180" Height="50" Theme="BlackGlass" OnClick="DashboardButton_Click"></dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="DriversButton" runat="server" Text="Drivers" Width="180" Height="50" Theme="BlackGlass" OnClick="DriversButton_Click"></dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="CabsButton" runat="server" Text="Cabs" Width="180" Height="50" Theme="BlackGlass" OnClick="CabsButton_Click"></dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="BookingRequestsButton" runat="server" Text="Booking Requests" Width="180" Height="50" Theme="BlackGlass" OnClick="BookingRequestsButton_Click"></dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="LogoutButton" runat="server" Text="Logout" Width="180" Height="50" Theme="BlackGlass" OnClick="LogoutButton_Click"></dx:ASPxButton>
                    </td>
                </table>
                 
            </center>
            
        </div>
        <br />
        <%--<div id="page">
            <center>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="53px" ImageUrl="~/images/buttons/d_button.png" OnClick="ImageButton1_Click" Width="183px"></asp:ImageButton>
            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/buttons/dshb.png" OnClick="ImageButton2_Click" Height="52px" Width="197px" />
            &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/buttons/f_button.png" OnClick="ImageButton3_Click" Height="53px" />
            &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/buttons/lg.png" OnClick="ImageButton4_Click" />
            &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/buttons/r_button.png" OnClick="ImageButton5_Click" />
            &nbsp;</center>
        </div>--%>
        <div id="page">
            <center>
                <asp:Label ID="Label1" runat="server" Text="Pending Registration Requests" Font-Size="Large" ForeColor="White"></asp:Label>
                <br />
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="2000">
                </asp:Timer>
                <center>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:GridView ID="BookingsGridView" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="960px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="BookingsGridView_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <asp:ImageButton ID="ReviewButton" runat="server" ImageUrl="~/images/buttons/ReviewButton.png" OnClick="ReviewButton_Click"></asp:ImageButton>
                </center>
                
            </center>
        </div>

            
    </form>
</body>
</html>
