using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace JediničniTestovi
{
    /// <summary>
    /// Summary description for TestGađanja
    /// </summary>
    [TestClass]
    public class TestGađanja
    {
        public TestGađanja()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGađanjaBroda()
        {
            MrežaZaBrodove m = new MrežaZaBrodove(10, 10);
            var polja = m.SmjestiBrod(new PočetnoPolje(new PoljeZaBrod(4, 4), Smjer.Horizontalan), 3);
            Flota f = new Flota();
            f.DodajBrod(polja);
            Assert.AreEqual(RezultatGađanja.Promašaj, f.GađajPolje(4, 3));
            Assert.AreEqual(RezultatGađanja.Pogodak, f.GađajPolje(4, 4));
            Assert.AreEqual(RezultatGađanja.Promašaj, f.GađajPolje(5, 4));
            Assert.AreEqual(RezultatGađanja.Pogodak, f.GađajPolje(4, 5));
            Assert.AreEqual(RezultatGađanja.Pogodak, f.GađajPolje(4, 5));
            Assert.AreEqual(RezultatGađanja.Potopljen, f.GađajPolje(4, 6));
        }
    }
}
