<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="FYP_Prototype_1.Review" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="css/stylesheet.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <br />
            <br />
            <br />
            <br />

            <asp:Label ID="Label1" runat="server" Text="Approve or Reject?" Font-Size="Large" ForeColor="White"></asp:Label>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <dx:ASPxButton ID="YesButton" runat="server" Text="Approve" Theme="BlackGlass" Width="150px" Height="50px" OnClick="YesButton_Click"></dx:ASPxButton>
                    </td>
                    &nbsp
                    &nbsp
                    &nbsp
                    <td>
                        
                         <dx:ASPxButton ID="noButton" runat="server" Text="Reject" Theme="BlackGlass" Width="150px" Height="50px" OnClick="noButton_Click"></dx:ASPxButton>
                    </td>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="DONE!" Visible="false" ForeColor="White"></asp:Label>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
