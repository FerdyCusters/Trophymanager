using System;
using System.Collections.Generic;
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
        private int opstellingCount;
        #endregion

        #region Pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            // Lijsten worden ge-update zoals de situatie in de database is.
            keepers = Klassen.DBConnect.GetKeepers(Inlogscherm.Gebruiker, "false");
            veldspelers = Klassen.DBConnect.GetVeldpspelers(Inlogscherm.Gebruiker, "false");
            opgesteldeKeepers = Klassen.DBConnect.GetKeepers(Inlogscherm.Gebruiker, "true");
            opgesteldeVeldspelers = Klassen.DBConnect.GetVeldpspelers(Inlogscherm.Gebruiker, "true");

            // Variabelen worden leeggemaakt.
            index = 0;
            code = "";

            // Er wordt getest of er een speler is aangeklikt.
            // Als er een speler is aangeklik wordt er opgeslagen om welke speler het gaat.
            // Ook worden de stats in lbStatestiek aangepast naar de stats van de geselecteerde speler.
            if (lbSelectie.SelectedItem != null && lbOpstelling.SelectedItem != null)
            {
                Reload("Selectie", "Opstelling");
                lbStatestiek.Items.Clear();
            }
            if (lbSelectie.SelectedItem != null && lbOpstelling.SelectedItem == null)
            {
                Reload("", "Opstelling");
                index = lbSelectie.SelectedItem.Text.IndexOf(" ");
                code = lbSelectie.SelectedItem.Text.Substring(0, index);
                opstellingCount = lbOpstelling.Items.Count;
                UpdateStatsListbox();
            }

            if (lbOpstelling.SelectedItem != null && lbSelectie.SelectedItem == null)
            {
                Reload("Selectie", "");
                index = lbOpstelling.SelectedItem.Text.IndexOf(" ");
                code = lbOpstelling.SelectedItem.Text.Substring(0, index);
                UpdateStatsListbox();
            }

            // Deze methode wordt alleen maar de eerste keer uitgevoerd als de pagina in page_load komt.
            if (Convert.ToInt32(Session["Counter"]) < 1)
            {
                Reload("Selectie", "Opstelling");
                Session["Counter"] = 1;
            }
        }
        #endregion

        // Event handlers

        #region btnGaTerug
        /// <summary>
        /// Er wordt terug gegaan naar de Homepage.
        /// </summary>
        protected void btnGaTerug_Click(object sender, EventArgs e)
        {
            Session["Counter"] = 0;
            Server.Transfer("Homepage.aspx", true);
        }
        #endregion

        #region btnRechts
        /// <summary>
        /// Speler wordt naar rechts verplaatst (van selectie naar de opstelling)
        /// </summary>
        protected void btnRechts_Click(object sender, EventArgs e)
        {
            // Er wordt gekeken of er een keeper is aangeklikt. Als dit het geval is wordt deze naar de opstelling verplaats
            // .. indien de opstelling nog geen 11 spelers bevat.

                if (keepers.Count > 0 && opstellingCount < 11)
                {
                    foreach (Klassen.Keeper k in keepers.ToArray())
                    {
                        k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                        if (k.Spelercode == Convert.ToInt32(code))
                        {
                            keepers.Remove(k);
                            opgesteldeKeepers.Add(k);
                            Klassen.DBConnect.UpdateSpeler(k, "true");
                            if (k.Spelercode == Convert.ToInt32(code))
                            {
                                KeeperStats(k, lbSelectie);
                            }
                        }
                    }
                }

                // Er wordt gekeken of er een veldspeler is aangeklikt. Als dit het geval is wordt deze naar de opstelling verplaats
                // .. indien de opstelling nog geen 11 spelers bevat.

                if (veldspelers.Count > 0 && opstellingCount < 11)
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
                Reload("Selectie", "Opstelling");
        }
        #endregion

        #region btnLinks
        /// <summary>
        /// Speler wordt naar links verplaatst (Van opstelling naar de selectie)
        /// </summary>
        protected void btnLinks_Click(object sender, EventArgs e)
        {
            // Er wordt gekeken of er een keeper is aangeklikt. Als dit het geval is wordt deze naar de selectie verplaats
            // .. indien de opstelling nog geen 11 spelers bevat.

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

            // Er wordt gekeken of er een veldspeler is aangeklikt. Als dit het geval is wordt deze naar de selectie verplaats
            // .. indien de opstelling nog geen 11 spelers bevat.

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
            Reload("Selectie", "Opstelling");
        }
        #endregion

        // Methodes

        #region Methode: Reload
        /// <summary>
        /// In deze methode worden velden, waar aangegeven, gerefreshed.
        /// De parameters bepalen welke listbox moet worden gerefreshed.
        /// </summary>
        public void Reload(string a, string b)
        {
            if(a == "Selectie")
            {
                lbSelectie.Items.Clear();
                if (keepers.Count > 0)
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
            }
            if(b == "Opstelling")
            {
                lbOpstelling.Items.Clear();
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
        }
        #endregion

        #region Methode: KeeperStats
        /// <summary>
        /// Deze methode zorgt ervoor dat de statistieken van de geselecteerde keeper in de listbox komen te staan
        /// </summary>
        /// <param name="k"></param>
        public void KeeperStats(Klassen.Keeper k, ListBox lb)
        {
            lb.Items.Add("Naam: " + k.Naam);
            lb.Items.Add("Leeftijd: " + k.Leeftijd);
            lb.Items.Add("Nummer: " + k.Nummer);
            lb.Items.Add("Passen: " + k.Passen);
            lb.Items.Add("Snelheid: " + k.Snelheid);
            lb.Items.Add("Kracht: " + k.Kracht);
            lb.Items.Add("Reflexen: " + k.Reflexen);
            lb.Items.Add("Handelen: " + k.Handelen);
            lb.Items.Add("Uitkomen: " + k.Uitkomen);
        }
        #endregion

        #region Methode: VeldspelerStats
        /// <summary>
        /// Deze methode zorgt ervoor dat de statistieken van de geselecteerde veldspeler in de listbox komen te staan
        /// </summary>
        /// <param name="v"></param>
        public void VeldspelerStats(Klassen.Veldspeler v, ListBox lb)
        {
            lb.Items.Add("Naam: " + v.Naam);
            lb.Items.Add("Leeftijd: " + v.Leeftijd);
            lb.Items.Add("Nummer: " + v.Nummer);
            lb.Items.Add("Passen: " + v.Passen);
            lb.Items.Add("Snelheid: " + v.Snelheid);
            lb.Items.Add("Kracht: " + v.Kracht);
            lb.Items.Add("Positiespel: " + v.Positiespel);
            lb.Items.Add("Koppen: " + v.Koppen);
            lb.Items.Add("Afwerken: " + v.Afwerken);
            lb.Items.Add("Tackelen: " + v.Tackelen);
            lb.Items.Add("Dekken: " + v.Dekken);
        }
        #endregion

        #region Methode: UpdateStatsListbox
        /// <summary>
        /// De listbox waar de statistieken zich in bevinden wordt ge-update.
        /// </summary>
        public void UpdateStatsListbox()
        {
            lbStatestiek.Items.Clear();
            if (keepers.Count > 0)
            {
                foreach (Klassen.Keeper k in keepers)
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    if (k.Spelercode == Convert.ToInt32(code))
                    {
                        KeeperStats(k, lbStatestiek);
                    }
                }
            }
            if (veldspelers.Count > 0)
            {
                foreach (Klassen.Veldspeler v in veldspelers)
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    if (v.Spelercode == Convert.ToInt32(code))
                    {
                        VeldspelerStats(v, lbStatestiek);
                    }
                }
            }
            if (opgesteldeKeepers != null)
            {
                foreach (Klassen.Keeper k in opgesteldeKeepers)
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    if (k.Spelercode == Convert.ToInt32(code))
                    {
                        KeeperStats(k, lbStatestiek);
                    }
                }
            }

            if (opgesteldeVeldspelers != null)
            {
                foreach (Klassen.Veldspeler v in opgesteldeVeldspelers)
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    if (v.Spelercode == Convert.ToInt32(code))
                    {
                        VeldspelerStats(v, lbStatestiek);
                    }
                }
            }
        }
        #endregion
    }
}