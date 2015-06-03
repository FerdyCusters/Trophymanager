<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inlogscherm.aspx.cs" Inherits="Trophymanager.Pages.Inlogscherm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link href="Inlogscherm.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <form id="Inlogscherm" runat="server">
            <div>
                INLOGGEN
                <asp:TextBox ID="tbInlognaam" runat="server" placeholder="Gebruikersnaam" />
                <asp:TextBox ID="tbWachtwoord" runat="server" placeholder="Wachtwoord" type="password" />        
                <asp:Button id="btnInloggen" Text="Inloggen" runat="server" OnClick="btnInloggen_Click" />
                REGISTREREN
                <asp:TextBox ID="tbUsername" runat="server" placeholder="Gebruikersnaam" />
                <asp:TextBox ID="tbPassword" runat="server" placeholder="Wachtwoord" type="password" />
                <asp:TextBox ID="tbClubnaam" runat="server" placeholder="Clubnaam" />
                <asp:TextBox ID="tbBijnaam" runat="server" placeholder="Bijnaam" />
                <asp:TextBox ID="tbClubKleuren" runat="server" placeholder="Clubkleuren" />          
                <asp:Button id="btnRegistreer" Text="Registreren" runat="server" OnClick="btnRegistreren_Click" />
            </div>
        </form>
    </body>
</html>
