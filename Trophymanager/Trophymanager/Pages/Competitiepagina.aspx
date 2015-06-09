<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Competitiepagina.aspx.cs" Inherits="Trophymanager.Pages.Competitiepagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Competitiepagina
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:ListBox ID="lbStand" runat="server" Width="600" Height="400" />
    </div>
</asp:Content>
