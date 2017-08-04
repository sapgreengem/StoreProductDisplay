<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddNewAdmin.aspx.cs" Inherits="StoreProductDisplay.AddNewAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Add New Admin</h3>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxAdminName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="ComparePassword" runat="server" ErrorMessage="Password and Confirm Password do not Match" ForeColor="Red" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxConfirmPassword"></asp:CompareValidator>
                </td>
            </tr>
        </table>
        <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />
        <asp:Button ID="ButtonAddAdmin" runat="server" Text="Add New Admin" OnClick="ButtonAddAdmin_Click" />
        <br />
        <br />
        <h3>List of All Admins</h3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Admin_ID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Admin_ID" HeaderText="Admin_ID" InsertVisible="False" ReadOnly="True" SortExpression="Admin_ID" />
                <asp:BoundField DataField="User_Name" HeaderText="User_Name" SortExpression="User_Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Last_Login" HeaderText="Last_Login" SortExpression="Last_Login" />
                <asp:CommandField HeaderText="Options" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" DeleteCommand="DELETE FROM [AdminInfo] WHERE [Admin_ID] = @Admin_ID" InsertCommand="INSERT INTO [AdminInfo] ([User_Name], [Email], [Last_Login]) VALUES (@User_Name, @Email, @Last_Login)" SelectCommand="SELECT [Admin_ID], [User_Name], [Email], [Last_Login] FROM [AdminInfo]" UpdateCommand="UPDATE [AdminInfo] SET [User_Name] = @User_Name, [Email] = @Email, [Last_Login] = @Last_Login WHERE [Admin_ID] = @Admin_ID">
            <DeleteParameters>
                <asp:Parameter Name="Admin_ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="User_Name" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Last_Login" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="User_Name" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Last_Login" Type="DateTime" />
                <asp:Parameter Name="Admin_ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
