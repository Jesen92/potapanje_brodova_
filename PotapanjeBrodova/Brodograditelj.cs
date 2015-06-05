using System.Collections.Generic;
using System;

namespace PotapanjeBrodova
{
    public class Brodograditelj
    {
        public Brodograditelj(int redaka, int stupaca)
        {
            m_mreža = new MrežaZaBrodove(redaka, stupaca);
        }

        public Flota SložiFlotu(int[] duljineBrodova)
        {
            Array.Sort(duljineBrodova, (x, y) => { return y - x; });
            Flota f = new Flota();
            for (int i = 0; i < duljineBrodova.Length; ++i)
            {
                var polja = m_mreža.DajSlobodnaPočetnaPolja(duljineBrodova[i]);
                var polje = IzaberiPočetnoPolje(polja);
                var poljaZaBrod = m_mreža.SmjestiBrod(polje, duljineBrodova[i]);
                f.DodajBrod(poljaZaBrod);
            }
            return f;
        }

        private PočetnoPolje IzaberiPočetnoPolje(List<PočetnoPolje> polja)
        {
            int index = m_slučaj.Next(0, polja.Count);
            return polja[index];
        }

        Random m_slučaj = new Random();
        MrežaZaBrodove m_mreža;
    }
}
