using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class BlefTaktika : ITaktikaGađanja
    {
        public BlefTaktika(MrežaZaEvidenciju mreža, int duljina)
        {
            m_mreža = mreža;
            m_duljinaBroda = duljina;
        }

        public PoljeZaBrod Gađaj()
        {
            var lista = m_mreža.DajSlobodnaPolja(m_duljinaBroda);
            var indeks = m_blef.Next(0, lista.Count);
            return lista[indeks];
        }

        MrežaZaEvidenciju m_mreža;
        int m_duljinaBroda;
        Random m_blef = new Random();

        public void DodajPogodak(PoljeZaBrod polje)
        {
            throw new NotImplementedException();
        }
    }
}
