<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FYP_Prototype_1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cab 9</title>
    <link type="text/css" rel="stylesheet" href="css/stylesheet.css" />
    <style>
		* { margin: 0; padding: 0; }
		
		html { 
			background: url(images/buttons/bg.jpg) no-repeat center center fixed; 
			-webkit-background-size: cover;
			-moz-background-size: cover;
			-o-background-size: cover;
			background-size: cover;
		}
		
		#page-wrap { width: 400px; margin: 50px auto; padding: 20px; background: white; -moz-box-shadow: 0 0 20px black; -webkit-box-shadow: 0 0 20px black; box-shadow: 0 0 20px black; }
		p { font: 15px/2 Georgia, Serif; margin: 0 0 30px 0; text-indent: 40px; }
	    .auto-style1 {
            width: 75px;
        }
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div>
            <center>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/buttons/Banner.png"></asp:Image>
            </center>
        </div>
        <br />
    <div id="page">
        <center>
            <table>
                <tr>
                    <td class="auto-style1"><center><asp:Label ID="Label1" runat="server" Text="ID" ForeColor="White"></asp:Label></center></td><td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td class="auto-style1"><center><asp:Label ID="Label2" runat="server" Text="Password" ForeColor="White"></asp:Label></center></td><td><asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox></td></tr>
                <tr>
                    <td colspan="2">
                        <center><br />
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/buttons/Log-In.png" OnClick="ImageButton1_Click" />
                        </center>
                    </td>
                </tr>
                
            </table>
            <table>
                <tr><td><asp:Label ID="Label3" runat="server" Text="Label" Visible="false" ForeColor="White" Font-Size="Large" ></asp:Label></td></tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
