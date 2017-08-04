<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ChangeProductImage.aspx.cs" Inherits="StoreProductDisplay.ChangeProductImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image2.ClientID%>').prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 390px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Change Image</h3>

    <table style="width: 100%; text-align: left;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label2" runat="server" Text="Previous Image"></asp:Label>

            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="New Image"></asp:Label>

            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <div style="height: 200px; width: 300px">
                    <asp:Image ID="Image1" runat="server" Height="100%" />
                </div>
            </td>
            <td>
                <div style="height: 200px; width: 300px">
                    <asp:Image ID="Image2" runat="server" Height="100%" />
                </div>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Select New Image: "></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" onchange="ShowImagePreview(this);" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
</asp:Content>
