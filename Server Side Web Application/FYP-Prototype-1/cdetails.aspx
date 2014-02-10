<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cdetails.aspx.cs" Inherits="FYP_Prototype_1.cdetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cab 9</title>
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
            <asp:Label ID="Label1" runat="server" Text="Cab Details" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br />
        </center>
    </div>
        <div id="page">
            <center>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Google Maps - Copy.jpg" Height="282px" Width="548px"></asp:Image>
            </center>
        </div>
        <br />
    </form>
</body>
</html>