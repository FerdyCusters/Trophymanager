namespace Trophymanager.Klassen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// De klasse wedstrijd. In deze klasse worden attributen van een wedstrijd bijgehouden en methodes uitgevoerd.
    /// </summary>
    public class Wedstrijd
    {
        #region Fields

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Wedstrijdcode { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public Club ThuisTeam { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public Club UitTeam { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int ClubCodeThuisTeam { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int ClubCodeUitTeam { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public string Speeldatum { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public string Uitslag { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public Competitie Competitie { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// De constructor van wedstrijd
        /// </summary>
        /// <param name="thuisTeam"></param>
        /// <param name="uitTeam"></param>
        /// <param name="speeldatum"></param>
        /// <param name="tijdstip"></param>
        /// <param name="competitie"></param>
        public Wedstrijd(Club thuisTeam, Club uitTeam, string speeldatum, string tijdstip, Competitie competitie)
        {
            this.ThuisTeam = thuisTeam;
            this.UitTeam = uitTeam;
            this.Speeldatum = speeldatum;
            this.Competitie = Competitie;
        }

        /// <summary>
        /// De tweede constructor van wedstrijd. Deze is gemaakt om de data fantsoenlijk uit de database te kunnen halen.
        /// </summary>
        /// <param name="clubCodeThuisTeam"></param>
        /// <param name="clubCodeUitTeam"></param>
        /// <param name="speeldatum"></param>
        /// <param name="uitslag"></param>
        public Wedstrijd(int clubCodeThuisTeam, int clubCodeUitTeam, string speeldatum, string uitslag)
        {
            this.ClubCodeThuisTeam = clubCodeThuisTeam;
            this.ClubCodeUitTeam = clubCodeUitTeam;
            this.Speeldatum = speeldatum;
            this.Uitslag = uitslag;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Wedstrijd wordt gegenereerd
        /// </summary>
        public void SpeelWedstrijd()
        {
            // Informatie wordt bijgewerkt
            List<Club> clubStatistieken = DBConnect.GetCTs();
            foreach (Club c in clubStatistieken)
            {
                c.Clubcode = DBConnect.GetClubCode(c);
                if (c.Clubcode == this.ThuisTeam.Clubcode)
                {
                    this.ThuisTeam.AantalGespeeld = c.AantalGespeeld;
                    this.ThuisTeam.AantalGewonnen = c.AantalGewonnen;
                    this.ThuisTeam.AantalGelijk = c.AantalGelijk;
                    this.ThuisTeam.AantalVerloren = c.AantalVerloren;
                    this.ThuisTeam.AantalPunten = c.AantalPunten;
                }

                if (c.Clubcode == this.UitTeam.Clubcode)
                {
                    this.UitTeam.AantalGespeeld = c.AantalGespeeld;
                    this.UitTeam.AantalGewonnen = c.AantalGewonnen;
                    this.UitTeam.AantalGelijk = c.AantalGelijk;
                    this.UitTeam.AantalVerloren = c.AantalVerloren;
                    this.UitTeam.AantalPunten = c.AantalPunten;
                }
            }

            Random random = new Random();
            int getal = random.Next(0, 8);
            int getal2 = random.Next(0, 8);
            this.Uitslag = getal + "-" + getal2;

            this.ThuisTeam.AantalGespeeld++;
            this.UitTeam.AantalGespeeld++;

            if (getal > getal2)
            {
                this.ThuisTeam.AantalGewonnen++;
                this.ThuisTeam.AantalPunten = this.ThuisTeam.AantalPunten + 3;
                this.UitTeam.AantalVerloren++;
            }

            if (getal < getal2)
            {
                this.UitTeam.AantalGewonnen++;
                this.UitTeam.AantalPunten = this.UitTeam.AantalPunten + 3;
                this.ThuisTeam.AantalVerloren++;
            }

            if (getal == getal2)
            {
                this.UitTeam.AantalGelijk++;
                this.ThuisTeam.AantalGelijk++;
                this.UitTeam.AantalPunten++;
                this.ThuisTeam.AantalPunten++;
            }

            DBConnect.UpdateCT(this.ThuisTeam);
            DBConnect.UpdateCT(this.UitTeam);
        }

        /// <summary>
        /// De ToString methode van Wedstrijd.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ThuisTeam.Clubnaam + "  " + this.Uitslag + "  " + this.UitTeam.Clubnaam + "    Datum: " + this.Speeldatum;
        }

        #endregion
    }
}