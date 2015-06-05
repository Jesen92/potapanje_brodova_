using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace JediničniTestovi
{
    /// <summary>
    /// Test mreže za smještaj brodova
    /// </summary>
    [TestClass]
    public class TestMrežeZaBrodove
    {
        // Provjeravamo da li metoda DajSlobodnaPočetnaPolja daje
        // očekivani broj slobodnih polja
        [TestMethod]
        public void TestBrojaSlobodnihPočetnihPolja()
        {
            MrežaZaBrodove mb = new MrežaZaBrodove(5, 5);
            Assert.AreEqual(20, mb.DajSlobodnaPočetnaPolja(4).Count);
            Assert.AreEqual(30, mb.DajSlobodnaPočetnaPolja(3).Count);
            Assert.AreEqual(40, mb.DajSlobodnaPočetnaPolja(2).Count);
        }

        // Provjeravamo da li metoda DajSlobodnaPočetnaPolja daje
        // očekivana početna polja
        [TestMethod]
        public void TestSlobodnihPočetnihPolja()
        {
            MrežaZaBrodove mb = new MrežaZaBrodove(5, 5);
            var lista = mb.DajSlobodnaPočetnaPolja(4);
            Assert.IsTrue(lista.Contains(new PočetnoPolje(new PoljeZaBrod(0, 0), Smjer.Horizontalan)));
            Assert.IsTrue(lista.Contains(new PočetnoPolje(new PoljeZaBrod(1, 1), Smjer.Horizontalan)));
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(3, 3), Smjer.Horizontalan)));
            Assert.IsTrue(lista.Contains(new PočetnoPolje(new PoljeZaBrod(3, 1), Smjer.Horizontalan)));
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(3, 1), Smjer.Vertikalan)));
        }


        // Provjeravamo da li metoda za smještaj brodova uklanja ispravna polja iz mreže
        [TestMethod]
        public void TestSmještajaBrodaUGronjemLijevomUglu()
        {
            MrežaZaBrodove mb = new MrežaZaBrodove(5, 5);
            int duljinaBroda = 3;
            PočetnoPolje početnoPolje = new PočetnoPolje(new PoljeZaBrod(0, 0), Smjer.Horizontalan);
            // od polja (0, 0) smjestimo brod duljine 3 u horizontalnom smjeru
            var brod = mb.SmjestiBrod(početnoPolje, duljinaBroda);
            // tražimo sva slobodna polja (tj. za brod duljine 1)
            var lista = mb.DajSlobodnaPočetnaPolja(1);
            // mora ostati slobodno 17 polja za vertikalni brod duljine 1 i 17 polja za horizontalni brod duljine 1
            Assert.AreEqual(34, lista.Count);
            // ne bi sjela biti polja koja je zauzeo brod:
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(0, 0), Smjer.Vertikalan)));
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(0, 1), Smjer.Vertikalan)));
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(0, 2), Smjer.Vertikalan)));
            // kao ni polje desno do broda...
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(0, 3), Smjer.Vertikalan)));
            // te ispod broda
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(1, 0), Smjer.Vertikalan)));
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(1, 1), Smjer.Vertikalan)));
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(1, 2), Smjer.Vertikalan)));
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(1, 3), Smjer.Vertikalan)));
            // polja u zadnjem stupcu, desno do broda moraju biti dostupna:
            Assert.IsTrue(lista.Contains(new PočetnoPolje(new PoljeZaBrod(0, 4), Smjer.Vertikalan)));
            Assert.IsTrue(lista.Contains(new PočetnoPolje(new PoljeZaBrod(1, 4), Smjer.Vertikalan)));
            // sva polja u trećem retku moraju biti dostupna
            Assert.IsTrue(lista.Contains(new PočetnoPolje(new PoljeZaBrod(2, 0), Smjer.Vertikalan)));
            Assert.IsTrue(lista.Contains(new PočetnoPolje(new PoljeZaBrod(2, 1), Smjer.Vertikalan)));
            Assert.IsTrue(lista.Contains(new PočetnoPolje(new PoljeZaBrod(2, 2), Smjer.Vertikalan)));
            Assert.IsTrue(lista.Contains(new PočetnoPolje(new PoljeZaBrod(2, 3), Smjer.Vertikalan)));
            Assert.IsTrue(lista.Contains(new PočetnoPolje(new PoljeZaBrod(2, 4), Smjer.Vertikalan)));
        }

        [TestMethod]
        public void TestSmještajaBrodaUGronjemDesnomUglu()
        {
            MrežaZaBrodove mb = new MrežaZaBrodove(10, 10); 
            int duljinaBroda = 5; 
            var počPolje = new PočetnoPolje(new PoljeZaBrod(0, 9), Smjer.Vertikalan); 
            var brod = mb.SmjestiBrod(počPolje, duljinaBroda); 
            var lista = mb.DajSlobodnaPočetnaPolja(1); 
            Assert.AreEqual(176, lista.Count); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(0, 9), Smjer.Vertikalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(1, 9), Smjer.Vertikalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(4, 9), Smjer.Vertikalan))); 
            
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(5, 9), Smjer.Vertikalan)));
            
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(0, 8), Smjer.Vertikalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(5, 8), Smjer.Vertikalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(4, 8), Smjer.Vertikalan)));
        }

        [TestMethod]
        public void TestSmještajaBrodaUDonjemDesnomUglu()
        {
            MrežaZaBrodove mb = new MrežaZaBrodove(8, 10); 
            int duljinaBroda = 3; 
            var počPolje = new PočetnoPolje(new PoljeZaBrod(7, 7), Smjer.Horizontalan); 
            var brod = mb.SmjestiBrod(počPolje, duljinaBroda); 
            var lista = mb.DajSlobodnaPočetnaPolja(1); 
            Assert.AreEqual(144, lista.Count); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(7, 7), Smjer.Vertikalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(7, 9), Smjer.Vertikalan))); 
            
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(6, 7), Smjer.Vertikalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(6, 8), Smjer.Vertikalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(6, 9), Smjer.Vertikalan))); 
            
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(6, 6), Smjer.Vertikalan)));
        }

        [TestMethod]
        public void TestSmještajaBrodaUDonjemLijevomUglu()
        {
            MrežaZaBrodove mb = new MrežaZaBrodove(10, 10); 
            int duljinaBroda = 4; 
            var počPolje = new PočetnoPolje(new PoljeZaBrod(9, 0), Smjer.Horizontalan); 
            var brod = mb.SmjestiBrod(počPolje, duljinaBroda); 
            var lista = mb.DajSlobodnaPočetnaPolja(1); 
            Assert.AreEqual(180, lista.Count); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(9, 0), Smjer.Horizontalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(9, 3), Smjer.Horizontalan))); 
            
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(8, 0), Smjer.Horizontalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(8, 1), Smjer.Horizontalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(8, 2), Smjer.Horizontalan))); 
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(8, 3), Smjer.Horizontalan))); 
            
            Assert.IsFalse(lista.Contains(new PočetnoPolje(new PoljeZaBrod(9, 4), Smjer.Horizontalan)));
        }
    }
}
