<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Wedstrijdpagina.aspx.cs" Inherits="Trophymanager.Pages.Wedstrijdpagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:ListBox ID="lbTeams" runat="server" Height="200" Width="300" />
    <asp:ListBox ID="lbWedstrijden" runat="server" Height="200" Width="500" />
    <asp:Button ID="btnSpeelWedstrijd" Text="Speel!" runat="server" OnClick="BtnSpeelWedstrijd_Click" />
    </div>
</asp:Content>
