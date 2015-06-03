using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trophymanager.Klassen
{
    public class Competitie
    {
        #region Fields
        public int Toernooicode { get; set; }
        public string Naam { get; set; }
        public List<Club> Clubs { get; set; }
        public List<Wedstrijd> Wedstrijden { get; set; }
        public int AantalClubs { get; set; }

        #endregion

        #region Constructor
        public Competitie(string naam)
        {
            this.Naam = naam;
            Clubs = new List<Club>();
            Wedstrijden = new List<Wedstrijd>();
        }
        #endregion

        #region Methods
        public void VoegClubToe(Club club)
        {
            Clubs.Add(club);
            DBConnect.AddCT(club, this);
        }

        public void VoegWedstrijdToe(Wedstrijd wedstrijd)
        {
            //TODO
        }

        public void GenereerStand()
        {
            //TODO
        }
        #endregion
    }
}