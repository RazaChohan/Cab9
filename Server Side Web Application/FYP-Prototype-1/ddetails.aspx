<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ddetails.aspx.cs" Inherits="FYP_Prototype_1.ddetails" %>

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
        <div>
            <center>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/banner2.png"></asp:Image>
            </center>
        </div>
        <br />
    <div id="page">
        <center>
           <asp:Label ID="Label1" runat="server" Text="Driver Details" ForeColor="White" Font-Size="XX-Large"></asp:Label>
            <br />
            <a href="drivers.aspx" style="text-decoration:none; font-size:large; color: #FFFFFF;">View All Drivers</a>
        </center>
    </div>
        <br />
        <div id="page">
            <center>
                <asp:Button ID="EditButton" runat="server" Text="Edit Driver Details" OnClick="EditButton_Click" Width="125px"></asp:Button>
                &nbsp&nbsp&nbsp&nbsp
                <asp:Button ID="DeleteDriverButton" runat="server" Text="Retire Driver" Width="125px" OnClick="DeleteDriverButton_Click"></asp:Button>
                <br />
                <asp:Label ID="DeleteWarningLabel" runat="server" Text="Label" ForeColor="White" Visible="false"></asp:Label>
                <br />
                <asp:Image ID="DriverImage" runat="server" ImageUrl="~/images/avatar.jpg" Height="250" Width="300px"></asp:Image><br /><br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Name:" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="NameLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Cab No.:" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="CabNoLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Password:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                             <asp:Label ID="PasswordLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Email ID:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="EmailLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Phone Number:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="PhoneNumberLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="NIC:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="NICLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Address:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="100px" Width="200px" ReadOnly="true"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Gender:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="GenderLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Age:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:Label ID="AgeLabel" runat="server" Text="Label" Font-Size="Large" ForeColor="White"></asp:Label><br />
                        </td>
                    </tr>
                </table>
                
               
            </center>
        </div>
    </form>
</body>
</html>
