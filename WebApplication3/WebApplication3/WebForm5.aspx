<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="WebApplication3.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 1059px">
            <br />
            <asp:Label ID="Label6" runat="server" Text="Today's Orders:"></asp:Label>
            <br />
             <asp:ListView ID="T_Order" runat="server" GroupPlaceholderID="groupPlaceHolder2" ItemPlaceholderID="itemPlaceHolder2">
<LayoutTemplate>
    <table>
        <tr>
            <th>
                Customer#
            </th>
            <th>
                Order Type
            </th>
            <th>
                Status
            </th>
            <th>
                Bill
            </th>
        </tr>
        <asp:PlaceHolder runat="server" ID="groupPlaceHolder2"></asp:PlaceHolder>
        <tr>
            <td colspan = "3">
                <asp:DataPager ID="DataPager2" runat="server" PagedControlID="T_Order" PageSize="10">
                   
                </asp:DataPager>
            </td>
        </tr>
    </table>
</LayoutTemplate>
<GroupTemplate>
    <tr>
        <asp:PlaceHolder runat="server" ID="itemPlaceHolder2"></asp:PlaceHolder>
    </tr>
</GroupTemplate>
<ItemTemplate>
    <td>
        <%# Eval("CustomerNumber") %>
    </td>
    <td>
        <%# Eval("OrderType") %>
    </td>
    <td>
        <%# Eval("Status") %>
    </td>
    <td>
        <%# Eval("TotalBill") %>
    </td>
</ItemTemplate>
</asp:ListView>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Yesterday's Orders:"></asp:Label>
             <br />
             <asp:ListView ID="Y_Order" runat="server" GroupPlaceholderID="groupPlaceHolder3" ItemPlaceholderID="itemPlaceHolder3">
<LayoutTemplate>
    <table>
        <tr>
            <th>
                Customer#
            </th>
            <th>
                Order Type
            </th>
            <th>
                Status
            </th>
            <th>
                Bill
            </th>
        </tr>
        <asp:PlaceHolder runat="server" ID="groupPlaceHolder3"></asp:PlaceHolder>
        <tr>
            <td colspan = "3">
                <asp:DataPager ID="DataPager3" runat="server" PagedControlID="Y_Order" PageSize="10">
                   
                </asp:DataPager>
            </td>
        </tr>
    </table>
</LayoutTemplate>
<GroupTemplate>
    <tr>
        <asp:PlaceHolder runat="server" ID="itemPlaceHolder3"></asp:PlaceHolder>
    </tr>
</GroupTemplate>
<ItemTemplate>
    <td>
        <%# Eval("CustomerNumber") %>
    </td>
    <td>
        <%# Eval("OrderType") %>
    </td>
    <td>
        <%# Eval("Status") %>
    </td>
    <td>
        <%# Eval("TotalBill") %>
    </td>
</ItemTemplate>
</asp:ListView>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Total Orders in the Month:"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:ListView ID="lvCustomers" runat="server" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">
<LayoutTemplate>
    <table>
        <tr>
            <th>
                Item ID
            </th>
            <th>
                Item Name
            </th>
            <th>
                Price
            </th>
        </tr>
        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        <tr>
            <td colspan = "3">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvCustomers" PageSize="10">
                   
                </asp:DataPager>
            </td>
        </tr>
    </table>
</LayoutTemplate>
<GroupTemplate>
    <tr>
        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
    </tr>
</GroupTemplate>
<ItemTemplate>
    <td>
        <%# Eval("ID") %>
    </td>
    <td>
        <%# Eval("Item") %>
    </td>
    <td>
        <%# Eval("Price") %>
    </td>
</ItemTemplate>
</asp:ListView>
            <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Delete_Click" />
            <asp:Button ID="Button2" runat="server" Text="Add New Item" OnClick="Add_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Logout" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;<asp:Label ID="Label1" runat="server" Text="Enter ID:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Confirm" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Item Name:"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Category:"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="Label5" runat="server" Text="Type:"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click1" Text="Confirm" />
        </div>
    </form>
</body>
</html>
