namespace Trophymanager.Klassen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// De klasse speler. Hier worden alle attributen van de klasse speler opgeslagen en bijgehouden.
    /// </summary>
    public abstract class Speler
    {
        #region Fields

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Spelercode { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public string Naam { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Nummer { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public string InOpstelling { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Leeftijd { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Passen { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Snelheid { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Kracht { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public string Soort { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public Club Club { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// De klasse speler. Hier worden alle attributen van een speler opgeslagen en bijgehouden.
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
        public Speler(string naam, int nummer, string inOpstelling, int leeftijd, int passen, int snelheid, int kracht, string soort, Club club)
        {
            this.Naam = naam;
            this.Nummer = nummer;
            this.InOpstelling = inOpstelling;
            this.Leeftijd = leeftijd;
            this.Passen = passen;
            this.Snelheid = snelheid;
            this.Kracht = kracht;
            this.Soort = soort;
            this.Club = club;
        }
        #endregion

        #region methods

        /// <summary>
        /// De ToString methode van Speler. Hierin worden enkele attributen teruggegeven van een speler.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Spelercode + " Naam: " + this.Naam + "  Leeftijd: " + this.Leeftijd + " Nummer: " + this.Nummer;
        }

        #endregion
    }
}