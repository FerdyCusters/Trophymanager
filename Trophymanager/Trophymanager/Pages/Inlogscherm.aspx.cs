﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trophymanager.Pages
{
    public partial class Inlogscherm : System.Web.UI.Page
    {
        Klassen.Club club;
        Klassen.Competitie eredivisie = new Klassen.Competitie("Eredivisie");
        Klassen.Competitie eersteDivisie = new Klassen.Competitie("Eerste Divisie");
        Klassen.Competitie tweedeDivisie = new Klassen.Competitie("Tweede Divisie");
        List<Klassen.Club> accounts = new List<Klassen.Club>();
        protected void Page_Load(object sender, EventArgs e)
        {
            club = new Klassen.Club();
        }

        protected void btnInloggen_Click(Object sender, EventArgs e)
        {
            if (club.CheckLogin(tbInlognaam.Text, tbWachtwoord.Text) == true)
            {
                Server.Transfer("Homepage.aspx", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Foutief Wachtwoord!');", true);
            }
        }

        protected void btnRegistreren_Click(Object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string clubnaam = tbClubnaam.Text;

            if (club.CheckRegistreer(tbUsername.Text, tbClubnaam.Text) == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Informatie goed ingevuld. Uw team is aangemaakt!');", true);
                Klassen.Club nieuweClub = new Klassen.Club(tbUsername.Text, tbPassword.Text, tbClubnaam.Text, tbBijnaam.Text, tbClubKleuren.Text);
                accounts.Add(nieuweClub);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Verkeerde informatie ingevuld!');", true);
            }
        }
    }
}