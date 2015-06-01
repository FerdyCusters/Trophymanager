using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trophymanager.Klassen
{
    public class Training
    {
        public int Trainingscode { get; set; }
        public Speler Speler { get; set; }
        public DateTime Datum { get; set; }

        public Training(Speler speler, DateTime datum)
        {
            this.Speler = speler;
            this.Datum = datum;
        }

        public void VoerTrainingUit()
        {
            //TODO
        }
    }
}