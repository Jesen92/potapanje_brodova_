using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace JediničniTestovi
{
    /// <summary>
    /// Summary description for TestMrežeZaEvidenciju
    /// </summary>
    [TestClass]
    public class TestMrežeZaEvidenciju
    {
        public TestMrežeZaEvidenciju()
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
        public void TestSlobodnihPolja()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(6, 6);
            Assert.AreEqual(120, me.DajSlobodnaPolja(5).Count);

            Assert.AreEqual(144, me.DajSlobodnaPolja(3).Count);
        }

        [TestMethod]
        public void TestSlobodnihPolja2()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(5, 6);
            Assert.AreEqual(60, me.DajSlobodnaPolja(1).Count);

            Assert.AreEqual(80, me.DajSlobodnaPolja(5).Count);
            Assert.AreEqual(114, me.DajSlobodnaPolja(3).Count);
        }
<<<<<<< .mine

        public void TestPromasaja()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(5, 5);
            me.ZabilježiPromašaj(2, 3);
            Assert.AreEqual(48, me.DajSlobodnaPolja(1).Count);
            me.ZabilježiPromašaj(46, me.DajSlobodnaPolja(1).Count);
            Assert.AreEqual(46, me.DajSlobodnaPolja(1).Count);
        }

        public void TestPogotkaUGornjemLijevomUglu() 
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(5, 5);
            me.ZabilježiPogodak(0, 0);
            Assert.AreEqual(46, me.DajSlobodnaPolja(1).Count);
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(0, 0)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(1, 1)));
        }

        public void TestPogotkaUGornjemDesnomUglu()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(5, 5);
            me.ZabilježiPogodak(0, 4);
            Assert.AreEqual(46, me.DajSlobodnaPolja(1).Count);
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(0, 4)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(1, 3)));

        }

        public void TestPogotkaUDonjemDesnomUglu()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(5, 5);
            me.ZabilježiPogodak(4, 4);
            Assert.AreEqual(46, me.DajSlobodnaPolja(1).Count);
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(4, 4)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(3, 3)));

        }

        public void TestPogotkaUDonjemLijevomUglu()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(5, 5);
            me.ZabilježiPogodak(4, 0);
            Assert.AreEqual(46, me.DajSlobodnaPolja(1).Count);
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(4, 0)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(3, 1)));

        }

        public void TestPogotkaUSridu() 
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(5, 5);
            me.ZabilježiPogodak(2, 2);
            Assert.AreEqual(44, me.DajSlobodnaPolja(1).Count);
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(2, 2)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(1, 1)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(3, 1)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(1, 3)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(3,3)));
        }
