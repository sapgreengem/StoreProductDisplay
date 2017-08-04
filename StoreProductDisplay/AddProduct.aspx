<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="StoreProductDisplay.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
    <style type="text/css">
    .auto-style1 {
        width: 179px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Add New Product</h3>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label9" runat="server" Text="Product ID: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxProductId" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Product Name: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxProductName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Product Code: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxProductCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Product Category: "></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:DropDownList ID="DropDownListProductCategory" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Product Size: "></asp:Label>
                </td>
                <td>
                    <asp:CheckBoxList ID="CheckBoxListProductSize" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>S</asp:ListItem>
                        <asp:ListItem>M</asp:ListItem>
                        <asp:ListItem>L</asp:ListItem>
                        <asp:ListItem>XL</asp:ListItem>
                        <asp:ListItem>XXL</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label8" runat="server" Text="Product Color: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxProductColor" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label5" runat="server" Text="Product Price: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxProductPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label7" runat="server" Text="Select Product Image: "></asp:Label>
                </td>
                <td>
                    <div style="height:150px; width:100px">
                        <asp:Image ID="Image1" runat="server" Height="80%" />
                    </div>
                    <br />
                    <asp:FileUpload ID="FileUploadImage" runat="server" onchange="ShowImagePreview(this);" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="BtnAddProduct" runat="server" Text="Add Product" OnClick="BtnAddProduct_Click" />
    </div>
</asp:Content>
