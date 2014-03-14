<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="farecalc.aspx.cs" Inherits="FYP_Prototype_1.farecalc" %>

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
	    .auto-style1 {
            width: 182px;
        }
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
            <asp:ImageButton ID="ImageButton1" runat="server" Height="53px" ImageUrl="~/images/buttons/d_button.png" OnClick="ImageButton1_Click" Width="183px"></asp:ImageButton>
        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/buttons/c_button.png" OnClick="ImageButton2_Click" Height="52px" Width="197px" />
&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/buttons/dshb.png" OnClick="ImageButton3_Click" Height="53px" />
&nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/buttons/lg.png" OnClick="ImageButton4_Click" />
        &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/buttons/r_button.png" OnClick="ImageButton5_Click" />
        &nbsp;</center>
    </div>
    <div id="page">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Fare Calculation" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br />
        </center>
    </div>
        <br />
        <div id="page" style="text-align:center">
            <div style="text-align:center">
                <center>
                <table>
            <tr>
                <td style="color:white">Distance</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtBox1" runat="server"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="/m" ForeColor="White"></asp:Label></td>
                
            </tr>
                    <tr><td colspan="2" style="text-align:center"><asp:Button ID="Button1" runat="server" Text="Calculate" OnClick="Button1_Click" Width="100px" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False" Font-Size="X-Large" ForeColor="White"></asp:Label></td></tr>
           
        </table>
            </div>
           
    </form>
</body>
</html>