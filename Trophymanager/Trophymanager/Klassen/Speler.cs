using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trophymanager.Klassen
{
    public abstract class Speler
    {
        #region Fields
        public int Spelercode { get; set; }
        public string Naam { get; set; }
        public int Nummer { get; set; }
        public string InOpstelling { get; set; }
        public int Leeftijd { get; set; }
        public int Passen { get; set; }
        public int Snelheid { get; set; }
        public int Kracht { get; set; }
        public string Soort { get; set; }
        public Club Club { get; set; }
        #endregion

        #region Constructor
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

        public override string ToString()
        {
            return Spelercode + " Naam: " + Naam + "  Leeftijd: " + Leeftijd + " Nummer: " + Nummer;
        }

        #endregion

    }
}