using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trophymanager.Klassen
{
    public class Training
    {
        #region Fields
        public int Trainingscode { get; set; }
        public Speler Speler { get; set; }
        public string Datum { get; set; }
        #endregion

        #region Constructor
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
        public void VoerTrainingUit(string inOpstelling)
        {
            Random random = new Random();
            int uitkomst = random.Next(1, 7);
            if (Speler.Club.Clubnaam == Pages.Inlogscherm.Gebruiker.Clubnaam)
            {
                // Dit kan elke waarde zijn.
                if (uitkomst == uitkomst)
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