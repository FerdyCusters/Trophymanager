namespace Trophymanager.Klassen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// De klasse Keeper. Keeper is een speler. Inheritance.
    /// </summary>
    public class Keeper : Speler
    {
        #region Fields

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Reflexen { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Handelen { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Uitkomen { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor van een keeper
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
        /// <param name="reflexen"></param>
        /// <param name="handelen"></param>
        /// <param name="uitkomen"></param>
        public Keeper(string naam, int nummer, string inOpstelling, int leeftijd, int passen, int snelheid, int kracht, string soort, Club club, int reflexen, int handelen, int uitkomen) : base(naam, nummer, inOpstelling, leeftijd, passen, snelheid, kracht, soort, club)
        {
            this.Reflexen = reflexen;
            this.Handelen = handelen;
            this.Uitkomen = uitkomen;
        }
        #endregion
    }
}