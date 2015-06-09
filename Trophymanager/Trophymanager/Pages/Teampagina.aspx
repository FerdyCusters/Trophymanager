<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Teampagina.aspx.cs" Inherits="Trophymanager.Pages.Teampagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Teampagina
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    SELECTIE
    <asp:ListBox ID="lbSelectie" autopostback="true" runat="server" Width="350" Height="350" />
    <asp:Button ID="btnRechts" Text=">>" runat="server" OnClick="btnRechts_Click" />
    <asp:Button ID="btnLinks" Text="<<" runat="server" OnClick="btnLinks_Click" />
    OPSTELLING
    <asp:ListBox ID="lbOpstelling" autopostback="true" Write="true" runat="server" Width="350" Height="350" />
    <asp:ListBox ID="lbStatestiek" runat="server" Width="350" Height="250"/>
    <asp:Button ID="btnTrain" runat="server" Text="Trainen" OnClick="btnTrain_Click" />
    </div>
</asp:Content>
