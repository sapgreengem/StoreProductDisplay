<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="StoreProductDisplay.SearchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

    <h3>Search Result</h3>
    <asp:Label ID="Label1" runat="server"></asp:Label>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" BorderStyle="None" CellPadding="10" >
        <Columns>
            <asp:ImageField DataImageUrlField="Product_Picture">
                <ControlStyle Height="200px"/>
            </asp:ImageField>
            <asp:BoundField DataField="Product_Name" SortExpression="Product_Name" />
            <asp:BoundField DataField="Product_Price" SortExpression="Product_Price" DataFormatString="{0} Tk"/>
            <asp:HyperLinkField DataNavigateUrlFields="Product_ID" DataNavigateUrlFormatString="ViewProductDetails.aspx?product_id={0}" Text="Details" />
        </Columns>
    </asp:GridView>

</asp:Content>
