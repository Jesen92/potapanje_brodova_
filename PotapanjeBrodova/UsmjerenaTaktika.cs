using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class UsmjerenaTaktika : ITaktikaGađanja
    {
        public UsmjerenaTaktika(MrežaZaEvidenciju mreža, PoljeZaBrod[] pogođenaPolja)
        {
            m_mreža = mreža;
            m_pogođenaPolja = new List<PoljeZaBrod>(pogođenaPolja);
        }
        
        public PoljeZaBrod Gađaj()
        {
            SortirajPolja();
            int r1 = m_pogođenaPolja[0].Redak;
            int r2 = m_pogođenaPolja[m_pogođenaPolja.Count - 1].Redak;

            List<List<PoljeZaBrod>> liste = null;
            if (r1 == r2)
            {
                liste = DajPoljaUNastavku(m_pogođenaPolja[0], PoljeDo.Lijevo, 
                                          m_pogođenaPolja[m_pogođenaPolja.Count - 1], 
                                          PoljeDo.Desno);
            }
            else
            {
                liste = DajPoljaUNastavku(m_pogođenaPolja[0], PoljeDo.Iznad,
                                          m_pogođenaPolja[m_pogođenaPolja.Count - 1],
                                          PoljeDo.Ispod);
            }
            liste.Sort((l1, l2) => { return l2.Count - l1.Count; });
            // i zadržavamo samo najdulje nizove (koji imaju duljinu jednaku najduljem)
            liste = liste.FindAll((li) => { return li.Count == liste[0].Count; });
            if (liste.Count == 1)
                return liste[0][0];
            int indeks = m_slučajni.Next(2);
            return liste[indeks][0];
        }

        private Random m_slučajni = new Random();

        private List<List<PoljeZaBrod>> DajPoljaUNastavku(PoljeZaBrod prvo, PoljeDo odPrvog, 
                                                          PoljeZaBrod zadnje, PoljeDo odZadnjeg)
        {
            List<List<PoljeZaBrod>> liste = new List<List<PoljeZaBrod>>();
            var lista = m_mreža.DajPoljaDo(prvo, odPrvog);
            if (lista.Count > 0)
                liste.Add(lista);
            lista = m_mreža.DajPoljaDo(zadnje, odZadnjeg);
            if (lista.Count > 0)
                liste.Add(lista);
            return liste;
        }

        void SortirajPolja()
        {
            m_pogođenaPolja.Sort((PoljeZaBrod p1, PoljeZaBrod p2) => { return p1.Redak - p2.Redak + p1.Stupac - p2.Stupac; });
        }

        private MrežaZaEvidenciju m_mreža;
        List<PoljeZaBrod> m_pogođenaPolja;

        public void DodajPogodak(PoljeZaBrod polje)
        {
            m_pogođenaPolja.Add(polje);
            SortirajPolja();
        }
    }
}
