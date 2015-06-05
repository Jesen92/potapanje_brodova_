using System.Collections.Generic;
using System;

namespace PotapanjeBrodova
{
    public class Brodograditelj
    {
        public Brodograditelj(int redaka, int stupaca, int[] duljineBrodova)
        {
            m_redaka = redaka;
            m_stupaca = stupaca;
            m_duljineBrodova = (int[])duljineBrodova.Clone();
            // sortiramo duljine brodova od najduljeg prema najkraćem
            Array.Sort(m_duljineBrodova, (x, y) => { return y - x; });
        }

        public Flota SložiFlotu()
        {
            for (int i = 0; i < m_brojPokušaja; ++i)
            {
                Flota flota = SložiBrodove();
                if (flota != null)
                    return flota;
            }
            throw new ApplicationException("Brodograditelj nije uspio složiti brodove na mrežu");
        }

        private Flota SložiBrodove()
        {
            MrežaZaBrodove mreža = new MrežaZaBrodove(m_redaka, m_stupaca);
            Flota f = new Flota();
            foreach (int duljinaBroda in m_duljineBrodova)
            {
                var polja = mreža.DajSlobodnaPočetnaPolja(duljinaBroda);
                // nije našao više slobodnih polja
                if (polja.Count == 0)
                    return null;
                var polje = IzaberiPočetnoPolje(polja);
                var poljaZaBrod = mreža.SmjestiBrod(polje, duljinaBroda);
                f.DodajBrod(poljaZaBrod);
            }
            return f;
        }

        private PočetnoPolje IzaberiPočetnoPolje(List<PočetnoPolje> polja)
        {
            int index = m_slučaj.Next(0, polja.Count);
            return polja[index];
        }

        int m_redaka;
        int m_stupaca;
        int[] m_duljineBrodova;
        Random m_slučaj = new Random();
        const int m_brojPokušaja = 10;
    }
}
