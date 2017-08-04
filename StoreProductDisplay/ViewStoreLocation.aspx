<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewStoreLocation.aspx.cs" Inherits="StoreProductDisplay.ViewStoreLocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div>
        <%foreach (StoreProductDisplay.storeImg objStr in myStorCollection)
            {%>
                <table>
                    <tr>
                        <td>
                            <div style="height:220px; width:320px">
                                <img src="<%Response.Write(objStr.Store_Image);%>" style="height:80%" />
                            </div>
                        </td>
                        <td style="vertical-align:top">
                            <label>Branch Address: <%Response.Write(objStr.Store_Address);%></label>
                            <br/>
                            <label>City: <%Response.Write(objStr.Store_Location);%></label>
                            <br/>
                            <label>Contact No: <%Response.Write(objStr.Contact_No);%></label>
                        </td>
                    </tr>
                </table>
            <%}
                myStorCollection.Clear();
        %>
    </div>
</asp:Content>
