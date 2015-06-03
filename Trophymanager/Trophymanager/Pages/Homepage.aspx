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
                <asp:Button ID="btnTeampagina" Text="Team" runat="server" OnClick="btnTeam_Click" />
                <asp:Button ID="btnCompetitiepagina" Text="Competitie" runat="server" OnClick="btnCompetitie_Click" />        
                <asp:Button ID="btnWedstrijdpagina" Text="Wedstrijd" runat="server" OnClick="btnWedstrijd_Click" />
                <asp:Button ID="btnLogUit" Text="Log uit" runat="server" OnClick="btnLogUit_Click" />
            </div>
        </form>
    </body>
</html>
