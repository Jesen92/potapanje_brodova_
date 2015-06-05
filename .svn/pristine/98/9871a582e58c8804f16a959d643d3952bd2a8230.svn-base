using System.Collections.Generic;

namespace PotapanjeBrodova
{
    public enum Smjer
    {
        Horizontalan,
        Vertikalan
    }

    public class MrežaZaBrodove
    {
        public MrežaZaBrodove(int redaka, int stupaca)
        {
            m_redaka = redaka;
            m_stupaca = stupaca;
            m_mreža = new PoljeZaBrod[redaka, stupaca];
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                    m_mreža[r, s] = new PoljeZaBrod(r, s);
            }
        }

        public List<PočetnoPolje> DajSlobodnaPočetnaPolja(int duljinaBroda)
        {
            List<PočetnoPolje> polja = new List<PočetnoPolje>();
            polja.AddRange(DajHorizontalnaPočetnaPolja(duljinaBroda));
            polja.AddRange(DajVertikalnaPočetnaPolja(duljinaBroda));
            return polja;
        }

        private List<PočetnoPolje> DajHorizontalnaPočetnaPolja(int duljinaBroda)
        {
            List<PočetnoPolje> polja = new List<PočetnoPolje>();
            for (int r = 0; r < m_redaka; ++r)
            {
                int slobodnihPolja = 0;
                for (int s = 0; s < m_stupaca; ++s)
                {
                    if (m_mreža[r, s] != null)
                    {
                        ++slobodnihPolja;
                        if (slobodnihPolja >= duljinaBroda)
                        {
                            PoljeZaBrod polje = m_mreža[r, s - duljinaBroda + 1];
                            polja.Add(new PočetnoPolje(polje, Smjer.Horizontalan));
                        }
                    }
                    else
                        slobodnihPolja = 0;
                }
            }
            return polja;
        }

        private List<PočetnoPolje> DajVertikalnaPočetnaPolja(int duljinaBroda)
        {
            List<PočetnoPolje> polja = new List<PočetnoPolje>();
            for (int s = 0; s < m_stupaca; ++s)
            {
                int slobodnihPolja = 0;
                for (int r = 0; r < m_redaka; ++r)
                {
                    if (m_mreža[r, s] != null)
                    {
                        ++slobodnihPolja;
                        if (slobodnihPolja >= duljinaBroda)
                        {
                            PoljeZaBrod polje = m_mreža[r - duljinaBroda + 1, s];
                            polja.Add(new PočetnoPolje(polje, Smjer.Vertikalan));
                        }
                    }
                    else
                        slobodnihPolja = 0;
                }
            }
            return polja;
        }

        public PoljeZaBrod[] SmjestiBrod(PočetnoPolje polje, int duljina)
        {
            var poljaZaBrod = IzlučiPoljaZaBrod(polje, duljina);
            IzbrišiPolja(poljaZaBrod);
            return poljaZaBrod;
        }

        private PoljeZaBrod[] IzlučiPoljaZaBrod(PočetnoPolje polje, int duljina)
        {
            PoljeZaBrod[] polja = new PoljeZaBrod[duljina];
            int redak = polje.PoljeZaBrod.Redak;
            int stupac = polje.PoljeZaBrod.Stupac;
            int prirastRetka = polje.Smjer == Smjer.Horizontalan ? 0 : 1;
            int prirastStupca = polje.Smjer == Smjer.Vertikalan ? 0 : 1;
            for (int i = 0; i < duljina; ++i)
            {
                polja[i] = m_mreža[redak, stupac];
                redak += prirastRetka;
                stupac += prirastStupca;
            }
            return polja;
        }

        private void IzbrišiPolja(PoljeZaBrod[] polja)
        {
            int redakPočetni = polja[0].Redak - 1;
            if (redakPočetni < 0)
                redakPočetni = 0;
            int stupacPočetni = polja[0].Stupac - 1;
            if (stupacPočetni < 0)
                stupacPočetni = 0;
            int n = polja.Length - 1;
            int redakZadnji = polja[n].Redak + 2;
            if (redakZadnji > m_redaka)
                redakZadnji = m_redaka;
            int stupacZadnji = polja[n].Stupac + 2;
            if (stupacZadnji > m_stupaca)
                stupacZadnji = m_stupaca;
            for (int r = redakPočetni; r < redakZadnji; ++r)
            {
                for (int s = stupacPočetni; s < stupacZadnji; ++s)
                    m_mreža[r, s] = null;
            }
        }

        PoljeZaBrod[,] m_mreža;
        int m_redaka;
        int m_stupaca;

        Flota m_flota = new Flota();
    }
}
