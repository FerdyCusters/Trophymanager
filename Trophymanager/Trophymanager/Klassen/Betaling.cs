using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trophymanager.Klassen
{
    public class Betaling
    {
        public Club Club { get; set; }
        public double Bedrag { get; set; }
        public string Soort { get; set; }
        public int Aantal { get; set; }

        public Betaling(Club club, double bedrag, string soort, int aantal)
        {
            this.Club = club;
            this.Bedrag = bedrag;
            this.Soort = soort;
            this.Aantal = aantal;
        }

        public void VoerBetalingUit()
        {
            //TODO
        }
    }
}