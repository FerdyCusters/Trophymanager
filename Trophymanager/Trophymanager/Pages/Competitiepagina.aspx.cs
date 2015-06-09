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
    /// Competitiepagina page.
    /// </summary>
    public partial class Competitiepagina : System.Web.UI.Page
    {
        #region Fields

        /// <summary>
        /// Lijst met clubs
        /// </summary>
        private List<Klassen.Club> clubs = new List<Klassen.Club>();

        #endregion

        #region Pageload

        /// <summary>
        /// Als de pagina wordt geladen worden de benodigde gegevens opgehaald en weergegeven op de pagina.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Master.Session["Counter"]) < 1)
            {
                this.clubs = Klassen.DBConnect.GetCTs();
                this.clubs.Sort();
                int counter = 1;
                foreach (Klassen.Club c in this.clubs.ToArray())
                {
                    this.lbStand.Items.Add(counter + ".   " + c.ToString());
                    counter++;
                }
            }
        }
        #endregion

        #region Eventhandlers

        #endregion
    }
}