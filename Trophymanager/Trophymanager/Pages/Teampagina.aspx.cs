using System;
using System.Collections.Generic;

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
            // Er wordt getest of er een speler is aangeklikt.
            if(lbSelectie.SelectedItem != null)
            {
                index = lbSelectie.SelectedItem.Text.IndexOf(" ");
                code = lbSelectie.SelectedItem.Text.Substring(0, index);
            }

            if(lbOpstelling.SelectedItem != null)
            {
                index = lbOpstelling.SelectedItem.Text.IndexOf(" ");
                code = lbOpstelling.SelectedItem.Text.Substring(0, index);
            }

            keepers = Klassen.DBConnect.GetKeepers(Inlogscherm.Gebruiker, "false");
            veldspelers = Klassen.DBConnect.GetVeldpspelers(Inlogscherm.Gebruiker, "false");
            opgesteldeKeepers = Klassen.DBConnect.GetKeepers(Inlogscherm.Gebruiker, "true");
            opgesteldeVeldspelers = Klassen.DBConnect.GetVeldpspelers(Inlogscherm.Gebruiker, "true");

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
        /// Speler wordt naar rechts verplaatst (van selectie naar de opstelling)
        /// </summary>

        protected void btnRechts_Click(object sender, EventArgs e)
        {
            // Er wordt gezocht naar de speler die is aangeklikt. Die speler wordt naar de juiste lijst verplaatst

                if (keepers.Count > 0)
                {
                    foreach (Klassen.Keeper k in keepers.ToArray())
                    {
                        k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                        if (k.Spelercode == Convert.ToInt32(code))
                        {
                            keepers.Remove(k);
                            opgesteldeKeepers.Add(k);
                            Klassen.DBConnect.UpdateSpeler(k, "true");

                        }
                    }
                }
                if (veldspelers.Count > 0)
                {
                    foreach (Klassen.Veldspeler v in veldspelers.ToArray())
                    {
                        v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                        if (v.Spelercode == Convert.ToInt32(code))
                        {
                            veldspelers.Remove(v);
                            opgesteldeVeldspelers.Add(v);
                            Klassen.DBConnect.UpdateSpeler(v, "true");
                        }
                    }
                }
                Reload();
        }

        /// <summary>
        /// Speler wordt naar links verplaatst (Van opstelling naar de selectie)
        /// </summary>
        protected void btnLinks_Click(object sender, EventArgs e)
        {
            // Er wordt gezocht naar de speler die is aangeklikt. Die speler wordt naar de juiste lijst verplaatst

            if (opgesteldeKeepers.Count > 0)
            {
                foreach (Klassen.Keeper k in opgesteldeKeepers.ToArray())
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    if (k.Spelercode == Convert.ToInt32(code))
                    {
                        opgesteldeKeepers.Remove(k);
                        keepers.Add(k);
                        Klassen.DBConnect.UpdateSpeler(k, "false");
                    }
                }
            }
            if (opgesteldeVeldspelers.Count > 0)
            {
                foreach (Klassen.Veldspeler v in opgesteldeVeldspelers.ToArray())
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    if (v.Spelercode == Convert.ToInt32(code))
                    {
                        opgesteldeVeldspelers.Remove(v);
                        veldspelers.Add(v);
                        Klassen.DBConnect.UpdateSpeler(v, "false");
                    }
                }
            }
            Reload();
        }

        /// <summary>
        /// Velden worden gereload
        /// </summary>
        public void Reload()
        {
            lbSelectie.Items.Clear();
            lbOpstelling.Items.Clear();

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
            if (opgesteldeKeepers != null)
            {
                foreach (Klassen.Keeper k in opgesteldeKeepers)
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    lbOpstelling.Items.Add(k.ToString());
                }
            }

            if (opgesteldeVeldspelers != null)
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