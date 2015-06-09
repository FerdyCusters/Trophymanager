namespace Trophymanager.Klassen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// In de klasse training worden enkele attributen bijgehouden en methodes uitgevoerd.
    /// </summary>
    public class Training
    {
        #region Fields

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public int Trainingscode { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public Speler Speler { get; set; }

        /// <summary>
        /// Gets or sets: Property
        /// </summary>
        public string Datum { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor van Training
        /// </summary>
        /// <param name="speler"></param>
        /// <param name="datum"></param>
        public Training(Speler speler, string datum)
        {
            this.Speler = speler;
            this.Datum = datum;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Training wordt uitgevoerd
        /// </summary>
        /// <param name="inOpstelling"></param>
        public void VoerTrainingUit(string inOpstelling)
        {
            Random random = new Random();
            int uitkomst = random.Next(1, 7);
            if (Speler.Club.Clubnaam == Pages.Inlogscherm.Gebruiker.Clubnaam)
            {
                // Komt de dobbelsteen op 1 of 6?
                if (uitkomst == 1 || uitkomst == 6)
                {
                    Speler.Passen = Speler.Passen + 1;
                    Speler.Snelheid = Speler.Snelheid + 1;
                    Speler.Kracht = Speler.Kracht + 1;
                    DBConnect.UpdateSpeler(Speler, inOpstelling);
                }
            }
        }
        #endregion
    }
}