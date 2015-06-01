using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trophymanager.Klassen
{
    public class Competitie
    {
        public int Toernooicode { get; set; }
        public string Naam { get; set; }
        public List<Club> Clubs { get; set; }
        public List<Wedstrijd> Wedstrijden { get; set; }

        public Competitie(string naam)
        {
            this.Naam = naam;
            Clubs = new List<Club>();
            Wedstrijden = new List<Wedstrijd>();
        }

        public void VoegClubToe(Club club)
        {
            //TODO
        }

        public void VoegWedstrijdToe(Wedstrijd wedstrijd)
        {
            //TODO
        }

        public void GenereerStand()
        {
            //TODO
        }
    }
}