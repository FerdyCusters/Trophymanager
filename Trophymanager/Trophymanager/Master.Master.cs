using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trophymanager
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private string path;
        protected void Page_Load(object sender, EventArgs e)
        {
            path = HttpContext.Current.Request.Url.AbsolutePath;
        }

        protected void btnTeam_Click(object sender, EventArgs e)
        {
            if (path != "/Pages/Teampagina.aspx")
            {
                Session["Counter"] = 0;
                Server.Transfer("Teampagina.aspx", true);
            }
        }
        protected void btnCompetitie_Click(object sender, EventArgs e)
        {
            if(path != "/Pages/Competitiepagina.aspx")
            {
                Session["Counter"] = 0;
                Server.Transfer("Competitiepagina.aspx", true);
            }
        }
        protected void btnWedstrijd_Click(object sender, EventArgs e)
        {
            if (path != "/Pages/Wedstrijdpagina.aspx")
            {
                Session["Counter"] = 0;
                Server.Transfer("Wedstrijdpagina.aspx", true);
            }
        }
        protected void btnLogUit_Click(object sender, EventArgs e)
        {
            Session["Counter"] = 0;
            Server.Transfer("Inlogscherm.aspx", true);
        }
    }
}