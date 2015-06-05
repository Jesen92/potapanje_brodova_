using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public enum PoljeDo
    {
        Iznad,
        Desno,
        Ispod,
        Lijevo
    }

    public class HorVerTaktika : ITaktikaGađanja
    {
        public HorVerTaktika(MrežaZaEvidenciju mreža, PoljeZaBrod pogođenoPolje)
        {
            m_mreža = mreža;
            m_pogođenoPolje = pogođenoPolje;
        }

        public PoljeZaBrod Gađaj()
        {
            // liste svih polja u nastavku (gore, desno, dolje, lijevo)
            List<List<PoljeZaBrod>> liste = DajPoljaUNastavku();
            // sortiramo ih po duljini, od najduljeg prema najkraćem
            liste.Sort((l1, l2) => { return l2.Count - l1.Count; });
            // i uzimamo samo najdulje nizove (koji imaju duljinu jednaku najduljem)
            var užiKrug = liste.FindAll((l) => { return l.Count == liste[0].Count; });
            // slučajnim odabirom uzimamo početni član jednog od nizova
            int slučajniOdabir = m_slučaj.Next(0, užiKrug.Count);
            return užiKrug[slučajniOdabir][0];
        }

        // vraća liste nizova polja do pogođenog polja
        private List<List<PoljeZaBrod>> DajPoljaUNastavku()
        {
            List<List<PoljeZaBrod>> liste = new List<List<PoljeZaBrod>>();
            // idemo po svim smjerovima
            foreach (PoljeDo s in Enum.GetValues(typeof(PoljeDo)))
            {
                var lista = m_mreža.DajPoljaDo(m_pogođenoPolje, s);
                if (lista.Count > 0)
                    liste.Add(lista);
            }
            return liste;
        }

        private MrežaZaEvidenciju m_mreža;
        private PoljeZaBrod m_pogođenoPolje;
        private Random m_slučaj = new Random();

        public void DodajPogodak(PoljeZaBrod polje)
        {
            throw new NotImplementedException();
        }
    }
}
