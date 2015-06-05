using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace JediničniTestovi
{
    /// <summary>
    /// Summary description for TestUsmjereneTaktike
    /// </summary>
    [TestClass]
    public class TestUsmjereneTaktike
    {
        public TestUsmjereneTaktike()
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
        public void TestUsmjerenogGađanjaHorizontalno()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            PoljeZaBrod[] pogođenaPolja = new PoljeZaBrod[] { new PoljeZaBrod(3, 4), new PoljeZaBrod(3, 5) };
            UsmjerenaTaktika taktika = new UsmjerenaTaktika(me, pogođenaPolja);
            PoljeZaBrod[] mogućaPolja = new PoljeZaBrod[] { new PoljeZaBrod(3, 3), new PoljeZaBrod(3, 6) };
            Assert.IsTrue(mogućaPolja.Contains(taktika.Gađaj()));
        }

        [TestMethod]
        public void TestUsmjerenogGađanjaVertikalno()
        {
            MrežaZaEvidenciju me = new MrežaZaEvidenciju(10, 10);
            PoljeZaBrod[] pogođenaPolja = new PoljeZaBrod[] { new PoljeZaBrod(3, 4), new PoljeZaBrod(4, 4), new PoljeZaBrod(5, 4), new PoljeZaBrod(6, 4) };
            UsmjerenaTaktika taktika = new UsmjerenaTaktika(me, pogođenaPolja);
            PoljeZaBrod[] mogućaPolja = new PoljeZaBrod[] { new PoljeZaBrod(2, 4), new PoljeZaBrod(7, 4) };
            Assert.IsTrue(mogućaPolja.Contains(taktika.Gađaj()));
        }

        [TestMethod]
        public void TestUsmjereneTaktikeUSredini()
        {
            MrežaZaEvidenciju mr = new MrežaZaEvidenciju(10, 10);
            PoljeZaBrod[] polje = { new PoljeZaBrod(4, 3), new PoljeZaBrod(4, 4) };
            UsmjerenaTaktika us = new UsmjerenaTaktika(mr, polje);
            PoljeZaBrod p = us.Gađaj();
            Assert.IsTrue(p == new PoljeZaBrod(4, 5));
            
            PoljeZaBrod[] polje2 = { new PoljeZaBrod(4, 3), new PoljeZaBrod(4, 4), new PoljeZaBrod(4, 5) };
            UsmjerenaTaktika us2 = new UsmjerenaTaktika(mr, polje2);
            p = us2.Gađaj();
            Assert.IsTrue(new PoljeZaBrod[] { new PoljeZaBrod(4, 2), new PoljeZaBrod(4, 6) }.Contains(p));
        }
    }
}
