using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace JediničniTestovi
{
    /// <summary>
    /// Summary description for TestHorVerGađanja
    /// </summary>
    [TestClass]
    public class TestHorVerTaktike
    {
        public TestHorVerTaktike()
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
        public void TestHorVerGađanjaLijeviGornjiKut()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            HorVerTaktika taktika = new HorVerTaktika(me, new PoljeZaBrod(0, 0));
            PoljeZaBrod[] mogućaPolja = new PoljeZaBrod[] {new PoljeZaBrod(1, 0), new PoljeZaBrod(0, 1)};
            Assert.IsTrue(mogućaPolja.Contains(taktika.Gađaj()));
        }

        [TestMethod]
        public void TestHorVerGađanjaDesniGornjiKut()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            HorVerTaktika taktika = new HorVerTaktika(me, new PoljeZaBrod(0, 9));
            PoljeZaBrod[] mogućaPolja = new PoljeZaBrod[] { new PoljeZaBrod(0, 8), new PoljeZaBrod(1, 9) };
            Assert.IsTrue(mogućaPolja.Contains(taktika.Gađaj()));
        }

        [TestMethod]
        public void TestHorVerGađanjaDesniDonjiKut()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            HorVerTaktika taktika = new HorVerTaktika(me, new PoljeZaBrod(9, 9));
            PoljeZaBrod[] mogućaPolja = new PoljeZaBrod[] { new PoljeZaBrod(9, 8), new PoljeZaBrod(8, 9) };
            Assert.IsTrue(mogućaPolja.Contains(taktika.Gađaj()));
        }

        [TestMethod]
        public void TestHorVerGađanjaLijeviDonjiKut()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            HorVerTaktika taktika = new HorVerTaktika(me, new PoljeZaBrod(9, 0));
            PoljeZaBrod[] mogućaPolja = new PoljeZaBrod[] { new PoljeZaBrod(8, 0), new PoljeZaBrod(9, 1) };
            Assert.IsTrue(mogućaPolja.Contains(taktika.Gađaj()));
        }

        [TestMethod]
        public void TestHorVerGađanjaLijeviRub()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            HorVerTaktika taktika = new HorVerTaktika(me, new PoljeZaBrod(5, 0));
            PoljeZaBrod[] mogućaPolja = new PoljeZaBrod[] { new PoljeZaBrod(5, 1) };
            Assert.IsTrue(mogućaPolja.Contains(taktika.Gađaj()));
        }

        [TestMethod]
        public void TestHorVerGađanjaDesniRub()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            HorVerTaktika taktika = new HorVerTaktika(me, new PoljeZaBrod(4, 9));
            PoljeZaBrod[] mogućaPolja = new PoljeZaBrod[] { new PoljeZaBrod(4, 8) };
            Assert.IsTrue(mogućaPolja.Contains(taktika.Gađaj()));
        }

        [TestMethod]
        public void TestHorVerGađanjaSredina()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            me.ZabilježiPromašaj(4, 9);
            me.ZabilježiPromašaj(9, 4);
            HorVerTaktika taktika = new HorVerTaktika(me, new PoljeZaBrod(4, 4));
            PoljeZaBrod[] mogućaPolja = new PoljeZaBrod[] { new PoljeZaBrod(3, 4), new PoljeZaBrod(4, 3), new PoljeZaBrod(4, 5), new PoljeZaBrod(5, 4) };
            Assert.IsTrue(mogućaPolja.Contains(taktika.Gađaj()));
        }

    }
}
