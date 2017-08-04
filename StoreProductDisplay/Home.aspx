<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="StoreProductDisplay.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div style="text-align: center; width: auto; height:auto">
        <div style="margin-left:15px; float:left; text-align:left ;width: 170px; ">
            <h4>Filter Data</h4>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownListProductCategory1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListProductCategory1_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Price Range"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="45px"></asp:TextBox>
            To
            <asp:TextBox ID="TextBox2" runat="server" Width="45px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Go" OnClick="Button1_Click"/>

        </div>
        <div style="margin-left:200px; margin-right:100px; width:auto;">
            <%foreach (StoreProductDisplay.imgArray objp in myCollection)
                {%>
                    <div style=" height:320px; width:250px; float:left; text-align:center; ">
                        <img src="<%Response.Write(objp.Product_Picture);%>" style="height:70%;" />
                        <br/>
                        <label><%Response.Write(objp.Product_Name);%></label>
                        <br/>
                        <label><%Response.Write(objp.Product_Price+" TK");%></label>
                        <br/>
                        <a href="ViewProductDetails.aspx?product_id=<%= objp.Product_ID %>">View Details</a>
                    </div>
                <%}
                    myCollection.Clear();
            %>
        </div>
    </div>
</asp:Content>
