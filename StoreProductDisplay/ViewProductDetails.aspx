<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewProductDetails.aspx.cs" Inherits="StoreProductDisplay.ViewProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 116px;
            vertical-align:top;
        }
    .auto-style2 {
        width: 131px;
        vertical-align: top;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <div style="height: 400px; width: 300px;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="#" Height="75%" />
                    </div>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Product Name:"></asp:Label> 
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Size:"></asp:Label> 
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Color:"></asp:Label> 
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Price:"></asp:Label> 
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Product Category:"></asp:Label> 
                </td>
                <td class="auto-style1">
                    <asp:Label ID="LabelName" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LabelSize" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LabelColor" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="LabelPrice" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="CategoryNameLabel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
