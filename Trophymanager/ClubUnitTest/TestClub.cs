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
    /// Test class voor club
    /// </summary>
    [TestClass]
    public class TestClub
    {
        /// <summary>
        /// Field Club
        /// </summary>
        private Club club;

        /// <summary>
        /// Field Veldspeler
        /// </summary>
        private Veldspeler veldspeler;

        /// <summary>
        /// Field Inlogscherm
        /// </summary>
        private Inlogscherm i = new Inlogscherm();

        /// <summary>
        /// Test Initialize
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            club = new Club("TestAccount", "123test", "FC Test", "De Testers", "TestGrijs");
            veldspeler = new Veldspeler("Johan van der Test", 23, "false", 38, 12, 12, 12, "veldspeler", club, 12, 12, 12, 12, 12);
            DBConnect.InitializeConnection();
        }

        /// <summary>
        /// TestMethode Inloggen
        /// </summary>
        [TestMethod]
        public void TestCheckLogin()
        {
            Assert.IsFalse(club.CheckLogin("ferdy", "124") == true);
            Assert.IsTrue(club.CheckLogin("ferdy", "123") == true);
        }

        /// <summary>
        /// TestMethode Registreren
        /// </summary>
        [TestMethod]
        public void TestCheckRegistreer()
        {
            Assert.IsFalse(this.club.CheckRegistreer("ferdy", "FC Oostzee", i) == true);
            Assert.IsTrue(this.club.CheckRegistreer("ferdy B", "FC Oostzee B", i) == true);
        }

        /// <summary>
        /// Test Methode voor ToString() van club
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            Assert.IsFalse(club.ToString() == "FC Oostzee W:2 W:2 G:0 V:0 P:6" == true);
        }
    }
}