=======

        [TestMethod]
        public void TestPromašaja()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(5, 5);
            me.ZabilježiPromašaj(2, 3);
            Assert.AreEqual(48, me.DajSlobodnaPolja(1).Count);
            me.ZabilježiPromašaj(3, 3);
            Assert.AreEqual(46, me.DajSlobodnaPolja(1).Count);
        }

        [TestMethod]
        public void TestPotonuća()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(5, 5);
            PoljeZaBrod[] polja = new PoljeZaBrod[]
            { new PoljeZaBrod(2, 1),
              new PoljeZaBrod(2, 2),
              new PoljeZaBrod(2, 3)
            };
            me.ZabilježiPotonuće(polja);
            Assert.AreEqual(20, me.DajSlobodnaPolja(1).Count);
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(2, 1)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(2, 2)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(2, 3)));

            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(1, 1)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(1, 4)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(3, 1)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(3, 4)));
        }

        [TestMethod]
        public void TestPogotkaUGornjemLijevomUglu()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(5, 5);
            me.ZabilježiPogodak(0, 0);
            Assert.AreEqual(46, me.DajSlobodnaPolja(1).Count);
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(0, 0)));
            Assert.IsFalse(me.DajSlobodnaPolja(1).Contains(new PoljeZaEvidenciju(1, 1)));
        }

        [TestMethod]
        public void TestPoljaDoGoreLijevo()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            PoljeZaBrod polje = new PoljeZaBrod(0, 0);
            var poljaLijevo = me.DajPoljaDo(polje, PoljeDo.Lijevo);
            Assert.AreEqual(0, poljaLijevo.Count);
            var poljaIznad = me.DajPoljaDo(polje, PoljeDo.Iznad);
            Assert.AreEqual(0, poljaIznad.Count);
            var poljaDesno = me.DajPoljaDo(polje, PoljeDo.Desno);
            Assert.AreEqual(9, poljaDesno.Count);
            Assert.AreEqual(new PoljeZaBrod(0, 1), poljaDesno[0]);
            var poljaIspod = me.DajPoljaDo(polje, PoljeDo.Ispod);
            Assert.AreEqual(9, poljaIspod.Count);
            Assert.AreEqual(new PoljeZaBrod(1, 0), poljaIspod[0]);
        }

        [TestMethod]
        public void TestPoljaDoGoreDesno()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            PoljeZaBrod polje = new PoljeZaBrod(0, 9);
            var poljaLijevo = me.DajPoljaDo(polje, PoljeDo.Lijevo);
            Assert.AreEqual(9, poljaLijevo.Count);
            Assert.AreEqual(new PoljeZaBrod(0, 8), poljaLijevo[0]);
            var poljaIznad = me.DajPoljaDo(polje, PoljeDo.Iznad);
            Assert.AreEqual(0, poljaIznad.Count);
            var poljaDesno = me.DajPoljaDo(polje, PoljeDo.Desno);
            Assert.AreEqual(0, poljaDesno.Count);
            var poljaIspod = me.DajPoljaDo(polje, PoljeDo.Ispod);
            Assert.AreEqual(9, poljaIspod.Count);
            Assert.AreEqual(new PoljeZaBrod(1, 9), poljaIspod[0]);
        }

        [TestMethod]
        public void TestPoljaDoDoljeDesno()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            PoljeZaBrod polje = new PoljeZaBrod(9, 9);
            var poljaLijevo = me.DajPoljaDo(polje, PoljeDo.Lijevo);
            Assert.AreEqual(9, poljaLijevo.Count);
            Assert.AreEqual(new PoljeZaBrod(9, 8), poljaLijevo[0]);
            var poljaIznad = me.DajPoljaDo(polje, PoljeDo.Iznad);
            Assert.AreEqual(9, poljaIznad.Count);
            Assert.AreEqual(new PoljeZaBrod(8, 9), poljaIznad[0]);
            var poljaDesno = me.DajPoljaDo(polje, PoljeDo.Desno);
            Assert.AreEqual(0, poljaDesno.Count);
            var poljaIspod = me.DajPoljaDo(polje, PoljeDo.Ispod);
            Assert.AreEqual(0, poljaIspod.Count);
        }

        [TestMethod]
        public void TestPoljaDoDoljeLijevo()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            PoljeZaBrod polje = new PoljeZaBrod(9, 0);
            var poljaLijevo = me.DajPoljaDo(polje, PoljeDo.Lijevo);
            Assert.AreEqual(0, poljaLijevo.Count);
            var poljaIznad = me.DajPoljaDo(polje, PoljeDo.Iznad);
            Assert.AreEqual(9, poljaIznad.Count);
            Assert.AreEqual(new PoljeZaBrod(8, 0), poljaIznad[0]);
            var poljaDesno = me.DajPoljaDo(polje, PoljeDo.Desno);
            Assert.AreEqual(9, poljaDesno.Count);
            Assert.AreEqual(new PoljeZaBrod(9, 1), poljaDesno[0]);
            var poljaIspod = me.DajPoljaDo(polje, PoljeDo.Ispod);
            Assert.AreEqual(0, poljaIspod.Count);
        }

        [TestMethod]
        public void TestPoljaDoUSredini()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            PoljeZaBrod polje = new PoljeZaBrod(5, 6);
            var poljaLijevo = me.DajPoljaDo(polje, PoljeDo.Lijevo);
            Assert.AreEqual(6, poljaLijevo.Count);
            Assert.AreEqual(new PoljeZaBrod(5, 5), poljaLijevo[0]);
            var poljaIznad = me.DajPoljaDo(polje, PoljeDo.Iznad);
            Assert.AreEqual(5, poljaIznad.Count);
            Assert.AreEqual(new PoljeZaBrod(4, 6), poljaIznad[0]);
            var poljaDesno = me.DajPoljaDo(polje, PoljeDo.Desno);
            Assert.AreEqual(3, poljaDesno.Count);
            Assert.AreEqual(new PoljeZaBrod(5, 7), poljaDesno[0]);
            var poljaIspod = me.DajPoljaDo(polje, PoljeDo.Ispod);
            Assert.AreEqual(4, poljaIspod.Count);
            Assert.AreEqual(new PoljeZaBrod(6, 6), poljaIspod[0]);
        }
>>>>>>> .r28
    }
}
