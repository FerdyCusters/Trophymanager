using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trophymanager.Pages
{
    public partial class Inlogscherm : System.Web.UI.Page
    {
        #region Fields
        Klassen.Club club;
        public static Klassen.Club Gebruiker;
        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            club = new Klassen.Club();
            Klassen.DBConnect.InitializeConnection();
        }
        #endregion

        #region Event Handlers

        /// <summary>
        /// Gebruiker logt in.
        /// </summary>
        protected void btnInloggen_Click(Object sender, EventArgs e)
        {
            if (club.CheckLogin(tbInlognaam.Text, tbWachtwoord.Text) == true)
            {
                Gebruiker = Klassen.DBConnect.GetClub(tbInlognaam.Text);
                Gebruiker.Clubcode = Klassen.DBConnect.GetClubCode(Gebruiker);
                Server.Transfer("Homepage.aspx", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Foutief Wachtwoord!');", true);
            }
        }

        /// <summary>
        /// Gebruiker registreert.
        /// </summary>
        protected void btnRegistreren_Click(Object sender, EventArgs e)
        {
            if (club.CheckRegistreer(tbUsername.Text, tbClubnaam.Text, this) == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Informatie goed ingevuld. Uw team is aangemaakt! Manage je team naar de top!');", true);
                Klassen.Club nieuweClub = new Klassen.Club(tbUsername.Text, tbPassword.Text, tbClubnaam.Text, tbBijnaam.Text, tbClubKleuren.Text);
                nieuweClub.VoegToeAanSysteem();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Verkeerde informatie ingevuld!');", true);
            }
        }
        #endregion
    }
}