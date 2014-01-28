<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menutest.aspx.cs" Inherits="FYP_Prototype_1.Menutest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div id="menu">
            <asp:TreeView ID="SampleTreeView" runat="server" Width="209px" Height="114px" style="margin-top: 5px">
                <Nodes>
                    <asp:TreeNode Value="Deals" Text="Deals" 
                    Target="Content" Expanded="True">
                        <asp:TreeNode  Value="Exclusive dilevery meal" Text="Exclusive dilevery meal" NavigateUrl="~/Resume.aspx"  Target="Content"> </asp:TreeNode>
                          <asp:TreeNode Value="Big Break Fast" Text="Big Break Fast" Target="Content"> </asp:TreeNode>  
                          <asp:TreeNode Value="Happy Meal" Text="Happy Meal" Target="Content"> </asp:TreeNode>  
                           <asp:TreeNode Value="Snack Time" Text="Snack Time" Target="Content"> </asp:TreeNode>   
                              <asp:TreeNode Value="The Big Catch" Text="The Big Catch" Target="Content"> </asp:TreeNode> 
                         </asp:TreeNode>
                        <asp:TreeNode Value="Ice creams" Text="Ice creams" Target="Content">
                        <asp:TreeNode Value="Mc Swirl" Text="Mc Swirl" Target="Content"> </asp:TreeNode>
                          <asp:TreeNode Value="Mc Float" Text="Mc Float" Target="Content"> </asp:TreeNode>  
                             <asp:TreeNode Value="Caremal Shake" Text="Caremal Shake" Target="Content"> </asp:TreeNode>  
                            <asp:TreeNode Value="Cofee" Text="Cofee" Target="Content"> </asp:TreeNode>  
                    </asp:TreeNode>

                     <asp:TreeNode Value="Location Details" Text="Location Details" Target="Content">
                        </asp:TreeNode>
                    
                    <asp:TreeNode Value="Contact us" Text="Contact us" Target="Content">
                       
                    </asp:TreeNode>
                   
                  
                </Nodes>
            </asp:TreeView>
        </div>
    </div>
    </form>
</body>
</html>
