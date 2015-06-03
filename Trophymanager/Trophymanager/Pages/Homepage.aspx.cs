using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trophymanager.Pages
{
    public partial class Homepage : System.Web.UI.Page
    {
        #region Fields

    #endregion

        #region Pageload
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Event handlers
        protected void btnTeam_Click(object sender, EventArgs e)
        {
            Server.Transfer("Teampagina.aspx", true);
        }

        protected void btnCompetitie_Click(object sender, EventArgs e)
        {
            Server.Transfer("Competitiepagina.aspx", true);
        }

        protected void btnWedstrijd_Click(object sender, EventArgs e)
        {
            Server.Transfer("Wedstrijdpagina.aspx", true);
        }

        protected void btnLogUit_Click(object sender, EventArgs e)
        {
            Server.Transfer("Inlogscherm.aspx", true);
        }
        #endregion
    }
}