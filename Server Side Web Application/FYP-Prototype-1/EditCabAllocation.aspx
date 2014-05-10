<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditCabAllocation.aspx.cs" Inherits="EditCabAllocation" %>

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

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="500px">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>

                
                <br />
                <br />

                
                <table>
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Select Cab" ForeColor="White"></asp:Label></td><td><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Select Driver" ForeColor="White"></asp:Label></td><td><asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList></td>
                    </tr>
                </table>
               <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" style="height: 26px"></asp:Button>
                <br />
                <br />
                <asp:Label ID="WarningLabel" runat="server" Text="Label" Visible="false" ForeColor="White"></asp:Label>
            </center>
        </div>
    </form>
</body>
</html>
