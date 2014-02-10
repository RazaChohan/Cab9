<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cabreg.aspx.cs" Inherits="FYP_Prototype_1.cabreg" %>

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
	    .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            height: 23px;
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
        <div id="page">
        <center>
            <asp:ImageButton ID="ImageButton2" runat="server" Height="53px" ImageUrl="~/images/buttons/d_button.png" OnClick="ImageButton2_Click" Width="183px"></asp:ImageButton>
        &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/buttons/dshb.png" OnClick="ImageButton3_Click" />
&nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/buttons/f_button.png" OnClick="ImageButton4_Click" Height="53px" />
&nbsp;<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/buttons/lg.png" OnClick="ImageButton5_Click" />
        &nbsp;<asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/images/buttons/r_button.png" OnClick="ImageButton6_Click" />
        &nbsp;</center>
    </div>
        <br />
    <div id="page">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Cab Registration" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <br />
            <a href="cabs.aspx" style="text-decoration:none; font-size:large; color: #FFFFFF;">View All Cabs</a>
        </center>
    </div>
        <br />
        <div id="page">
            <center>
                <table>
                    <tr><td>
                        <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Registration Number"></asp:Label>
                        </td><td><asp:TextBox ID="RegistrationNumberTextBox" runat="server" Width="150px"></asp:TextBox></td><td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RegistrationNumberTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td>
                        <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Chassis Number"></asp:Label>
                        </td><td><asp:TextBox ID="ChassisNumberTextBox" runat="server" Width="150px"></asp:TextBox></td><td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ChassisNumberTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Make"></asp:Label>
                        </td><td class="auto-style1">
                            <asp:DropDownList ID="MakeDropDown" runat="server"  Width="150px">
                                <asp:ListItem>Toyota</asp:ListItem>
                                <asp:ListItem>Nissan</asp:ListItem>
                                <asp:ListItem>Suzuki</asp:ListItem>
                                <asp:ListItem>Hyundai</asp:ListItem>
                                <asp:ListItem>Kia</asp:ListItem>
                                <asp:ListItem>Daihatsu</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Honda</asp:ListItem>
                            </asp:DropDownList>
                        </td><td class="auto-style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="MakeDropDown" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Model"></asp:Label>
                        </td><td class="auto-style2">
                            <asp:TextBox ID="ModelTextBox" runat="server" Width="150px"></asp:TextBox>
                        </td><td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ModelTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    <tr><td>
                        <asp:Label ID="Label7" runat="server" ForeColor="White" Text="Color"></asp:Label>
                        </td><td><asp:TextBox ID="ColorTextBox" runat="server" Width="150px"></asp:TextBox></td><td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ColorTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td colspan="3"><center><br /><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/buttons/s_button.png" Height="40px"  Width="150px" OnClick="ImageButton1_Click"></asp:ImageButton></center></td></tr>
                    <tr><td colspan="3" style="text-align:center"><br/><asp:Label ID="Label8" runat="server" Text="Label" Visible="false" ForeColor="White" Font-Size="Large"></asp:Label></td></tr>
                </table>
            </center>
        </div>
        <br />
    </form>
</body>
</html>