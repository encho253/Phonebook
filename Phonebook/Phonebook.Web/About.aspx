<%@ Page Title="About" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="About.aspx.cs"
    Inherits="Phonebook.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="Test" runat="server" ItemType="Phonebook.Models.Citizen">
        <LayoutTemplate>
            <h3>Citizens</h3>
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Username</th>
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
                <th scope="row">1</th>
                <td><%#: Item.FirstName %></td>
                <td><%#: Item.LastName %></td>
                <td>@mdo</td>
            </tr>
        </ItemTemplate>

    </asp:ListView>
</asp:Content>
