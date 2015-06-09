namespace Trophymanager.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Trophymanager.Klassen;

    /// <summary>
    /// Teampagina page.
    /// </summary>
    public partial class Teampagina : System.Web.UI.Page
    {
        #region Fields

        /// <summary>
        /// Lijst met niet-opgestelde keepers.
        /// </summary>
        private List<Klassen.Keeper> keepers = new List<Klassen.Keeper>();

        /// <summary>
        /// Lijst met niet-opgstelde veldspelers.
        /// </summary>
        private List<Klassen.Veldspeler> veldspelers = new List<Klassen.Veldspeler>();

        /// <summary>
        /// Lijst met wel-opgestelde keepers.
        /// </summary>
        private List<Klassen.Keeper> opgesteldeKeepers = new List<Klassen.Keeper>();

        /// <summary>
        /// Lijst met wel-opgestelde veldspelers.
        /// </summary>
        private List<Klassen.Veldspeler> opgesteldeVeldspelers = new List<Klassen.Veldspeler>();

        /// <summary>
        /// Integer index.
        /// </summary>
        private int index;

        /// <summary>
        /// String code.
        /// </summary>
        private string code;

        /// <summary>
        /// Aantal spelers in de opstelling
        /// </summary>
        private int opstellingCount;

        #endregion

        #region Pageload

        /// <summary>
        /// De Page Load van de teampagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Lijsten worden ge-update zoals de situatie in de database is.
            this.keepers = Klassen.DBConnect.GetKeepers(Inlogscherm.Gebruiker, "false");
            this.veldspelers = Klassen.DBConnect.GetVeldpspelers(Inlogscherm.Gebruiker, "false");
            this.opgesteldeKeepers = Klassen.DBConnect.GetKeepers(Inlogscherm.Gebruiker, "true");
            this.opgesteldeVeldspelers = Klassen.DBConnect.GetVeldpspelers(Inlogscherm.Gebruiker, "true");

            // Variabelen worden leeggemaakt.
            this.index = 0;
            this.code = "";

            // Er wordt getest of er een speler is aangeklikt.
            // Als er een speler is aangeklik wordt er opgeslagen om welke speler het gaat.
            // Ook worden de stats in lbStatestiek aangepast naar de stats van de geselecteerde speler.
            if (this.lbSelectie.SelectedItem != null && this.lbOpstelling.SelectedItem != null)
            {
                this.Reload();
                this.lbStatestiek.Items.Clear();
            }

            if (this.lbSelectie.SelectedItem != null && this.lbOpstelling.SelectedItem == null)
            {
                this.index = this.lbSelectie.SelectedItem.Text.IndexOf(" ");
                this.code = this.lbSelectie.SelectedItem.Text.Substring(0, this.index);
                this.opstellingCount = this.lbOpstelling.Items.Count;
                this.UpdateStatsListbox();
            }

            if (this.lbOpstelling.SelectedItem != null && this.lbSelectie.SelectedItem == null)
            {
                this.index = this.lbOpstelling.SelectedItem.Text.IndexOf(" ");
                this.code = this.lbOpstelling.SelectedItem.Text.Substring(0, this.index);
                this.UpdateStatsListbox();
            }

            // Deze methode wordt alleen maar de eerste keer uitgevoerd als de pagina in page_load komt.
            if (Convert.ToInt32(Master.Session["Counter"]) < 1)
            {
                this.Reload();
                Master.Session["Counter"] = 1;
            }
        }
        #endregion

        #region btnRechts
        /// <summary>
        /// Speler wordt naar rechts verplaatst (van selectie naar de opstelling)
        /// </summary>
        protected void BtnRechts_Click(object sender, EventArgs e)
        {
            // Er wordt gekeken of er een keeper is aangeklikt. Als dit het geval is wordt deze naar de opstelling verplaats
            // .. indien de opstelling nog geen 11 spelers bevat.
            if (this.keepers.Count > 0 && this.opstellingCount < 11 && this.lbSelectie.SelectedItem != null)
            {
                foreach (Klassen.Keeper k in this.keepers.ToArray())
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    if (k.Spelercode == Convert.ToInt32(this.code))
                    {
                        this.keepers.Remove(k);
                        this.opgesteldeKeepers.Add(k);
                        Klassen.DBConnect.UpdateSpeler(k, "true");
                        if (k.Spelercode == Convert.ToInt32(this.code))
                        {
                            this.KeeperStats(k, this.lbSelectie);
                        }
                    }
                }
            }

            // Er wordt gekeken of er een veldspeler is aangeklikt. Als dit het geval is wordt deze naar de opstelling verplaats
            // .. indien de opstelling nog geen 11 spelers bevat.
            if (this.veldspelers.Count > 0 && this.opstellingCount < 11 && this.lbSelectie.SelectedItem != null)
            {
                foreach (Klassen.Veldspeler v in this.veldspelers.ToArray())
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    if (v.Spelercode == Convert.ToInt32(this.code))
                    {
                        this.veldspelers.Remove(v);
                        this.opgesteldeVeldspelers.Add(v);
                        Klassen.DBConnect.UpdateSpeler(v, "true");
                    }
                }
            }

            this.Reload();
        }
        #endregion

        #region btnLinks
        /// <summary>
        /// Speler wordt naar links verplaatst (Van opstelling naar de selectie)
        /// </summary>
        protected void BtnLinks_Click(object sender, EventArgs e)
        {
            // Er wordt gekeken of er een keeper is aangeklikt. Als dit het geval is wordt deze naar de selectie verplaats
            // .. indien de opstelling nog geen 11 spelers bevat.
            if (this.opgesteldeKeepers.Count > 0 && this.lbOpstelling.SelectedItem != null)
            {
                foreach (Klassen.Keeper k in this.opgesteldeKeepers.ToArray())
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    if (k.Spelercode == Convert.ToInt32(this.code))
                    {
                        this.opgesteldeKeepers.Remove(k);
                        this.keepers.Add(k);
                        Klassen.DBConnect.UpdateSpeler(k, "false");
                    }
                }
            }

            // Er wordt gekeken of er een veldspeler is aangeklikt. Als dit het geval is wordt deze naar de selectie verplaats
            // .. indien de opstelling nog geen 11 spelers bevat.
            if (this.opgesteldeVeldspelers.Count > 0 && this.lbOpstelling.SelectedItem != null)
            {
                foreach (Klassen.Veldspeler v in this.opgesteldeVeldspelers.ToArray())
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    if (v.Spelercode == Convert.ToInt32(this.code))
                    {
                        this.opgesteldeVeldspelers.Remove(v);
                        this.veldspelers.Add(v);
                        Klassen.DBConnect.UpdateSpeler(v, "false");
                    }
                }
            }

            this.Reload();
        }
        #endregion

        #region btnTrain

        /// <summary>
        /// In deze event handler is er een mogelijkheid dat spelers vaardigheden verbeteren. 
        /// Hoe groot de kans is dat spelers beter worden kun je hier bepalen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnTrain_Click(object sender, EventArgs e)
        {
            foreach (Keeper k in this.keepers)
            {
                Training training = new Training(k, DateTime.Now.ToString("yyyy-MM-dd"));
                training.VoerTrainingUit("false");
            }

            foreach (Keeper k in this.opgesteldeKeepers)
            {
                Training training = new Training(k, DateTime.Now.ToString("yyyy-MM-dd"));
                training.VoerTrainingUit("true");
            }

            foreach (Veldspeler v in this.veldspelers)
            {
                Training training = new Training(v, DateTime.Now.ToString("yyyy-MM-dd"));
                training.VoerTrainingUit("false");
            }

            foreach (Veldspeler v in this.opgesteldeVeldspelers)
            {
                Training training = new Training(v, DateTime.Now.ToString("yyyy-MM-dd"));
                training.VoerTrainingUit("true");
            }

            this.Reload();
        }

        #endregion

        #region Methode: Reload
        /// <summary>
        /// In deze methode worden velden, waar nodig, gerefreshed.
        /// </summary>
        protected void Reload()
        {
            this.lbSelectie.Items.Clear();
            if (this.keepers.Count > 0)
            {
                foreach (Klassen.Keeper k in this.keepers)
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    this.lbSelectie.Items.Add(k.ToString());
                }
            }

            if (this.veldspelers.Count > 0)
            {
                foreach (Klassen.Veldspeler v in this.veldspelers)
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    this.lbSelectie.Items.Add(v.ToString());
                }
            }

            this.lbOpstelling.Items.Clear();
            if (this.opgesteldeKeepers != null)
            {
                foreach (Klassen.Keeper k in this.opgesteldeKeepers)
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    this.lbOpstelling.Items.Add(k.ToString());
                }
            }

            if (this.opgesteldeVeldspelers != null)
            {
                foreach (Klassen.Veldspeler v in this.opgesteldeVeldspelers)
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    this.lbOpstelling.Items.Add(v.ToString());
                }
            }
        }
        #endregion

        #region Methode: KeeperStats
        /// <summary>
        /// Deze methode zorgt ervoor dat de statistieken van de geselecteerde keeper in de listbox komen te staan
        /// </summary>
        /// <param name="k"></param>
        protected void KeeperStats(Klassen.Keeper k, ListBox lb)
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
        protected void VeldspelerStats(Klassen.Veldspeler v, ListBox lb)
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
        protected void UpdateStatsListbox()
        {
            this.lbStatestiek.Items.Clear();
            if (this.keepers.Count > 0)
            {
                foreach (Klassen.Keeper k in this.keepers)
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    if (k.Spelercode == Convert.ToInt32(this.code))
                    {
                        this.KeeperStats(k, this.lbStatestiek);
                    }
                }
            }

            if (this.veldspelers.Count > 0)
            {
                foreach (Klassen.Veldspeler v in this.veldspelers)
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    if (v.Spelercode == Convert.ToInt32(this.code))
                    {
                        this.VeldspelerStats(v, this.lbStatestiek);
                    }
                }
            }

            if (this.opgesteldeKeepers != null)
            {
                foreach (Klassen.Keeper k in this.opgesteldeKeepers)
                {
                    k.Spelercode = Klassen.DBConnect.GetSpelerCode(k);
                    if (k.Spelercode == Convert.ToInt32(this.code))
                    {
                        this.KeeperStats(k, this.lbStatestiek);
                    }
                }
            }

            if (this.opgesteldeVeldspelers != null)
            {
                foreach (Klassen.Veldspeler v in this.opgesteldeVeldspelers)
                {
                    v.Spelercode = Klassen.DBConnect.GetSpelerCode(v);
                    if (v.Spelercode == Convert.ToInt32(this.code))
                    {
                        this.VeldspelerStats(v, this.lbStatestiek);
                    }
                }
            }
        }
        #endregion
    }
}