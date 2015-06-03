using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trophymanager.Pages
{
    public partial class Wedstrijdpagina : System.Web.UI.Page
    {
        #region Fields
        #endregion

        #region Pageload
        protected void Page_Load(object sender, EventArgs e)
        {

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