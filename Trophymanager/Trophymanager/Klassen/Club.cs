namespace Trophymanager.Klassen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// De klasse club. Hier wordt alle informatie van een club bijgehouden.
    /// </summary>
    public class Club : IComparable<Club>
    {
        #region Fields

        /// <summary>
        /// Statische Competitie: Eredivisie
        /// </summary>
        public static Klassen.Competitie Eredivisie = new Klassen.Competitie("Eredivisie");

        /// <summary>
        /// Statische Competitie: Eerste Divisie
        /// </summary>
        public static Klassen.Competitie EersteDivisie = new Klassen.Competitie("Eerste Divisie");

        /// <summary>
        /// Statische Competitie: Tweede Divisie
        /// </summary>
        public static Klassen.Competitie TweedeDivisie = new Klassen.Competitie("Tweede Divisie");

        /// <summary>
        /// Tijdelijke code
        /// </summary>
        private int tempCode;

        /// <summary>
        /// Gets or sets Property Clubcode
        /// </summary>
        public int Clubcode { get; set; }

        /// <summary>
        /// Gets or sets: Property Landcode
        /// </summary>
        public int Landcode { get; set; }

        /// <summary>
        /// Gets or sets: Property Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets: Property Wachtwoord
        /// </summary>
        public string Wachtwoord { get; set; }
        
        /// <summary>
        /// Gets or sets: Property Clubnaam
        /// </summary>
        public string Clubnaam { get; set; }

        /// <summary>
        /// Gets or sets: Property Bijnaam
        /// </summary>
        public string Bijnaam { get; set; }

        /// <summary>
        /// Gets or sets: Property Fans
        /// </summary>
        public int Fans { get; set; }

        /// <summary>
        /// Gets or sets: Property Clubkleuren
        /// </summary>
        public string Clubkleuren { get; set; }

        /// <summary>
        /// Gets or sets: Property Spelers
        /// </summary>
        public List<Speler> Spelers { get; set; }

        /// <summary>
        /// Gets or sets: Property Competitie
        /// </summary>
        public Competitie Competitie { get; set; }

        /// <summary>
        /// Gets or sets: Property Behaalde punten
        /// </summary>
        public int AantalPunten { get; set; }

        /// <summary>
        /// Gets or sets: Property aantal wedstrijden gewonnen
        /// </summary>
        public int AantalGewonnen { get; set; }

        /// <summary>
        /// Gets or sets: Property aantal wedstrijden gelijk
        /// </summary>
        public int AantalGelijk { get; set; }

        /// <summary>
        /// Gets or sets: Property aantal wedstrijden verloren
        /// </summary>
        public int AantalVerloren { get; set; }

        /// <summary>
        /// Gets or sets: Property aantal wedstrijden gespeeld
        /// </summary>
        public int AantalGespeeld { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor 1
        /// </summary>
        /// <param name="username"></param>
        /// <param name="wachtwoord"></param>
        /// <param name="clubnaam"></param>
        /// <param name="bijnaam"></param>
        /// <param name="clubkleuren"></param>
        public Club(string username, string wachtwoord, string clubnaam, string bijnaam, string clubkleuren)
        {
            this.Username = username;
            this.Wachtwoord = wachtwoord;
            this.Clubnaam = clubnaam;
            this.Bijnaam = bijnaam;
            this.Clubkleuren = clubkleuren;
            this.Spelers = new List<Speler>();
        }

        /// <summary>
        /// Constructor 2
        /// </summary>
        /// <param name="username"></param>
        /// <param name="wachtwoord"></param>
        /// <param name="clubnaam"></param>
        /// <param name="bijnaam"></param>
        /// <param name="clubkleuren"></param>
        /// <param name="aantalGespeeld"></param>
        /// <param name="aantalGewonnen"></param>
        /// <param name="aantalGelijk"></param>
        /// <param name="aantalVerloren"></param>
        /// <param name="aantalPunten"></param>
        public Club(string username, string wachtwoord, string clubnaam, string bijnaam, string clubkleuren, int aantalGespeeld, int aantalGewonnen, int aantalGelijk, int aantalVerloren, int aantalPunten)
        {
            this.Username = username;
            this.Wachtwoord = wachtwoord;
            this.Clubnaam = clubnaam;
            this.Bijnaam = bijnaam;
            this.Clubkleuren = clubkleuren;
            this.AantalGespeeld = aantalGespeeld;
            this.AantalGewonnen = aantalGewonnen;
            this.AantalGelijk = aantalGelijk;
            this.AantalVerloren = aantalVerloren;
            this.AantalPunten = aantalPunten;
            this.Spelers = new List<Speler>();
        }

        /// <summary>
        /// Lege Constructor. Voor enkele methodes waar nog geen waardes bekend zijn.
        /// </summary>
        public Club()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Speler wordt aan de database en aan het team toegevoegd
        /// </summary>
        /// <param name="speler"></param>
        public void VoegSpelerToe(Speler speler)
        {
            DBConnect.AddSpeler(speler);
            this.tempCode = DBConnect.GetSpelerCode(speler);
        }

        /// <summary>
        /// Login gegevens worden gechecked
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckLogin(string username, string password)
        {
            if (DBConnect.VerifyClub(username, password) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Registreer gegevens worden gechecked
        /// </summary>
        public bool CheckRegistreer(string username, string clubnaam, Pages.Inlogscherm i)
        {
            List<Club> bestaandeClubs = new List<Club>();
            bestaandeClubs = DBConnect.GetClubs();
            foreach (Club c in bestaandeClubs)
            {
                if (c.Username == username || c.Clubnaam == clubnaam)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Team wordt toegevoegd aan het systeem. Hij krijgt een tal van spelers en wordt toegevoegd aan een competitie.
        /// </summary>
        public void VoegToeAanSysteem()
        {
            DBConnect.AddClub(this);
            if (Eredivisie.AantalClubs >= 18)
            {
                if (EersteDivisie.AantalClubs >= 18)
                {
                    TweedeDivisie.VoegClubToe(this);
                }
                else
                {
                    EersteDivisie.VoegClubToe(this);
                }
            }
            else
            {
                Eredivisie.VoegClubToe(this);
            }

            this.Clubcode = DBConnect.GetClubCode(this);
            for (int i = 1; i < 3; i++)
            {
                Random random1 = new Random();
                int leeftijd = random1.Next(16, 37);
                Random random2 = new Random();
                int skill = random2.Next(1, 21);
                Keeper keeper = new Keeper("Kees Steen", i, "false", Convert.ToInt32(leeftijd), Convert.ToInt32(skill), Convert.ToInt32(skill), Convert.ToInt32(skill), "Keeper", this, Convert.ToInt32(skill), Convert.ToInt32(skill), Convert.ToInt32(skill));
                this.VoegSpelerToe(keeper);
                keeper.Spelercode = this.tempCode;
                DBConnect.AddKeeper(keeper);
                this.Spelers.Add(keeper);
            }

            for (int i = 3; i < 15; i++)
            {
                Random random1 = new Random();
                int leeftijd = random1.Next(16, 37);
                Random random2 = new Random();
                int skill = random2.Next(1, 21);
                Veldspeler veldspeler = new Veldspeler("Jan Boom", i, "false", Convert.ToInt32(leeftijd), Convert.ToInt32(skill), Convert.ToInt32(skill), Convert.ToInt32(skill), "Veldspeler", this, Convert.ToInt32(skill), Convert.ToInt32(skill), Convert.ToInt32(skill), Convert.ToInt32(skill), Convert.ToInt32(skill));
                this.VoegSpelerToe(veldspeler);
                veldspeler.Spelercode = this.tempCode;
                DBConnect.AddVeldSpeler(veldspeler);
                this.Spelers.Add(veldspeler);
            }          
        }

        /// <summary>
        /// De ToString methode, voor het vullen van de competitie listbox
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Clubnaam + " W:" + this.AantalGespeeld + " W:" + this.AantalGewonnen + " G:" + this.AantalGelijk + " V:" + this.AantalVerloren + " P:" + this.AantalPunten;
        }

        /// <summary>
        /// IComparable methode, voor het sorteren van clubs op behaalde punten
        /// </summary>
        public int CompareTo(Club club)
        {           
            if (this.AantalPunten < club.AantalPunten)
            {
                return 1;
            }

            if (this.AantalPunten > club.AantalPunten)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}