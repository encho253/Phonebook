<%@ Page Title="Citizens" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Citizens.aspx.cs"
    Inherits="Phonebook.Citizens" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="Test" runat="server" ItemType="Phonebook.Models.Citizen">
        <LayoutTemplate>
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>First Name</th>
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