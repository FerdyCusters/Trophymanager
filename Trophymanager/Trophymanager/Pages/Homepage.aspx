<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Trophymanager.Pages.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link href="Inlogscherm.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <form id="Inlogscherm" runat="server">
            <div>
                <asp:TextBox ID="tbInlognaam" runat="server" placeholder="Gebruikersnaam" />
                <asp:TextBox ID="tbWachtwoord" runat="server" placeholder="Wachtwoord" type="password" />        
                <asp:Button id="btnInloggen" Text="Inloggen" runat="server" />
            </div>
        </form>
    </body>
</html>
