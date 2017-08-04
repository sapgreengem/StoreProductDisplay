<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddEditCategory.aspx.cs" Inherits="StoreProductDisplay.AddEditCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 119px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Add new category of product</h3>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Category ID:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCategoryID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Category Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCategoryName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="BtnAddCategory" runat="server" Text="Add Category" OnClick="BtnAddCategory_Click" />

        <h3>Category List</h3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Category_ID" DataSourceID="SqlDataSource1" CellPadding="10" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Category_ID" HeaderText="Category_ID" ReadOnly="True" SortExpression="Category_ID" />
                <asp:BoundField DataField="Category_Name" HeaderText="Category_Name" SortExpression="Category_Name" />
                <asp:CommandField HeaderText="Options" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" DeleteCommand="DELETE FROM [ProductCategory] WHERE [Category_ID] = @Category_ID" InsertCommand="INSERT INTO [ProductCategory] ([Category_ID], [Category_Name]) VALUES (@Category_ID, @Category_Name)" SelectCommand="SELECT * FROM [ProductCategory]" UpdateCommand="UPDATE [ProductCategory] SET [Category_Name] = @Category_Name WHERE [Category_ID] = @Category_ID">
            <DeleteParameters>
                <asp:Parameter Name="Category_ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Category_ID" Type="Int32" />
                <asp:Parameter Name="Category_Name" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Category_Name" Type="String" />
                <asp:Parameter Name="Category_ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>

    </asp:Content>
