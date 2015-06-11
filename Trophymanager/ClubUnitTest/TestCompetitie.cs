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

    [TestClass]
    public class TestCompetitie
    {
        /// <summary>
        /// Field competitie
        /// </summary>
        private Competitie competitie;

        /// <summary>
        /// Field club
        /// </summary>
        private Club club;

        /// <summary>
        /// Test Initialize
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            club = new Club("TestAccount", "123test", "FC Test", "De Testers", "TestGrijs");
            competitie = new Competitie("Text League");
            DBConnect.InitializeConnection();
        }

        /// <summary>
        /// TestMethode VoegClubToe
        /// </summary>
        [TestMethod]
        public void TestVoegClubToe()
        {
            Assert.IsFalse(competitie.VoegClubToe(club) == true);
        }
    }
}
