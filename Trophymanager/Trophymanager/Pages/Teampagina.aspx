<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Teampagina.aspx.cs" Inherits="Trophymanager.Pages.Teampagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="t_Selectie">
        <h2>Selectie</h2>
    </div>
    <div id="t_Opstelling">
        <h2>Opstelling</h2>
    </div>
    <div id="lb_Selectie">
        <asp:ListBox ID="lbSelectie" autopostback="true" runat="server" Width="350" Height="350" />
    </div>
    <div id="btn_Rechts">
        <asp:Button ID="btnRechts" Text=">>" runat="server" OnClick="BtnRechts_Click" />
    </div>
    <div id="btn_Links">
        <asp:Button ID="btnLinks" Text="<<" runat="server" OnClick="BtnLinks_Click" />
    </div>
    <div id="lb_Opstelling">
        <asp:ListBox ID="lbOpstelling" autopostback="true" runat="server" Width="350" Height="350" />
    </div>
    <div id="lb_Statestiek">
        <asp:ListBox ID="lbStatestiek" runat="server" Width="350" Height="250"/>
    </div>
    <div id="btn_Train">
        <asp:Button ID="btnTrain" runat="server" Text="Trainen" OnClick="BtnTrain_Click" />
    </div>
</asp:Content>
