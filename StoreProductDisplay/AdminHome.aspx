<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="StoreProductDisplay.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; width: auto; height:auto;">
        <div style="margin-left:150px; margin-right:150px; width:auto;">
            <%foreach (StoreProductDisplay.adminImgArray objp in myCollection)
                {%>
                    <div style="height:250px; width:200px; float:left; text-align:center;">
                        <img src="<%Response.Write(objp.Product_Picture);%>" style="height:70%;" />
                        <br/>
                        <label><%Response.Write(objp.Product_Name);%></label>
                        <br/>
                        <label><%Response.Write(objp.Product_Price+" TK");%></label>
                    </div>
                <%}
                    myCollection.Clear();
            %>
        </div>
    </div>
</asp:Content>
