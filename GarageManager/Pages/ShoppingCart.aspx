<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="GarageManager.Pages.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlShoppingCart" runat="server">
    </asp:Panel>
    <table>
        <tr>
            <td>
                <b>Total: </b>
            </td>
            <td>
                <asp:Literal ID="litTotal" runat="server" Text=""></asp:Literal>
            </td>
        </tr>

        <tr>
            <td>
                <b>Vat: </b>
            </td>
            <td>
                <asp:Literal ID="litVat" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Shipping: </b>
            </td>
            <td>£ 15
            </td>
        </tr>

        <tr>
            <td>
                <b>Total Amount: </b>
            </td>
            <td>
                <asp:Literal ID="litTotalAmount" runat="server" Text="" />
            </td>
        </tr>

        <tr>
            <td>
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Index.aspx">Continue Shopping</asp:LinkButton>
                &nbsp;&nbsp; or
                    <asp:Button ID="btnCheckout" runat="server" Text="Check Out" CssClass="button" Width="250px" PostBackUrl="~/Pages/Success.aspx" />

                <br />

                <asp:LinkButton ID="litPaypal" Text="" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>