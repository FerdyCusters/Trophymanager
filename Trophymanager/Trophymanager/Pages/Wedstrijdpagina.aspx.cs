namespace Trophymanager.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Trophymanager.Klassen;
    public partial class Wedstrijdpagina : System.Web.UI.Page
    {

        #region Fields
        private List<Club> clubs = new List<Club>();
        #endregion

        #region Pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            clubs = DBConnect.GetClubs();

            // Deze methode wordt alleen maar de eerste keer uitgevoerd als de pagina in page_load komt.           
            if (Convert.ToInt32(Session["Counter"]) < 1)
            {
                Reload(true);
                Session["Counter"] = 1;
            }

            Reload(false);
        }
        #endregion

        #region Eventhandlers

        protected void btnSpeelWedstrijd_Click(object sender, EventArgs e)
        {
            if(lbTeams.SelectedItem != null)
            {
                foreach (Club a in clubs)
                {
                    if (a.Clubnaam == lbTeams.SelectedItem.ToString())
                    {
                        Inlogscherm.Gebruiker.Competitie.SpeelWedstrijd(Inlogscherm.Gebruiker, a);
                    }
                }
            }
            Reload(false);
        }

        /// <summary>
        /// Velden worden gerefreshed
        /// </summary>
        public void Reload(bool check)
        {
            if (check == true)
            {
                foreach (Club c in clubs)
                {
                    if (c.Clubnaam != Inlogscherm.Gebruiker.Clubnaam)
                    {
                        lbTeams.Items.Add(c.Clubnaam);
                    }
                }
            }

            lbWedstrijden.Items.Clear();
            List<Wedstrijd> wedstrijden = DBConnect.GetWedstrijden();
            foreach (Wedstrijd w in wedstrijden)
            {
                if (w.ClubCodeThuisTeam == Inlogscherm.Gebruiker.Clubcode || w.ClubCodeUitTeam == Inlogscherm.Gebruiker.Clubcode)
                {
                    List<Club> clubs = DBConnect.GetClubs();
                    foreach (Club c in clubs)
                    {
                        c.Clubcode = DBConnect.GetClubCode(c);
                        if(c.Clubcode == w.ClubCodeThuisTeam)
                        {
                            w.ThuisTeam = c;
                        }
                        if (c.Clubcode == w.ClubCodeUitTeam)
                        {
                            w.UitTeam = c;
                        }
                    }
                    lbWedstrijden.Items.Add(w.ToString());
                }
            }
        }
        #endregion
    }
}