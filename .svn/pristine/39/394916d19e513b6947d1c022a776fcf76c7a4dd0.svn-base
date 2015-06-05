using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PotapanjeBrodova
{
    public class MrežaZaEvidenciju
    {
        public MrežaZaEvidenciju(int redaka, int stupaca)
        {
            m_redaka = redaka;
            m_stupaca = stupaca;
            m_polja = new PoljeZaEvidenciju[redaka, stupaca];
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                    m_polja[r, s] = new PoljeZaEvidenciju(r, s);
            }
        }

        public List<PoljeZaBrod> DajSlobodnaPolja(int duljina)
        {
            List<PoljeZaBrod> polja = new List<PoljeZaBrod>();
            polja.AddRange(DajHorizontalnaPolja(duljina));
            polja.AddRange(DajVertikalnaPolja(duljina));
            return polja;
        }

        public void ZabilježiPromašaj(int redak, int stupac)
        {
            if (JeLiPoljeUMreži(redak, stupac))
                m_polja[redak, stupac].PromijeniStanje(StanjePolja.Promašeno);
        }

        public void ZabilježiPogodak(int redak, int stupac)
        {
            m_polja[redak, stupac].PromijeniStanje(StanjePolja.Pogođeno);
            ZabilježiPromašaj(redak - 1, stupac - 1);
            ZabilježiPromašaj(redak - 1, stupac + 1);
            ZabilježiPromašaj(redak + 1, stupac - 1);
            ZabilježiPromašaj(redak + 1, stupac + 1);
        }

        public void ZabilježiPotonuće(PoljeZaBrod[] polja)
        {
            // prvo moramo polja sortirati
            Array.Sort(polja, (PoljeZaBrod p1, PoljeZaBrod p2) => { return p1.Redak - p2.Redak + p1.Stupac - p2.Stupac; });
            PoljeZaBrod prvo = polja[0];
            PoljeZaBrod zadnje = polja[polja.Length - 1];
            int r1 = prvo.Redak - 1;
            int r2 = zadnje.Redak + 2;
            int s1 = prvo.Stupac - 1;
            int s2 = zadnje.Stupac + 2;
            for (int r = r1; r < r2; ++r)
            {
                for (int s = s1; s < s2; ++s)
                    ZabilježiPromašaj(r, s);
            }
            // za godinu dana: ovo smo napravili kolegi Čoviću za inat
            foreach (var p in polja)
                m_polja[p.Redak, p.Stupac].PromijeniStanje(StanjePolja.Potopljeno);
        }

        public List<PoljeZaBrod> DajPoljaDo(PoljeZaBrod polje, PoljeDo smjer)
        {
            int deltaRedak = 0;
            int deltaStupac = 0;
            switch (smjer)
            {
                case PoljeDo.Iznad:
                    deltaRedak = -1;
                    break;
                case PoljeDo.Desno:
                    deltaStupac = +1;
                    break;
                case PoljeDo.Ispod:
                    deltaRedak = +1;
                    break;
                case PoljeDo.Lijevo:
                    deltaStupac = -1;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            return DajPoljaUNizu(polje, deltaRedak, deltaStupac);
        }

        private List<PoljeZaBrod> DajPoljaUNizu(PoljeZaBrod polje, int deltaRedak, int deltaStupac)
        {
            int redak = polje.Redak;
            int stupac = polje.Stupac;
            List<PoljeZaBrod> polja = new List<PoljeZaBrod>();
            while (JeLiPoljeUMreži(redak += deltaRedak, stupac += deltaStupac) && m_polja[redak, stupac].StanjePolja == StanjePolja.Netaknuto)
            {
                polja.Add(m_polja[redak, stupac]);
            }
            return polja;
        }

        private bool JeLiPoljeUMreži(int redak, int stupac)
        {
            return redak >= 0 && redak < m_redaka && stupac >= 0 && stupac < m_stupaca;
        }

        delegate PoljeZaEvidenciju Dohvat(int i, int j);

        private List<PoljeZaBrod> DajHorizontalnaPolja(int duljina)
        {
            return DajPolja(duljina, m_redaka, m_stupaca, (int i, int j) => m_polja[i, j]);
        }

        private List<PoljeZaBrod> DajVertikalnaPolja(int duljina)
        {
            return DajPolja(duljina, m_stupaca, m_redaka, (int i, int j) => m_polja[j, i]);
        }

        private List<PoljeZaBrod> DajPolja(int duljina, int vanjska, int unutarnja, Dohvat dohvat)
        {
            List<PoljeZaBrod> polja = new List<PoljeZaBrod>();
            for (int i = 0; i < vanjska; ++i)
            {
                int slobodnihPolja = 0;
                for (int j = 0; j < unutarnja; ++j)
                {
                    if (dohvat(i, j).StanjePolja == StanjePolja.Netaknuto)
                    {
                        ++slobodnihPolja;
                        if (slobodnihPolja >= duljina)
                        {
                            for (int k = j - duljina + 1; k <= j; ++k)
                                polja.Add(dohvat(i, k));
                        }
                    }
                    else
                        slobodnihPolja = 0;
                }
            }
            return polja;
        }


        private PoljeZaEvidenciju[,] m_polja;
        private int m_redaka;
        private int m_stupaca;
    }
}
