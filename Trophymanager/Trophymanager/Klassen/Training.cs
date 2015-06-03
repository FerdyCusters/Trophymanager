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
        public DateTime Datum { get; set; }
        #endregion

        #region Constructor
        public Training(Speler speler, DateTime datum)
        {
            this.Speler = speler;
            this.Datum = datum;
        }
        #endregion

        #region Methods
        public void VoerTrainingUit()
        {
            //TODO
        }
        #endregion
    }
}