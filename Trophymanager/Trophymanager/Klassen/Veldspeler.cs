namespace Trophymanager.Klassen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Een veldspeler is een Speler. Er is hier sprake van Inheritance
    /// </summary>
    public class Veldspeler : Speler
    {
        #region Fields

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Positiespel { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Afwerken { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Koppen { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Tackelen { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Dekken { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor van een veldspeler
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="nummer"></param>
        /// <param name="inOpstelling"></param>
        /// <param name="leeftijd"></param>
        /// <param name="passen"></param>
        /// <param name="snelheid"></param>
        /// <param name="kracht"></param>
        /// <param name="soort"></param>
        /// <param name="club"></param>
        /// <param name="positiespel"></param>
        /// <param name="afwerken"></param>
        /// <param name="koppen"></param>
        /// <param name="tackelen"></param>
        /// <param name="dekken"></param>
        public Veldspeler(string naam, int nummer, string inOpstelling, int leeftijd, int passen, int snelheid, int kracht, string soort, Club club, int positiespel, int afwerken, int koppen, int tackelen, int dekken) : base(naam, nummer, inOpstelling, leeftijd, passen, snelheid, kracht, soort, club)
        {
            this.Positiespel = positiespel;
            this.Afwerken = afwerken;
            this.Koppen = koppen;
            this.Tackelen = tackelen;
            this.Dekken = dekken;
        }
        #endregion
    }
}