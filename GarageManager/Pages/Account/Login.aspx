<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GarageManager.Pages.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Log In</h4>
    <hr />
    <asp:Literal runat="server" ID="litErrorMsg" Text="Invalid username or password." Visible="false" />
    <asp:Label runat="server" AssociatedControlID="txtUserName">User name</asp:Label>
    <br />
    <asp:TextBox runat="server" ID="txtUserName" CssClass="inputs" />
    <br />
    <asp:Label runat="server" AssociatedControlID="txtPassword">Password</asp:Label>
    <br />
    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="inputs" />
    <br />
    <asp:Button ID="btnSignIn" runat="server" Text="Log in" OnClick="btnSignIn_OnClick" CssClass="button" />
</asp:Content>
