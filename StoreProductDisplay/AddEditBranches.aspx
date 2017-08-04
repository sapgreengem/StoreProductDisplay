<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddEditBranches.aspx.cs" Inherits="StoreProductDisplay.AddEditBranches" %>
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
            width: 181px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Add New Store/Branch Location and Contact Info</h3>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Store ID:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxStoreId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Store Location:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListStoreLocation" runat="server">
                        <asp:ListItem Value="NULL">Select One</asp:ListItem>
                        <asp:ListItem>Dhaka</asp:ListItem>
                        <asp:ListItem>Chittagong</asp:ListItem>
                        <asp:ListItem>Khulna</asp:ListItem>
                        <asp:ListItem>Rajshahi</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Store Address:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxStoreAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Contact No:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxStoreContactNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Select Store Image:</td>
                <td>
                    <div style="height:150px; width:200px">
                        <asp:Image ID="Image1" runat="server" Height="70%"/>
                    </div>
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="ShowImagePreview(this);"/>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="BtnAddStore" runat="server" Text="Add New Store" OnClick="BtnAddStore_Click" />
        <br />
        <br />
        <h3>List Of Store Informations</h3>
        <asp:GridView ID="GridViewStoreLocation" runat="server" AutoGenerateColumns="False" DataKeyNames="Store_ID" DataSourceID="SqlDataSource1" CellPadding="10" OnRowDeleting="GridViewStoreLocation_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Store_ID" HeaderText="ID" ReadOnly="True" SortExpression="Store_ID" />
                <asp:BoundField DataField="Store_Location" HeaderText="Location" SortExpression="Store_Location" />
                <asp:BoundField DataField="Store_Address" HeaderText="Address" SortExpression="Store_Address" />
                <asp:BoundField DataField="Contact_No" HeaderText="Contact No" SortExpression="Contact_No" />
                <asp:ImageField DataImageUrlField="Store_Image" HeaderText="Preview">
                    <ControlStyle Height="50px" Width="70px"/>
                </asp:ImageField>
                <asp:CommandField HeaderText="Options" ShowDeleteButton="True" ShowEditButton="True" />
                <asp:HyperLinkField HeaderText="Change Image" Text="Change Image" DataNavigateUrlFields="Store_ID" DataNavigateUrlFormatString="ChangeStoreImage.aspx?id={0}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" DeleteCommand="DELETE FROM [StoreAddress] WHERE [Store_ID] = @Store_ID" InsertCommand="INSERT INTO [StoreAddress] ([Store_ID], [Store_Location], [Store_Address], [Contact_No], [Store_Image]) VALUES (@Store_ID, @Store_Location, @Store_Address, @Contact_No, @Store_Image)" SelectCommand="SELECT * FROM [StoreAddress]" UpdateCommand="UPDATE [StoreAddress] SET [Store_Location] = @Store_Location, [Store_Address] = @Store_Address, [Contact_No] = @Contact_No, [Store_Image] = @Store_Image WHERE [Store_ID] = @Store_ID">
            <DeleteParameters>
                <asp:Parameter Name="Store_ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Store_ID" Type="Int32" />
                <asp:Parameter Name="Store_Location" Type="String" />
                <asp:Parameter Name="Store_Address" Type="String" />
                <asp:Parameter Name="Contact_No" Type="String" />
                <asp:Parameter Name="Store_Image" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Store_Location" Type="String" />
                <asp:Parameter Name="Store_Address" Type="String" />
                <asp:Parameter Name="Contact_No" Type="String" />
                <asp:Parameter Name="Store_Image" Type="String" />
                <asp:Parameter Name="Store_ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
