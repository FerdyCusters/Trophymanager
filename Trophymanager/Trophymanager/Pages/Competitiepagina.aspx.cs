using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trophymanager.Pages
{
    public partial class Competitiepagina : System.Web.UI.Page
    {
        #region Fields
        List<Klassen.Club> clubs = new List<Klassen.Club>();
        #endregion

        #region Pageload
        /// <summary>
        /// Als de pagina wordt geladen worden de benodigde gegevens opgehaald en weergegeven op de pagina.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            clubs = Klassen.DBConnect.GetCTs();
            clubs.Sort();

            int counter = 1;

            foreach(Klassen.Club c in clubs.ToArray())
            {
                lbStand.Items.Add(counter + ".   " + c.ToString());
                counter++;
            }
        }
        #endregion

        #region Eventhandlers
        protected void btnGaTerug_Click(object sender, EventArgs e)
        {
            Server.Transfer("Homepage.aspx", true);
        }
        #endregion
    }
}