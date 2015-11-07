<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="UI.Web.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="panelPrincipal" runat="server" CssClass="body">
        <asp:LinkButton ID="usuarioLinkButton" runat="server">Usuarios </asp:LinkButton>        
    </asp:Panel>
</asp:Content>

