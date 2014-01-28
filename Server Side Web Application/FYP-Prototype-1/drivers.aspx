﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="drivers.aspx.cs" Inherits="FYP_Prototype_1.drivers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RadioCab Travel Central</title>
    <link type="text/css" rel="stylesheet" href="css/stylesheet.css" />
    <style>
		* { margin: 0; padding: 0; }
		
		html { 
			background: url(images/bg.jpg) no-repeat center center fixed; 
			-webkit-background-size: cover;
			-moz-background-size: cover;
			-o-background-size: cover;
			background-size: cover;
		}
		
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
            <asp:ImageButton ID="ImageButton1" runat="server" Height="53px" ImageUrl="~/images/buttons/dshb.png" OnClick="ImageButton1_Click" Width="183px"></asp:ImageButton>
        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/buttons/c_button.png" OnClick="ImageButton2_Click" Height="52px" Width="197px" />
&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/buttons/f_button.png" OnClick="ImageButton3_Click" Height="53px" />
&nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/buttons/lg.png" OnClick="ImageButton4_Click" />
        &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/buttons/r_button.png" OnClick="ImageButton5_Click" />
        &nbsp;</center>
    </div>
    <div id="page">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Drivers" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br />
            <a href="driverreg.aspx" style="text-decoration:none; font-size:large; color: #FFFFFF;">Driver Registration</a>
        </center>
    </div>
        <br />
        <div id="page">
            <center>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
            </center>
        </div>
    </form>
</body>
</html>