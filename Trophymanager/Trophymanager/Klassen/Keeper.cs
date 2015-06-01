using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trophymanager.Klassen
{
    public class Keeper : Speler
    {
        public int Reflexen { get; set; }
        public int Handelen { get; set; }
        public int Uitkomen { get; set; }

        public Keeper(string naam, int nummer, int leeftijd, int passen, int snelheid, int kracht, string soort, Club club,
            int reflexen, int handelen, int uitkomen) : base (naam, nummer, leeftijd, passen, snelheid, kracht, soort, club)
        {
            this.Reflexen = reflexen;
            this.Handelen = handelen;
            this.Uitkomen = uitkomen;
        }
    }
}