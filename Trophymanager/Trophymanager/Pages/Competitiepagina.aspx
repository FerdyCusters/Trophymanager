<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Competitiepagina.aspx.cs" Inherits="Trophymanager.Pages.Competitiepagina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ListBox ID="lbStand" runat="server" Width="600" Height="800" />
    <asp:Button ID="btnGaTerug" Text="Ga terug" runat="server" OnClick="btnGaTerug_Click" />
    </div>
    </form>
</body>
</html>
