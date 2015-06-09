namespace Trophymanager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// De Master page.
    /// </summary>
    public partial class Master : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Field om te weten op welke pagina je je bevindt
        /// </summary>
        private string path;

        /// <summary>
        /// De PageLoad van Masterpage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.path = HttpContext.Current.Request.Url.AbsolutePath;
        }

        /// <summary>
        /// Event handler van btnTeam. Site gaat zo niet vasthangen als je al op dezelfde pagina bent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnTeam_Click(object sender, EventArgs e)
        {
            if (this.path != "/Pages/Teampagina.aspx")
            {
                this.Session["Counter"] = 0;
                Server.Transfer("Teampagina.aspx", true);
            }
        }

        /// <summary>
        /// Event handler van btnCompetitie. Site gaat zo niet vasthangen als je al op dezelfde pagina bent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCompetitie_Click(object sender, EventArgs e)
        {
            if (this.path != "/Pages/Competitiepagina.aspx")
            {
                this.Session["Counter"] = 0;
                Server.Transfer("Competitiepagina.aspx", true);
            }
        }

        /// <summary>
        /// Event handler van btnWedstrijd. Site gaat zo niet vasthangen als je al op dezelfde pagina bent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnWedstrijd_Click(object sender, EventArgs e)
        {
            if (this.path != "/Pages/Wedstrijdpagina.aspx")
            {
                this.Session["Counter"] = 0;
                Server.Transfer("Wedstrijdpagina.aspx", true);
            }
        }

        /// <summary>
        /// Event handler van btnLogUit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLogUit_Click(object sender, EventArgs e)
        {
            this.Session["Counter"] = 0;
            Server.Transfer("Inlogscherm.aspx", true);
        }
    }
}