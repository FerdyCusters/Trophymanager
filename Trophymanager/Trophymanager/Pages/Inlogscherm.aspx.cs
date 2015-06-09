namespace Trophymanager.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Het inlogscherm. Op deze page worden inlog en registreer gegevens gechecked.
    /// </summary>
    public partial class Inlogscherm : System.Web.UI.Page
    {
        #region Fields

        /// <summary>
        /// Statische Gebruiker. Hierdoor kun je op élke pagina weten op welke gebruiker je ingelogd bent.
        /// </summary>
        public static Klassen.Club Gebruiker;

        /// <summary>
        /// Field club.
        /// </summary>
        private Klassen.Club club;

        #endregion

        #region pageload

        /// <summary>
        /// PageLoad van deze pagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.club = new Klassen.Club();
            Klassen.DBConnect.InitializeConnection();
        }
        #endregion

        #region Event Handlers

        /// <summary>
        /// Gebruiker logt in.
        /// </summary>
        protected void BtnInloggen_Click(object sender, EventArgs e)
        {
            if (this.club.CheckLogin(this.tbInlognaam.Text, this.tbWachtwoord.Text) == true)
            {
                Gebruiker = Klassen.DBConnect.GetClub(this.tbInlognaam.Text);
                Gebruiker.Competitie = Klassen.Club.Eredivisie;
                Gebruiker.Clubcode = Klassen.DBConnect.GetClubCode(Gebruiker);
                Server.Transfer("Teampagina.aspx", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Foutief Wachtwoord!');", true);
            }
        }

        /// <summary>
        /// Gebruiker registreert.
        /// </summary>
        protected void BtnRegistreren_Click(object sender, EventArgs e)
        {
            if (this.club.CheckRegistreer(this.tbUsername.Text, this.tbClubnaam.Text, this) == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Informatie goed ingevuld. Uw team is aangemaakt! Manage je team naar de top!');", true);
                Klassen.Club nieuweClub = new Klassen.Club(this.tbUsername.Text, this.tbPassword.Text, this.tbClubnaam.Text, this.tbBijnaam.Text, this.tbClubKleuren.Text);
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