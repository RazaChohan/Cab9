<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="driverreg.aspx.cs" Inherits="FYP_Prototype_1.driverreg" %>

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
        <div id="Div1">
        <center>
            <asp:ImageButton ID="ImageButton2" runat="server" Height="53px" ImageUrl="~/images/buttons/d_button.png" OnClick="ImageButton1_Click" Width="183px"></asp:ImageButton>
        &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/buttons/c_button.png" OnClick="ImageButton2_Click" Height="52px" Width="197px" />
&nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/buttons/f_button.png" OnClick="ImageButton3_Click" Height="53px" />
&nbsp;<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/buttons/lg.png" OnClick="ImageButton4_Click" />
        &nbsp;<asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/images/buttons/r_button.png" OnClick="ImageButton5_Click" />
        &nbsp;</center>
    </div>
    <div id="page">
        <center>
            
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" ForeColor="White" Text="Driver Registration"></asp:Label>
            
        </center>
    </div>
        <br />
        <div id="page">
            <center>
                <table>
                    <tr><td>
                        <asp:Label ID="Label2" runat="server" ForeColor="White" Text="ID"></asp:Label>
                        </td><td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td></tr>
                    <tr><td>
                        <asp:Label ID="Label3" runat="server" ForeColor="White" Text="NIC"></asp:Label>
                        </td><td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td></tr>
                    <tr><td>
                        <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Address"></asp:Label>
                        </td><td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td></tr>
                    <tr><td>
                        <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Phone"></asp:Label>
                        </td><td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td></tr>
                    <tr><td>
                        <asp:Label ID="Label6" runat="server" ForeColor="White" Text="Dependants"></asp:Label>
                        </td><td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td></tr>
                    <tr><td>
                        <asp:Label ID="Label7" runat="server" ForeColor="White" Text="Availibility"></asp:Label>
                        </td><td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td></tr>
                    <tr><td colspan="2"><center><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/buttons/s_button.png" OnClick="ImageButton1_Click1"></asp:ImageButton></center></td></tr>
                </table>
            </center>
        </div>
    </form>
</body>
</html>
