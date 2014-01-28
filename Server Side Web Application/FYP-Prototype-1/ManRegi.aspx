<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManRegi.aspx.cs" Inherits="FYP_Prototype_1.ManRegi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cab 9</title>
    <link type="text/css" rel="stylesheet" href="css/stylesheet.css" />
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
            
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" ForeColor="White" Text="Driver Registration"></asp:Label>
            
            <br />
            <br />
             <table>
                    <tr><td>
                        <asp:Label ID="Label7" runat="server" ForeColor="White" Text="Customer Name"></asp:Label>
                        </td><td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td></tr>
                    <tr><td>
                        <asp:Label ID="Label8" runat="server" ForeColor="White" Text="Phone Number"></asp:Label>
                        </td><td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td></tr>
                    <tr><td>
                        <asp:Label ID="Label9" runat="server" ForeColor="White" Text="Cab Requested to :"></asp:Label>
                        </td><td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td></tr>
                    <tr><td>
                        <asp:Label ID="Label10" runat="server" ForeColor="White" Text="Cab Requested from: "></asp:Label>
                        </td><td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td></tr>
                    <tr><td>
                        <asp:Label ID="Label11" runat="server" ForeColor="White" Text="Cab requested at"></asp:Label>
                        </td><td><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td></tr>
                    
                    <tr><td colspan="2"><center><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/buttons/s_button.png" OnClick="ImageButton1_Click"></asp:ImageButton></center></td></tr>
                </table>
        </center>
    </div>
        <br />
        
    </form>
</body>
</html>
