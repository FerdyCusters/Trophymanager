namespace ClubUnitTest
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Trophymanager;
    using Trophymanager.Klassen;
    using Trophymanager.Pages;

    /// <summary>
    /// Unit Test Wedstrijd
    /// </summary>
    [TestClass]
    public class TestWedstrijd
    {
        /// <summary>
        /// Field thuisteam
        /// </summary>
        private Club teamThuis;

        /// <summary>
        /// Field uitteam
        /// </summary>
        private Club teamUit;

        /// <summary>
        /// Field wedstrijd
        /// </summary>
        private Wedstrijd wedstrijd;


        /// <summary>
        /// Field competitie
        /// </summary>
        private Competitie competitie;

        /// <summary>
        /// Test Initialize
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            teamThuis = new Club("TestAccount", "123test", "FC Test", "De Testers", "TestGrijs");
            teamUit = new Club("TestAccount2", "321test", "FC Test B", "De Testers B", "TestGroen");
            competitie = new Competitie("Test League");
            wedstrijd = new Wedstrijd(teamThuis, teamUit, "16-12-1995", "02:00", competitie);
            DBConnect.InitializeConnection();
        }

        /// <summary>
        /// Test ToString()
        /// </summary>
        [TestMethod]
        public void TestWedstrijdToString()
        {
            wedstrijd.Uitslag = "2-2";
            Assert.IsTrue(wedstrijd.ToString() == this.teamThuis.Clubnaam + "  " + this.wedstrijd.Uitslag + "  " + this.teamUit.Clubnaam + "    Datum: " + wedstrijd.Speeldatum);
        }
    }
}
