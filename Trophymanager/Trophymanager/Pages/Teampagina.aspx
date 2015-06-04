<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teampagina.aspx.cs" Inherits="Trophymanager.Pages.Teampagina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    SELECTIE
    <asp:ListBox ID="lbSelectie" runat="server" Width="400" Height="500"/>
    <asp:Button ID="btnRechts" Text=">>" runat="server" OnClick="btnRechts_Click" />
    <asp:Button ID="btnLinks" Text="<<" runat="server" OnClick="btnLinks_Click" />
    OPSTELLING
    <asp:ListBox ID="lbOpstelling" runat="server" Width="400" Height="500"/>
    <asp:Button ID="btnGaTerug" Text="Ga terug" runat="server" OnClick="btnGaTerug_Click" />
    </div>
    </form>
</body>
</html>
