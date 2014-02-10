<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="driverreg.aspx.cs" Inherits="FYP_Prototype_1.driverreg" %>

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
            <br />
            <a href="drivers.aspx" style="text-decoration:none; font-size:large; color: #FFFFFF;">View All Drivers</a>
            
        </center>
    </div>
        <br />
        <div id="page">
            <center>
                <table>
                    <tr><td>
                        <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Driver Name"></asp:Label>
                        </td><td><asp:TextBox ID="NameTextBox" runat="server" Width="150px"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="NameTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr><td>
                        <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Password"></asp:Label>
                        </td><td><asp:TextBox ID="PasswordTextBox" runat="server" Width="150px" TextMode="Password"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PasswordTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr><td>
                        <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Email"></asp:Label>
                        </td><td><asp:TextBox ID="EmailTextBox" runat="server" Width="150px"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr><td>
                        <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Phone Number"></asp:Label>
                        </td><td><asp:TextBox ID="PhoneNumberTextBox" runat="server" Width="150px"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PhoneNumberTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr><td>
                        <asp:Label ID="Label6" runat="server" ForeColor="White" Text="NIC"></asp:Label>
                        </td><td><asp:TextBox ID="NICTextBox" runat="server" Width="150px"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NICTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr><td>
                        <asp:Label ID="Label7" runat="server" ForeColor="White" Text="Address"></asp:Label>
                        </td><td><asp:TextBox ID="AddressTextBox" runat="server" Width="150px"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="AddressTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label8" runat="server" ForeColor="White" Text="Gender"></asp:Label></td>
                        <td><asp:DropDownList ID="GenderDropDown" runat="server" Width="150px">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="GenderDropDown" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label9" runat="server" ForeColor="White" Text="Age"></asp:Label></td>
                        <td><asp:TextBox ID="AgeTextBox" runat="server" Width="150px" OnTextChanged="AgeTextBox_TextChanged"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="AgeTextBox" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label10" runat="server" ForeColor="White" Text="Profile Photo"></asp:Label></td>
                        <td><asp:FileUpload ID="ImageUploadToDB" Width="150px" runat="server" ForeColor="White" /></td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ImageUploadToDB" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label11" runat="server" ForeColor="White" Text="Cab"></asp:Label></td>
                        <td><asp:DropDownList ID="CabDropDown" runat="server" Width="150px"></asp:DropDownList></td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="CabDropDown" ErrorMessage="* Required Field" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr><td colspan="3"><center><br/><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/buttons/s_button.png" OnClick="ImageButton1_Click1"></asp:ImageButton></center></td></tr>
                    <tr>
                        <td colspan="3"><asp:Label ID="WarningLabel" runat="server" Text="Label" Visible="False" ForeColor="White" Font-Size="Large"></asp:Label></td>
                    </tr>
                </table>
            </center>
        </div>
    </form>
</body>
</html>
