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

        /// <summary>
        /// Club wordt toegevoegd aan de competitie (DB)
        /// </summary>
        /// <param name="club"></param>
        public void VoegClubToe(Club club)
        {
            club.Clubcode = DBConnect.GetClubCode(club);
            this.Toernooicode = DBConnect.GetToernooiCode(this);
            Clubs.Add(club);
            DBConnect.AddCT(club, this);
        }

        public void SpeelWedstrijd(Club thuisTeam, Club uitTeam)
        {
            Wedstrijd wedstrijd = new Wedstrijd(thuisTeam, uitTeam, DateTime.Now.ToString("yyyy-MM-dd"), "19:45", this);
            wedstrijd.ThuisTeam.Clubcode = DBConnect.GetClubCode(wedstrijd.ThuisTeam);
            wedstrijd.UitTeam.Clubcode = DBConnect.GetClubCode(wedstrijd.UitTeam);
            wedstrijd.SpeelWedstrijd();
            DBConnect.AddWedstrijd(wedstrijd);
        }
        #endregion
    }
}