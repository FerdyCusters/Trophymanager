using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trophymanager.Klassen
{
    public class Veldspeler : Speler
    {
        #region Fields
        public int Positiespel { get; set; }
        public int Afwerken { get; set; }
        public int Koppen { get; set; }
        public int Tackelen { get; set; }
        public int Dekken { get; set; }
        #endregion

        #region Constructor
        public Veldspeler(string naam, int nummer, string inOpstelling, int leeftijd, int passen, int snelheid, int kracht, string soort, Club club, 
            int positiespel, int afwerken, int koppen, int tackelen, int dekken) : base(naam, nummer, inOpstelling, leeftijd,
            passen, snelheid, kracht, soort, club)
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