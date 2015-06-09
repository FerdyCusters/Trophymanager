namespace Trophymanager.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Trophymanager.Klassen;

    /// <summary>
    /// De wedstrijdpagina. Hier worden wedstrijden gespeeld en weergegeven.
    /// </summary>
    public partial class Wedstrijdpagina : System.Web.UI.Page
    {
        #region Fields

        /// <summary>
        /// Lijst met clubs
        /// </summary>
        private List<Club> clubs = new List<Club>();

        #endregion

        #region Pageload

        /// <summary>
        /// Page Load van de Wedstrijdpagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.clubs = DBConnect.GetClubs();

            // Deze methode wordt alleen maar de eerste keer uitgevoerd als de pagina in page_load komt.           
            if (Convert.ToInt32(Master.Session["Counter"]) < 1)
            {
                this.Reload(true);
                Master.Session["Counter"] = 1;
            }

            this.Reload(false);
        }
        #endregion

        #region Eventhandlers

        /// <summary>
        /// In deze methode wordt ervoor gezorgd dat er een wedstrijd wordt gespeeld.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSpeelWedstrijd_Click(object sender, EventArgs e)
        {
            if (this.lbTeams.SelectedItem != null)
            {
                foreach (Club a in this.clubs)
                {
                    if (a.Clubnaam == this.lbTeams.SelectedItem.ToString())
                    {
                        Inlogscherm.Gebruiker.Competitie.SpeelWedstrijd(Inlogscherm.Gebruiker, a);
                    }
                }
            }

            this.Reload(false);
        }

        /// <summary>
        /// Velden worden gerefreshed
        /// </summary>
        protected void Reload(bool check)
        {
            if (check == true)
            {
                foreach (Club c in this.clubs)
                {
                    if (c.Clubnaam != Inlogscherm.Gebruiker.Clubnaam)
                    {
                        this.lbTeams.Items.Add(c.Clubnaam);
                    }
                }
            }

            this.lbWedstrijden.Items.Clear();
            List<Wedstrijd> wedstrijden = DBConnect.GetWedstrijden();
            foreach (Wedstrijd w in wedstrijden)
            {
                if (w.ClubCodeThuisTeam == Inlogscherm.Gebruiker.Clubcode || w.ClubCodeUitTeam == Inlogscherm.Gebruiker.Clubcode)
                {
                    List<Club> clubs = DBConnect.GetClubs();
                    foreach (Club c in clubs)
                    {
                        c.Clubcode = DBConnect.GetClubCode(c);
                        if (c.Clubcode == w.ClubCodeThuisTeam)
                        {
                            w.ThuisTeam = c;
                        }

                        if (c.Clubcode == w.ClubCodeUitTeam)
                        {
                            w.UitTeam = c;
                        }
                    }

                    this.lbWedstrijden.Items.Add(w.ToString());
                }
            }
        }
        #endregion
    }
}