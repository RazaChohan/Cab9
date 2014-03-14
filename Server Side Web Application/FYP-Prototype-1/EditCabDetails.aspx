<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCabDetails.aspx.cs" Inherits="FYP_Prototype_1.EditCabDetails" %>

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
           <asp:Label ID="Label1" runat="server" Text="Edit Cab Details" ForeColor="White" Font-Size="XX-Large"></asp:Label>
            <br />
            <a href="cabs.aspx" style="text-decoration:none; font-size:large; color: #FFFFFF;">View All Cabs</a>
        </center>
    </div>
        <br />
        <div id="page">
            <center>
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Registration No.:" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:TextBox ID="RegistrationNumbertextBox" runat="server" Width="200px"></asp:TextBox><br />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RegistrationNumberTextBox" runat="server" ForeColor="White" ErrorMessage="* Required Field"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Chassis No.:" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:TextBox ID="ChassisNumTextBox" runat="server" Width="200px"></asp:TextBox><br />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ChassisNumTextBox" runat="server" ForeColor="White" ErrorMessage="* Required Field"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Make:" ForeColor="White"></asp:Label>
                        </td>
                        
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:DropDownList ID="MakeDropDown" runat="server"  Width="200px">
                                <asp:ListItem>Toyota</asp:ListItem>
                                <asp:ListItem>Nissan</asp:ListItem>
                                <asp:ListItem>Suzuki</asp:ListItem>
                                <asp:ListItem>Hyundai</asp:ListItem>
                                <asp:ListItem>Kia</asp:ListItem>
                                <asp:ListItem>Daihatsu</asp:ListItem>
                                <asp:ListItem>Honda</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="MakeDropDown" runat="server" ForeColor="White" ErrorMessage="* Required Field"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Model:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:TextBox ID="ModelTextBox" runat="server" Width="200px"></asp:TextBox><br />
                
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="MakeDropDown" runat="server" ForeColor="White" ErrorMessage="* Required Field"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Color:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:TextBox ID="ColorTextBox" runat="server" Width="200px"></asp:TextBox><br />
                
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ColorTextBox" runat="server" ForeColor="White" ErrorMessage="* Required Field"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Status:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="StatusLabel" runat="server" Text="Label" ForeColor="White"></asp:Label>
                            <br />
                
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
                
               <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click"></asp:Button>
                <br />
                <br />
                <asp:Label ID="WarningLabel" runat="server" Text="Label" Visible="false" ForeColor="White"></asp:Label>
            </center>
        </div>
    </form>
</body>
</html>
