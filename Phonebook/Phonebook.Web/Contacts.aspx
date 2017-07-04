<%@ Page Title="Contacts" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Contacts.aspx.cs"
    Inherits="Phonebook.Citizens" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="CitizensCollection" runat="server" ItemType="Phonebook.Models.Citizen" SelectMethod="CitizensCollection_GetData">
        <LayoutTemplate>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th><a href="?id=FirstName">First Name</a></th>
                        <th><a href="?id=LastName">Last Name</a></th>
                        <th><a href="#">Phone Number</a></th>
                        <th><a href="?id=City">City</a></th>
                        <th><a href="?id=Street">Street</a></th>
                        <th><a href="#">Street Number</a></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                    <tr runat="server" id="itemPlaceholder">
                    </tr>
                </tbody>
            </table>
          <%--  <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>--%>
        </LayoutTemplate>

<%--        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>--%>

        <ItemTemplate>
            <tr runat="server">
                <td><%#: Item.FirstName %></td>
                <td><%#: Item.LastName %></td>
                <td><%#: Item.Phone.PhoneNumber %></td>
                <td><%#: Item.City.Name %></td>
                <td><%#: Item.Address.Street %></td>
                <td><%#: Item.Address.StreetNumber %></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>