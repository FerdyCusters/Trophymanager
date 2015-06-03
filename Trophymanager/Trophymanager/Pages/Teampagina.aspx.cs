using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trophymanager.Pages
{
    public partial class Teampagina : System.Web.UI.Page
    {
        #region Fields
        List<Klassen.Keeper> keepers = new List<Klassen.Keeper>();
        List<Klassen.Veldspeler> veldspelers = new List<Klassen.Veldspeler>();
        List<Klassen.Keeper> opgesteldeKeepers = new List<Klassen.Keeper>();
        List<Klassen.Veldspeler> opgesteldeVeldspelers = new List<Klassen.Veldspeler>();
        private int index;
        private string code;
        #endregion

        #region Pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            keepers = Klassen.DBConnect.GetKeepers(Inlogscherm.Gebruiker);
            veldspelers = Klassen.DBConnect.GetVeldpspelers(Inlogscherm.Gebruiker);

            Reload();
        }
        #endregion

        #region Eventhandlers
        /// <summary>
        /// Er wordt terug gegaan naar de Homepage
        /// </summary>
        protected void btnGaTerug_Click(object sender, EventArgs e)
        {
            Server.Transfer("Homepage.aspx", true);
        }

        /// <summary>
        /// Speler wordt naar rechts verplaatst
        /// </summary>

        protected void btnRechts_Click(object sender, EventArgs e)
        {
            index = lbSelectie.SelectedItem.Text.IndexOf(" ");
            code = lbSelectie.SelectedItem.Text.Substring(0, index);
            if(keepers.Count > 0)
            {
                foreach(Klassen.Keeper k in keepers.ToArray())
                {
                    if(k.Spelercode == Convert.ToInt32(code))
                    {
                        keepers.Remove(k);
                        opgesteldeKeepers.Add(k);
                    }
                }
            if(veldspelers.Count > 0)
            {
                foreach (Klassen.Veldspeler v in veldspelers.ToArray())
                {
                    if (v.Spelercode == Convert.ToInt32(code))
                    {
                        veldspelers.Remove(v);
                        opgesteldeVeldspelers.Add(v);
                    }
                }
            }

            Reload();
            }

        }

        /// <summary>
        /// Speler wordt naar links verplaatst
        /// </summary>
        protected void btnLinks_Click(object sender, EventArgs e)
        {
            index = lbOpstelling.SelectedItem.Text.IndexOf(" ");
            code = lbOpstelling.SelectedItem.Text.Substring(0, index);
            if (opgesteldeKeepers.Count > 0)
            {
                foreach (Klassen.Keeper k in opgesteldeKeepers.ToArray())
                {
                    if (k.Spelercode == Convert.ToInt32(code))
                    {
                        opgesteldeKeepers.Remove(k);
                        keepers.Add(k);
                    }
                }
                if (opgesteldeVeldspelers.Count > 0)
                {
                    foreach (Klassen.Veldspeler v in opgesteldeVeldspelers.ToArray())
                    {
                        if (v.Spelercode == Convert.ToInt32(code))
                        {
                            opgesteldeVeldspelers.Remove(v);
                            veldspelers.Add(v);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Opstelling wordt opgeslagen
        /// </summary>
        protected void btnSlaOp_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Velden worden gereload
        /// </summary>
        public void Reload()
        {
            lbSelectie.Items.Clear();
            lbOpstelling.Items.Clear();
            index = 0;
            code = "";

            if(keepers.Count > 0)
            {
                foreach (Klassen.Keeper k in keepers)
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    lbSelectie.Items.Add(k.ToString());
                }
            }
            if (veldspelers.Count > 0)
            {
                foreach (Klassen.Veldspeler v in veldspelers)
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    lbSelectie.Items.Add(v.ToString());
                }
            }

            if(opgesteldeKeepers.Count > 0)
            {
                foreach(Klassen.Keeper k in opgesteldeKeepers)
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    lbOpstelling.Items.Add(k.ToString());
                }
            }

            if (opgesteldeVeldspelers.Count > 0)
            {
                foreach (Klassen.Veldspeler v in opgesteldeVeldspelers)
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    lbOpstelling.Items.Add(v.ToString());
                }
            }
        }
        #endregion
    }
}