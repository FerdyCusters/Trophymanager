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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInloggen_Click(Object sender, EventArgs e)
        {
            tbInlognaam.Text = "Frits";
        }
    }
}