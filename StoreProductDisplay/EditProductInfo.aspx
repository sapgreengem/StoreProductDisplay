<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="EditProductInfo.aspx.cs" Inherits="StoreProductDisplay.EditProductInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:auto; text-align:center;">
        <h3 style="text-align:left;">List Of All Available Products</h3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Product_ID" DataSourceID="SqlDataSource1" CellPadding="10" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Product_ID" HeaderText="ID" ReadOnly="True" SortExpression="Product_ID" />
                <asp:BoundField DataField="Product_Name" HeaderText="Name" SortExpression="Product_Name" />
                <asp:BoundField DataField="Product_Code" HeaderText="Code" SortExpression="Product_Code" />
                <asp:BoundField DataField="Product_Size" HeaderText="Size" SortExpression="Product_Size" />
                <asp:BoundField DataField="Product_Color" HeaderText="Color" SortExpression="Product_Color" />
                <asp:BoundField DataField="Product_Price" HeaderText="Price" SortExpression="Product_Price" />
                <asp:ImageField DataImageUrlField="Product_Picture" HeaderText="Img">
                    <ControlStyle Height="80px" Width="60px"></ControlStyle>
                </asp:ImageField>
                <asp:CommandField HeaderText="Options" ShowDeleteButton="True" ShowEditButton="True" />
                <asp:HyperLinkField HeaderText="Change_Image" NavigateUrl="~/ChangeProductImage.aspx" Text="Change Image" DataNavigateUrlFields="Product_ID" DataNavigateUrlFormatString="ChangeProductImage.aspx?id={0}" />
            </Columns>
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" DeleteCommand="DELETE FROM [ProductDetails] WHERE [Product_ID] = @Product_ID" InsertCommand="INSERT INTO [ProductDetails] ([Product_ID], [Product_Name], [Product_Code], [Product_Size], [Product_Color], [Product_Price], [Product_Picture]) VALUES (@Product_ID, @Product_Name, @Product_Code, @Product_Size, @Product_Color, @Product_Price, @Product_Picture)" SelectCommand="SELECT [Product_ID], [Product_Name], [Product_Code], [Product_Size], [Product_Color], [Product_Price], [Product_Picture] FROM [ProductDetails]" UpdateCommand="UPDATE [ProductDetails] SET [Product_Name] = @Product_Name, [Product_Code] = @Product_Code, [Product_Size] = @Product_Size, [Product_Color] = @Product_Color, [Product_Price] = @Product_Price, [Product_Picture] = @Product_Picture WHERE [Product_ID] = @Product_ID">
            <DeleteParameters>
                <asp:Parameter Name="Product_ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Product_ID" Type="Int32" />
                <asp:Parameter Name="Product_Name" Type="String" />
                <asp:Parameter Name="Product_Code" Type="String" />
                <asp:Parameter Name="Product_Size" Type="String" />
                <asp:Parameter Name="Product_Color" Type="String" />
                <asp:Parameter Name="Product_Price" Type="Double" />
                <asp:Parameter Name="Product_Picture" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Product_Name" Type="String" />
                <asp:Parameter Name="Product_Code" Type="String" />
                <asp:Parameter Name="Product_Size" Type="String" />
                <asp:Parameter Name="Product_Color" Type="String" />
                <asp:Parameter Name="Product_Price" Type="Double" />
                <asp:Parameter Name="Product_Picture" Type="String" />
                <asp:Parameter Name="Product_ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
