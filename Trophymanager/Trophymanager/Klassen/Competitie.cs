namespace Trophymanager.Klassen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// De klasse competitie. In deze klasse worden attributen van een competitie bijgehouden en enkele methodes uitgevoerd.
    /// </summary>
    public class Competitie
    {
        #region Fields

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Toernooicode { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public string Naam { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public List<Club> Clubs { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public List<Wedstrijd> Wedstrijden { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int AantalClubs { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor van competitie. Hier wordt een competitie aangemaakt.
        /// </summary>
        /// <param name="naam"></param>
        public Competitie(string naam)
        {
            this.Naam = naam;
            this.Clubs = new List<Club>();
            this.Wedstrijden = new List<Wedstrijd>();
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
            this.Clubs.Add(club);
            DBConnect.AddCT(club, this);
        }

        /// <summary>
        /// Wedstrijd wordt aangemaakt en gespeeld.
        /// </summary>
        /// <param name="thuisTeam"></param>
        /// <param name="uitTeam"></param>
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