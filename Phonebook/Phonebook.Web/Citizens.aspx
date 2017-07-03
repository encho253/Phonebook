<%@ Page Title="Citizens" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Citizens.aspx.cs"
    Inherits="Phonebook.Citizens" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="CitizensCollection" runat="server" ItemType="Phonebook.Models.Citizen" SelectMethod="CitizensCollection_GetData">
        <LayoutTemplate>
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th><a href="?id=FirstName">First Name</a></th>
                        <th>Last Name</th>
                        <th>Phone Number</th>
                        <th>City</th>
                        <th>Street</th>
                        <th>Street Number</th>
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