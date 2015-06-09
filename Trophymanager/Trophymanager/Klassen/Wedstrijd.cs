using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trophymanager.Klassen
{
    public class Wedstrijd
    {

        #region Fields
        public int Wedstrijdcode { get; set; }
        public Club ThuisTeam { get; set; }
        public Club UitTeam { get; set; }
        public int ClubCodeThuisTeam { get; set; }
        public int ClubCodeUitTeam { get; set; }
        public string Speeldatum { get; set; }
        public string Uitslag { get; set; }
        public Competitie Competitie { get; set; }
        #endregion

        #region Constructor
        public Wedstrijd(Club thuisTeam, Club uitTeam, string speeldatum, string tijdstip, Competitie competitie)
        {
            this.ThuisTeam = thuisTeam;
            this.UitTeam = uitTeam;
            this.Speeldatum = speeldatum;
            this.Competitie = Competitie;
        }

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
            foreach(Club c in clubStatistieken)
            {
                c.Clubcode = DBConnect.GetClubCode(c);
                if(c.Clubcode == ThuisTeam.Clubcode)
                {
                    ThuisTeam.AantalGespeeld = c.AantalGespeeld;
                    ThuisTeam.AantalGewonnen = c.AantalGewonnen;
                    ThuisTeam.AantalGelijk = c.AantalGelijk;
                    ThuisTeam.AantalVerloren = c.AantalVerloren;
                    ThuisTeam.AantalPunten = c.AantalPunten;
                }
                if (c.Clubcode == UitTeam.Clubcode)
                {
                    UitTeam.AantalGespeeld = c.AantalGespeeld;
                    UitTeam.AantalGewonnen = c.AantalGewonnen;
                    UitTeam.AantalGelijk = c.AantalGelijk;
                    UitTeam.AantalVerloren = c.AantalVerloren;
                    UitTeam.AantalPunten = c.AantalPunten;
                }

            }

            Random random = new Random();
            int getal = random.Next(0, 8);
            int getal2 = random.Next(0, 8);
            this.Uitslag = getal + "-" + getal2;

            ThuisTeam.AantalGespeeld++;
            UitTeam.AantalGespeeld++;

            if(getal > getal2)
            {
                ThuisTeam.AantalGewonnen++;
                ThuisTeam.AantalPunten = ThuisTeam.AantalPunten + 3;
                UitTeam.AantalVerloren++;
            }
            if (getal < getal2)
            {
                UitTeam.AantalGewonnen++;
                UitTeam.AantalPunten = UitTeam.AantalPunten + 3;
                ThuisTeam.AantalVerloren++;
            }
            if (getal == getal2)
            {
                UitTeam.AantalGelijk++;
                ThuisTeam.AantalGelijk++;
                UitTeam.AantalPunten++;
                ThuisTeam.AantalPunten++;
            }
            DBConnect.UpdateCT(ThuisTeam);
            DBConnect.UpdateCT(UitTeam);
        }

        public override string ToString()
        {
            return this.ThuisTeam.Clubnaam + "  " + Uitslag + "  " + UitTeam.Clubnaam + "    Datum: " + Speeldatum;
        }
        #endregion

    }
}