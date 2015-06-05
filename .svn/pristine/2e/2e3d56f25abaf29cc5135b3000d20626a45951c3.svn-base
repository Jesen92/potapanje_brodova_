using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    enum TaktikaGađanja
    {
        Blef,
        HorizontalnoVertikalno,
        Usmjereno
    }

    public class Razarač
    {
        public Razarač(int redaka, int stupaca, int[] duljineBrodova)
        {
            m_mreža = new MrežaZaEvidenciju(redaka, stupaca);
            m_trenutnaTaktika = new BlefTaktika(m_mreža, duljineBrodova[0]);
            m_preostaliBrodovi = new List<int>(duljineBrodova);
        }

        public PoljeZaBrod Gađaj()
        {
            m_gađanoPolje = m_trenutnaTaktika.Gađaj();
            return m_gađanoPolje;
        }

        public bool ZabilježiRezultat(RezultatGađanja rezultat)
        {
            int redak = m_gađanoPolje.Redak;
            int stupac = m_gađanoPolje.Stupac;
            switch (rezultat)
            {
                case RezultatGađanja.Promašaj:
                    m_mreža.ZabilježiPromašaj(redak, stupac);
                    break;
                case RezultatGađanja.Pogodak:
                    m_mreža.ZabilježiPogodak(redak, stupac);
                    m_gađaniBrod.Add(m_gađanoPolje);
                    PromijeniTaktiku();
                    break;
                case RezultatGađanja.Potopljen:
                    m_gađaniBrod.Add(m_gađanoPolje);
                    m_mreža.ZabilježiPotonuće(m_gađaniBrod.ToArray());
                    int duljinaBroda = m_gađaniBrod.Count;
                    m_preostaliBrodovi.Remove(duljinaBroda);
                    // potopljen je i zadnji protivnički brod!
                    if (m_preostaliBrodovi.Count == 0)
                        return true;
                    m_gađaniBrod.Clear();
                    // makni brod iz liste brodova koje gađamo
                    m_taktika = TaktikaGađanja.Blef;
                    m_trenutnaTaktika = new BlefTaktika(m_mreža, m_preostaliBrodovi[0]);
                    break;
            }
            return false;
        }

        private void PromijeniTaktiku()
        {
            switch (m_taktika)
            {
                case TaktikaGađanja.Blef:
                    m_taktika = TaktikaGađanja.HorizontalnoVertikalno;
                    m_trenutnaTaktika = new HorVerTaktika(m_mreža, m_gađanoPolje);
                    break;
                case TaktikaGađanja.HorizontalnoVertikalno:
                    m_taktika = TaktikaGađanja.Usmjereno;
                    m_trenutnaTaktika = new UsmjerenaTaktika(m_mreža, m_gađaniBrod.ToArray());
                    break;
                case TaktikaGađanja.Usmjereno:
                    m_trenutnaTaktika.DodajPogodak(m_gađanoPolje);
                    break;
            }
        }

        MrežaZaEvidenciju m_mreža;
        PoljeZaBrod m_gađanoPolje;
        List<PoljeZaBrod> m_gađaniBrod = new List<PoljeZaBrod>();
        TaktikaGađanja m_taktika = TaktikaGađanja.Blef;
        ITaktikaGađanja m_trenutnaTaktika;
        List<int> m_preostaliBrodovi;
    }
}
