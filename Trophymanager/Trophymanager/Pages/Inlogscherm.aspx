<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inlogscherm.aspx.cs" Inherits="Trophymanager.Pages.Inlogscherm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Trophymanager</title>
        <link href="../Site.css" rel="stylesheet" />
    </head>
    <body>
        <form id="Form1" runat="server">
            <div id="i_Inloggen_Balkje">
                <h1>
                     Inloggen
                </h1>
            </div>
                <div id="textbox1">
                    <asp:TextBox ID="tbInlognaam" runat="server" placeholder="Gebruikersnaam" />
                </div>
                <div id="textbox2">
                    <asp:TextBox ID="tbWachtwoord" runat="server" placeholder="Wachtwoord" type="password" />
                </div>
                <div id="button1">      
                    <asp:Button id="btnInloggen" Text="Inloggen" runat="server" OnClick="btnInloggen_Click" />
                </div>
            <div id ="i_Registreren_Balkje">
                <h1>
                    Registreren
                </h1>
            </div>
            <div id="i_Registreren">
                <div id="textbox3">
                    <asp:TextBox ID="tbUsername" runat="server" placeholder="Gebruikersnaam" />
                </div>
                <div id="textbox4">
                    <asp:TextBox ID="tbPassword" runat="server" placeholder="Wachtwoord" type="password" />
                </div>
                <div id="textbox5">
                    <asp:TextBox ID="tbClubnaam" runat="server" placeholder="Clubnaam" />
                </div>
                <div id="textbox6">
                    <asp:TextBox ID="tbBijnaam" runat="server" placeholder="Bijnaam" />
                </div>
                <div id="textbox7">
                    <asp:TextBox ID="tbClubKleuren" runat="server" placeholder="Clubkleuren" />  
                </div>
                <div id="button2">        
                    <asp:Button id="btnRegistreer" Text="Registreren" runat="server" OnClick="btnRegistreren_Click" />
                </div>
            </div>
        </form>
    </body>
</html>
